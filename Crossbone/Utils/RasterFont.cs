using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal class RasterFont : IDisposable
    {
        public Texture texture;
        private int _height;
        private Dictionary<char, int> _indexes = new Dictionary<char, int>();
        private Dictionary<char, int> _widthes = new Dictionary<char, int>();

        public RasterFont(string texture, string info)
        {
            this.texture = new Texture(texture);
            ParseInfo(info);
        }

        private void ParseInfo(string fileName)
        {
            var data = File.ReadAllText(fileName);
            var document = JsonDocument.Parse(data);
            _height = document.RootElement.GetProperty("height").GetInt32();
            foreach (var gliph in document.RootElement.GetProperty("gliphs").EnumerateObject())
            {
                _indexes.Add(gliph.Name[0], _indexes.Count);
                _widthes.Add(gliph.Name[0], gliph.Value.GetInt32());
            }
        }

        private int GetIndex(char ch)
        {
            return _indexes.ContainsKey(ch) ? _indexes[ch] : -1;
        }

        public int GetWidth(char ch)
        {
            return _widthes.ContainsKey(ch) ? _widthes[ch] : 0;
        }

        public void ApplyTextureRect(char ch, Sprite sprite)
        {
            int i = GetIndex(ch);
            if (i == -1)
            {
                return;
            }
            sprite.TextureRect = new IntRect(0, _height * i, GetWidth(ch), _height);
        }

        public void Dispose()
        {
            texture.Dispose();
        }
    }
}
