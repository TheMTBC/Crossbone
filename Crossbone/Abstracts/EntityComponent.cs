using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Abstracts
{
    internal abstract class EntityComponent : GameObject, IDisposable
    {
        public Entity entity;

        public void SetEntity(Entity entity)
        {
            this.entity = entity;
        }

        public virtual void Dispose()
        {
            
        }

        public virtual void Tick()
        {

        }
    }
}
