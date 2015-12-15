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
        public float SlimesRemain = 3f;
        public int Lives = 15;
        public int WaveId = 1;

        public bool Paused;
        public NavGrid Grid;
        public List<MapElement> MapElements = new List<MapElement>();
        float _minTimePerTurn = 0.25f;
        public int Popups;

        public int Turn = 0;
        int finalWave = 60;

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

            var slimesText = GameObject.Find("SlimesText").GetComponent<TextMesh>();
            var livesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
            var waveText = GameObject.Find("WaveText").GetComponent<TextMesh>();

            var elapsed = 0f;
            while (true)
            {
                slimesText.text = Math.Min((int)SlimesRemain, 99).ToString();
                livesText.text = Math.Min((int)Lives, 99).ToString();
                waveText.text = "Wave " + WaveId;

                if(Lives <= 0)
                {
                    var kingDeadPop = new Popup("Kings are dead");
                    yield return TinyCoro.WaitUntil(() => kingDeadPop.IsDestroyed);

                    var gameOverPop = new Popup("Game Over");
                    yield return TinyCoro.WaitUntil(() => gameOverPop.IsDestroyed);

                    foreach(var coro in TinyCoro.AllCoroutines)
                    {
                        coro.Kill();
                    }
                    Application.LoadLevel(Application.loadedLevel);
                    yield break;
                }
                if(Turn >= finalWave
                    && !MapElements.Any(e => e is Mob))
                {
                    var wave60Pop = new Popup("Wave 60 complete");
                    yield return TinyCoro.WaitUntil(() => wave60Pop.IsDestroyed);

                    var winPop = new Popup("You win!");
                    yield return TinyCoro.WaitUntil(() => winPop.IsDestroyed);

                    foreach (var coro in TinyCoro.AllCoroutines)
                    {
                        coro.Kill();
                    }
                    Application.LoadLevel(Application.loadedLevel);
                    yield break;
                }

                if (!Paused && RougeBoyGame.S.Popups == 0)
                {
                    elapsed += Time.deltaTime;
                }

                var timePerTurn = _minTimePerTurn * Math.Max(1f, 5f - (WaveId / 2f));
                if(elapsed >= timePerTurn)
                {
                    elapsed -= timePerTurn;
                    PerformTurn();

                    Turn++;
                    if (Turn > 20 && Turn <= finalWave)
                    {
                        WaveId++;
                        Turn = 0;
                    }
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
