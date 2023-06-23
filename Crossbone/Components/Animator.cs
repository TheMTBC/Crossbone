using Crossbone.Abstracts;
using Crossbone.Utils;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Components
{
    internal class Animator : EntityComponent
    {
        private Animations _animations;
        private Renderer? _renderer;
        public float speed = 1;
        private string _animation = "";
        public int frame = 0;
        private float _time = 0;
        public string Animation
        {
            get { return _animation; }
            set
            {
                if (_animation != value)
                {
                    frame = 0;
                    _time = 0;
                    _animation = value;
                }
            }
        }

        public Animator(Animations animations, string animation)
        {
            _animations = animations;
            this._animation = animation;
        }

        public override void Start()
        {
            base.Start();
            _renderer = entity.Get<Renderer>();
        }

        public override void Tick()
        {
            base.Tick();
            if (_renderer == null)
            {
                return;
            }
            var index = _animations.Index(_animation);
            if (index < 0)
            {
                return;
            }
            _renderer.sprite.TextureRect = new IntRect(frame * _animations.width, _animations.height * index, _animations.width, _animations.height);
            _time += game.deltaTime;
            if (_time > speed)
            {
                _time = 0;
                frame = (frame + 1) % _animations.Frame(_animation);
            }
        }
    }
}
