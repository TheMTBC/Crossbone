using Crossbone.Abstracts;
using Crossbone.Utils;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Components
{
    internal class TextRenderer : EntityComponent
    {
        public string text = "";
        private RasterFont _font;
        private Sprite _sprite;
        private Transform? _transform;

        public TextRenderer(RasterFont font)
        {
            _font = font;
            _sprite = new Sprite(_font.texture);
        }

        public override void Start()
        {
            base.Start();
            _transform = entity.Get<Transform>();
        }

        public override void Dispose()
        {
            base.Dispose();
            _sprite.Dispose();
        }

        public override void Tick()
        {
            Vector2f position = new Vector2f();
            if (_transform != null)
            {
                position = _transform.position.vector;
            }
            base.Tick();
            int offset = 0;
            foreach (var ch in text)
            {
                int width = _font.GetWidth(ch);
                if (width > 0)
                {
                    _font.ApplyTextureRect(ch, _sprite);
                    _sprite.Position = position + new Vector2f(offset, 0);
                    game?.window.Draw(_sprite);
                }
                offset += width;
            }
        }
    }
}
