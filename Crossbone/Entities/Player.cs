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
    internal class Player : Entity
    {
        private Transform _transform;
        private Renderer _renderer;
        private BoxCollider _boxCollider;

        public override void Start()
        {
            base.Start();
            _transform = new Transform();
            Add(_transform);
            _renderer = new Renderer(game.resources.player);
            Add(_renderer);
            _boxCollider = new BoxCollider(new Vector2(16, 16));
            Add(_boxCollider);
        }

        public override void Tick()
        {
            base.Tick();
            var offset = (game.input.x * new Vector2(1, 0) + game.input.y * new Vector2(0, -1)).Normilized * 150 * game.deltaTime;
            foreach (var boxCollider in game.Scene.GetAll<BoxCollider>())
            {
                if (boxCollider == _boxCollider)
                {
                    continue;
                }
                if (!_boxCollider.Collide(_transform.position + offset.X * new Vector2(1, 0), boxCollider))
                {
                    _transform.position += offset.X * new Vector2(1, 0);
                }
                if (!_boxCollider.Collide(_transform.position + offset.Y * new Vector2(0, 1), boxCollider))
                {
                    _transform.position += offset.Y * new Vector2(0, 1);
                }
            }
        }
    }
}
