using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Scenes
{
    internal class DemoScene : Scene
    {
        public override void Start()
        {
            Add(new Player());
            var a = new Text();
            a.text = "The quick brown fox jumps over the lazy dog.";
            Add(a);
            var b = new Text();
            b.text = "1234567890 3.14 3,14";
            Add(b);
            b.Get<Transform>().position += new Utils.Vector2(0, 40);
            Add(new FPSMeter());
            Add(new StaticSprite(game.resources.player)).Get<Transform>().position += new Utils.Vector2(100, 0);
        }
    }
}
