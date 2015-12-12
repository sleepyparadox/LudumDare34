using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Cursor : Sprite
    {
        public Cursor()
            : base(MyAssets.Resources.RougeBoy.Materials.Cursor.mat.Clone(), 2)
        {
            Origin = new Vec2(GameBoyScreen.Width / NavGrid.CellBlockSize / 2, GameBoyScreen.Height / NavGrid.CellBlockSize / 2);
            TinyCoro.SpawnNext(DoCursor);
        }

        float _leftDuration;
        float _rightDuration;
        float _upDuration;
        float _downDuration;

        const float _moveAfter = 0.25f;

        public IEnumerator DoCursor()
        {
            while(true)
            {
                if(_leftDuration >= _moveAfter || (_leftDuration < _moveAfter && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))) )
                {
                    Origin = new Vec2(Origin.x - 1, Origin.y);
                    _leftDuration -= _moveAfter;
                }

                if (_rightDuration >= _moveAfter || (_rightDuration < _moveAfter && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightAlt))))
                {
                    Origin = new Vec2(Origin.x + 1, Origin.y);
                    _rightDuration -= _moveAfter;
                }

                if (_upDuration >= _moveAfter || (_upDuration < _moveAfter && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))))
                {
                    Origin = new Vec2(Origin.x, Origin.y + 1);
                    _upDuration -= _moveAfter;
                }

                if (_downDuration >= _moveAfter || (_downDuration < _moveAfter && (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))))
                {
                    Origin = new Vec2(Origin.x, Origin.y - 1);
                    _downDuration -= _moveAfter;
                }


                _leftDuration = Input.GetAxis("Horizontal") < 0 ? _leftDuration + Time.deltaTime : 0f;
                _rightDuration = Input.GetAxis("Horizontal") > 0 ? _rightDuration + Time.deltaTime : 0f;
                _upDuration = Input.GetAxis("Vertical") > 0 ? _upDuration + Time.deltaTime : 0f;
                _downDuration = Input.GetAxis("Vertical") < 0 ? _downDuration + Time.deltaTime : 0f;


                if(Input.GetKeyUp(KeyCode.X))
                {
                    var tower = new SlimeTower();
                    if(tower.Move(Origin))
                    {
                        RougeBoyGame.S.MapElements.Add(tower);
                    }
                    else
                    {
                        //Not optimized but jam
                        tower.Destroy();
                    }

                    for (int x = 0; x < RougeBoyGame.S.Grid.Width; x++)
                    {
                        for (int y = 0; y < RougeBoyGame.S.Grid.Height; y++)
                        {
                            var cell = RougeBoyGame.S.Grid.Cells[x, y];
                            Debug.Log(x + ", " + y + " is " + (cell == null ? "null" : cell.GetHashCode().ToString()));
                        }
                    }
                }

                
                yield return null;
            }
            
        }
    }
}
