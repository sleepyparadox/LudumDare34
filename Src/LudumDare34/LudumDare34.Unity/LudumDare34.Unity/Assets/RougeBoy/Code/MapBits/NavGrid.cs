using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class NavGrid
    {
        public const int CellBlockSize = 8;
        public MapElement[,] Cells;
        public readonly int Width;
        public readonly int Height;
        public NavGrid()
        {
            Width = GameBoyScreen.Width / CellBlockSize;
            Height = GameBoyScreen.Height / CellBlockSize;
            Cells = new MapElement[Width, Height];
        }

        public bool Move(Vec2 destPosition, int size, MapElement mapElement = null, Vec2? srcPosition = null)
        {
            var grid = this;

            if (destPosition.x < 0 || destPosition.x + size > grid.Width
                || destPosition.y < 0 || destPosition.y + size > grid.Height)
            {
                Debug.Log("Out of bounds");
                return false;
            }

            Debug.Log("Move");
            for (int x = destPosition.x; x < destPosition.x + size; x++)
            {
                for (int y = destPosition.y; y < destPosition.y + size; y++)
                {
                    if (grid.Cells[x, y] != null && grid.Cells[x, y] != mapElement)
                    {
                        //Something else is in the way
                        Debug.Log("Something in way");
                        return false;
                    }
                }
            }

            //Clear old pos
            if (mapElement != null && srcPosition.HasValue)
            {
                for (int x = srcPosition.Value.x; x < srcPosition.Value.x + size; x++)
                {
                    for (int y = srcPosition.Value.y; y < srcPosition.Value.y + size; y++)
                    {
                        if (grid.Cells[x, y] == mapElement)
                        {
                            grid.Cells[x, y] = null;
                        }
                    }
                }
            }
            if (mapElement != null)
            { 
                    //Set new pos
                for (int x = destPosition.x; x < destPosition.x + size; x++)
                {
                    for (int y = destPosition.y; y < destPosition.y + size; y++)
                    {
                        grid.Cells[x, y] = mapElement;
                    }
                }
                mapElement.Origin = destPosition;
            }

            return true;
        }
    }
}
