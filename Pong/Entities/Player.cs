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
    public class Player
    {
        private readonly MovingSprite sprite;
        private Keys up_key;
        private Keys down_key;

        public Player(MovingSprite base_sprite, Keys up, Keys down)
        {
            sprite = base_sprite;
            up_key = up;
            down_key = down;
        }
        public Sprite Sprite { get => sprite;}

        public void Update()
        {
            Move();
            sprite.Update();
        }
        public void Move()
        {
            if (Game1.keyboard_state.IsKeyDown(up_key))
            {
                sprite.Accelerate(new Vector2(0, -1));
            }
            if (Game1.keyboard_state.IsKeyDown(down_key))
            {
                sprite.Accelerate(new Vector2(0, +1));
            }
            sprite.Decelerate();          
        }
    }
}
