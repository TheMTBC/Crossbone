using Crossbone.Components;
using Crossbone.Utils;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities.UI
{
    internal class UIButton : UIEntity
    {
        private Renderer _renderer;
        private Texture _texture;
        public Vector2 position;
        private Action<UIButton> _onPress;

        public UIButton(Texture texture, Vector2 position, Action<UIButton> press)
        {
            _texture = texture;
            this.position = position;
            _onPress = press;
        }

        public override void Start()
        {
            base.Start();
            _renderer = Add(new Renderer(_texture));
            _renderer.position = position;
        }

        public override void Press(KeyEventArgs e)
        {
            base.Press(e);
            if (e.Code == Keyboard.Key.Enter)
            {
                _onPress.Invoke(this);
            }
        }
    }
}
