using Crossbone.Abstracts;
using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Components
{
    internal class Transform : EntityComponent
    {
        public Vector2 position = new Vector2(0, 0);

        public Vector2 ToWorld()
        {
            return position - game.Scene.camera.position;
        }
    }
}
