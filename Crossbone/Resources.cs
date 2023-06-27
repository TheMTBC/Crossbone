using Crossbone.Utils;
using SFML.Audio;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private List<IDisposable> disposed = new List<IDisposable>();

        public void Dispose()
        {
            foreach (var item in disposed)
            {
                item.Dispose();
            }
        }

        public Texture player;
        public Texture frisk;
        public Texture ui;
        public Texture logo;
        public Texture button;
        public Texture black;
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
        public Music musicDungeon;
        public SoundBuffer soundSndBreak1;
        public SoundBuffer soundSndTalk1;

        public Resources()
        {
            player = Add(new Texture(Prefix("player.png")));
            frisk = Add(new Texture(Prefix("frisk.png")));
            ui = Add(new Texture(Prefix("ui.png")));
            logo = Add(new Texture(Prefix("logo.png")));
            button = Add(new Texture(Prefix("button.png")));
            uiStart = Add(new Texture(Prefix("ui/start.png")));
            uiOptions = Add(new Texture(Prefix("ui/options.png")));
            uiCredits = Add(new Texture(Prefix("ui/credits.png")));
            uiExit = Add(new Texture(Prefix("ui/exit.png")));
            uiSelect = Add(new Texture(Prefix("ui/select.png")));
            animFrisk = Add(new Animations(Prefix("frisk.json")));
            animButton = Add(new Animations(Prefix("button.json")));
            fontRoman = Add(new RasterFont(Prefix("fonts/en.png"), Prefix("fonts/en.json")));
            tilesDungeon = Add(new Tiles(Prefix("dungeon.png"), Prefix("dungeon.json")));
            roomRoom1 = Add(new Level(Prefix("levels/room1.json")));
            roomRoom1s1 = Add(new Level(Prefix("levels/room1s1.json")));
            shaderUI = Add(new Shader(null, null, Prefix("shaders/ui.glsl")));
            musicDungeon = Add(new Music(Prefix("sound/dungeon.ogg")));
            musicDungeon.Loop = true;
            musicDungeon.Volume = 50;
            soundSndBreak1 = Add(new SoundBuffer(Prefix("sound/snd_break1.wav")));
            soundSndTalk1 = Add(new SoundBuffer(Prefix("sound/snd_talk1.wav")));
        }

        public T Add<T>(T c) where T : class
        {
            if (c.GetType().IsAssignableTo(typeof(IDisposable)))
            {
                disposed.Add((IDisposable)c);
            }
            return c;
        }
    }
}
