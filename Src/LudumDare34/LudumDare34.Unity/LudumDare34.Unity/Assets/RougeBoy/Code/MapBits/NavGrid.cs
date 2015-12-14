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
        //public Vec2[,] Path;
        public readonly int Width;
        public readonly int Height;
        public NavGrid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new MapElement[Width, Height];
            //Path = new Vec2[Width, Height];
        }

        public bool CanMoveTo(Vec2 destPosition, Vec2 size, MapElement mapElement = null)
        {
            var grid = this;
            if (destPosition.x < 0 || destPosition.x + size.x > grid.Width
                || destPosition.y < 0 || destPosition.y + size.y > grid.Height)
            {
                LoggerCheap.Log("Out of bounds");
                return false;
            }

            //LoggerCheap.Log("Move");
            for (int x = destPosition.x; x < destPosition.x + size.x; x++)
            {
                for (int y = destPosition.y; y < destPosition.y + size.y; y++)
                {
                    if (grid.Cells[x, y] != null && grid.Cells[x, y] != mapElement)
                    {
                        //Something else is in the way
                        LoggerCheap.Log("Something in way");
                        return false;
                    }
                }
            }
            return true;
        }

        public void Remove(Vec2 size, MapElement mapElement, Vec2? srcPosition = null)
        {
            var grid = this;
            //Clear old pos
            if (mapElement != null && srcPosition.HasValue)
            {
                for (int x = srcPosition.Value.x; x < srcPosition.Value.x + size.x; x++)
                {
                    for (int y = srcPosition.Value.y; y < srcPosition.Value.y + size.y; y++)
                    {
                        if (grid.Cells[x, y] == mapElement)
                        {
                            grid.Cells[x, y] = null;
                        }
                    }
                }
            }
        }

        public bool Move(Vec2 destPosition, Vec2 size, MapElement mapElement, Vec2? srcPosition = null)
        {
            var grid = this;
            
            if(!CanMoveTo(destPosition, size, mapElement))
            {
                return false;
            }

            Remove(size, mapElement, srcPosition);

            if (mapElement != null)
            { 
                //Set new pos
                for (int x = destPosition.x; x < destPosition.x + size.x; x++)
                {
                    for (int y = destPosition.y; y < destPosition.y + size.y; y++)
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
