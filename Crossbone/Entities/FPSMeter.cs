using Crossbone.Abstracts;
using Crossbone.Components;
using SFML.Graphics;
using SFML.System;
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
        private Components.Transform? _player;
        private TextRenderer _position;
        private Sprite _collider;

        public override void Start()
        {
            _renderer = Add(new TextRenderer(game.resources.font));
            _renderer.position = new Utils.Vector2(0, game.height - 40);
            _position = Add(new TextRenderer(game.resources.font));
            _position.position = new Utils.Vector2(0, game.height - 80);
            var player = game.Scene.Get<Player>();
            if (player != null)
            {
                _player = player.Get<Components.Transform>();
            }
            _collider = new Sprite(game.resources.collider);
        }

        public override void Dispose()
        {
            base.Dispose();
            _collider.Dispose();
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
            foreach (var collider in game.Scene.GetAll<BoxCollider>())
            {
                Draw(collider);
            }
        }

        private void Draw(BoxCollider boxCollider)
        {
            _collider.Position = (boxCollider.entity.Get<Components.Transform>().ToWorld() + boxCollider.offset).vector;
            _collider.Scale = new Vector2f(boxCollider.size.X / _collider.TextureRect.Width, boxCollider.size.Y / _collider.TextureRect.Height);
            var _shader = game.resources.uiShader;
            _shader.SetUniform("texture", Shader.CurrentTexture);
            _shader.SetUniform("scale", _collider.Scale);
            _shader.SetUniform("color", boxCollider.layer == BoxCollider.SOLID_LAYER ? new Color(255, 0, 0, 255) : new Color(0, 255, 0, 255));
            game.window.Draw(_collider, new RenderStates(_shader));
        }
    }
}
