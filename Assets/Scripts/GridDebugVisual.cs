using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using Unkreativboy;


namespace Unkreativboy
{

    public class GridDebugVisual<T>
    {

        private Grid<T> _grid;
        private float _debugLineDestroyTime = 100f;
        private TextMesh[,] _debugTextMesh;

        //Constuctor
        public GridDebugVisual(Grid<T> grid)
        {
            _grid = grid;
            _grid.OnGridCreated += Grid_OnGridCreated;
            _grid.OnGridObjectChanged += Grid_OnGridObjectChanged;
            //Two dimensional Array
            _debugTextMesh = new TextMesh[_grid.GetGridArrayLenght(0), _grid.GetGridArrayLenght(1)];
        }

        //Destructor
        ~GridDebugVisual()
        {
            _grid.OnGridCreated -= Grid_OnGridCreated;
            _grid.OnGridObjectChanged -= Grid_OnGridObjectChanged;
        }
        private void Grid_OnGridObjectChanged(object sender, Grid<T>.OnGridObjectChangedEventArgs e)
        {
            if(e.gridObject == null)
            {
                _debugTextMesh[e.gridPosX, e.gridPosY].text = "0";
                return;
            }

            _debugTextMesh[e.gridPosX, e.gridPosY].text = e.gridObject.ToString();
        }

        private void Grid_OnGridCreated(object sender, EventArgs e)
        {
            DrawDebugVisuals();
            
        }

        private void DrawDebugVisuals()
        {
            for (int x = 0; x < _grid.GetGridArrayLenght(0); x++)
            {
                for (int y = 0; y < _grid.GetGridArrayLenght(1); y++)
                {
                    //Save all the TextMeshes in an Array
                    _debugTextMesh[x, y] = UtilsClass.CreateWorldText("0", null, _grid.GridPositionToWorldPosition(x, y) + new Vector3(_grid._cellSize, _grid._cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(_grid.GridPositionToWorldPosition(x, y), _grid.GridPositionToWorldPosition(x + 1, y), Color.white, _debugLineDestroyTime);
                    Debug.DrawLine(_grid.GridPositionToWorldPosition(x, y), _grid.GridPositionToWorldPosition(x, y + 1), Color.white, _debugLineDestroyTime);

                }


            }

            // Draw the vertical line at the end
            Debug.DrawLine(_grid.GridPositionToWorldPosition(0, _grid._height), _grid.GridPositionToWorldPosition(_grid._width, _grid._height), Color.white, _debugLineDestroyTime);
            //Draw the horizontal line at the end
            Debug.DrawLine(_grid.GridPositionToWorldPosition(_grid._width, 0), _grid.GridPositionToWorldPosition(_grid._width, _grid._height), Color.white, _debugLineDestroyTime);
        }
    }
}


