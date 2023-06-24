using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal class LevelBuilder
    {
        private Tiles _tiles;
        private Level _level;
        private Vector2 _offset;

        public LevelBuilder(Tiles tiles, Level level, Vector2 offset)
        {
            _tiles = tiles;
            _level = level;
            _offset = offset;
        }

        public void Build(Scene scene)
        {
            for (int x = 0; x < _level.width; x++)
            {
                for (int y = 0; y < _level.height; y++)
                {
                    var tile = scene.Add(new StaticTile(_tiles, _level.GetTile(x, y)));
                    var tr = tile.Get<Transform>();
                    if (tr != null)
                    {
                        tr.position = new Vector2(x * _tiles.size, y * _tiles.size) + _offset;
                    }
                }
            }
        }
    }
}
