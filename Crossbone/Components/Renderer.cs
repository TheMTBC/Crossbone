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
    internal class Renderer : EntityComponent
    {
        public Sprite sprite;
        public Vector2 position = new Vector2();
        private Shader? _shader = null;
        public Color color = new Color(255, 255, 255, 255);

        public Renderer(Texture texture)
        {
            sprite = new Sprite(texture);
        }

        public Renderer(Texture texture, Shader shader)
        {
            sprite = new Sprite(texture);
            _shader = shader;
        }

        public override void Dispose()
        {
            base.Dispose();
            sprite.Dispose();
        }

        public override void Tick()
        {
            base.Tick();
            sprite.Position = position.vector;
            if (_shader != null)
            {
                _shader.SetUniform("texture", Shader.CurrentTexture);
                _shader.SetUniform("scale", sprite.Scale);
                _shader.SetUniform("color", color);
                game.window.Draw(sprite, new RenderStates(_shader));
            }
            else
            {
                game.window.Draw(sprite);
            }
        }

        public Vector2 Size
        {
            get
            {
                return new Vector2(sprite.Scale.X * sprite.TextureRect.Width, sprite.TextureRect.Height * sprite.Scale.Y);
            }
            set
            {
                sprite.Scale = new Vector2f(value.X / sprite.TextureRect.Width, value.Y / sprite.TextureRect.Height);
            }
        }
    }
}
