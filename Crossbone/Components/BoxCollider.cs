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

        public BoxCollider(Vector2 size)
        {
            _size = size;
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
            return (position.X + _size.X > collider._transform.position.X) &&
                (position.X < collider._transform.position.X + collider._size.X);
        }

        private bool CollideByY(Vector2 position, BoxCollider collider)
        {
            if (collider._transform == null)
            {
                return false;
            }
            return (position.Y + _size.Y > collider._transform.position.Y) &&
                (position.Y < collider._transform.position.Y + collider._size.Y);
        }

        public bool Collide(Vector2 position, BoxCollider collider)
        {
            return CollideByX(position, collider) && CollideByY(position, collider);
        }
    }
}
