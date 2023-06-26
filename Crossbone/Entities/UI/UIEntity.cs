using Crossbone.Abstracts;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities.UI
{
    internal abstract class UIEntity : Entity
    {
        public virtual void Press(KeyEventArgs e)
        {

        }
    }
}
