using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace Pong
{
    public static class Settings
    {
        public static Point resolution;
        public static bool KeyPressedOnce(string key_name)
        {
            Keys k;
            k = (Keys)System.Enum.Parse(typeof(Keys), key_name);
            if (Game1.keyboard_state.IsKeyUp(k) && Game1.old_keyboard_state.IsKeyDown(k))
            {
                return true;
            }
            else
            {
                return false;
            }         
        }
    }
}
