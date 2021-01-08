using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;

namespace GameDevProject.Menu
{
    class MenuState : State
    {
        /* DE HELE MENU STATE IS GEMAAKT ROND HET PRINCIPE VAN EEN VIDEO DIE IK HEB GEVOLGT
         * 
         * LINK: https://youtu.be/76Mz7ClJLoE
         * 
         * 
         * 
         * 
         * 
         * 
         */
        //Code voor media player werd afgeleid uit volgende video
        //link: https://youtu.be/Vw-UCTLhIFw


        private List<Component> _components;
        private Texture2D background;
        private Song introSong;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game,graphicsDevice,content)
        {
            MediaPlayer.Stop();
            var buttonTexture = _content.Load<Texture2D>("menu/Button");
            var buttonFont = _content.Load<SpriteFont>("menu/Font");
            background = _content.Load<Texture2D>("menu/background");
            introSong = _content.Load<Song>("music/intro");
            MediaPlayer.Play(introSong);

            var newGameButton = new Button(buttonTexture, buttonFont)
            {

                Position = new Vector2(720, 600),
                Text = "Play Level1"
            };
            newGameButton.Click += NewGameButton_Click;
            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 700),
                Text = "Play Level2 "
            };
            loadGameButton.Click += LoadGameButton_Click;
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(720, 800),
                Text = "Quit Game"
            };
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton
            };
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("New game");

            _game.ChangeState(new GameState(_game, _graphicsDevice, _content,1));
        }


        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Level 2 ");
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content, 2));
        }

        

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Quiting Game");
            _game.Exit();
        }


        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            //Debug.WriteLine("Draw Menu");
            _spriteBatch.Begin();

            _spriteBatch.Draw(background, new Rectangle(0, 0, 1600, 960), Color.White);
            foreach (var component in _components)
            {
                component.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    

        



    }
}
