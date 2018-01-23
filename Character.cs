using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Character : Sprite
    {
        const string CHARACTER_ASSETNAME = "Characters/Cyndaquil";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int CHARACTER_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        //state enum is used to store the current "state" of the sprite
        enum State
        {
            Walking
        }
        State CurrentState = State.Walking;

        Vector2 Direction = Vector2.Zero;
        Vector2 Speed = Vector2.Zero;

        KeyboardState PreviousKeyboardState;

        public void LoadContent(ContentManager theContentManger)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManger, CHARACTER_ASSETNAME);
        }

        public void Update(GameTime theGameTime)
        {
            KeyboardState CurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(CurrentKeyboardState);

            PreviousKeyboardState = CurrentKeyboardState;

            base.Update(theGameTime, Speed, Direction);
        }

        private void UpdateMovement(KeyboardState CurrentKeyboardState)
        {
            if(CurrentState == State.Walking)
            {
                Speed = Vector2.Zero;
                Direction = Vector2.Zero;

                if (CurrentKeyboardState.IsKeyDown(Keys.A) == true)
                {
                    Speed.X = CHARACTER_SPEED;
                    Direction.X = MOVE_LEFT;
                }
                else if (CurrentKeyboardState.IsKeyDown(Keys.D) == true)
                {
                    Speed.X = CHARACTER_SPEED;
                    Direction.X = MOVE_RIGHT;
                }

                if (CurrentKeyboardState.IsKeyDown(Keys.W) == true)
                {
                    Speed.Y = CHARACTER_SPEED;
                    Direction.Y = MOVE_UP;
                }
                else if (CurrentKeyboardState.IsKeyDown(Keys.S) == true)
                {
                    Speed.Y = CHARACTER_SPEED;
                    Direction.Y = MOVE_DOWN;
                }
            }
        }

    }
}
