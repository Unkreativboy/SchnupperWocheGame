using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using System;

namespace Unkreativboy
{

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

        public event EventHandler OnGridCreated;
        public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;

        #region CustomEventArgs
        
        public class OnGridObjectChangedEventArgs : EventArgs
        {
            public T gridObject;
            public int gridPosX;
            public int gridPosY;
        }
        #endregion


        public int _width { get; private set; }
        public int _height { get; private set; }
        public float _cellSize { get; private set; }

        private T[,] _gridArray;

        //Constructor
        public Grid(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;

            _gridArray = new T[width, height];
        }

        public Vector3 GridPositionToWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * _cellSize;
        }

        public void WorldPositionToGridPosition(Vector3 worldPositon, out int x, out int y)
        {
            x = Mathf.FloorToInt(worldPositon.x / _cellSize);
            y = Mathf.FloorToInt(worldPositon.y / _cellSize);
        }

        public void SetObjectWithGridPosition(int x, int y, T setObject)
        {
            T gridObject = GetObjectWithGridPosition(x, y);
            gridObject = setObject;


            OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs {  gridObject = gridObject, gridPosX = x, gridPosY = y});
   
        }
        public void SetObjectWithWorldPosition(Vector3 worldPosition, T setObject)
        {

            WorldPositionToGridPosition(worldPosition, out int x, out int y);
            SetObjectWithGridPosition(x, y, setObject);

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

        public int GetGridArrayLenght(int dimension)
        {
            return _gridArray.GetLength(dimension);
        }
        public void InvokeOnGridCreated()
        {
            OnGridCreated?.Invoke(this, EventArgs.Empty);
        }
    }
}