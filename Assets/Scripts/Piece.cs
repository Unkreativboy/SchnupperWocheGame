using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Constructor
    public Piece(PieceTypes createPieceType)
    {
        _type = createPieceType;
    }


    //Override the ToString method to have a easy debug visual
    public override string ToString()
    {
        return _type.ToString();
    }

}
