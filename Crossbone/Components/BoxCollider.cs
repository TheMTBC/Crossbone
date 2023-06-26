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
        public Vector2 size;
        private Transform? _transform;
        public Vector2 offset;
        public int layer;

        public static readonly int SOLID_LAYER = 0b1;
        public static readonly int TRIGGER_LAYER = 0b10;

        public BoxCollider(Vector2 size, Vector2 offset, int layer)
        {
            this.size = size;
            this.offset = offset;
            this.layer = layer;
        }

        public BoxCollider(Vector2 size)
        {
            this.size = size;
            offset = new Vector2(0, 0);
            layer = SOLID_LAYER;
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
            return (position.X + size.X + offset.X > collider._transform.position.X + collider.offset.X) &&
                (position.X + offset.X < collider._transform.position.X + collider.size.X + collider.offset.X);
        }

        private bool CollideByY(Vector2 position, BoxCollider collider)
        {
            if (collider._transform == null)
            {
                return false;
            }
            return (position.Y + size.Y + offset.Y > collider._transform.position.Y + collider.offset.Y) &&
                (position.Y + offset.Y < collider._transform.position.Y + collider.size.Y + collider.offset.Y);
        }

        public bool Collide(Vector2 position, BoxCollider collider, int layer = -1)
        {
            if (layer == -1)
            {
                layer = this.layer;
            }
            if ((layer & collider.layer) > 0)
            {
                return CollideByX(position, collider) && CollideByY(position, collider);
            }
            return false;
        }
    }
}
