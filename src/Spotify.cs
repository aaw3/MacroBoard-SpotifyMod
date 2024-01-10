using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpotifyMod
{

    class Spotify
    {
        static Process Process;

        public static IntPtr MainWindowHandle => Process.MainWindowHandle;
        public static int Id => Process.Id;


        public static bool IsNull()
        {
            if (Process == null)
            {
                var processes = Process.GetProcessesByName("Spotify");
                if (processes.Length == 0)
                    return true;

                Process = processes[0];
                Process.EnableRaisingEvents = true;
                Process.Exited += (s, eargs) =>
                {
                    SpotifyClosed();
                };
            }
            return false;
        }
        static void SpotifyClosed()
        {
            Process = null;
        }
    }
}
