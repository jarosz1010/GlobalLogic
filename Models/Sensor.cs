using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GL_Sensors_v0._2.Models
{
    public class Sensor
    {
        public int Id { get; set; }

        public string name { get; set; }
        public List<Measurement> Measurements { get; set; }
        public Sensor() => Measurements = new List<Measurement>();
    }
}
