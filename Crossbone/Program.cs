using Crossbone.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Scene = new LoaderScene();
            game.Run();
            game.Dispose();
        }
    }
}
