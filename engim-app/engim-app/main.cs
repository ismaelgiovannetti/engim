using engim_app.Models;
using engim_app.Models.Shapes;
using Object = engim_app.Models.Object;

namespace engim_app
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Object o = new Object();
            o.SetShape(_Shapes.Ellipse);
            o.Draw(this.panel1);
        }
    }
}