using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits
{
    public class Astar
    {
        public List<Vec2> FinalPath;
        public Astar(Vec2 start, Vec2 end)
        {
            _start = start;
            _end = end;

            _open.Add(new AStarNode(_start, 0, null));
        }

        public void Perform()
        {
            var grid = RougeBoyGame.S.Grid;
            var i = 0;
            var directions = Vec2.Directions;

            while(_open.Keys.Any())
            {
                var parent = _open.Values.OrderBy(p => p.Cost + GetHeuristic(p.Point)).First();
                _open.Remove(parent.Point);
                //LoggerCheap.Log("Look at " + i);

                foreach (var dir in directions)
                {
                    var neighbourKey = parent.Point + dir;

                    if(_open.ContainsKey(neighbourKey))
                    {
                        //if(_open[neighbourKey].Cost < parent.Cost + 1)
                        //{
                        //    _open[neighbourKey].Cost = parent.Cost + 1;
                        //    _open[neighbourKey].Parent = parent;
                        //}
                    }
                    else if (_closed.ContainsKey(neighbourKey))
                    {
                        //if (_closed[neighbourKey].Cost < parent.Cost + 1)
                        //{
                        //    _closed[neighbourKey].Cost = parent.Cost + 1;
                        //    _closed[neighbourKey].Parent = parent;
                        //}
                    }
                    else
                    {
                        if (neighbourKey.x >= 0 && neighbourKey.x < grid.Width
                            && neighbourKey.y >= 0 && neighbourKey.y < grid.Height)
                        {
                            if(grid.Cells[neighbourKey.x, neighbourKey.y] == null
                                || grid.Cells[neighbourKey.x, neighbourKey.y] is Mob
                                || grid.Cells[neighbourKey.x, neighbourKey.y] is SlimeKing)
                            {
                                _open.Add(new AStarNode(neighbourKey, parent.Cost + 1f, parent));
                            }
                        }
                    }
                }

                _closed.Add(parent);

               // LoggerCheap.Log("Open " + _open.Values.Count + " Closed " + _closed.Values.Count);

                if(parent.Point.Equals(_end))
                {
                    FinalPath = new List<Vec2>();
                    var next = parent;

                    while(next != null)
                    {
                        //LoggerCheap.Log("Add to path " + next.Point);
                        FinalPath.Add(next.Point);
                        next = next.Parent;
                    }
                    FinalPath.Reverse();
                }
                ++i;
            }
        }

        Dictionary<Vec2, AStarNode> _open = new Dictionary<Vec2, AStarNode>(RougeBoyGame.S.Grid.Width * RougeBoyGame.S.Grid.Height);
        Dictionary<Vec2, AStarNode> _closed = new Dictionary<Vec2, AStarNode>(RougeBoyGame.S.Grid.Width * RougeBoyGame.S.Grid.Height);
        Vec2 _start;
        Vec2 _end;

        float GetHeuristic(Vec2 node)
        {
            return Vec2.GetDistance(node, _end);
        }
    }

    public class AStarNode
    {
        public AStarNode(Vec2 point, float cost, AStarNode parent)
        {
            Point = point;
            Cost = cost;
            Parent = parent;
            //LoggerCheap.Log("Create node at " + point);
        }

        public Vec2 Point;
        public float Cost;
        public AStarNode Parent;
    }

    public static class AStartNodeHelper
    {
        public static void Add(this Dictionary<Vec2, AStarNode> dict, AStarNode node)
        {
            dict.Add(node.Point, node);
        }
    }
}
