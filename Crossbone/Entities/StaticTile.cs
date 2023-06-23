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
    internal class StaticTile : Entity
    {
        private Transform _transform;
        private Renderer _renderer;
        private BoxCollider _boxCollider;
        private Tiles _tiles;
        private int _tile;
        
        public StaticTile(Tiles tiles, int tile)
        {
            _tiles = tiles;
            _tile = tile;
        }

        public override void Start()
        {
            base.Start();
            _transform = Add(new Transform());
            _renderer = Add(new Renderer(_tiles.texture));
            _tiles.ApplyTextureRect(_tile, _renderer.sprite);
            if (_tiles.IsSolid(_tile))
            {
                _boxCollider = Add(new BoxCollider(new Vector2(_tiles.size, _tiles.size)));
            }
        }

        public override void Tick()
        {
            base.Tick();
            _renderer.position = _transform.ToWorld();
        }
    }
}
