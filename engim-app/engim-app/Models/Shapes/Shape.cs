using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engim_app.Models.Shapes
{
    abstract class Shape
    {
        public Color Color { get; private set; }
        private bool? Gravity { get; set; }
        private bool? Collision { get; set; }

        protected Shape()
        {
            Color = Color.FromArgb(0, 0, 0);
            Gravity = false;
            Collision = false;
        }

        protected Shape(Shape caller)
        {
            Color = caller.Color;
            Gravity = null;
            Collision = null;
        }

        public void SetColor(byte r, byte g, byte b)
        {
            Color = Color.FromArgb(r, g, b);
        }

        public void SetGravity(bool gravity)
        {
            Gravity = gravity;
        }

        public void SetCollision(bool collision)
        {
            Collision = collision;
        }
    }
}
