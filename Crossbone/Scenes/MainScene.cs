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
    internal class MainScene : Scene
    {
        public override void Start()
        {
            var level = new Vector2(
                game.width / 2 - game.resources.dungeon.size * game.resources.room1.width / 2,
                game.height / 2 - game.resources.dungeon.size * game.resources.room1.height / 2
            );
            new LevelBuilder(game.resources.dungeon, game.resources.room1, level).Build(this);

            Add(new Player()).Get<Transform>().position += new Vector2(360, 456);

            var trigger = Add(new UseTrigger(new Vector2(483, 171), new Vector2(60, 60)));
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
