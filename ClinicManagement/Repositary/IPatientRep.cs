using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Repositary
{
    public interface IPatientRep
    {
        public List<Patient> GetDetails();
        public Patient GetDetail(int id);
        public int AddDetail(Patient pat);
        public int UpdateDetail(int id, Patient pat);
        public int Delete(int id);
    }
}
