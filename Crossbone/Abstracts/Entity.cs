using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Abstracts
{
    internal abstract class Entity : GameObject, IDisposable
    {
        private List<EntityComponent> _components = new List<EntityComponent>();

        public virtual void Dispose()
        {
            foreach (var component in _components)
            {
                component.Dispose();
            }
        }

        public void Add(EntityComponent component)
        {
            _components.Add(component);
            component.SetGame(game);
            component.SetEntity(this);
            component.Start();
        }

        public T? Get<T>() where T : EntityComponent
        {
            foreach (var component in _components)
            {
                if (component.GetType().IsAssignableTo(typeof(T)))
                {
                    return (T) component;
                }
            }
            return null;
        }

        public List<T> GetAll<T>() where T : EntityComponent
        {
            List<T> list = new List<T>();
            foreach (var component in _components)
            {
                if (component.GetType().IsAssignableTo(typeof(T)))
                {
                    list.Add((T) component);
                }
            }
            return list;
        }

        public virtual void Tick()
        {
            foreach (var component in _components)
            {
                component.Tick();
            }
        }
    }
}
