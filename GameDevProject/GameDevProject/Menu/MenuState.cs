using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GameDevProject.Menu
{
    class MenuState : State
    {
        private List<Component> _components;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game,graphicsDevice,content)
        {
            var buttonTexture = _content.Load<Texture2D>("menu/Button");
            var buttonFont = _content.Load<SpriteFont>("menu/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game"
            };
            newGameButton.Click += NewGameButton_Click;
            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Game"
            };
            loadGameButton.Click += LoadGameButton_Click;
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
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
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }


        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("LOADING GAME");
        }

        

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Quiting Game");
            _game.Exit();
        }


        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            Debug.WriteLine("Draw Menu");
            _spriteBatch.Begin();
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
        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they are not needed
        }

        



    }
}
