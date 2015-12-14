using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits
{
    public class SlimeKing : MapElement
    {
        public SlimeKing(Vec2 pos)
            : base(MyAssets.Resources.RougeBoy.Materials.KingSlime.mat.Clone(), new Vec2(1, 2), true)
        {
            //RougeBoyGame.S.Grid.Move(pos, Vec2.One, this);
            Origin = pos;
        }
    }
}
