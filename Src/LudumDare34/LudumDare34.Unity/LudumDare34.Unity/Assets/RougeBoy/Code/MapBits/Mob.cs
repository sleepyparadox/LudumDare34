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
        public Mob()
            : base(MyAssets.Resources.RougeBoy.Materials.Mob.mat.Clone(), 1)
        {
        }

        public void StartWandering()
        {
            TinyCoro.SpawnNext(DoWander);
        }

        IEnumerator DoWander()
        {
            while(true)
            {
                Debug.Log("wander");
                var randDir = Vec2.Directions[UnityEngine.Random.Range(0, Vec2.Directions.Length)];

                if(RougeBoyGame.S.Grid.Move(Origin + randDir, 1, this, Origin))
                {
                    yield return TinyCoro.Wait(1f);
                }
                else
                {
                    Debug.Log(randDir + " is bad direction");
                    yield return TinyCoro.Wait(0.1f);
                }
            }
        }
    }
}
