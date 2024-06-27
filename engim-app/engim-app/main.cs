using engim_app.Models;
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
            Object o = new Object("myEllipse");
            o.SetShape(_Shapes.Ellipse);
            o.SetPanel(panel1);
            o.Display();
            o.SetColor(Color.Red);
            o.SetGravity(true);

            Scenario s = new Scenario("myScenario");
            s.AddObject(o);
        }
    }
}