using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GL_Sensors_v0._2.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public Sensor Sensor { get; set; }
        public int SensorId { get; set; }
        public int pm_1_0 { get; set; }
        public int pm_2_5 { get; set; }
        public int pm_10 { get; set; }
        public int temp { get; set; }
        public int humidity { get; set; }       
        public DateTime Time { get; set; }
    }
}
