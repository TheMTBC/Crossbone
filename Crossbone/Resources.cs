using Crossbone.Utils;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone
{
    internal class Resources : IDisposable
    {
        public static string Prefix(string value)
        {
            return "resources/" + value;
        }

        public void Dispose()
        {
            player.Dispose();
            font.Dispose();
        }

        public Texture player;
        public RasterFont font;

        public Resources()
        {
            player = new Texture(Prefix("player.png"));
            font = new RasterFont(Prefix("fonts/en.png"), Prefix("fonts/en.json"));
        }
    }
}
