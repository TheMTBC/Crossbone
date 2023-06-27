using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using Crossbone.Entities.Triggers;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Scenes
{
    internal class MainScene : Scene
    {
        private Transform _player;

        public override void Start()
        {
            CreateRoom1();
            CreateRoom1s1();
            

            _player = Add(new Player()).Get<Transform>();
            _player.position += new Vector2(360, 426);


            Add(new FPSMeter());
        }

        private void CreateRoom1()
        {
            var level = new Vector2(
                game.width / 2 - game.resources.tilesDungeon.size * game.resources.roomRoom1.width / 2,
                game.height / 2 - game.resources.tilesDungeon.size * game.resources.roomRoom1.height / 2
            );
            var builder = new LevelBuilder(game.resources.tilesDungeon, game.resources.roomRoom1, level);
            builder.Build(this);
            CreateButton(builder, 10, 6, "1");
            CreateButton(builder, 10, 8, "3");
            CreateButton(builder, 9, 7, "4");
            CreateButton(builder, 11, 7, "2");
            var trigger = Add(new UseTrigger(new Vector2(483, 171), new Vector2(60, 60)));
            trigger.OnUse += (tr, player) =>
            {
                if (game.Scene.Get<DialogBox>() == null)
                {
                    game.Scene.Add(new DialogBox()).Text = "Up, up, down, down, left, right, left, right";
                }
            };
        }

        private void CreateRoom1s1()
        {
            var level = new Vector2(
                game.width / 2 - game.resources.tilesDungeon.size * game.resources.roomRoom1s1.width / 2,
                game.height / 2 - game.resources.tilesDungeon.size * game.resources.roomRoom1s1.height / 2
            ) + new Vector2(game.width, 0);
            var builder = new LevelBuilder(game.resources.tilesDungeon, game.resources.roomRoom1s1, level);
            builder.Build(this);

            CreateButton(builder, 10, 6, "");
            CreateButton(builder, 10, 8, "");
            CreateButton(builder, 9, 7, "");
            CreateButton(builder, 11, 7, "");

            var trigger = Add(new UseTrigger(new Vector2(483, 171) + new Vector2(game.width, 0), new Vector2(60, 60)));
            trigger.OnUse += (tr, player) =>
            {
                if (game.Scene.Get<DialogBox>() == null)
                {
                    var a = game.Scene.Add(new DialogBox());
                    a.Text = "YA voobshche delayu, chto hochu (A)\nHochu implanty — zvonyu vrachu (Allyo)\nKto menya ne lyubit — ya vas ne slyshu (CHyo?)\nVy prosto mne zaviduete, ya molchu";
                    a.OnNext += (e) =>
                    {
                        var d = "YA ne molchu, kogda ya hochu\nYA ne prodayus', no za den'gi — da (Da)\nMoj prodyuser govorit: «Ty — pop-zvezda»\nI kstati, moj prodyuser — eto moj muzh, da";
                        if (a.Text == d)
                        {
                            return null;
                        }
                        return d;
                    };
                }
            };
        }

        private string _code;

        private void WriteCode(string b)
        {
            _code += b;
            if ("11334242".StartsWith(_code))
            {
                if ("11334242" == _code)
                {
                    camera.position += new Vector2(game.width, 0);
                    _player.position += new Vector2(game.width, 0);
                    _code = "";
                }
            }
            else
            {
                _code = "";
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
