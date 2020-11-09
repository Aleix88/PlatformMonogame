using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace InputGames
{
    public class Component
    {
        protected List<Component> components;

        public Component()
        {
            this.components = new List<Component>();
        }

        public virtual void Update(GameTime gameTime) {
            foreach(Component component in components) {
                component.Update(gameTime);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch) {
            foreach (Component component in components)
            {
                component.Draw(spriteBatch);
            }
        }

    }
}
