using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using InputGames.Animation;

namespace InputGames
{
    public class Player: Component
    {
        private enum State { idle, running };

        private List<Texture2D> textures;
        private Animator animator;
        private Input input;
        private Vector2 position;
        private State state = State.idle;

        public float velocity = 1;
        public float jumpForce = 1;

        public Player(List<Texture2D> textures, Input input, Vector2 initialPosition) : base()
        {
            this.textures = textures;
            this.input = input;
            this.initializeAnimations();
        }

        public override void Update(GameTime gameTime) {
            Move();
            this.animator.loadState((int)this.state);
            this.animator.position = position;
            base.Update(gameTime);
        }

        private void initializeAnimations() {
            
            AnimatedSprite idle = new AnimatedSprite(this.textures[(int)State.idle], 1, 6, new List<Animation.KeyFrame>() {
                new Animation.KeyFrame(0, 0),
                new Animation.KeyFrame(1, 5),
                new Animation.KeyFrame(2, 10),
                new Animation.KeyFrame(3, 15),
                new Animation.KeyFrame(4, 20),
                new Animation.KeyFrame(5, 25),
                new Animation.KeyFrame(5, 30)
            }, 0);
            AnimatedSprite run = new AnimatedSprite(this.textures[(int)State.running], 1, 6, new List<Animation.KeyFrame>() {
                new Animation.KeyFrame(1, 0),
                new Animation.KeyFrame(2, 5),
                new Animation.KeyFrame(3, 10),
                new Animation.KeyFrame(4, 15),
                new Animation.KeyFrame(5, 20),
                new Animation.KeyFrame(0, 25),
                new Animation.KeyFrame(0, 30)
            }, 0);

            this.animator = new Animator(
                new Dictionary<int, AnimatedSprite>()
                {
                    { (int)State.idle, idle },
                    { (int)State.running, run }
                }
            );

            this.components.Add(this.animator);
        }

        private void Move() {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(input.Left))
            {
                this.state = State.running;
                position.X -= velocity;
                this.animator.mirror(true);
            }
            else if (state.IsKeyDown(input.Right))
            {
                this.state = State.running;
                position.X += velocity;
                this.animator.mirror(false);
            }
            else {
                this.state = State.idle;
            }

            if (state.IsKeyDown(input.Jump)) { 
            
            }
        }
    }
}
