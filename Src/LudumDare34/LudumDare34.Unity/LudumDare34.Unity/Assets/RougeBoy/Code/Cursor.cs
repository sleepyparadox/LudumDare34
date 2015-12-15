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
            : base(MyAssets.Resources.RougeBoy.Materials.Cursor.mat.Clone(), Vec2.Two)
        {
            Origin = new Vec2((GBScreen.Width / NavGrid.CellBlockSize / 2) - 1, (GBScreen.Height / NavGrid.CellBlockSize / 2) - 1);
            _inputs = new InputAxis[]
            {
                new InputAxis(new Vec2(-1, 0), KeyCode.LeftArrow, KeyCode.A),
                new InputAxis(new Vec2(1, 0), KeyCode.RightArrow, KeyCode.D),
                new InputAxis(new Vec2(0, 1), KeyCode.UpArrow, KeyCode.W),
                new InputAxis(new Vec2(0, -1), KeyCode.DownArrow, KeyCode.S),
            };

            var camera = GameObject.Find("Camera");
            camera.transform.parent = Transform;
            TinyCoro.SpawnNext(DoCursor);
        }


        const float _moveAfter = 0.25f;
        private InputAxis[] _inputs;

        public IEnumerator DoCursor()
        {
            while(true)
            {
                foreach(var input in _inputs)
                {
                    Origin += input.MovementThisFrame;
                }

                if(Input.GetKeyDown(KeyCode.Z) && RougeBoyGame.S.Popups == 0)
                {
                    if(RougeBoyGame.S.SlimesRemain >= 1)
                    {
                        if (RougeBoyGame.S.Grid.Move(Origin, Vec2.Two, null, null))
                        {
                            var tower = new SlimeTower();
                            RougeBoyGame.S.Grid.Move(Origin, tower.Size, tower, null);
                            RougeBoyGame.S.SlimesRemain--;
                        }
                    }
                    else
                    {
                        new Popup("Not enough slime!");
                    }
                }
                if (Input.GetKeyDown(KeyCode.X) && RougeBoyGame.S.Popups == 0)
                {
                    var towersToRemove = new List<MapElement>();
                    
                    for (int x = Math.Max(Origin.x, 0); x < Math.Min(Origin.x + Size.x, RougeBoyGame.S.Grid.Width - 1); x++)
                    {
                        for (int y = Math.Max(Origin.y, 0); y < Math.Min(Origin.y + Size.y, RougeBoyGame.S.Grid.Height - 1); y++)
                        {
                            if (RougeBoyGame.S.Grid.Cells[x, y] != null
                                && RougeBoyGame.S.Grid.Cells[x, y] is SlimeTower)
                            {
                                towersToRemove.Add(RougeBoyGame.S.Grid.Cells[x, y]);
                            }
                        }
                    }
                    foreach(var tower in towersToRemove.Distinct())
                    {
                        tower.Destroy();
                        RougeBoyGame.S.SlimesRemain++;
                    }
                }

                if (Input.GetKeyDown(KeyCode.P))
                {
                    RougeBoyGame.S.Paused = !RougeBoyGame.S.Paused;
                }

                if (Input.GetKeyDown(KeyCode.O))
                {
                    RougeBoyGame.S.PerformTurn();
                }

                if (Input.GetKeyDown(KeyCode.I))
                {
                    var log = "";
                    for (int y = 0; y < RougeBoyGame.S.Grid.Height; y++)
                    {
                        for (int x = 0; x < RougeBoyGame.S.Grid.Width; x++)
                        {
                            var cell = RougeBoyGame.S.Grid.Cells[x, y];
                            if(cell == null)
                            {
                                log += "null,";
                            }
                            else
                            {
                                log += cell.GetType().Name + " (" + cell.GetHashCode() + "),";
                            }
                        }
                        log += Environment.NewLine;
                    }
                    LoggerCheap.Log(log);
                }

                yield return null;
            }
            
        }

        public class InputAxis
        {
            public Vec2 MovementThisFrame
            {
                get
                {
                    return _keys.Any(key => Input.GetKeyUp(key)) ? _direction : Vec2.Zero;
                }
            }
            private Vec2 _direction;
            private KeyCode[] _keys;

            public InputAxis(Vec2 direction, params KeyCode[] keys)
            {
                _direction = direction;
                _keys = keys;
            }
        }
    }
}
