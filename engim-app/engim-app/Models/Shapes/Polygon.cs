using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engim_app.Models.Shapes
{
    internal class Polygon : Shape
    {
        public List<Point> Vertices { get; set; }

        public Polygon()
        {
            Vertices = new List<Point>();
        }

        public void AddVertex()
        {
            Vertices.Add(new Point(this));
        }

        public void RemoveVertex(int index)
        {
            Vertices.RemoveAt(index);
        }
    }
}
