using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unkreativboy;

public class Piece 
{

    /// <summary>
    /// class representing a piece in the game
    /// the pieces are distinqished via a enum
    /// 
    /// Responsibilities:
    /// Holds the information about the type of the piece and the owner of this piece
    /// 
    /// 
    /// </summary>

    public enum PieceTypes{Kight,Mage,Archer,}
    public PieceTypes _type {  get; private set; }
    private Grid<Piece> _grid;
    private int _xPosOnGrid;
    private int _yPosOnGrid;

    //Constructor
    public Piece(PieceTypes createPieceType, int xPosOnGrid,int yPosOnGrid, Grid<Piece> grid)
    {
        _type = createPieceType;
        _grid = grid;
        _xPosOnGrid = xPosOnGrid;
        _yPosOnGrid = yPosOnGrid;
    }

    public void MoveTo(Vector3 worldPosition)
    {
        
        //remove the old position on the Grid
        _grid.SetObjectWithGridPosition(_xPosOnGrid, _yPosOnGrid, null);

        //set the new position on the Grid
        _grid.WorldPositionToGridPosition(worldPosition, out int x, out int y);
        _grid.SetObjectWithGridPosition(x, y, this);
        _xPosOnGrid = x;
        _yPosOnGrid = y;

    }



    //Override the ToString method to have a easy debug visual
    public override string ToString()
    {
        return _type.ToString();
    }

}
