using Crossbone.Abstracts;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Components
{
    internal class Renderer : EntityComponent
    {
        public Sprite sprite;
        private Transform? _transform;

        public Renderer(Texture texture)
        {
            sprite = new Sprite(texture);
        }

        public override void Start()
        {
            base.Start();
            _transform = entity.Get<Transform>();
        }

        public override void Dispose()
        {
            base.Dispose();
            sprite.Dispose();
        }

        public override void Tick()
        {
            base.Tick();
            game.window.Draw(sprite);
            if (_transform != null)
            {
                sprite.Position = _transform.position.vector - game.Scene.camera.position.vector;
            }
        }
    }
}
