using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace InputGames
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Component> components;
        private Player player;
        private Camera2D camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            components = new List<Component>();
            player = new Player(
                new List<Texture2D>() {
                    Content.Load<Texture2D>("Idle"),
                    Content.Load<Texture2D>("Run")
                },
                new Input()
                {
                    Left = Keys.A,
                    Right = Keys.D,
                    Jump = Keys.Space
                },
                new Vector2(50, 50) //Initial position
            );
            components.Add(player);

            camera = new Camera2D(GraphicsDevice.Viewport);
        }

        protected override void Update(GameTime gameTime)
        {   
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(Component component in components) {
                component.Update(gameTime);
            }
            //camera.Follow(player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //transformMatrix: camera.transformMatrix
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (Component component in components)
            {
                component.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
