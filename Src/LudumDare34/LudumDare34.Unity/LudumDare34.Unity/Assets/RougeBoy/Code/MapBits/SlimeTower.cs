using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class SlimeTower : MapElement
    {
        private MapElement _closetMob;
        public int _range = 28;

        public SlimeTower()
            : base(MyAssets.Resources.RougeBoy.Materials.Slime.mat.Clone(), Vec2.Two, true)
        {
            
        }

        int turnIndex = 0;

        public override void PerformTurn()
        {
            if(turnIndex % 3 == 0)
            {
                var center = GetCenterWorldPosition();
                if (_closetMob != null
                    && (_closetMob.IsDestroyed || (_closetMob.GetCenterWorldPosition() - this.GetCenterWorldPosition()).sqrMagnitude > (_range * _range)))
                {
                    //Moved out of range
                    _closetMob = null;
                }

                if (_closetMob == null)
                {
                    _closetMob = RougeBoyGame.S.MapElements.Where(m => m is Mob && !m.IsDestroyed)
                                                            .Select(m => new { Mob = m, SqrDist = ((m.WorldPosition) - this.WorldPosition).sqrMagnitude })
                                                            .Where(pair => (pair.Mob.GetCenterWorldPosition() - this.GetCenterWorldPosition()).sqrMagnitude <= (_range * _range))
                                                            .OrderBy(pair => pair.SqrDist)
                                                            .Select(pair => pair.Mob)
                                                            .FirstOrDefault();
                }

                if (_closetMob != null)
                {
                    new Bullet(_closetMob as Mob, this);
                }
            }
            turnIndex++;
        }
    }
}
