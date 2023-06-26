using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Utils;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Player : Entity
    {
        private Transform _transform;
        private Renderer _renderer;
        private BoxCollider _boxCollider;
        private Animator _animator;

        public override void Start()
        {
            base.Start();
            _transform = Add(new Transform());
            _renderer = Add(new Renderer(game.resources.frisk));
            _boxCollider = Add(new BoxCollider(
                new Vector2(game.resources.animFrisk.width * 0.7f, game.resources.animFrisk.height / 2 * 0.7f),
                new Vector2(0, game.resources.animFrisk.height / 2 * 1.3f),
                BoxCollider.SOLID_LAYER | BoxCollider.TRIGGER_LAYER
            ));
            _animator = Add(new Animator(game.resources.animFrisk, "down"));
        }

        private int IsCollide(Vector2 offset)
        {
            var colliders = game.Scene.GetAll<BoxCollider>();
            if (colliders.Count == 1)
            {
                return 0;
            }
            foreach (var boxCollider in colliders)
            {
                if (boxCollider == _boxCollider)
                {
                    continue;
                }
                int collided = 0;
                if (_boxCollider.Collide(_transform.position + offset.X * new Vector2(1, 0), boxCollider, BoxCollider.SOLID_LAYER))
                {
                    collided += 1;
                }
                if (_boxCollider.Collide(_transform.position + offset.Y * new Vector2(0, 1), boxCollider, BoxCollider.SOLID_LAYER))
                {
                    collided += 2;
                }
                if (collided > 0)
                {
                    return collided;
                }
            }
            return 0;
        }

        public override void Tick()
        {

            var offset = (game.input.x * new Vector2(1, 0) + game.input.y * new Vector2(0, -1)) * 150 * game.deltaTime;
            if (IsCollide(offset) == 0)
            {
                _transform.position += offset;
            }

            SetAnimation(offset);
            
            _renderer.position = _transform.ToWorld();

            base.Tick();
        }

        private void SetAnimation(Vector2 offset)
        {
            _animator.speed = offset.Magnitude < 0.1f ? float.PositiveInfinity : 0.15f;
            _animator.frame = offset.Magnitude < 0.1f ? 0 : _animator.frame;
            if (game.input.y < 0 && game.input.x == 0)
            {
                _animator.Animation = "down";
            }
            else if (game.input.y > 0 && game.input.x == 0)
            {
                _animator.Animation = "up";
            }
            else if (game.input.x > 0)
            {
                _animator.Animation = "right";
            }
            else if (game.input.x < 0)
            {
                _animator.Animation = "left";
            }
        }
    }
}
