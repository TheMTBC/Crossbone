using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using Crossbone.Utils;
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
            new LevelBuilder(game.resources.dungeon, game.resources.demo).Build(this);

            Add(new Player()).Get<Transform>().position += new Vector2(300, 300);

            Add(new FPSMeter());
        }
    }
}
