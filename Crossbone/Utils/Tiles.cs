using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal class Tiles : IDisposable
    {
        public Texture texture;
        public int size;
        private HashSet<int> _solid = new HashSet<int>();

        public Tiles(string texture, string info)
        {
            this.texture = new Texture(texture);
            ParseInfo(info);
        }

        private void ParseInfo(string fileName)
        {
            var data = File.ReadAllText(fileName);
            var document = JsonDocument.Parse(data);
            size = document.RootElement.GetProperty("size").GetInt32();
            foreach (var n in document.RootElement.GetProperty("solid").EnumerateArray())
            {
                _solid.Add(n.GetInt32());
            }
        }

        public void Dispose()
        {
            texture.Dispose();
        }

        public void ApplyTextureRect(int tile, Sprite sprite)
        {
            var y = tile / (texture.Size.X / size);
            var x = tile % (texture.Size.X / size);
            sprite.TextureRect = new IntRect((int)(size * x), (int)(size * y), size, size);
        }

        public bool IsSolid(int tile)
        {
            return _solid.Contains(tile);
        }
    }
}
