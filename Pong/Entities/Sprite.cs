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
    public class Sprite
    {
        protected readonly Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 position;
        protected Vector2 centre;
        public Sprite(string texture_name, Vector2 starting_position)
        {
            texture = Game1.content_loader.Load<Texture2D>(texture_name);
            position = starting_position;
            rectangle = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
            centre = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public Texture2D Texture { get => texture; }
        public Rectangle Rectangle { get => rectangle; }
        public Vector2 Position { get => position; }
        public Vector2 Centre { get => centre; }

        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        public virtual void Update()
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
            centre = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }
    }
}
