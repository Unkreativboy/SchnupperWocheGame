using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unkreativboy;

public class BoardManager : MonoBehaviour
{

    private Grid<Piece> board;
    private GridDebugVisual<Piece> boardDebugVisual;

    // Start is called before the first frame update
    void Start()
    {
        
        board = new Grid<Piece>(8,8,10);

        //inject the board as a reference
        boardDebugVisual = new GridDebugVisual<Piece>(board);
        //Call the event that the grid was created
        board.InvokeOnGridCreated();
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
