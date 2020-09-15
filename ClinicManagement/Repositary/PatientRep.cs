using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Repositary
{
    public class PatientRep :IPatientRep
    {
       private readonly ClinicContext db;
        public PatientRep(ClinicContext _db)
        {
            db = _db;
        }


        public int AddDetail(Patient pat)
        {
            db.Patients.Add(pat);
            db.SaveChanges();

            return pat.PatientId;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Patients.FirstOrDefault(x => x.PatientId == id);

                if (post != null)
                {

                    db.Patients.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;
        }

        public Patient GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Patients.Where(x => x.PatientId == id)).FirstOrDefault();
            }
            return null;
        }

        public List<Patient> GetDetails()
        {
            return db.Patients.ToList();

        }
        public int UpdateDetail(int id, Patient pat)
        {
            if (db != null)
            {
                var obj = (db.Patients.Where(x => x.PatientId == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = pat.Name;
                    obj.Email = pat.Email;
                    obj.Password = pat.Password;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }
    }

  
}
