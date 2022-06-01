using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    public class Ball
    {
        private readonly MovingSprite sprite;

        public Ball(MovingSprite base_sprite)
        {
            sprite = base_sprite;
            sprite.SetVelocity(new Vector2(3, 3));
        }
        public Sprite Sprite { get => sprite; }

        public void Update(Rectangle limit)
        {
            Bounce(limit);
            sprite.Update();
        }
        public void ChangeDirection(char axis)
        {
            if (axis == 'x')
            {
                sprite.SetVelocity(new Vector2(-sprite.Velocity.X, sprite.Velocity.Y));
            }
            else if (axis == 'y')
            {
                sprite.SetVelocity(new Vector2(sprite.Velocity.X, -sprite.Velocity.Y));
            }
        }
        public void Reset(Rectangle game_area)
        {
            int rx, ry;
            Random r = new Random();
            rx = (int)Math.Floor(r.NextDouble() * 2) *2 - 1;
            ry = (int)Math.Floor(r.NextDouble() * 2) *2 - 1;
            sprite.SetVelocity(new Vector2(rx*3, ry*3));
            sprite.SetPosition(new Vector2(game_area.Width / 2, game_area.Height / 2));
        }
        private void Bounce(Rectangle limit)
        {
            if (sprite.Position.Y < limit.Top || sprite.Position.Y > limit.Bottom)
            {
                ChangeDirection('y');
            }
            //if (sprite.Position.X < limit.Left || sprite.Position.X > limit.Right)
            //{
            //    ChangeDirection('x');
            //}
        }
    }
}
