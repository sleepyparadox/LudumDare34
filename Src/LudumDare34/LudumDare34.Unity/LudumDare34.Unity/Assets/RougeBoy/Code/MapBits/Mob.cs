using LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Mob : MapElement
    {
        private TinyCoro _doWalk;
        List<Vec2> _path;
        public Mob()
            : base(MyAssets.Resources.RougeBoy.Materials.Mob.mat.Clone(), 1)
        {
        }

        public void StartWandering()
        {
            var astar = new Astar(Origin, new Vec2(RougeBoyGame.S.Grid.Width - 1, 0));
            astar.Perform();
            _path = astar.FinalPath;
            _doWalk = TinyCoro.SpawnNext(DoWalk);
        }

        IEnumerator DoWalk()
        {
            while (_path != null && _path.Any())
            {
                var nextPos = _path[0];
                _path.RemoveAt(0);

                RougeBoyGame.S.Grid.Move(nextPos, 1, this, Origin);

                yield return TinyCoro.Wait(1f);
            }

            _doWalk.Kill();
            Destroy();

            //while(true)
            //{
            //    Debug.Log("wander");


            //    var randDir = Vec2.Directions[UnityEngine.Random.Range(0, Vec2.Directions.Length)];

            //    if(RougeBoyGame.S.Grid.Move(Origin + randDir, 1, this, Origin))
            //    {
            //        yield return TinyCoro.Wait(1f);
            //    }
            //    else
            //    {
            //        Debug.Log(randDir + " is bad direction");
            //        yield return TinyCoro.Wait(0.1f);
            //    }
            //}
        }
    }
}
