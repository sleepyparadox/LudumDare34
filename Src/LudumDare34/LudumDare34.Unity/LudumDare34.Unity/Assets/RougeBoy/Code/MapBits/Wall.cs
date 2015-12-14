using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits
{
    public static class Wall 
    {
        public static MapElement Down
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallD.mat.Clone(), Vec2.Two); }
        }

        public static MapElement Up
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallU.mat.Clone(), Vec2.Two); }
        }

        public static MapElement Left
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallL.mat.Clone(), Vec2.Two); }
        }

        public static MapElement Right
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallR.mat.Clone(), Vec2.Two); }
        }

        public static MapElement UpLeft
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallUL.mat.Clone(), Vec2.Two); }
        }

        public static MapElement UpRight
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallUR.mat.Clone(), Vec2.Two); }
        }

        public static MapElement DownLeft
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallDL.mat.Clone(), Vec2.Two); }
        }

        public static MapElement DownRight
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallDR.mat.Clone(), Vec2.Two); }
        }

        public static MapElement HalfDown
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallHalfD.mat.Clone(), new Vec2(1, 2)); }
        }

        public static MapElement HalfUp
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallHalfU.mat.Clone(), new Vec2(1, 2)); }
        }

        public static MapElement HalfLeft
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallHalfL.mat.Clone(), new Vec2(2, 1)); }
        }

        public static MapElement HalfRight
        {
            get { return new MapElement(MyAssets.Resources.RougeBoy.Materials.WallHalfR.mat.Clone(), new Vec2(2, 1)); }
        }
    }
}
