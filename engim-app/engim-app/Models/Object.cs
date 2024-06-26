using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using engim_app.Models.Shapes;
using Point = engim_app.Models.Shapes.Point;

namespace engim_app.Models
{
    enum _Shapes
    {
        Point,
        Segment,
        Polygon,
        Ellipse
    }

    internal class Object
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        private Shape? Shape { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public Object()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Constructor with name parameter
        /// </summary>
        /// <param name="name"></param>
        public Object(string name) : this()
        {
            Name = name;
        }

        public void SetShape(_Shapes shape)
        {
            switch (shape)
            {
                case _Shapes.Point:
                    Shape = new Point();
                    break;
                case _Shapes.Segment:
                    Shape = new Segment();
                    break;
                case _Shapes.Polygon:
                    Shape = new Polygon();
                    break;
                case _Shapes.Ellipse:
                    Shape = new Ellipse();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
