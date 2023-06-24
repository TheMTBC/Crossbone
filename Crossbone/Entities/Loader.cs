using Crossbone.Abstracts;
using Crossbone.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Loader : Entity
    {
        private float _time = 0;

        public override void Start()
        {
            base.Start();
            if (game != null)
            {
                game.resources = new Resources();
            }
        }

        public override void Tick()
        {
            if (_time > 3) {
                game.Scene = new MainScene();
                return;
            }
            _time += game.deltaTime;
            base.Tick();
        }
    }
}
