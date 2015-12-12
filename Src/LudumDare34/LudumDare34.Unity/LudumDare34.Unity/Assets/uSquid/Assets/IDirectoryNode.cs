namespace uSquid.Assets
{
    public interface IDirectoryNode
    {
        string Name { get; }
        string Path { get; }
        Asset[] GetAssets();
        IAssetNode[] GetAssetNodes();
        IDirectoryNode[] GetDirectories();
    }
}
