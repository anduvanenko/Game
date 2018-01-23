using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D background;
        private Texture2D cyndaquil;

        Sprite cyndaquilImage;
        Character PlayerOne;

        KeyboardState oldKeyboardState;

        //Vector2 is an object provided by the XNA framework, used to store 2D positional information
        //Texture2D is an object provided by XNA framework, used to hold image content loaded by the Content Pipeline

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
  
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //sprite object created
            PlayerOne= new Character();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerOne.LoadContent(this.Content, "Characters/Cyndaquil");


            //cyndaquilImage.Position = new Vector2(125, 245);

            // TODO: use this.Content to load your game content here

            //Texture2D image = Content.Load<Texture2D>("Characters/Cyndaquil");



            //For a small game, you may not ever need to unload any content in your game. 
            //However, if you have a big game, you can't just keep loading more and more content and expect it to keep working. 
            //It is a good idea to unload unnecessary content whenever you are done using it. 
            //So, for instance, you can unload all of the content for a particular level, after the level is completed, so that there is room for the next level's content to be loaded.

            //Content.Unload();

            background = Content.Load<Texture2D>("Backgrounds/200px-Hoenn_Route_101_RS");
            //cyndaquil = Content.Load<Texture2D>("Characters/Cyndaquil");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            PlayerOne.Update(gameTime);

            base.Update(gameTime);
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //x, y, width, height
            //800 x 480 is width and height by default
            //color.white is for not having our image tinted at all
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            //spriteBatch.Draw(cyndaquil, new Rectangle(200, 300, 50, 50), Color.White);

            PlayerOne.Draw(this.spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
