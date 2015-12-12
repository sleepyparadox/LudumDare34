/// <summary>
/// 
/// GENERAGED CODE 
/// ANY CHANGES YOU MAKE WILL PROBABLY BE LOST
/// 
/// This code file was generated at 12/12/2015 9:09:32 PM 
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
		public RougeBoyNode RougeBoy = new RougeBoyNode();
		public class RougeBoyNode : IDirectoryNode
		{
			public string Name { get { return "RougeBoy"; } }
			public string Path { get { return "Resources/RougeBoy"; } }
			public SpriteNode Sprite = new SpriteNode();
			public MaterialsNode Materials = new MaterialsNode();
			public TexturesNode Textures = new TexturesNode();
			public class SpriteNode : IAssetNode
			{
				public Asset<UnityEngine.GameObject> prefab = new Asset<UnityEngine.GameObject>("Sprite.prefab", "Resources/RougeBoy/Sprite.prefab");
				public Asset[] GetAssets() { return new Asset[] { prefab }; }
			}
			public class MaterialsNode : IDirectoryNode
			{
				public string Name { get { return "Materials"; } }
				public string Path { get { return "Resources/RougeBoy/Materials"; } }
				public CursorNode Cursor = new CursorNode();
				public MobNode Mob = new MobNode();
				public SlimeNode Slime = new SlimeNode();
				public class CursorNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Cursor.mat", "Resources/RougeBoy/Materials/Cursor.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class MobNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Mob.mat", "Resources/RougeBoy/Materials/Mob.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public class SlimeNode : IAssetNode
				{
					public Asset<UnityEngine.Material> mat = new Asset<UnityEngine.Material>("Slime.mat", "Resources/RougeBoy/Materials/Slime.mat");
					public Asset[] GetAssets() { return new Asset[] { mat }; }
				}
				public Asset[] GetAssets() { return new Asset[] { Cursor.mat, Mob.mat, Slime.mat }; }
				public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { Cursor, Mob, Slime }; }
				public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
			}
			public class TexturesNode : IDirectoryNode
			{
				public string Name { get { return "Textures"; } }
				public string Path { get { return "Resources/RougeBoy/Textures"; } }
				public Art___ShortcutNode Art___Shortcut = new Art___ShortcutNode();
				public CursorNode Cursor = new CursorNode();
				public MobNode Mob = new MobNode();
				public SlimeNode Slime = new SlimeNode();
				public class Art___ShortcutNode : IAssetNode
				{
					// unsupported filetype: Art - Shortcut.lnk
					public Asset[] GetAssets() { return new Asset[] {  }; }
				}
				public class CursorNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Cursor.png", "Resources/RougeBoy/Textures/Cursor.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class MobNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Mob.png", "Resources/RougeBoy/Textures/Mob.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public class SlimeNode : IAssetNode
				{
					public Asset<UnityEngine.Texture2D> png = new Asset<UnityEngine.Texture2D>("Slime.png", "Resources/RougeBoy/Textures/Slime.png");
					public Asset[] GetAssets() { return new Asset[] { png }; }
				}
				public Asset[] GetAssets() { return new Asset[] { Cursor.png, Mob.png, Slime.png }; }
				public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { Art___Shortcut, Cursor, Mob, Slime }; }
				public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] {  }; }
			}
			public Asset[] GetAssets() { return new Asset[] { Sprite.prefab }; }
			public IAssetNode[] GetAssetNodes() { return new IAssetNode[] { Sprite }; }
			public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { Materials, Textures }; }
		}
		public Asset[] GetAssets() { return new Asset[] {  }; }
		public IAssetNode[] GetAssetNodes() { return new IAssetNode[] {  }; }
		public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { RougeBoy }; }
	}
	public Asset[] GetAssets() { return new Asset[] {  }; }
	public IAssetNode[] GetAssetNodes() { return new IAssetNode[] {  }; }
	public IDirectoryNode[] GetDirectories() { return new IDirectoryNode[] { Resources }; }
}
