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

        public Renderer(Texture texture)
        {
            sprite = new Sprite(texture);
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
            game.window.Draw(sprite);
        }
    }
}
