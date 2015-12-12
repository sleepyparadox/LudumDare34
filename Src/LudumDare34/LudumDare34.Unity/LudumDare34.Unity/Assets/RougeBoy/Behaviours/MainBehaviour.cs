using LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Behaviours
{
    public class MainBehaviour : MonoBehaviour
    {
        void Awake()
        {
            new RougeBoyGame();
        }

        void Update()
        {
            TinyCoro.StepAllCoros();
        }
    }
}
