using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using Crossbone.Entities.Triggers;
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
            new LevelBuilder(game.resources.dungeon, game.resources.demo, new Vector2(110, 70)).Build(this);

            Add(new Player()).Get<Transform>().position += new Vector2(375, 480);

            var trigger = Add(new UseTrigger(new Vector2(492, 201), new Vector2(60, 60)));
            trigger.Action += (player) =>
            {
                if (game.Scene.Get<DialogBox>() == null)
                {
                    game.Scene.Add(new DialogBox()).Text = "Up, up, down, down, left, right, left, right";
                }
            };

            Add(new FPSMeter());
        }
    }
}
