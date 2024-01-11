using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private Texture2D Background;
        private Texture2D SpriteSheet;
        private Texture2D Blargg;
        private Texture2D Rex;
        private Texture2D FireBall;
        private Texture2D Earth;
        private AnimatedSprite DinoRhinoAnimated;
        private AnimatedSpriteMoving BlarggAnimatedMoving;
        private StaticSpriteMoving RexStaticMoving;
        private StaticSprite FireBallStatic;
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            //upload original picture here
            SpriteSheet = Content.Load<Texture2D>("enemies-dinosaur");
            // Animates sprites
            DinoRhinoAnimated = new AnimatedSprite(SpriteSheet, 1, 2, new Rectangle(312, 22, 64, 32), new Vector2(400, 240));
            BlarggAnimatedMoving = new AnimatedSpriteMoving(SpriteSheet, 1, 2, new Rectangle(195, 22, 96, 32), new Vector2(600, 80));
            RexStaticMoving = new StaticSpriteMoving(SpriteSheet, new Rectangle(9, 22, 20, 30), new Vector2(200, 60));
            FireBallStatic = new StaticSprite(SpriteSheet, new Rectangle(461, 31, 16, 16), new Vector2(350, 240));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            DinoRhinoAnimated.Update(gameTime);
            BlarggAnimatedMoving.Update(gameTime);
            RexStaticMoving.Update(gameTime);
            FireBallStatic.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            SpriteBatch.Begin();
          
            DinoRhinoAnimated.Draw(SpriteBatch);
            BlarggAnimatedMoving.Draw(SpriteBatch);
            RexStaticMoving.Draw(SpriteBatch);
            FireBallStatic.Draw(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
