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
        private Panel? Panel { get; set; }
        private bool Drawn { get; set; } = false;
        private bool Filled { get; set; } = false;

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

        /// <summary>
        /// Set the color of the object
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public void SetColor(byte r, byte g, byte b)
        {
            Shape?.SetColor(r, g, b);
            this.Update();
        }

        /// <summary>
        /// Set the color of the object
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            this.SetColor(color.R, color.G, color.B);
        }

        /// <summary>
        /// Set the gravity of the object
        /// </summary>
        /// <param name="gravity"></param>
        public void SetGravity(bool gravity)
        {
            Shape?.SetGravity(gravity);
            this.Update();
        }

        /// <summary>
        /// Set the panel where the object will be drawn
        /// </summary>
        /// <param name="panel"></param>
        public void SetPanel (Panel panel)
        {
            Panel = panel;
        }

        public void Update()
        {
            if (Drawn && Filled)
            {
                this.Draw();
                this.Fill();
            }
            else if (Drawn)
            {
                this.Draw();
            }
            else if (Filled)
            {
                this.Fill();
            }
        }

        /// <summary>
        /// Set the shape of the object
        /// </summary>
        /// <param name="shape"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Draw and fill the object on the panel
        /// </summary>
        public void Display() {
            this.Draw();
            this.Fill();
        }

        /// <summary>
        /// Draw the object on the panel
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Draw()
        {
            if (Shape == null
            || Panel == null)
            {
                throw new NullReferenceException();
            }

            Pen _ = new Pen(Shape.Color);
            var g = Panel.CreateGraphics();

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

            Drawn = true;
        }

        /// <summary>
        /// Fill the object on the panel
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Fill ()
        {
            if (Shape == null
            || Panel == null)
            {
                throw new NullReferenceException();
            }

            Brush _ = new SolidBrush(Shape.Color);
            var g = Panel.CreateGraphics();

            switch (Shape)
            {
                case Point point:
                    g.FillRectangle(_, point.Position.X, point.Position.Y, 1, 1);
                    break;
                case Segment segment:
                    g.FillRectangle(_, segment.A.Position.X, segment.A.Position.Y, segment.B.Position.X - segment.A.Position.X, segment.B.Position.Y - segment.A.Position.Y);
                    break;
                case Polygon polygon:
                    g.FillPolygon(_, polygon.Vertices.Select(p => new System.Drawing.Point(p.Position.X, p.Position.Y)).ToArray());
                    break;
                case Ellipse ellipse:
                    g.FillEllipse(_, ellipse.Center.Position.X, ellipse.Center.Position.Y, ellipse.Radius, ellipse.Radius);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            g.Dispose();

            Filled = true;
        }   
    }
}
