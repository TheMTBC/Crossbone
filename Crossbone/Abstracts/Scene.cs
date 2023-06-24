using Crossbone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Abstracts
{
    internal abstract class Scene : GameObject, IDisposable
    {
        private List<Entity> _entities = new List<Entity>();
        public Camera camera = new Camera();

        public void Dispose()
        {
            foreach (var entity in _entities)
            {
                entity.Dispose();
            }
            _entities.Clear();
        }

        public void Tick()
        {
            foreach (var entity in _entities.ToArray())
            {
                entity.Tick();
            }
        }

        public T Add<T>(T entity) where T : Entity
        {
            _entities.Add(entity);
            entity.SetGame(game);
            entity.Start();
            return entity;
        }

        public List<T> GetAll<T>() where T : EntityComponent
        {
            List<T> list = new List<T>();
            foreach (var entity in _entities)
            {
                list.AddRange(entity.GetAll<T>());
            }
            return list;
        }

        public T? Get<T>() where T : Entity
        {
            foreach (var entity in _entities)
            {
                if (entity.GetType().IsAssignableTo(typeof(T)))
                {
                    return (T) entity;
                }
            }
            return null;
        }

        public void Remove(Entity entity)
        {
            _entities.Remove(entity);
            entity.Dispose();
        }
    }
}
