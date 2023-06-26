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
    internal class UseTrigger : Entity
    {
        private Transform _transform;
        private BoxCollider _boxCollider;
        private Vector2 _position;
        private Vector2 _size;
        public Action<UseTrigger, Player> Action;

        public UseTrigger(Vector2 position, Vector2 size)
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

        public override void Tick()
        {
            foreach (var collider in game.Scene.GetAll<BoxCollider>())
            {
                if (collider == _boxCollider)
                {
                    continue;
                }
                if (_boxCollider.Collide(_position, collider) && collider.entity.GetType().IsAssignableTo(typeof(Player)))
                {
                    if (game.input.use)
                    {
                        Action.Invoke(this, (Player)collider.entity);
                    }
                }
            }
            base.Tick();
        }
    }
}
