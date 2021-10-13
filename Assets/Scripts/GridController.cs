using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public enum PieceType
    {
        EMPTY,
        NORMAL,
        COUNT,
    };

    [System.Serializable]
    public struct PiecePrefab
    {
        public PieceType type;
        public GameObject prefab;
    };

    [Header("Dimentions")]
    public int xDim;
    public int yDim;

    [Header("Array of Structs")]
    public PiecePrefab[] piecePrefabs;

    [Header("Background Prefab")]
    public GameObject backgroundPrefab;

    private Dictionary<PieceType, GameObject> piecePrefabDict;

    // 2D Array of GameObjects
    private GamePiece[,] pieces;
    
    // Initialization
    private void Start()
    {
        piecePrefabDict = new Dictionary<PieceType, GameObject>();

        for(int i = 0; i < piecePrefabs.Length; i++)
        {
            if(!piecePrefabDict.ContainsKey(piecePrefabs[i].type))
            {
                piecePrefabDict.Add(piecePrefabs[i].type, piecePrefabs[i].prefab);
            }
        }

        // Instantiation
        for(int x = 0; x < xDim; x++)
        {
            for(int y = 0; y < yDim; y++)
            {
                GameObject background = (GameObject)Instantiate(backgroundPrefab, GetWorldPos(x, y), Quaternion.identity);
                background.transform.parent = transform;
            }
        }

        pieces = new GamePiece[xDim, yDim];
        for(int x = 0; x < xDim; x++)
        {
            for(int y = 0; y < yDim; y++)
            {
                SpawnNewPiece(x, y, PieceType.EMPTY);
            }
        }
    }

    // Update

    public void Fill()
    {

    }

    public bool FillStep()
    {
        bool movedPiece = false;

        for(int y = yDim - 2; y >= 0; y--)
        {
            for(int x = 0; x < xDim; x++)
            {
                GamePiece piece = pieces[x, y];

                if(piece.IsMoveable())
                {
                    GamePiece pieceBelow = pieces[x, y +1];

                    if(pieceBelow.Type == PieceType.EMPTY)
                    {
                        piece.MoveableComponent.Move(x, y + 1);
                        pieces[x, y + 1] = piece;
                        SpawnNewPiece(x, y, PieceType.EMPTY);
                        movedPiece = true;
                    }
                }
            }
        }

        for(int x = 0; x < xDim; x++)
        {
            GamePiece pieceBelow = pieces[x, 0];

            if(pieceBelow.Type == PieceType.EMPTY)
            {
                GameObject newPiece = (GameObject)Instantiate(piecePrefabDict[PieceType.NORMAL], GetWorldPos(x, -1), Quaternion.identity); //
                newPiece.transform.parent = transform;

                pieces[x, 0] = newPiece.GetComponent<GamePiece>();
                pieces[x, 0].Init(x, -1, this, PieceType.NORMAL);
                pieces[x, 0].MoveableComponent.Move(x, 0);
                pieces[x, 0].ColorComponent.SetColor((ColorPiece.ColorType)Random.Range(0, pieces[x, 0].ColorComponent.NumColors));
                movedPiece = true;
            }
        }

        return movedPiece;
    }

    public Vector2 GetWorldPos(int x, int y)
    {
        return new Vector2(transform.position.x - xDim/2.0f + x,
        transform.position.y + yDim / 2.0f - y);
    }

    // Spawning Pieces
    public GamePiece SpawnNewPiece(int x, int y, PieceType type)
    {
        GameObject newpiece = (GameObject)Instantiate(piecePrefabDict[type], GetWorldPos(x, y), Quaternion.identity);
        newpiece.transform.parent = transform;

        pieces[x, y] = newpiece.GetComponent<GamePiece>();
        pieces[x, y].Init(x, y, this, type);

        return pieces[x, y];
    }

}
