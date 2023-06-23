using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal class Animations
    {
        public int width = 0;
        public int height = 0;
        private Dictionary<string, int> _row = new Dictionary<string, int>();
        private Dictionary<string, int> _animations = new Dictionary<string, int>();

        public Animations(string fileName)
        {
            ParseInfo(fileName);
        }

        private void ParseInfo(string fileName)
        {
            var data = File.ReadAllText(fileName);
            var document = JsonDocument.Parse(data);
            width = document.RootElement.GetProperty("width").GetInt32();
            height = document.RootElement.GetProperty("height").GetInt32();
            foreach (var animation in document.RootElement.GetProperty("animations").EnumerateObject())
            {
                _row.Add(animation.Name, _row.Count);
                _animations.Add(animation.Name, animation.Value.GetInt32());
            }
        }

        public int GetIndex(string animationName)
        {
            return _row.ContainsKey(animationName) ? _row[animationName] : -1;
        }

        public int GetCountFrame(string animationName)
        {
            return _animations.ContainsKey(animationName) ? _animations[animationName] : -1;
        }
    }
}
