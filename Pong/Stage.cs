using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Stage
    {
        private Texture2D background_texture;
        private Rectangle game_area;
        private string name;
        private int score_limit;
        private Player player1, player2;
        private Ball ball;

        public Stage(string stage_name)
        {           
            StreamReader file;
            try
            {
                file = new StreamReader(stage_name);
                //FILE FORMAT EXAMPLE:                
                //name:level 1
                //texture:bg1
                //points:10
                name = file.ReadLine().Split(':')[1];
                background_texture = Game1.content_loader.Load<Texture2D>(file.ReadLine().Split(':')[1]);
                score_limit = Convert.ToInt32(file.ReadLine().Split(':')[1]);                
                file.Close();
                game_area = new Rectangle(0, 0, background_texture.Width, background_texture.Height);
                player1 = new Player(new MovingSprite("graphics/paddle", new Vector2(game_area.Left + 32, game_area.Height /2), 10f, 1f), Keys.W, Keys.S);
                player2 = new Player(new MovingSprite("graphics/paddle", new Vector2(game_area.Right - 32, game_area.Height / 2), 10f, 1f), Keys.Up, Keys.Down);
                ball = new Ball(new MovingSprite("graphics/ball", new Vector2(game_area.Width / 2, game_area.Height / 2), 10f, 1f));
                ball.Reset(game_area);
                Game1.state = Game1.GameState.playing;
            }
            catch
            {
                Game1.state = Game1.GameState.error;
            }
        }
        public void Update()
        {
            player1.Update();
            player2.Update();
            if (CheckCollision(player1.Sprite.Rectangle, ball.Sprite.Rectangle))
            {
                ball.ChangeDirection('x');
            }
            if (CheckCollision(player2.Sprite.Rectangle, ball.Sprite.Rectangle))
            {
                ball.ChangeDirection('x');
            }
            if (ball.Sprite.Rectangle.Left < game_area.Left || ball.Sprite.Rectangle.Right > game_area.Right)
            {
                ball.Reset(game_area);
            }
            ball.Update(game_area);
        }

        private bool CheckCollision(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        public void Draw(ref SpriteBatch stage_drawer)
        {
            stage_drawer.Draw(background_texture, Vector2.Zero, Color.White);
            stage_drawer.Draw(player1.Sprite.Texture, player1.Sprite.Rectangle, Color.White);
            stage_drawer.Draw(player2.Sprite.Texture, player2.Sprite.Rectangle, Color.White);
            stage_drawer.Draw(ball.Sprite.Texture, ball.Sprite.Rectangle, Color.White);
        }
    }
}
