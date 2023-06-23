using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal class Level
    {
        public int width;
        public int height;
        public int[] tiles;

        public Level(string fileName)
        {
            ParseInfo(fileName);
        }

        private void ParseInfo(string fileName)
        {
            var data = File.ReadAllText(fileName);
            var document = JsonDocument.Parse(data);
            width = document.RootElement.GetProperty("width").GetInt32();
            height = document.RootElement.GetProperty("height").GetInt32();
            var offset = document.RootElement.GetProperty("offset").GetInt32();
            tiles = new int[width * height];
            int i = 0;
            foreach (var tile in document.RootElement.GetProperty("data").EnumerateArray())
            {
                tiles[i] = tile.GetInt32() + offset;
                i++;
            }
        }

        public int GetTile(int x, int y)
        {
            return tiles[y * width + x];
        }
    }
}
