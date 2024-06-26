using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engim_app.Models.Shapes
{
    internal class Ellipse : Shape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Ellipse()
        {
            Center = new Point(this);
            Radius = 0;
        }
    }
}
