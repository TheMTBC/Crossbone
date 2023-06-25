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
            frisk.Dispose();
            font.Dispose();
        }

        public Texture player;
        public Texture frisk;
        public Texture ui;
        public Texture logo;
        public Animations friskAnimations;
        public RasterFont font;
        public Tiles dungeon;
        public Level room1;
        public Shader uiShader;

        public Resources()
        {
            player = new Texture(Prefix("player.png"));
            frisk = new Texture(Prefix("frisk.png"));
            ui = new Texture(Prefix("ui.png"));
            logo = new Texture(Prefix("logo.png"));
            friskAnimations = new Animations(Prefix("frisk.json"));
            font = new RasterFont(Prefix("fonts/en.png"), Prefix("fonts/en.json"));
            dungeon = new Tiles(Prefix("dungeon.png"), Prefix("dungeon.json"));
            room1 = new Level(Prefix("levels/room1.json"));
            uiShader = new Shader(null, null, Prefix("shaders/ui.glsl"));
        }
    }
}
