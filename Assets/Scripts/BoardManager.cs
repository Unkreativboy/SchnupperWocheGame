using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unkreativboy;

public class BoardManager : MonoBehaviour
{

    private Grid<Piece> _board;
    private GridDebugVisual<Piece> _boardDebugVisual;

    private Piece lastPieceCreated;

    // Start is called before the first frame update
    void Start()
    {
        
        _board = new Grid<Piece>(8,8,10);

        //inject the board as a reference
        _boardDebugVisual = new GridDebugVisual<Piece>(_board);
        //Call the event that the grid was created
        _board.InvokeOnGridCreated();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            PlacePiece(UtilsClass.GetMouseWorldPosition(), Piece.PieceTypes.Mage);

        }
        if(Input.GetMouseButtonDown(1))
        {
            lastPieceCreated.MoveTo(UtilsClass.GetMouseWorldPosition());
        }
        
       

    }

    private void PlacePiece(Vector3 worldPosition, Piece.PieceTypes pieceType)
    {
        _board.WorldPositionToGridPosition(worldPosition, out int x, out int y);

        Piece piece = new Piece(pieceType,x,y, _board);
        
        _board.SetObjectWithWorldPosition( worldPosition, piece);
        //testing
        lastPieceCreated = piece;
    }
}
