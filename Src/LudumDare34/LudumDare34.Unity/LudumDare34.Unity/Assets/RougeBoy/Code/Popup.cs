using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Popup : UnityObject
    {
        public Popup(string text)
            :base(MyAssets.Resources.RougeBoy.Popup.prefab.Clone())
        {
            var popupParent = GameObject.Find("PopupParent").transform;
            WorldPosition = popupParent.position;
            Transform.parent = popupParent;

            FindChildAt<TextMesh>("Text").text = text;

            RougeBoyGame.S.Popups++;

            u.Update += me =>
            {
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    Destroy();
                    RougeBoyGame.S.Popups--;
                }
            };
        }
    }
}
