using InputGames.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Transactions;

namespace InputGames
{
    public class AnimatedSprite: Component
    {
        private Texture2D textureAtlas;
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int currentKeyFrame;
        private int FrameWidth;
        private int FrameHeigth;
        private int SpriteX;
        private int SpriteY;
        private MTimer timer;
        private List<KeyFrame> keyframes;
        private int mirrorOffset;

        public float scaleFactor = 1;
        public bool isMirroed = false;
        public Vector2 position;

        public AnimatedSprite(Texture2D textureAtlas, int rows, int columns, List<KeyFrame> keyFrames, int mirrorOffset) : base()
        {
            this.textureAtlas = textureAtlas;
            this.Rows = rows;
            this.Columns = columns;
            this.currentFrame = 0;
            this.FrameWidth = textureAtlas.Width / columns;
            this.FrameHeigth = textureAtlas.Height / rows;
            this.keyframes = keyFrames;
            this.currentKeyFrame = 0;
            this.mirrorOffset = mirrorOffset;
            timer = new MTimer(1000 / Animator.ANIMATION_FPS); //Frames per mili
            timer.addTime(1000); //Sumar 1 segon per entrar al primer frame directament
        }

        public override void Update(GameTime gameTime) {
            this.UpdateFrameIfNeeded(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, (int)(FrameWidth * scaleFactor), (int)(FrameHeigth * scaleFactor));
            Rectangle sourceRect = new Rectangle(SpriteX * FrameWidth, SpriteY * FrameHeigth, FrameWidth, FrameHeigth);
            spriteBatch.Draw(textureAtlas, destinationRect, sourceRect, Color.White);
            base.Draw(spriteBatch);
        }

        private void UpdateFrameIfNeeded(GameTime gameTime) {
            timer.UpdateTimer(gameTime);
            if (timer.TimeOk())
            {
                UpdateFrame();
            }
        }

        private void UpdateFrame() {

            if (keyframes[currentKeyFrame].frameNumber == currentFrame) {
                loadSpriteFrame();
            }

            if (currentKeyFrame >= keyframes.Count)
            {
                currentFrame = 0;
                currentKeyFrame = 0;
            }
            else { 
                currentFrame++;
            }
        }

        private void loadSpriteFrame() {
            int spriteFrame = keyframes[currentKeyFrame].spriteFrame;
            int spriteIndex = isMirroed ? spriteFrame + mirrorOffset : spriteFrame;
            this.SpriteY = (int)((float)spriteIndex / (float)Columns);
            this.SpriteX = spriteIndex % Columns;
            currentKeyFrame++;
        }

        public void resetFrames() {
            this.currentFrame = this.keyframes[0].frameNumber;
            this.currentKeyFrame = 0;
            loadSpriteFrame();
            this.timer.resetTimer();
        }

   

    }
}
