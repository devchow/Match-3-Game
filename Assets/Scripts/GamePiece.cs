using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        //set { x = value; }
        set{
            if(IsMoveable())
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        //set { y = value; }
        set{
            if(IsMoveable())
            {
                y = value;
            }
        }
    }

    private GridController.PieceType type;

    public GridController.PieceType Type
    {
        get { return type; }
    }

    private GridController grid;

    public GridController GridRef
    {
        get { return grid; }
    }

    // ref
    private MoveablePiece moveableComponent;

    public MoveablePiece MoveableComponent
    {
        get { return moveableComponent; }
    }

    private ColorPiece colorComponent;
    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }

    // get ref to moveable comp
    private void Awake()
    {
        moveableComponent = GetComponent<MoveablePiece>();
        colorComponent = GetComponent<ColorPiece>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init(int _x, int _y, GridController _grid, GridController.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

    public bool IsMoveable()
    {
        return moveableComponent != null;
    }

    // check whether colored
    public bool IsColored()
    {
        return colorComponent != null;
    }

}
