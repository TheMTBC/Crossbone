using Crossbone.Abstracts;
using Crossbone.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Test : Entity
    {
        private Transform _transform;
        private Renderer _renderer;

        public override void Start()
        {
            base.Start();
            _transform = new Transform();
            _transform.position = new Utils.Vector2(70, 70);
            Add(_transform);
            _renderer = new Renderer(game.resources.player);
            Add(_renderer);
            Add(new BoxCollider(new Utils.Vector2(16, 16)));
        }
    }
}
