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
        private Transform? _player;
        private TextRenderer _position;

        public override void Start()
        {
            _renderer = Add(new TextRenderer(game.resources.font));
            _renderer.position = new Utils.Vector2(0, game.height - 40);
            _position = Add(new TextRenderer(game.resources.font));
            _position.position = new Utils.Vector2(0, game.height - 80);
            var player = game.Scene.Get<Player>();
            if (player != null)
            {
                _player = player.Get<Transform>();
            }
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
            if (_player != null)
            {
                _position.text = string.Format("{0} {1}", _player.position.X.ToString("0.0"), _player.position.Y.ToString("0.0"));
            }
        }
    }
}
