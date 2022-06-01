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
    public class MovingSprite : Sprite
    {
        private float acceleration;
        private float max_speed;
        private Vector2 velocity;

        public MovingSprite(string texture_name, Vector2 starting_position, float maximum_speed, float accel) : base(texture_name, starting_position)
        {
            acceleration = accel;
            max_speed = maximum_speed;
            velocity = Vector2.Zero;
        }
        public Vector2 Velocity { get => velocity; }

        public void Accelerate(Vector2 direction)
        {
            velocity += new Vector2(acceleration * direction.X, acceleration * direction.Y);       
        }
        public void Decelerate()
        {
            velocity *= 0.95f;
        }
        public override void Update()
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }
        public void SetVelocity(Vector2 vel)
        {
            velocity = vel;
        }
    }
}
