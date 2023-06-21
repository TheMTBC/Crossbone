using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Utils;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Text : Entity
    {
        private TextRenderer _textRenderer;
        private Transform _transform;
        public string text = "";

        public override void Start()
        {
            _transform = new Transform();
            Add(_transform);
            _textRenderer = new TextRenderer(game.resources.font);
            Add(_textRenderer);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void Tick()
        {
            base.Tick();
            _textRenderer.text = text;
        }
    }
}
