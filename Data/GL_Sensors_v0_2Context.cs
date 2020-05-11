using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GL_Sensors_v0._2.Models;

namespace GL_Sensors_v0._2.Data
{
    public class GL_Sensors_v0_2Context : DbContext
    {
        public GL_Sensors_v0_2Context (DbContextOptions<GL_Sensors_v0_2Context> options)
            : base(options)
        {
        }

        public DbSet<GL_Sensors_v0._2.Models.Measurement> Measurement { get; set; }

        public DbSet<GL_Sensors_v0._2.Models.Sensor> Sensor { get; set; }
    }
}
