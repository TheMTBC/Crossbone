using Crossbone.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities.UI
{
    internal class Distributor : Entity
    {
        private List<UIEntity> _entities = new List<UIEntity>();
        private int _element = 0;

        public override void Start()
        {
            base.Start();
            game.input.OnPress += Press;
        }

        public T AddUI<T>(T entity) where T : UIEntity
        {
            _entities.Add(entity);
            return entity;
        }

        public override void Tick()
        {
            if (_element < 0)
            {
                _element = 0;
                return;
            }
            if (_element >= _entities.Count)
            {
                _element = _entities.Count - 1;
            }
            base.Tick();
        }

        public UIEntity? Element
        {
            get
            {
                if (_element >= _entities.Count || _element < 0)
                {
                    return null;
                }
                return _entities[_element];
            }
        }

        private void Press(SFML.Window.KeyEventArgs e)
        {
            if (e.Code == SFML.Window.Keyboard.Key.Up)
            {
                _element -= 1;
                return;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Down)
            {
                _element += 1;
                return;
            }
            Element?.Press(e);
        }

        public override void Dispose()
        {
            game.input.OnPress -= Press;
            base.Dispose();
        }
    }
}
