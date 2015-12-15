/// <summary>
/// 
/// GENERAGED CODE 
/// ANY CHANGES YOU MAKE WILL PROBABLY BE LOST
/// 
/// This code file was generated at 12/15/2015 10:32:13 AM 
/// using the open source kit uSquid https://github.com/sleepyparadox/uSquid
/// 
/// </summary>
using uSquid.Assets;
using UnityEngine;
public static class MyAssets
{
	public static MyAssetsNode Root = new MyAssetsNode();
	public static MyAssetsNode.ResourcesNode Resources { get { return Root.Resources; } }
	public static IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { Resources }; }
}
public class MyAssetsNode : IDirectoryNode
{
	public string Name { get { return "Assets"; } }
	public string Path { get { return "D:/SleepyParadox/LudumDare34/Src/LudumDare34/LudumDare34.Unity/LudumDare34.Unity/Assets"; } }
	public ResourcesNode Resources = new ResourcesNode();
	public class ResourcesNode : IDirectoryNode
	{
		public string Name { get { return "Resources"; } }
		public string Path { get { return "Resources"; } }
		public FontsNode Fonts = new FontsNode();
		public RougeBoyNode RougeBoy = new RougeBoyNode();
		public class FontsNode : IDirectoryNode
		{
			public string Name { get { return "Fonts"; } }
			public string Path { get { return "Resources/Fonts"; } }
			public SF_PixelateNode SF_Pixelate = new SF_PixelateNode();
			public class SF_PixelateNode : IAssetNode
			{
				public Asset<UnityEngine.Font> ttf = new Asset<UnityEngine.Font>("SF Pixelate.ttf", "Resources/Fonts/SF Pixelate.ttf");
				public Asset[] GetAssets() { return new Asset[] { ttf }; }
			}
			public Asset[] GetAssets() { return new Asset[] { SF_Pixelate.ttf }; }
			public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { SF_Pixelate }; }
			public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
		}
		public class RougeBoyNode : IDirectoryNode
		{
			public string Name { get { return "RougeBoy"; } }
			public string Path { get { return "Resources/RougeBoy"; } }
			public PopupNode Popup = new PopupNode();
			public SpriteNode Sprite = new SpriteNode();
			public MaterialsNode Materials = new MaterialsNode();
			public MaterialsColorsNode MaterialsColors = new MaterialsColorsNode();
			public SFXNode SFX = new SFXNode();
			public TexturesNode Textures = new TexturesNode();
			public class PopupNode : IAssetNode
			{
				public Asset<UnityEngine.GameObject> prefab = new Asset<UnityEngine.GameObject>("Popup.prefab", "Resources/RougeBoy/Popup.prefab");
				public Asset[] GetAssets() { return new Asset[] { prefab }; }
			}
			public class SpriteNode : IAssetNode
			{
				public Asset<UnityEngine.GameObject> prefab = new Asset<UnityEngine.GameObject>("Sprite.prefab", "Resources/RougeBoy/Sprite.prefab");
				public Asset[] GetAssets() { return new Asset[] { prefab }; }
			}
			public class MaterialsNode : IDirectoryNode
			{
				public string Name { get { return "Materials"; } }
				public string Path { get { return "Resources/RougeBoy/Materials"; } }
				public _DTextureNode _DTexture = new _DTextureNode();
				public BulletNode Bullet = new BulletNode();
				public CursorNode Cursor = new CursorNode();
				public KingSlimeNode KingSlime = new KingSlimeNode();
				public MapFloorx10Node MapFloorx10 = new MapFloorx10Node();
				public MobNode Mob = new MobNode();
				public NavTileNode NavTile = new NavTileNode();
				public PopupBarNode PopupBar = new PopupBarNode();
				public SlimeNode Slime = new SlimeNode();
				public UIBarNode UIBar = new UIBarNode();
				public WallDNode WallD = new WallDNode();
				public WallDLNode WallDL = new WallDLNode();
				public WallDRNode WallDR = new WallDRNode();
				public WallHalfDNode WallHalfD = new WallHalfDNode();
				public WallHalfLNode WallHalfL = new WallHalfLNode();
				public WallHalfRNode WallHalfR = new WallHalfRNode();
				public WallHalfUNode WallHalfU = new WallHalfUNode();
				public WallLNode WallL = new WallLNode();
				public WallRNode WallR = new WallRNode();
				public WallUNode WallU = new WallUNode();
				public WallULNode WallUL = new WallULNode();
				public WallURNode WallUR = new WallURNode();
				public class _DTextureNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("3DTexture.mat", "Resources/RougeBoy/Materials/3DTexture.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class BulletNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Bullet.mat", "Resources/RougeBoy/Materials/Bullet.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class CursorNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Cursor.mat", "Resources/RougeBoy/Materials/Cursor.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class KingSlimeNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("KingSlime.mat", "Resources/RougeBoy/Materials/KingSlime.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class MapFloorx10Node : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("MapFloorx10.mat", "Resources/RougeBoy/Materials/MapFloorx10.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class MobNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Mob.mat", "Resources/RougeBoy/Materials/Mob.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class NavTileNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("NavTile.mat", "Resources/RougeBoy/Materials/NavTile.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class PopupBarNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("PopupBar.mat", "Resources/RougeBoy/Materials/PopupBar.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class SlimeNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Slime.mat", "Resources/RougeBoy/Materials/Slime.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class UIBarNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("UIBar.mat", "Resources/RougeBoy/Materials/UIBar.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallDNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallD.mat", "Resources/RougeBoy/Materials/WallD.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallDLNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallDL.mat", "Resources/RougeBoy/Materials/WallDL.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallDRNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallDR.mat", "Resources/RougeBoy/Materials/WallDR.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallHalfDNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallHalfD.mat", "Resources/RougeBoy/Materials/WallHalfD.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallHalfLNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallHalfL.mat", "Resources/RougeBoy/Materials/WallHalfL.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallHalfRNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallHalfR.mat", "Resources/RougeBoy/Materials/WallHalfR.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallHalfUNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallHalfU.mat", "Resources/RougeBoy/Materials/WallHalfU.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallLNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallL.mat", "Resources/RougeBoy/Materials/WallL.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallRNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallR.mat", "Resources/RougeBoy/Materials/WallR.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallUNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallU.mat", "Resources/RougeBoy/Materials/WallU.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallULNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallUL.mat", "Resources/RougeBoy/Materials/WallUL.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WallURNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("WallUR.mat", "Resources/RougeBoy/Materials/WallUR.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public Asset[] GetAssets() { return new Asset[] { _DTexture.mat, Bullet.mat, Cursor.mat, KingSlime.mat, MapFloorx10.mat, Mob.mat, NavTile.mat, PopupBar.mat, Slime.mat, UIBar.mat, WallD.mat, WallDL.mat, WallDR.mat, WallHalfD.mat, WallHalfL.mat, WallHalfR.mat, WallHalfU.mat, WallL.mat, WallR.mat, WallU.mat, WallUL.mat, WallUR.mat }; }
				public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { _DTexture, Bullet, Cursor, KingSlime, MapFloorx10, Mob, NavTile, PopupBar, Slime, UIBar, WallD, WallDL, WallDR, WallHalfD, WallHalfL, WallHalfR, WallHalfU, WallL, WallR, WallU, WallUL, WallUR }; }
				public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
			}
			public class MaterialsColorsNode : IDirectoryNode
			{
				public string Name { get { return "MaterialsColors"; } }
				public string Path { get { return "Resources/RougeBoy/MaterialsColors"; } }
				public RedNode Red = new RedNode();
				public WhiteNode White = new WhiteNode();
				public class RedNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Red.mat", "Resources/RougeBoy/MaterialsColors/Red.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class WhiteNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("White.mat", "Resources/RougeBoy/MaterialsColors/White.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public Asset[] GetAssets() { return new Asset[] { Red.mat, White.mat }; }
				public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { Red, White }; }
				public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
			}
			public class SFXNode : IDirectoryNode
			{
				public string Name { get { return "SFX"; } }
				public string Path { get { return "Resources/RougeBoy/SFX"; } }
				public DecentNode Decent = new DecentNode();
				public class DecentNode : IAssetNode
				{
					// unsupported filetype: Decent.bfxrsound
					public Asset<UnityEngine.AudioSource> wav = new Asset<UnityEngine.AudioSource>("Decent.wav", "Resources/RougeBoy/SFX/Decent.wav");
					public Asset[] GetAssets() { return new Asset[] { wav }; }
				}
				public Asset[] GetAssets() { return new Asset[] { Decent.wav }; }
				public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { Decent }; }
				public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
			}
			public class TexturesNode : IDirectoryNode
			{
				public string Name { get { return "Textures"; } }
				public string Path { get { return "Resources/RougeBoy/Textures"; } }
				public _DTextureNode _DTexture = new _DTextureNode();
				public Art___ShortcutNode Art___Shortcut = new Art___ShortcutNode();
				public BulletNode Bullet = new BulletNode();
				public CursorNode Cursor = new CursorNode();
				public KingSlimeNode KingSlime = new KingSlimeNode();
				public MapFloorNode MapFloor = new MapFloorNode();
				public MobNode Mob = new MobNode();
				public NavTileNode NavTile = new NavTileNode();
				public PopupBarNode PopupBar = new PopupBarNode();
				public SlimeNode Slime = new SlimeNode();
				public SplashScreenNode SplashScreen = new SplashScreenNode();
				public UIBarNode UIBar = new UIBarNode();
				public WallDNode WallD = new WallDNode();
				public WallDLNode WallDL = new WallDLNode();
				public WallDRNode WallDR = new WallDRNode();
				public WallHalfDNode WallHalfD = new WallHalfDNode();
				public WallHalfLNode WallHalfL = new WallHalfLNode();
				public WallHalfRNode WallHalfR = new WallHalfRNode();
				public WallHalfUNode WallHalfU = new WallHalfUNode();
				public WallLNode WallL = new WallLNode();
				public WallRNode WallR = new WallRNode();
				public WallUNode WallU = new WallUNode();
				public WallULNode WallUL = new WallULNode();
				public WallURNode WallUR = new WallURNode();
				public class _DTextureNode : IAssetNode
				{
					public Asset<UnityEngine.RenderTexture> renderTexture = new Asset<UnityEngine.RenderTexture>("3DTexture.renderTexture", "Resources/RougeBoy/Textures/3DTexture.renderTexture");
					public Asset[] GetAssets() { return new Asset[] { renderTexture }; }
				}
				public class Art___ShortcutNode : IAssetNode
				{
					// unsupported filetype: Art - Shortcut.lnk
					public Asset[] GetAssets() { return new Asset[] {  }; }
				}
				public class BulletNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Bullet.png", "Resources/RougeBoy/Textures/Bullet.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class CursorNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Cursor.png", "Resources/RougeBoy/Textures/Cursor.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class KingSlimeNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("KingSlime.png", "Resources/RougeBoy/Textures/KingSlime.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class MapFloorNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("MapFloor.png", "Resources/RougeBoy/Textures/MapFloor.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class MobNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Mob.png", "Resources/RougeBoy/Textures/Mob.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class NavTileNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("NavTile.png", "Resources/RougeBoy/Textures/NavTile.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class PopupBarNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("PopupBar.png", "Resources/RougeBoy/Textures/PopupBar.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class SlimeNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Slime.png", "Resources/RougeBoy/Textures/Slime.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class SplashScreenNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("SplashScreen.png", "Resources/RougeBoy/Textures/SplashScreen.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class UIBarNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("UIBar.png", "Resources/RougeBoy/Textures/UIBar.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallDNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallD.png", "Resources/RougeBoy/Textures/WallD.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallDLNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallDL.png", "Resources/RougeBoy/Textures/WallDL.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallDRNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallDR.png", "Resources/RougeBoy/Textures/WallDR.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallHalfDNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallHalfD.png", "Resources/RougeBoy/Textures/WallHalfD.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallHalfLNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallHalfL.png", "Resources/RougeBoy/Textures/WallHalfL.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallHalfRNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallHalfR.png", "Resources/RougeBoy/Textures/WallHalfR.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallHalfUNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallHalfU.png", "Resources/RougeBoy/Textures/WallHalfU.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallLNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallL.png", "Resources/RougeBoy/Textures/WallL.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallRNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallR.png", "Resources/RougeBoy/Textures/WallR.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallUNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallU.png", "Resources/RougeBoy/Textures/WallU.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallULNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallUL.png", "Resources/RougeBoy/Textures/WallUL.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class WallURNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("WallUR.png", "Resources/RougeBoy/Textures/WallUR.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public Asset[] GetAssets() { return new Asset[] { _DTexture.renderTexture, Bullet.png, Cursor.png, KingSlime.png, MapFloor.png, Mob.png, NavTile.png, PopupBar.png, Slime.png, SplashScreen.png, UIBar.png, WallD.png, WallDL.png, WallDR.png, WallHalfD.png, WallHalfL.png, WallHalfR.png, WallHalfU.png, WallL.png, WallR.png, WallU.png, WallUL.png, WallUR.png }; }
				public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { _DTexture, Art___Shortcut, Bullet, Cursor, KingSlime, MapFloor, Mob, NavTile, PopupBar, Slime, SplashScreen, UIBar, WallD, WallDL, WallDR, WallHalfD, WallHalfL, WallHalfR, WallHalfU, WallL, WallR, WallU, WallUL, WallUR }; }
				public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
			}
			public Asset[] GetAssets() { return new Asset[] { Popup.prefab, Sprite.prefab }; }
			public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { Popup, Sprite }; }
			public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { Materials, MaterialsColors, SFX, Textures }; }
		}
		public Asset[] GetAssets() { return new Asset[] {  }; }
		public IAssetNode[] GetAssetNodes() { return new IAssetNode[] {  }; }
		public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { Fonts, RougeBoy }; }
	}
	public Asset[] GetAssets() { return new Asset[] {  }; }
	public IAssetNode[] GetAssetNodes() { return new IAssetNode[] {  }; }
	public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { Resources }; }
}
