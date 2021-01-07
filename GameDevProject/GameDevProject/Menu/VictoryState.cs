using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Menu
{
    class VictoryState : State
    {
        private int levelnumber;
        private List<Component> _components;
        public VictoryState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int _levelnumber) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("menu/Button");
            var buttonFont = _content.Load<SpriteFont>("menu/Font");

            var NextLevel = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Next Level"
            };
            NextLevel.Click += NextLevel_Click;
            var MainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Main Menu"
            };
            MainMenuButton.Click += MainMenu_Click;
            this.levelnumber = _levelnumber;
            _components = new List<Component>()
            {
                NextLevel,
                MainMenuButton
            };
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void NextLevel_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content, levelnumber+1));
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
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
    }
}
