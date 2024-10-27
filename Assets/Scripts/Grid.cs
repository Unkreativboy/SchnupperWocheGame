using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T> 
{
    ///<summary>
    /// class that holds the grid which contains all the pieces on the board
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>

    private int _width;
    private int _height;
    private float _cellSize;

    private T[,] gridArray;
    //Constructor
    public Grid(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;   
        _cellSize = cellSize;




    }





}
