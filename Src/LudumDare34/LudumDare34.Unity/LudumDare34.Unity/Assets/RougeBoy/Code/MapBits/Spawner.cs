using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits
{
    public class Spawner : MapElement
    {
        public Vec2 MoveToPos;
        public Spawner()
            : base(MyAssets.Resources.RougeBoy.Materials.Mob.mat.Clone(), Vec2.One)
        {
            GameObject.SetActive(false);
        }

        public override void PerformTurn()
        {
            if(RougeBoyGame.S.Turn % 2 == 0
                && RougeBoyGame.S.Turn <= 14)
            {
                if (RougeBoyGame.S.Grid.CanMoveTo(Origin, Vec2.One))
                {
                    var mob = new Mob();
                    mob.MoveToPos = MoveToPos;
                    mob.WorldPosition = this.WorldPosition;
                    RougeBoyGame.S.Grid.Move(Origin, Vec2.One, mob, null);
                }
            }
        }
    }
}
