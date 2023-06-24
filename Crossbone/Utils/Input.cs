using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal class Input
    {
        private bool _up = false;
        private bool _right = false;
        private bool _left = false;
        private bool _down = false;
        public float x
        {
            get { return (_right ? 1 : 0) + (_left ? -1 : 0); }
        }
        public float y
        {
            get { return (_up ? 1 : 0) + (_down ? -1 : 0); }
        }
        public bool use = false;

        public void ApplyListeners(Game game)
        {
            game.window.KeyPressed += Window_KeyPressed;
            game.window.KeyReleased += Window_KeyReleased;
        }

        private void Window_KeyReleased(object? sender, SFML.Window.KeyEventArgs e)
        {
            bool d = false;
            if (e.Code == SFML.Window.Keyboard.Key.Right)
            {
                _right = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Left)
            {
                _left = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Up)
            {
                _up = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Down)
            {
                _down = d;
            }
        }

        private void Window_KeyPressed(object? sender, SFML.Window.KeyEventArgs e)
        {
            bool d = true;
            if (e.Code == SFML.Window.Keyboard.Key.Right)
            {
                _right = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Left)
            {
                _left = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Up)
            {
                _up = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Down)
            {
                _down = d;
            }
            if (e.Code == SFML.Window.Keyboard.Key.Enter)
            {
                use = true;
            }
        }
    }
}
