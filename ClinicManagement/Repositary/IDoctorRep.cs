using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Repositary
{
   public interface IDoctorRep
    {
        public List<Doctor> GetDetails();

        public Doctor GetDetail(int id);

        public String AddDetail(Doctor doc);

        public int UpdateDetail(int id, Doctor doc);

        public int Delete(int id);


    }
}
