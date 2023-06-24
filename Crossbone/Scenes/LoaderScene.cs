using Crossbone.Abstracts;
using Crossbone.Components;
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
            Add(new Text("YA voobshche delayu, chto hochu"));
            Add(new Text("Hochu implanty — zvonyu vrachu (alyo)")).Get<Transform>().position += new Utils.Vector2(0, 32);
            Add(new Text("Kto menya ne lyubit, ya vas ne slyshu (chyo?)")).Get<Transform>().position += new Utils.Vector2(0, 64);
            Add(new Text("Vy prosto mne zaviduete, ya molchu")).Get<Transform>().position += new Utils.Vector2(0, 64+32);
        }
    }
}
