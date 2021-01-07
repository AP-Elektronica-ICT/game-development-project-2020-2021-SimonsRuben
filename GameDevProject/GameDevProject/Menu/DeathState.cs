using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Menu
{
    class DeathState : State
    {
        private int levelnumber;
        private List<Component> _components;
        public DeathState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int _levelnumber) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("menu/Button");
            var buttonFont = _content.Load<SpriteFont>("menu/Font");

            var TryAgain = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Try Again"
            };
            TryAgain.Click += TryAgain_Click;
            var MainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Main Menu"
            };
            MainMenuButton.Click += MainMenu_Click;
            this.levelnumber = _levelnumber;
            _components = new List<Component>()
            {
                TryAgain,
                MainMenuButton
            };
        }

        private void TryAgain_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content, levelnumber));
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
