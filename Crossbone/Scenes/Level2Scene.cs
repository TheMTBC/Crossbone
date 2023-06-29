using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using Crossbone.Entities.Triggers;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Scenes
{
    internal class Level2Scene : Scene
    {
        private Transform _player;

        public override void Start()
        {
            
            _player = Add(new Player()).Get<Transform>();
            _player.position += new Vector2(360, 426);

            Add(new Fade(true));

            Add(new FPSMeter());
        }
    }
}
