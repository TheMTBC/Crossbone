﻿using Crossbone.Abstracts;
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
            _boxCollider = Add(new BoxCollider(new Vector2(game.resources.friskAnimations.width, game.resources.friskAnimations.height / 2), new Vector2(0, game.resources.friskAnimations.height / 2)));
            _animator = Add(new Animator(game.resources.friskAnimations, "down"));
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
                if (_boxCollider.Collide(_transform.position + offset.X * new Vector2(1, 0), boxCollider))
                {
                    collided += 1;
                }
                if (_boxCollider.Collide(_transform.position + offset.Y * new Vector2(0, 1), boxCollider))
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
            base.Tick();
            var offset = (game.input.x * new Vector2(1, 0) + game.input.y * new Vector2(0, -1)) * 150 * game.deltaTime;
            var collided = IsCollide(offset);
            if (collided > 0)
            {
                /*
                if (collided == 2)
                {
                    _transform.position += offset.X * new Vector2(1, 0);
                }
                else if (collided == 1)
                {
                    _transform.position += offset.Y * new Vector2(0, 1);

                }
                */
            }
            else
            {
                _transform.position += offset;
            }


            game.Scene.camera.position = Vector2.Clamp(_transform.position - new Vector2(400, 0), new Vector2(0, 0), new Vector2(300, 0));
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
            _renderer.position = _transform.ToWorld();
        }
    }
}
