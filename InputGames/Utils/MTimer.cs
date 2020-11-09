using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace InputGames
{
    public class MTimer
    {

        private TimeSpan timeSpan;
        private double timeToWait; //Miliseconds
        public MTimer(double timeToWait)
        {
            timeSpan = new TimeSpan();
            this.timeToWait = timeToWait;
        }

        public void UpdateTimer(GameTime gameTime) {
            timeSpan += gameTime.ElapsedGameTime;
        }

        public double getElapsedMS() {
            return timeSpan.TotalMilliseconds;
        }

        public void resetTimer() {
            this.timeSpan = TimeSpan.Zero;
        }

        public void addTime(int miliseconds) {
            timeSpan.Add(new TimeSpan(0, 0, 0, 0, miliseconds));
        }

        public bool TimeOk() {
            if (this.timeSpan.TotalMilliseconds > this.timeToWait) {
                this.timeSpan = TimeSpan.Zero;
                return true;
            }
            return false;
        }
    }
}
