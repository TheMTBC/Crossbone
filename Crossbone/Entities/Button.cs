using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Button : Entity
    {
        private Transform _transform;
        private Renderer _renderer;
        private BoxCollider _boxCollider;
        private Animator _animator;
        public Action<Button>? OnPress;
        public Action<Button>? OnUnPress;
        private bool _state = false;
        private SoundPlayer _soundPlayer;

        public override void Start()
        {
            base.Start();
            _transform = Add(new Transform());
            _renderer = Add(new Renderer(game.resources.button));
            _boxCollider = Add(new BoxCollider(new Vector2(game.resources.animButton.width, game.resources.animButton.height), new Vector2(), BoxCollider.TRIGGER_LAYER));
            _animator = Add(new Animator(game.resources.animButton, "idle"));
            _soundPlayer = Add(new SoundPlayer(game.resources.soundSndBreak1));
        }

        private bool IsCollide()
        {
            foreach (var collider in game.Scene.GetAll<BoxCollider>())
            {
                if (collider == _boxCollider)
                {
                    continue;
                }
                if (_boxCollider.Collide(_transform.position, collider) && collider.entity.GetType().IsAssignableTo(typeof(Player)))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Tick()
        {
            _renderer.position = _transform.ToWorld();
            var c = IsCollide();
            _animator.Animation = c ? "press" : "idle";
            if (c != _state)
            {
                if (c == true)
                {
                    OnPress?.Invoke(this);
                    _soundPlayer.Play(30);
                }
                else
                {
                    OnUnPress?.Invoke(this);
                }
                _state = c;
            }
            base.Tick();
        }
    }
}
