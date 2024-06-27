using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace engim_app.Models
{
    internal class Scenario
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Object> Objects { get; set; } = new List<Object>();
        public Timer Timer { get; set; } = new Timer();

        public Scenario()
        {
            Id = Guid.NewGuid();
        }

        public Scenario(string name) : this()
        {
            Name = name;
        }

        public void AddObject(Object obj)
        {
            Objects.Add(obj);
        }

        public void RemoveObject(Object obj)
        {
            Objects.Remove(obj);
        }


    }
}
