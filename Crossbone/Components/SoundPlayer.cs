using Crossbone.Abstracts;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Components
{
    internal class SoundPlayer : EntityComponent
    {
        public Sound sound;

        public SoundPlayer(SoundBuffer soundBuffer)
        {
            sound = new Sound(soundBuffer);
        }

        public override void Dispose()
        {
            base.Dispose();
            sound.Dispose();
        }

        public void Play(float volume)
        {
            sound.Volume = volume;
            sound.Play();
        }
    }
}
