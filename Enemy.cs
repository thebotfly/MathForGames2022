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
        private Color _alertColor;


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

            Vector2 direction = Vector2.Normalize(LocalPosition - Target.LocalPosition);

            if (Vector2.DotProduct(Forward, direction) > 1)
                return true;

            return false;
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
