using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSquid.Assets
{
    public class Asset
    {
        public Type Type { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }

        public Asset(Type type, string name, string path)
        {
            Type = type;
            Name = name;
            Path = path;
        }
    }

    public class Asset<T> : Asset where T : UnityEngine.Object
    {
        public Asset(string name, string path)
            : base(typeof(T), name, path)
        {

        }

        public T Clone()
        {
            return UnityEngine.Object.Instantiate<T>(Load());
        }

        public T Load()
        {
            return AssetManager.Load<T>(Path);
        }

        public void Unload()
        {
            AssetManager.Unload(Path);
        }
    }
}
