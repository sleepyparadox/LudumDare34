using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class RougeBoyGame
    {
        public static RougeBoyGame S;
        public NavGrid Grid;
        public List<MapElement> MapElements = new List<MapElement>();
        public RougeBoyGame()
        {
            S = this;
            TinyCoro.SpawnNext(DoGame);
        }

        public IEnumerator DoGame()
        {
            Grid = new NavGrid();
            new Cursor();

            while (true)
            {
                yield return TinyCoro.Wait(10);
            }
        }
    }
}
