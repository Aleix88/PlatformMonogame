using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace InputGames
{
    public class Camera2D
    {
        private Viewport viewport;

        public Matrix transformMatrix;

        public  Camera2D(Viewport viewport) {
            this.viewport = viewport;
        }

        public Matrix Follow(Vector2 targetPos, int targetWidth, int targetHeight) {
            Matrix followPosition = Matrix.CreateTranslation(targetPos.X - targetWidth / 2, targetPos.Y - targetHeight / 2, 0);
            Matrix screenCenterOffset = Matrix.CreateTranslation(-viewport.Width / 2, -viewport.Height / 2, 0);
            transformMatrix = followPosition * screenCenterOffset;
            return transformMatrix;
        }

    }
}
