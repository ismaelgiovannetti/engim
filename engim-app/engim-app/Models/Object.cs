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
                    Shape = new Point(this);
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

        public void Draw(Panel panel)
        {
            if(Shape == null)
            {
                throw new NullReferenceException();
            }

            Pen _ = new Pen(Shape.Color);
            var g = panel.CreateGraphics();

            switch (Shape)
            {
                case Point point:
                    g.DrawRectangle(_, point.Position.X, point.Position.Y, 1, 1);
                    break;
                case Segment segment:
                    g.DrawLine(_, segment.A.Position.X, segment.A.Position.Y, segment.B.Position.X, segment.B.Position.Y);
                    break;
                case Polygon polygon:
                    g.DrawPolygon(_, polygon.Vertices.Select(p => new System.Drawing.Point(p.Position.X, p.Position.Y)).ToArray());
                    break;
                case Ellipse ellipse:
                    g.DrawEllipse(_, ellipse.Center.Position.X, ellipse.Center.Position.Y, ellipse.Radius, ellipse.Radius);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            g.Dispose();
        }
    }
}
