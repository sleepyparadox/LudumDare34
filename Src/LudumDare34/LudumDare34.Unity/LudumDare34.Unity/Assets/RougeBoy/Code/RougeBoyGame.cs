using LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code.MapBits;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class RougeBoyGame
    {
        public static RougeBoyGame S;
        public bool Paused;
        public NavGrid Grid;
        public List<MapElement> MapElements = new List<MapElement>();
        float _timePerTurn = 0.16f;

        public RougeBoyGame()
        {
            S = this;
            TinyCoro.SpawnNext(DoGame);
        }

        public IEnumerator DoGame()
        {
            Grid = new NavGrid(2 * GBScreen.Width / NavGrid.CellBlockSize, 1 * GBScreen.Height / NavGrid.CellBlockSize);
            new Cursor();

            var kingSlime0 = new SlimeKing(new Vec2(Grid.Width - 5, (Grid.Height / 2) - 2));
            var kingSlime1 = new SlimeKing(new Vec2(Grid.Width - 5, (Grid.Height / 2)));

            var spawner0 = new Spawner();
            spawner0.MoveToPos = kingSlime0.Origin;
            spawner0.Origin = new Vec2(0, (Grid.Height / 2) - 2);

            var spawner1 = new Spawner();
            spawner1.MoveToPos = kingSlime1.Origin;
            spawner1.Origin = new Vec2(0, (Grid.Height / 2));

            for (int i = 2; i < Grid.Width - 4; /*iterated below*/)
            {
                var sneakyWall = i == 2;

                var wallD = sneakyWall ? Wall.HalfDown : Wall.Down;
                Grid.Move(new Vec2(i, Grid.Height - 3), wallD.Size, wallD);

                var wallU = sneakyWall ? Wall.HalfUp : Wall.Up;
                Grid.Move(new Vec2(i, 0), wallU.Size, wallU);

                i += sneakyWall ? 1 : 2;
            }

            for (int i = 2; i < Grid.Height - 3;  /*iterated below*/)
            {
                var sneakyWallAt = (Grid.Height / 2) - 1;
                var sneakyWall = i == sneakyWallAt;

                var wallL = sneakyWall ? Wall.HalfLeft : Wall.Left;
                Grid.Move(new Vec2(Grid.Width - 3, i), wallL.Size, wallL);

                if(sneakyWall || i == sneakyWallAt - 2 || i == sneakyWallAt + 1)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        for (int y = i; y < i + (sneakyWall ? 1 : 2); y++)
                        {
                            var floorSprite = new Sprite(MyAssets.Resources.RougeBoy.Materials.NavTile.mat.Clone(), Vec2.One);
                            floorSprite.Origin = new Vec2(x, y);
                            floorSprite.WorldPosition += Vector3.forward * 9f;
                        }
                    }
                }
                else
                {
                    var wallR = Wall.Right;
                    Grid.Move(new Vec2(0, i), wallR.Size, wallR);
                }

                i += sneakyWall ? 1 : 2;
            }

            var wallUL = Wall.UpLeft;
            Grid.Move(new Vec2(Grid.Width - 3, 0), wallUL.Size, wallUL);
            var wallUR = Wall.UpRight;
            Grid.Move(new Vec2(0, 0), wallUR.Size, wallUR);
            var wallDL = Wall.DownLeft;
            Grid.Move(new Vec2(Grid.Width - 3, Grid.Height - 3), wallDL.Size, wallDL);
            var wallDR = Wall.DownRight;
            Grid.Move(new Vec2(0, Grid.Height - 3), wallDR.Size, wallDR);

            var elapsed = 0f;
            while (true)
            {
                if(!Paused)
                {
                    elapsed += Time.deltaTime;
                }

                if(elapsed >= _timePerTurn)
                {
                    elapsed -= _timePerTurn;
                    PerformTurn();
                }

                yield return null;
            }
        }

        public void PerformTurn()
        {
            var elementsThisTurn = MapElements.ToList();
            foreach (var element in elementsThisTurn)
            {
                element.PerformTurn();
            }
        }
    }
}
