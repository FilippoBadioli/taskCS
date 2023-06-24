using System;
using System.Media;
using System.IO;

namespace MyProject
{

    class Music
    {

        SoundPlayer _music;

        public void StartMusic (string song)
        {
            _music = new SoundPlayer(Directory.GetCurrentDirectory() + "/../../music/" +song+".wav" );

            _music.PlayLooping();
        }

        public void StopMusic ()
        {
            _music.Stop();
        }

    }
}
