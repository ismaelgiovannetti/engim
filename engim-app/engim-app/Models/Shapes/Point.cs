using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engim_app.Models.Shapes
{
    internal class Point : Shape
    {
        public Position Position { get; set; }
        protected Point() : base()
        {
            Position = new Position();
        }

        public Point(Object _) : this()
        {
            return;
        }

        public Point(Shape caller) : base(caller)
        {
            Position = new Position();
        }
    }
}
