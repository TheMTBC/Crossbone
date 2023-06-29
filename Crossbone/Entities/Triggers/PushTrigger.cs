using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities.Triggers
{
    internal class PushTrigger : Entity
    {
        private Transform _transform;
        private BoxCollider _boxCollider;
        private Vector2 _position;
        private Vector2 _size;
        public Action<PushTrigger> OnPush;
        private bool _state = false;

        public PushTrigger(Vector2 position, Vector2 size)
        {
            _position = position;
            _size = size;
        }

        public override void Start()
        {
            base.Start();
            _transform = Add(new Transform());
            _transform.position = _position;
            _boxCollider = Add(new BoxCollider(_size, new Vector2(), BoxCollider.TRIGGER_LAYER));
        }

        private bool IsCollided()
        {
            foreach (var collider in game.Scene.GetAll<BoxCollider>())
            {
                if (collider == _boxCollider)
                {
                    continue;
                }
                if (_boxCollider.Collide(_position, collider) && collider.entity.GetType().IsAssignableTo(typeof(Player)))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Tick()
        {
            base.Tick();
            var state = IsCollided();
            if (state != _state)
            {
                if (state)
                {
                    OnPush?.Invoke(this);
                }
                _state = state;
            }
        }
    }
}
