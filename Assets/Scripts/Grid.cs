using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

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

    private T[,] _gridArray;

    private float _debugLineDestroyTime = 100f;
    private TextMesh[,] _debugTextMesh;

    //Constructor
    public Grid(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;   
        _cellSize = cellSize;

        _gridArray = new T[width, height];
        _debugTextMesh = new TextMesh[width, height];

        DrawDebugVisuals();

    }

    private void DrawDebugVisuals()
    {
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                //Save all the TextMeshes in an Array
                _debugTextMesh[x,y] = UtilsClass.CreateWorldText("0", null, GridPositionToWorldPosition(x, y) + new Vector3(_cellSize, _cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GridPositionToWorldPosition(x, y), GridPositionToWorldPosition(x + 1, y), Color.white, _debugLineDestroyTime);
                Debug.DrawLine(GridPositionToWorldPosition(x, y), GridPositionToWorldPosition(x, y + 1), Color.white, _debugLineDestroyTime);

            }


        }

        // Draw the vertical line at the end
        Debug.DrawLine(GridPositionToWorldPosition(0, _height), GridPositionToWorldPosition(_width, _height), Color.white, _debugLineDestroyTime);
        //Draw the horizontal line at the end
        Debug.DrawLine(GridPositionToWorldPosition(_width, 0), GridPositionToWorldPosition(_width, _height), Color.white, _debugLineDestroyTime);
    }


    public Vector3 GridPositionToWorldPosition(int x, int y)
    {
        //return default when the x or y is not on the Grid
        //if (x < 0 || y < 0 || x >= _width && y >= _height) return default;

        return new Vector3(x, y) * _cellSize;
    }

    public void WorldPositionToGridPosition(Vector3 worldPositon, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPositon.x/_cellSize);
        y = Mathf.FloorToInt(worldPositon.y / _cellSize);
    }

    public void SetObjectWithGridPosition(int x, int y, T setObject)
    {
        T gridObject = GetObjectWithGridPosition(x, y);
        gridObject = setObject;

        _debugTextMesh[x,y].text = gridObject.ToString();


    }
    public void SetObjectWithWorldPosition(Vector3 worldPosition, T setObject)
    {

        WorldPositionToGridPosition(worldPosition, out int x, out int y);
        SetObjectWithGridPosition(x,y, setObject);
        
    }


    public T GetObjectWithWorldPosition(Vector3 worldPosition)
    {
        WorldPositionToGridPosition(worldPosition, out int x, out int y);
        return GetObjectWithGridPosition(x, y);
    }

    public T GetObjectWithGridPosition(int x, int y)
    {
        if (x < 0 || y < 0 || x >= _width && y >= _height) return default;
        return _gridArray[x, y];
    }




}
