using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public enum PieceType
    {
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
    private GameObject[,] pieces;
    
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

        pieces = new GameObject[xDim, yDim];
        for(int x = 0; x < xDim; x++)
        {
            for(int y = 0; y < yDim; y++)
            {
                pieces[x, y] = (GameObject)Instantiate(piecePrefabDict[PieceType.NORMAL], GetWorldPos(x, y), Quaternion.identity);
                // Changing Name
                pieces[x, y].name = "Piece(" + x + "," + y + ")";
                pieces[x, y].transform.parent = transform;
            }
        }
    }

    // Update

    Vector2 GetWorldPos(int x, int y)
    {
        return new Vector2(transform.position.x - xDim/2.0f + x,
        transform.position.y + yDim / 2.0f - y);
    }

}
