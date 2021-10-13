using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePiece : MonoBehaviour
{
    private GamePiece piece;

    private void Awake()
    {
        piece =  GetComponent<GamePiece>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Function to move piece
    public void Move(int newX, int newY)
    {
        piece.X = newX;
        piece.Y = newY;
    }
}
