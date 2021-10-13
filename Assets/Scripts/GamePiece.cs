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
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
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

}
