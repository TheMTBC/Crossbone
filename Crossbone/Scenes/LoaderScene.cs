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
    internal class LoaderScene : Scene
    {
        public override void Start()
        {
            base.Start();
            Add(new Loader());
            Add(new StaticSprite(game.resources.logo)).Get<Transform>().position = new Utils.Vector2(game.width / 2 - 363 / 2, game.height / 2 - 126 / 2);
        }
    }
}
