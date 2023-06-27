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
        public Vector2 position = new Vector2();

        public TextRenderer(RasterFont font)
        {
            _font = font;
            _sprite = new Sprite(_font.texture);
        }

        public override void Dispose()
        {
            base.Dispose();
            _sprite.Dispose();
        }

        public override void Tick()
        {
            base.Tick();
            int offset = 0;
            int line = 0;
            foreach (var ch in text)
            {
                if (ch == '\n')
                {
                    line += 1;
                    offset = 0;
                    continue;
                }
                int width = _font.GetWidth(ch);
                if (width > 0)
                {
                    _font.ApplyTextureRect(ch, _sprite);
                    _sprite.Position = (position + new Vector2(offset, line * _font.height)).vector;
                    game.window.Draw(_sprite);
                }
                offset += width;
            }
        }
    }
}
