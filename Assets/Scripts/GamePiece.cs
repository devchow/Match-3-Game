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
    }

    public int Y
    {
        get { return y; }
    }

    private GridController.PieceType type;

    public GridController.PieceType Type
    {
        get { return type; }
    }

    private Grid grid;

    public Grid GridRef
    {
        get { return grid; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init(int _x, int _y, Grid _grid, GridController.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

}
