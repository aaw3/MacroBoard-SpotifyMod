using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyMod
{
    class HandlerCommunications
    {
        /// <summary>
        /// Tells the Mod Handler how keys should be handled.
        /// </summary>
        public enum HandleType
        {
            /// <summary>
            /// Have the mod handler (Main Application) handle all of the keys. This means the mod won't recieve "Call" method calls.
            /// </summary>
            HandlerOnly,

            /// <summary>
            /// Have the mod handle all of the keys. This means the mod handler (Main Application) won't accept any [List&lt;KeyCombination&gt;, delegate] dicts.
            /// </summary>
            ModOnly,
            
            /// <summary>
            /// Have both the mod handler (Main Application) and mod handle the keys. This means the mod will recieve "Call" method calls, and can send [List&lt;KeyCombination&gt;, delegate] dicts to the mod handler.
            /// </summary>
            Both
        }
    }


    public class ModKeyCombination
    {
        public ModKeyCombination() { }
        public static List<ModKeyCombination> ModKeyCombinations = new List<ModKeyCombination>();
        
        public ModKeyCombination(List<KeyData> keys, Action callbackMethod)
        {
            Keys = keys;
            CallbackMethod = callbackMethod;

        }


        public List<KeyData> Keys { get; set; }
        public Action CallbackMethod { get; set; }
    }


    public class KeyData
    {
        public KeyData() { }

        public int Flags { get; set; }
        public int ScanCode { get; set; }
        public int VirtualKey { get; set; }

        public string KeyboardAlias { get; set; }

        public KeyData(string keyboardAlias, int flags, int scanCode, int virtualKey)
        {
            KeyboardAlias = keyboardAlias;
            Flags = flags;
            ScanCode = scanCode;
            VirtualKey = virtualKey;
        }
    }
}
