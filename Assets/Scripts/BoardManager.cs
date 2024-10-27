using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BoardManager : MonoBehaviour
{

    private Grid<Piece> board;

    // Start is called before the first frame update
    void Start()
    {
        board = new Grid<Piece>(8,8,10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            board.SetObjectWithWorldPosition(UtilsClass.GetMouseWorldPosition(), new Piece(Piece.PieceTypes.Kight));
        }
        
       

    }
}
