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
            var builder = new LevelBuilder(game.resources.dungeon, game.resources.room1, level);
            builder.Build(this);
            CreateButton(builder, 10, 6, "1");
            CreateButton(builder, 10, 8, "3");
            CreateButton(builder, 9, 7, "4");
            CreateButton(builder, 11, 7, "2");

            Add(new Player()).Get<Transform>().position += new Vector2(360, 426);

            var trigger = Add(new UseTrigger(new Vector2(483, 171), new Vector2(60, 60)));
            trigger.Action += (tr, player) =>
            {
                if (game.Scene.Get<DialogBox>() == null)
                {
                    game.Scene.Add(new DialogBox()).Text = "Up, up, down, down, left, right, left, right";
                }
            };

            Add(new FPSMeter());
        }

        private string code;

        private void WriteCode(string b)
        {
            code += b;
            if ("11334242".StartsWith(code))
            {
                if ("11334242" == code)
                {
                    Console.WriteLine("CORRECT");
                }
            }
            else
            {
                code = "";
                Console.WriteLine("reset");
            }
        }

        private Button CreateButton(LevelBuilder builder, int x, int y, string b)
        {
            var button = Add(new Button());
            builder.ApplyTransform(button, x, y);
            button.OnPress += (button) =>
            {
                WriteCode(b);
            };
            return button;
        }
    }
}
