using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits
{
    public class Spawner : Sprite
    {
        public Spawner()
            : base(MyAssets.Resources.RougeBoy.Materials.Mob.mat.Clone())
        {
            Origin = new Vec2(0, RougeBoyGame.S.Grid.Height - 2);
            TinyCoro.SpawnNext(DoSpawning);
        }

        public IEnumerator DoSpawning()
        {
            while (true)
            {
                if (RougeBoyGame.S.Grid.Move(Origin, 1, null, null))
                {
                    var mob = new Mob();
                    mob.StartWandering();
                    RougeBoyGame.S.Grid.Move(Origin, 1, mob, null);
                    RougeBoyGame.S.MapElements.Add(mob);
                }
                else
                {
                    Debug.Log(Origin + " is in use");
                }
                yield return TinyCoro.Wait(1f);
            }
        }
    }
}
