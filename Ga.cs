using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;

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
        private SpriteFontKate Font;
        private KeyboardKate KeyboardKate;
        private MouseKate MouseKate;
        private List<ISprite> SpriteList;
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = 800;
            Graphics.PreferredBackBufferHeight = 450;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            KeyboardKate = new KeyboardKate();
            KeyboardKate.Add(Keys.D0, Exit);
            KeyboardKate.Add(Keys.D1, Key1);
            KeyboardKate.Add(Keys.D2, Key2);
            KeyboardKate.Add(Keys.D3, Key3);
            KeyboardKate.Add(Keys.D4, Key4);

            MouseKate = new MouseKate();
            MouseKate.Add("Right-click", Exit);
            MouseKate.Add("Quad1", Key1);
            MouseKate.Add("Quad2", Key2);
            MouseKate.Add("Quad3", Key3);
            MouseKate.Add("Quad4", Key4);

            base.Initialize();
        }

        protected void Key1()
        {
            KillKeys(FireBallStatic);
        }
        protected void Key2()
        {
            KillKeys(DinoRhinoAnimated);
        }
        protected void Key3()
        {
            KillKeys(RexStaticMoving);
        }
        protected void Key4()
        {
            KillKeys(BlarggAnimatedMoving);
        }

        private void KillKeys(ISprite sprite)
        {
            sprite.Start = !sprite.Start;
            foreach (ISprite i in SpriteList)
            {
                if (i != sprite)
                {
                    i.Start = false;
                }
            }
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
            SpriteFont Place = Content.Load<SpriteFont>("File");
            Font = new SpriteFontKate(Place, new Rectangle(0, 0, 0, 0), new Vector2(10, 300));

            SpriteList = new List<ISprite>() { DinoRhinoAnimated, BlarggAnimatedMoving, RexStaticMoving, FireBallStatic };

            FireBallStatic.Start = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            DinoRhinoAnimated.Update(gameTime);
            BlarggAnimatedMoving.Update(gameTime);
            RexStaticMoving.Update(gameTime);
            FireBallStatic.Update(gameTime);
            KeyboardKate.Update(gameTime);
            MouseKate.Update(gameTime);

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
            Font.Draw(SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
