using System;
using System.Media;
using System.IO;

namespace MyProject
{
    class Sfx
    {

        SoundPlayer _SFX;

        public void StartMusic (string SFX)
        {
            _SFX = new SoundPlayer(Directory.GetCurrentDirectory() + "/../../music/SFX/" + SFX + ".wav");

            _SFX.Play ();
        }

    }

}
