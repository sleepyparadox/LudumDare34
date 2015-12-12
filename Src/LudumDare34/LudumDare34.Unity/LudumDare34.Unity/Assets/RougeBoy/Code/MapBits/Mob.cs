using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Mob : MapElement
    {
        public Mob()
            : base(MyAssets.Resources.RougeBoy.Materials.Mob.mat.Clone(), 1)
        {

        }
    }
}
