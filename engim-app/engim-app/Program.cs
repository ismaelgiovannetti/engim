using engim_app.Models;
using engim_app.Models.Shapes;
using System.Runtime.CompilerServices;
using Object = engim_app.Models.Object;

namespace engim_app
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new main());
        }
    }
}