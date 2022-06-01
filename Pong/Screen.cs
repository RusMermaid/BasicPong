using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Screen
    {
        private Texture2D background_texture;

        public Screen()
        {
            background_texture = Game1.content_loader.Load<Texture2D>("graphics/screen_title");
        }
        public void Update()
        {
            if (Settings.KeyPressedOnce("Space"))
            {
                Game1.state = Game1.GameState.loading;
            }
            else if (Settings.KeyPressedOnce("Escape"))
            {
                Game1.state = Game1.GameState.exit;
            }
        }

        public void Draw(ref SpriteBatch stage_drawer)
        {
            stage_drawer.Draw(background_texture, Vector2.Zero, Color.White);
        }
    }
}
