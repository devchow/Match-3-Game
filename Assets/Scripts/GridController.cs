using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public enum PieceType
    {
        NORAMAL,
        COUNT,
    };

    public struct piecePrefab
    {

    };

    [Header("Dimentions")]
    public int xDim;
    public int yDim;

    private Dictionary<PieceType, GameObject> piecePrefabDict;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
