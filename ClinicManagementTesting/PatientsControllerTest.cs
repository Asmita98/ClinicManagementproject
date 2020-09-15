using Clinic_Management.Controller;
using ClinicManagement.Models;
using ClinicManagement.Repositary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicManagementTesting
{
    class PatientsControllerTest
    {
        ClinicContext db;
        [SetUp]
        public void Setup()
        {
            var doc = new List<Patient>
            {
                new Patient{PatientId=1,Name="Dummy 1",Email="DD1",Password="12"},
                new Patient{PatientId=2,Name="Dummy 2",Email="DD2",Password="23"},
                new Patient{PatientId=3,Name="Dummy 3",Email="DD3",Password="34"}

            };

            var docdata = doc.AsQueryable();
            var mockSet = new Mock<DbSet<Patient>>();
            mockSet.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(docdata.Provider);
            mockSet.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(docdata.Expression);
            mockSet.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(docdata.ElementType);
            mockSet.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(docdata.GetEnumerator());

            var mockContext = new Mock<ClinicContext>();
            mockContext.Setup(c => c.Patients).Returns(mockSet.Object);
            db = mockContext.Object;

        }

        [Test]
        public void GetDetailsTest()
        {
            var res = new Mock<PatientRep>(db);
            PatientsController obj = new PatientsController(res.Object);
            var data = obj.Get();
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [Test]
        public void Add_Valid_Detail()
        {
            var res = new Mock<PatientRep>(db);
            PatientsController obj = new PatientsController(res.Object);
            Patient doc = new Patient { PatientId= 4,Name = "Dummy 4", Email = "DD@gmail.com", Password = "12" };

            var data = obj.Post(doc);
            var okResult = data as ObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);


        }



        [Test]
            public void GetDetail()
        {
           var res = new Mock<PatientRep>(db);
            
                PatientsController obj = new PatientsController(res.Object);
            var data = obj.Get(1);
            var okResult = data as ObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }



        [Test]
        public void Update_Valid_Detail()
        {

            Patient doc = new Patient { Name = "Dummy 3", Email = "DD", Password = "12" };
            var res = new Mock<PatientRep>(db);
                PatientsController obj = new PatientsController(res.Object);
            var data = obj.Put(1, doc);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [Test]
        public void Delete_Valid_Detail()
        {
            var loandata = new Mock<PatientRep>(db);
                PatientsController obj = new PatientsController(loandata.Object);
            var data = obj.Delete(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}
    

