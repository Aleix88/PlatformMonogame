using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace InputGames.Animation
{
    public class Animator: Component
    {
        public static double ANIMATION_FPS = 30; // 30 FPS

        private Dictionary<int, AnimatedSprite> animations;
        private int currentState;
        private int oldState;
        private bool isMirroed = false;
        public Vector2 position;

        public Animator(Dictionary<int, AnimatedSprite> animations):base()
        {
            this.animations = animations;
            this.currentState = 0;
            this.oldState = -1;
        }
        public Animator(Dictionary<int, AnimatedSprite> animations, int startState) {
            this.animations = animations;
            this.currentState = startState;
        }

        public override void Update(GameTime gameTime) {
            animations[this.currentState].Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            animations[this.currentState].position = position;
            animations[this.currentState].Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public void loadState(int state) {
            if (this.oldState != -1 && this.oldState != state) {    
                animations[this.currentState].resetFrames();
            }
            this.oldState = this.currentState;
            this.currentState = state;
        }

        public void mirror(bool isMirroed) {
            if (this.isMirroed != isMirroed) {
                this.isMirroed = isMirroed;
                foreach (KeyValuePair<int, AnimatedSprite> entry in animations) {
                    entry.Value.isMirroed = isMirroed;
                    entry.Value.resetFrames();
                }
            }
        }

        public void setScaleFactor(float scaleFactor) {
            foreach (KeyValuePair<int, AnimatedSprite> entry in animations)
            {
                entry.Value.scaleFactor = scaleFactor;
            }
        }
    }
}
