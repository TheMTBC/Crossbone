using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class DialogBox : Entity
    {
        private Renderer _renderer;
        private TextRenderer _textRenderer;
        private string _text = "";
        private float _time = 0;
        private int _index = 0;
        public string Text
        {
            get { return _text; }
            set
            {
                _index = 0;
                _text = value;
            }
        }


        public override void Start()
        {
            base.Start();
            _renderer = Add(new Renderer(game.resources.ui, game.resources.uiShader));
            _textRenderer = Add(new TextRenderer(game.resources.font));
        }

        public override void Tick()
        {
            _renderer.position = new Vector2(30, game.height - 200);
            _renderer.Size = new Vector2(game.width - 60, 170);
            _textRenderer.position = new Vector2(40, game.height - 190);
            if (_time > 0.09f)
            {
                _time = 0;
                if (_index <= _text.Length)
                {
                    _textRenderer.text = _text.Substring(0, _index);
                    _index++;
                }
            }
            _time += game.deltaTime;

            if (game.input.use)
            {
                if (_index <= _text.Length)
                {
                    _index = _text.Length;
                }
                else
                {
                    game.Scene.Remove(this);
                    return;
                }
            }
            base.Tick();
        }
    }
}
