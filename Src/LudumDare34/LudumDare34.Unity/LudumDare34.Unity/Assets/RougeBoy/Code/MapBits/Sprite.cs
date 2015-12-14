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

        public Sprite(Material material, Vec2 size, bool animated = false)
            : base(MyAssets.Resources.RougeBoy.Sprite.prefab.Clone())
        {
            GameObject.name = GetType().Name;
            Size = size;
            _quadRenderer = FindChildAt<Renderer>("Quad");
            _quadRenderer.sharedMaterial = material;
            Transform.localScale = new Vector3(size.x * NavGrid.CellBlockSize, size.y * NavGrid.CellBlockSize, 1);

            if(animated)
            {
                u.Update += SpriteAnimate;
            }
        }

        private void SpriteAnimate(UnityObject uObj)
        {
            var frame = (int)((Time.time * 6) % 2);
            _quadRenderer.material.mainTextureOffset = new Vector2(frame * 0.5f, 0f);
        }

        public Vec2 Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                WorldPosition = GetOrginAsWorldPosition();
            }
        }

        public Vector2 GetOrginAsWorldPosition()
        {
            return new Vector3(_origin.x * NavGrid.CellBlockSize, _origin.y * NavGrid.CellBlockSize);
        }

        public Vector2 GetCenterWorldPosition()
        {
            var center = GetOrginAsWorldPosition();
            center.x += Transform.localScale.x / 2f;
            center.y += Transform.localScale.y / 2f;
            return center;
        }

        public void SetCenterWorldPosition(Vector2 center)
        {
            center.x -= Transform.localScale.x / 2f;
            center.y -= Transform.localScale.y / 2f;
            WorldPosition = center;
        }
    }
}
