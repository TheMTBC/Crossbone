using Crossbone.Abstracts;
using Crossbone.Utils;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone
{
    internal class Game : IDisposable
    {
        public RenderWindow window;
        private Scene _scene;
        public Resources resources;
        public float deltaTime = 1f / 60f;
        public Input input = new Input();
        public int width = 800;
        public int height = 600;

        public Game()
        {
            window = new RenderWindow(new VideoMode((uint)width, (uint)height), "Crossbone");
            window.SetFramerateLimit(0);
            window.SetVerticalSyncEnabled(true);
            AddListeners();
        }

        public void Run()
        {
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                clock.Restart();
                window.DispatchEvents();
                window.Clear();
                _scene?.Tick();
                window.Display();
                ResetInput();
                deltaTime = clock.ElapsedTime.AsSeconds();
            }
            window.Dispose();
        }

        private void ResetInput()
        {
            input.use = false;
        }

        private void AddListeners()
        {
            window.Closed += (object? sender, EventArgs e) =>
            {
                window.Close();
            };
            input.ApplyListeners(this);
        }

        public void Dispose()
        {
            window.Dispose();
            resources.Dispose();
        }

        public Scene Scene
        {
            get
            {
                return _scene;
            }
            set
            {
                if (_scene != null)
                {
                    _scene.Dispose();
                }
                _scene = value;
                if (_scene != null)
                {
                    _scene.SetGame(this);
                    _scene.Start();
                }
            }
        }
    }
}
