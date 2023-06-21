using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Abstracts
{
    internal abstract class GameObject
    {
        protected Game game;

        public void SetGame(Game game)
        {
            this.game = game;
        }

        public virtual void Start()
        {

        }
    }
}
