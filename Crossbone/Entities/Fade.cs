using Crossbone.Abstracts;
using Crossbone.Components;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Fade : Entity
    {
        private Renderer _renderer;
        private bool _enter;

        public Fade(bool enter)
        {
            _enter = enter;
        }

        public override void Start()
        {
            base.Start();
            _renderer = Add(new Renderer(game.resources.black, game.resources.shaderUI));
            _renderer.Size = new Utils.Vector2(game.width, game.height);
            if (!_enter)
            {
                _renderer.color.A = 0;
            }
        }

        public override void Tick()
        {
            base.Tick();
            if (_enter)
            {
                _renderer.color.A = (byte)Math.Clamp((_renderer.color.A - (255 * game.deltaTime * 3)), 0, 255);
            }
            else
            {
                _renderer.color.A = (byte)Math.Clamp((_renderer.color.A + (255 * game.deltaTime * 3)), 0, 255);
            }
        }
    }
}
