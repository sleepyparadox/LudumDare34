using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class MapElement : Sprite
    {
        public MapElement(Material material, Vec2 size, bool animated = false)
            : base(material, size, animated)
        {
            RougeBoyGame.S.MapElements.Add(this);
            u.OnDestroy += (me) =>
            {
                RougeBoyGame.S.MapElements.Remove(this);
                RougeBoyGame.S.Grid.Remove(Size, this, Origin);
            };
        } 

        public virtual void PerformTurn()
        {

        }
    }
}
