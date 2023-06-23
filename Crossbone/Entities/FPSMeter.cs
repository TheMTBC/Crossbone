using Crossbone.Abstracts;
using Crossbone.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class FPSMeter : Entity
    {
        private TextRenderer _renderer;
        private float _time;
        private float _count;

        public override void Start()
        {
            _renderer = new TextRenderer(game.resources.font);
            _renderer.position = new Utils.Vector2(0, game.height - 40);
            Add(_renderer);
        }

        public override void Tick()
        {
            base.Tick();
            _time += game.deltaTime;
            _count += 1;
            if (_time > 0.3f )
            {
                _renderer.text = "FPS " + Math.Round((_count / _time));
                _time = 0;
                _count = 0;
            }
        }
    }
}
