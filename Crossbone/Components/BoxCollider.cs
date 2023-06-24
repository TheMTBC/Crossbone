using Crossbone.Abstracts;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Components
{
    internal class BoxCollider : EntityComponent
    {
        private Vector2 _size;
        private Transform? _transform;
        private Vector2 _offset;
        private int _layer;

        public static readonly int SOLID_LAYER = 0b1;
        public static readonly int TRIGGER_LAYER = 0b10;

        public BoxCollider(Vector2 size, Vector2 offset, int layer)
        {
            _size = size;
            _offset = offset;
            _layer = layer;
        }

        public BoxCollider(Vector2 size)
        {
            _size = size;
            _offset = new Vector2(0, 0);
            _layer = SOLID_LAYER;
        }

        public override void Start()
        {
            base.Start();
            _transform = entity.Get<Transform>();
        }

        private bool CollideByX(Vector2 position, BoxCollider collider)
        {
            if (collider._transform == null)
            {
                return false;
            }
            return (position.X + _size.X + _offset.X > collider._transform.position.X) &&
                (position.X + _offset.X < collider._transform.position.X + collider._size.X);
        }

        private bool CollideByY(Vector2 position, BoxCollider collider)
        {
            if (collider._transform == null)
            {
                return false;
            }
            return (position.Y + _size.Y + _offset.Y > collider._transform.position.Y) &&
                (position.Y + _offset.Y < collider._transform.position.Y + collider._size.Y);
        }

        public bool Collide(Vector2 position, BoxCollider collider, int layer = -1)
        {
            if (layer == -1)
            {
                layer = _layer;
            }
            if ((layer & collider._layer) > 0)
            {
                return CollideByX(position, collider) && CollideByY(position, collider);
            }
            return false;
        }
    }
}
