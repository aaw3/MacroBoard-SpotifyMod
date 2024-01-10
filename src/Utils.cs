using SpotifyMod.Volume;
using System;
using System.Collections.Generic;
using System.Text;
using static SpotifyMod.Native.Messages;

namespace SpotifyMod
{
    class Utils
    {
        public static int ShiftAppCommandCode(AppComandCode code)
        {
            return (int)code << 16;
        }

        //public const int DefaultVolumeChange = 10;
        public static void ChangeVolume(int id, VolumeChange volChange, int volChangeAmount)
        {
            switch (volChange)
            {
                case VolumeChange.Decrease:
                    {

                        var curVol = (int)VolumeMixer.GetApplicationVolume(id);
                        if (curVol > 0)
                        {
                            VolumeMixer.SetApplicationVolume(id, curVol - volChangeAmount <= 0 ? 0 : curVol - volChangeAmount);

                        }
                    }
                    break;

                case VolumeChange.Increase:
                    {
                        var curVol = (int)VolumeMixer.GetApplicationVolume(Spotify.Id);
                        if (curVol < 100)
                        {
                            VolumeMixer.SetApplicationVolume(Spotify.Id, curVol + volChangeAmount >= 100 ? 100 : curVol + volChangeAmount);
                        }
                    }
                    break;
            }
        }

        public enum VolumeChange
        {
            Decrease,
            Increase
        }
    }
}
