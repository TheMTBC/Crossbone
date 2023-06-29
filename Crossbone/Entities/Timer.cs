using Crossbone.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Entities
{
    internal class Timer : Entity
    {
        private Action<Timer> _task;
        private float _t = 0;
        private float _delay = 0;

        public Timer(float delay, Action<Timer> task)
        {
            _task = task;
            _delay = delay;
        }

        public override void Tick()
        {
            _t += game.deltaTime;
            if (_t >= _delay)
            {
                _t = 0;
                _task.Invoke(this);
            }
            base.Tick();
        }
    }
}
