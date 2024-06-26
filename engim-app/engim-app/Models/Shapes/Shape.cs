using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engim_app.Models.Shapes
{
    abstract class Shape
    {
        private Color Color { get; set; }
        private double? Mass { get; set; }
        private bool? Gravity { get; set; }
        private bool? Collision { get; set; }

        protected Shape()
        {
            Color = Color.FromArgb(0, 0, 0);
            Mass = 0;
            Gravity = false;
            Collision = false;
        }

        protected Shape(Shape caller)
        {
            Color = caller.Color;
            Mass = null;
            Gravity = null;
            Collision = null;
        }

        public void SetColor(byte r, byte g, byte b)
        {
            Color = Color.FromArgb(r, g, b);
        }

        public void SetMass(double mass)
        {
            Mass = mass;
        }

        public void SetGravity(bool gravity)
        {
            Gravity = gravity;
        }
    }
}
