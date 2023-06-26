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
            fontRoman.Dispose();
            ui.Dispose();
            logo.Dispose();
            button.Dispose();
            uiStart.Dispose();
            uiOptions.Dispose();
            uiCredits.Dispose();
            uiExit.Dispose();
            uiSelect.Dispose();
            shaderUI.Dispose();
        }

        public Texture player;
        public Texture frisk;
        public Texture ui;
        public Texture logo;
        public Texture button;
        public Texture uiStart;
        public Texture uiOptions;
        public Texture uiCredits;
        public Texture uiExit;
        public Texture uiSelect;
        public Animations animFrisk;
        public Animations animButton;
        public RasterFont fontRoman;
        public Tiles tilesDungeon;
        public Level roomRoom1;
        public Level roomRoom1s1;
        public Shader shaderUI;

        public Resources()
        {
            player = new Texture(Prefix("player.png"));
            frisk = new Texture(Prefix("frisk.png"));
            ui = new Texture(Prefix("ui.png"));
            logo = new Texture(Prefix("logo.png"));
            button = new Texture(Prefix("button.png"));
            uiStart = new Texture(Prefix("ui/start.png"));
            uiOptions = new Texture(Prefix("ui/options.png"));
            uiCredits = new Texture(Prefix("ui/credits.png"));
            uiExit = new Texture(Prefix("ui/exit.png"));
            uiSelect = new Texture(Prefix("ui/select.png"));
            animFrisk = new Animations(Prefix("frisk.json"));
            animButton = new Animations(Prefix("button.json"));
            fontRoman = new RasterFont(Prefix("fonts/en.png"), Prefix("fonts/en.json"));
            tilesDungeon = new Tiles(Prefix("dungeon.png"), Prefix("dungeon.json"));
            roomRoom1 = new Level(Prefix("levels/room1.json"));
            roomRoom1s1 = new Level(Prefix("levels/room1s1.json"));
            shaderUI = new Shader(null, null, Prefix("shaders/ui.glsl"));
        }
    }
}
