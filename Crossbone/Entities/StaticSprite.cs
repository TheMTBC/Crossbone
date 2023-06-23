using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Utils;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class StaticSprite : Entity
    {
        private Components.Transform _transform;
        private Renderer _renderer;
        private BoxCollider _boxCollider;
        private Animator _animator;
        private Texture _texture;
        
        public StaticSprite(Texture texture)
        {
            _texture = texture;
        }

        public override void Start()
        {
            base.Start();
            _transform = Add(new Components.Transform());
            _renderer = Add(new Renderer(_texture));
            _boxCollider = Add(new BoxCollider(new Vector2(16, 16)));
        }

        public override void Tick()
        {
            base.Tick();
            _renderer.position = _transform.ToWorld();
        }
    }
}
