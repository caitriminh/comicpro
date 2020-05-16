using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPro2019
{
    public class KeyHelper
    {
        public static bool IsNumlockActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.NumLock);
            }
        }

        /// <summary>
        /// This property indicates if caps lock is active.
        /// </summary>
        public static bool IsCapslockActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.CapsLock);
            }
        }

        /// <summary>
        /// This property indicates if scroll lock is active.
        /// </summary>
        public static bool IsScrolllockActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.Scroll);
            }
        }

        public static bool IsInsertActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.Insert);
            }
        }
    }
}
