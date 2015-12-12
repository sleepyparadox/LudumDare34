using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class MapElement : Sprite
    {
        public NavGrid Grid;
        public MapElement(Material material, int size)
            : base(material, size)
        {
            Grid = RougeBoyGame.S.Grid;
        }   

        public bool Move(Vec2 newPosition)
        {
            Debug.Log("Move");
            for (int x = newPosition.x; x < newPosition.x + Size.x; x++)
            {
                for (int y = newPosition.y; y < newPosition.y + Size.y; y++)
                {
                    if (Grid.Cells[x, y] != null && Grid.Cells[x, y] != this)
                    {
                        //Something else is in the way
                        Debug.Log("Something in way");
                        return false;
                    }
                }
            }


            //Clear old pos
            for (int x = Origin.x; x < Origin.x + Size.x; x++)
            {
                for (int y = Origin.y; y < Origin.y + Size.y; y++)
                {
                    if(Grid.Cells[x, y] == this)
                    {
                    Debug.Log("Clear " + x + ", " + y);
                        Grid.Cells[x, y] = null;
                    }
                }
            }

            //Set new pos
            for (int x = newPosition.x; x < newPosition.x + Size.x; x++)
            {
                for (int y = newPosition.y; y < newPosition.y + Size.y; y++)
                {
                    Debug.Log("Set " + x + ", " + y + " set to " + GetHashCode());
                    Grid.Cells[x, y] = this;
                }
            }

            Origin = newPosition;
            return true;
        }
    }
}
