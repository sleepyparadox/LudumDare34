using LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Mob : MapElement
    {
        private TinyCoro _doWalk;
        public int Health = 5;
        List<Vec2> _path;
        Vector2 _animatePos;
        float _speed = 60;
        public Mob()
            : base(MyAssets.Resources.RougeBoy.Materials.Mob.mat.Clone(), Vec2.One)
        {
            u.Update += Update;
        }

        private void Update(UnityObject uObj)
        {
            var targetPos = GetOrginAsWorldPosition();

            var distThisFrame = _speed * Time.deltaTime;

            var dif = targetPos - _animatePos;
            var difMag = dif.magnitude;
            
            if(difMag < 0.1 || difMag < distThisFrame)
            {
                _animatePos = targetPos;
            }
            else
            {
                _animatePos += (dif / difMag) * distThisFrame;
            }

            WorldPosition = new Vector3((int)_animatePos.x, (int)_animatePos.y);
        }


        bool firstTurn = true;
        internal Vec2 MoveToPos;

        public override void PerformTurn()
        {
            if(firstTurn)
            {
                _animatePos = GetOrginAsWorldPosition();
                firstTurn = false;
                FindPath();
            }

            if(Health <= 0 || _path == null || !_path.Any())
            {
                Destroy();
                return;
            }

            var nextPos = _path[0];
            _path.RemoveAt(0);

            if (!RougeBoyGame.S.Grid.Move(nextPos, Size, this, Origin))
            {
                //Failed to move, find new path
                FindPath();

                //Turn destroys if can't continue down path
                PerformTurn();
            }
        }

        void FindPath()
        {
            var astar = new Astar(Origin, MoveToPos);
            astar.Perform();
            _path = astar.FinalPath;
        }
    }
}
