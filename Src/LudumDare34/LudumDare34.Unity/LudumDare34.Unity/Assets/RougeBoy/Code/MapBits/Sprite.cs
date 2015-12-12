using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LudumDare34.Unity.LudumDare34.Unity.Assets.RougeBoy.Code
{
    public class Sprite : UnityObject
    {
        public Vec2 Size;
        Vec2 _origin;
        Renderer _quadRenderer;

        public Sprite(Material material, int size = 1)
            : base(MyAssets.Resources.RougeBoy.Sprite.prefab.Clone())
        {
            GameObject.name = GetType().Name;
            Size = new Vec2(size, size);
            _quadRenderer = FindChildAt<Renderer>("Quad");
            _quadRenderer.sharedMaterial = material;
            Transform.localScale = Vector3.one * size * NavGrid.CellBlockSize;
        }

        public Vec2 Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                WorldPosition = new Vector3(_origin.x * NavGrid.CellBlockSize, _origin.y * NavGrid.CellBlockSize);
            }
        }
    }
}
