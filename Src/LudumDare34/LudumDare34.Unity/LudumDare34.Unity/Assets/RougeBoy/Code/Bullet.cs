using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Bullet : MapElement
    {
        private Mob _target;
        int _stepsToHit = 2;
        int _steps;
        Vector2 _animatePos;
        private SlimeTower _source;
        private Vector2 _targetPos;
        float _speed = 70;

        public Bullet(Mob targetMob, SlimeTower source)
            : base(MyAssets.Resources.RougeBoy.Materials.Bullet.mat.Clone(), Vec2.One)
        {
            _target = targetMob;
            _source = source;
            _animatePos = source.GetCenterWorldPosition();
            _targetPos = _animatePos;
            SetCenterWorldPosition(new Vector3((int)_animatePos.x, (int)_animatePos.y, -0.1f));

            u.Update += Update;
        }

        private void Update(UnityObject uObj)
        {
            var distThisFrame = _speed * Time.deltaTime;

            var dif = _targetPos - _animatePos;
            var difMag = dif.magnitude;

            if (difMag < 0.1 || difMag < distThisFrame)
            {
                _animatePos = _targetPos;
            }
            else
            {
                _animatePos += (dif / difMag) * distThisFrame;
            }

            SetCenterWorldPosition(new Vector3((int)_animatePos.x, (int)_animatePos.y, -0.1f));
        }

        public override void PerformTurn()
        {
            if(_target.IsDestroyed
                || _source.IsDestroyed)
            {
                Destroy();
                return;
            }

            var lerp = (_steps + 1f) / _stepsToHit;
            _targetPos = Vector2.Lerp(_source.GetCenterWorldPosition(), _target.GetCenterWorldPosition(), lerp);
            SetCenterWorldPosition(new Vector3((int)_targetPos.x, (int)_targetPos.y, -0.1f));

            //Debug.Log("Bullet step " + _steps);
            _steps++;

            if (_steps > _stepsToHit)
            {
                //Debug.Log("Bullet Destroy");
                Destroy();
                (_target as Mob).Health -= 1;
                return;
            }
        }
    }
}
