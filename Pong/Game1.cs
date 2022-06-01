using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Pong
{
    public class Game1 : Game
    {
        public enum GameState
        {
            menu,
            loading,
            playing,
            paused,
            error,
            exit
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Stage current_stage;
        private Screen current_menu;
        public static KeyboardState keyboard_state, old_keyboard_state;
        public static ContentManager content_loader;
        public static GameState state, old_state;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Settings.resolution = new Point(960, 540);
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Settings.resolution.X;
            graphics.PreferredBackBufferHeight = Settings.resolution.Y;
            graphics.ApplyChanges();
            base.Initialize();
            content_loader = Content;
            state = GameState.menu;
            current_menu = new Screen();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            old_keyboard_state = keyboard_state;
            keyboard_state = Keyboard.GetState();
            switch (state)
            {
                case GameState.menu:
                    current_menu.Update();
                    break;
                case GameState.loading:
                    current_stage = new Stage("content/stages/stage1.txt");
                    break;
                case GameState.playing:
                    current_stage.Update();
                    break;
                case GameState.paused:

                    break;
                case GameState.error:

                    break;
                case GameState.exit:
                    Exit();
                    break;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Magenta);
            spriteBatch.Begin();
            switch (state)
            {
                case GameState.menu:
                    current_menu.Draw(ref spriteBatch);
                    break;
                case GameState.loading:

                    break;
                case GameState.paused:
                case GameState.playing:
                    current_stage.Draw(ref spriteBatch);
                    break;                                   
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
