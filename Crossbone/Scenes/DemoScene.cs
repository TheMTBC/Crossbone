using Crossbone.Abstracts;
using Crossbone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Scenes
{
    internal class DemoScene : Scene
    {
        public override void Start()
        {
            Add(new Player());
            var a = new Text();
            a.text = "ABC";
            Add(a);
            Add(new Test());
        }
    }
}
