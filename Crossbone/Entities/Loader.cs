using Crossbone.Abstracts;
using Crossbone.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Loader : Entity
    {
        public override void Start()
        {
            base.Start();
            if (game != null)
            {
                game.resources = new Resources();
            }
        }
    }
}
