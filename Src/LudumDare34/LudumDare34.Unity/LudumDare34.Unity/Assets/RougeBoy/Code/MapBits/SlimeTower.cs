using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class SlimeTower : MapElement
    {
        public SlimeTower()
            : base(MyAssets.Resources.RougeBoy.Materials.Slime.mat.Clone(), 2)
        {
            
        }
    }
}
