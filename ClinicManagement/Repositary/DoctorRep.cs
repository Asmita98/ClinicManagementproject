using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Repositary
{

    public class DoctorRep : IDoctorRep
    {
        ClinicContext db;
        public DoctorRep (ClinicContext _db)
        {
            db = _db;
        }


        public string AddDetail(Doctor doc)
        {
            db.Doctors.Add(doc);
            db.SaveChanges();

            return "added";
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Doctors.FirstOrDefault(x => x.DoctorId == id);

                if (post != null)
                {

                    db.Doctors.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;
        }

        public Doctor GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Doctors.Where(x => x.DoctorId == id)).FirstOrDefault();
            }
            return null;
        }

        public List<Doctor> GetDetails()
        {
            return db.Doctors.ToList();

        }
        public int UpdateDetail(int id, Doctor doc)
        {
            if (db != null)
            {
                var obj = (db.Doctors.Where(x => x.DoctorId == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = doc.Name;
                    obj.Email = doc.Email;
                    obj.Password = doc.Password;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }
    }
}
