using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engim_app.Models.Shapes
{
    internal class Segment : Shape
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Segment()
        {
            A = new Point(this);
            B = new Point(this);
        }
    }
}
