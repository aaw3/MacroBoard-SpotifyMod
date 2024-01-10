using SpotifyMod.Native;
using SpotifyMod.Volume;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static SpotifyMod.HandlerCommunications;
using static SpotifyMod.Native.Messages;
using static SpotifyMod.Utils;
using static SpotifyMod.VirtualKeys;

//View this to embed dlls into the mod file itself: https://denhamcoder.net/2018/08/25/embedding-net-assemblies-inside-net-assemblies/
namespace SpotifyMod
{

    public class Mod
    {


        public void Call(long wParam, long lParam, params dynamic[] args)
        {
            //HandleKey(wParam, lParam, args);

        }

        private dynamic HostWindow;
        public static dynamic Tunnel;
        public int Init(dynamic tunnelInstance)
        {
            Tunnel = tunnelInstance;
            HostWindow = Tunnel.HostWindow;

            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Config.Load();

            return (int)HandleType.HandlerOnly;
        }

        public dynamic ReturnKeyCombinations()
        {
            return ModKeyCombination.ModKeyCombinations;
        }

        public void SetKeyCombinations()
        {
            Tunnel.UpdateKeyCombinations(this, ModKeyCombination.ModKeyCombinations);
        }

        public void Reload()
        {
            Config.Load();
        }

        public void Closing()
        {
            Config.SaveConfig(Settings.Current);
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SpotifyMod.EmbeddedAssemblies.Newtonsoft.Json.dll"))
            //{
            //    var assemblyData = new byte[stream.Length];
            //    stream.Read(assemblyData, 0, assemblyData.Length);
            //    return Assembly.Load(assemblyData);
            //}

            return null;
        }

        public void Testing()
        {
            if (Spotify.IsNull()) return;

            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_KEYDOWN, (int)VKeys.LCONTROL, 0);
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_KEYDOWN, (int)VKeys.UP, 0);

            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_KEYUP, (int)VKeys.LCONTROL, 1);
            PostMessage(Spotify.MainWindowHandle, (int)WindowMessage.WM_KEYUP, (int)VKeys.UP, 1);
        }


    }
}
