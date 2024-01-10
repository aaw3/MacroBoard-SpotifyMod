using SpotifyMod;
using SpotifyMod.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using static SpotifyMod.Native.Messages;
using static SpotifyMod.Utils;

namespace SpotifyMod
{
    class ModMethods
    {
        public static ModMethods Singleton = new ModMethods();

        public static Dictionary<CommandType, Action> MethodDict = new Dictionary<CommandType, Action>()
        {
            { CommandType.OpenSpotify, Singleton.OpenSpotify },
            { CommandType.PreviousSong, Singleton.PreviousSong },
            { CommandType.NextSong, Singleton.NextSong },
            { CommandType.Rewind, Singleton.Rewind },
            { CommandType.FastForward, Singleton.FastForward },
            { CommandType.PlayPause, Singleton.PlayPause },
            { CommandType.VolumeDown, Singleton.VolumeDown },
            { CommandType.VolumeUp, Singleton.VolumeUp }
        };

        public void OpenSpotify()
        {
            try
            {
                if (Settings.Current.SpotifyLocation.Contains(" {ARGS} "))
                {
                    string[] processData = Settings.Current.SpotifyLocation.Split(" {ARGS} ");
                    Process.Start(new ProcessStartInfo() { FileName = processData[0], Arguments = processData[1], UseShellExecute = true });
                }
                else
                {
                    Process.Start(new ProcessStartInfo() { FileName = Settings.Current.SpotifyLocation, UseShellExecute = true });
                }

            }
            catch (Exception ex)
            {
                Mod.Tunnel.ShowMessageBox($"Type: {ex.GetType()}\r\nMessage: {ex.Message}", "Spotify Mod - Execution Error @ OpenSpotify");
            }
        }

        public void PreviousSong()
        {
            if (Spotify.IsNull()) return;
            
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_APPCOMMAND, 0, ShiftAppCommandCode(AppComandCode.MEDIA_PREVIOUSTRACK));
        }

        public void NextSong()
        {
            if (Spotify.IsNull()) return;
            
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_APPCOMMAND, 0, ShiftAppCommandCode(AppComandCode.MEDIA_NEXTTRACK));
        }

        public void Rewind()
        {
            if (Spotify.IsNull()) return;
            
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_APPCOMMAND, 0, ShiftAppCommandCode(AppComandCode.MEDIA_REWIND));
        }

        public void FastForward()
        {
            if (Spotify.IsNull()) return;
            
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_APPCOMMAND, 0, ShiftAppCommandCode(AppComandCode.MEDIA_FASTFORWARD));
        }

        public void PlayPause()
        {
            if (Spotify.IsNull()) return;
            
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_APPCOMMAND, 0, ShiftAppCommandCode(AppComandCode.MEDIA_PLAY_PAUSE));
        }

        public void VolumeDown()
        {
            if (Spotify.IsNull()) return;
            
            ChangeVolume(Spotify.Id, VolumeChange.Decrease, Settings.Current.VolumeIncreaseRate);
}

        public void VolumeUp()
        {
            if (Spotify.IsNull()) return;
            
            ChangeVolume(Spotify.Id, VolumeChange.Increase, Settings.Current.VolumeIncreaseRate);
        }
    }
}
