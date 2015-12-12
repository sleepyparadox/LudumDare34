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
    }
}
