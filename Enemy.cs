using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using Math_Library;

namespace MathForGames
{
    class Enemy : Actor
    {

        private Actor _target;


        public Actor Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }

        public bool CheckTargetInSight()
        {
            if (Target == null)
                return false;

            Vector2 direction = Vector2.Normalize(Position - Target.Position);

            if (Vector2.DotProduct(Forward, direction) == 1)
                return true;

            return false;
        }
    }
}
