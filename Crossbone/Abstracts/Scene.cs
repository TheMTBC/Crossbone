﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Abstracts
{
    internal abstract class Scene : GameObject, IDisposable
    {
        private List<Entity> _entities = new List<Entity>();

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
            foreach (var entity in _entities)
            {
                entity.Tick();
            }
        }

        public void Add(Entity entity)
        {
            _entities.Add(entity);
            entity.SetGame(game);
            entity.Start();
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
    }
}
