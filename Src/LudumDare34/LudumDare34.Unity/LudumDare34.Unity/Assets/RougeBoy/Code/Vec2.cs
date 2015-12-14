using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public struct Vec2
    {
        public int x;
        public int y;

        public Vec2(int x, int y) : this()
        {
            this.x = x;
            this.y = y;
        }

        public static Vec2 operator + (Vec2 a, Vec2 b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x - b.x, a.y - b.y);
        }

        public static Vec2 Zero
        {
            get { return new Vec2(); }
        }

        public static Vec2 One
        {
            get { return new Vec2(1,1); }
        }

        public static Vec2 Two
        {
            get { return new Vec2(2, 2); }
        }

        public static Vec2 Left
        {
            get { return new Vec2(-1, 0); }
        }

        public static Vec2 Right
        {
            get { return new Vec2(1, 0); }
        }

        public static Vec2 Up
        {
            get { return new Vec2(0, 1); }
        }


        public static Vec2 Down
        {
            get { return new Vec2(0, -1); }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", x, y);
        }

        public static float GetDistance(Vec2 a, Vec2 b)
        {
            return ((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y));
        }

        public override bool Equals(object obj)
        {
            if(obj is Vec2)
            {
                var other = (Vec2)obj;
                return x == other.x && y == other.y;
            }
            return false;
        }

        public static bool operator ==(Vec2 a, Vec2 b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Vec2 a, Vec2 b)
        {
            return !(a == b);
        }

        public static Vec2[] Directions = new Vec2[] { Left, Right, Up, Down };
    }
}
