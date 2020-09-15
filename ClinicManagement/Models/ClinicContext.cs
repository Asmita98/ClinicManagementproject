using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{
    public class ClinicContext:DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)

        { }
        public ClinicContext()
        { }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
