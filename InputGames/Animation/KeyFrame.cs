using System;
using System.Collections.Generic;
using System.Text;

namespace InputGames.Animation
{
    public class KeyFrame
    {

        public int spriteFrame;
        public int frameNumber;

        public KeyFrame(int spriteFrame, int frameNumber) {
            this.spriteFrame = spriteFrame;
            this.frameNumber = frameNumber;
        }
    }
}
