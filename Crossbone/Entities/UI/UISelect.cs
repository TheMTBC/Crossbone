using Crossbone.Abstracts;
using Crossbone.Components;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities.UI
{
    internal class UISelect : Entity
    {
        private Renderer _renderer;
        private Distributor _distributor;

        public UISelect(Distributor distributor)
        {
            _distributor = distributor;
        }

        public override void Start()
        {
            base.Start();
            _renderer = Add(new Renderer(game.resources.uiSelect));
        }

        public override void Tick()
        {
            var element = _distributor.Element;
            if (element != null)
            {
                if (element.GetType().IsAssignableTo(typeof(UIButton)))
                {
                    var btn = (UIButton)element;
                    _renderer.position = btn.position - new Utils.Vector2(40, 0);
                }
            }
            base.Tick();
        }
    }
}
