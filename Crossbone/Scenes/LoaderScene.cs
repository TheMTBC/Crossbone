using Crossbone.Abstracts;
using Crossbone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Scenes
{
    internal class LoaderScene : Scene
    {
        public override void Start()
        {
            base.Start();

            Add(new Loader());
        }
    }
}
