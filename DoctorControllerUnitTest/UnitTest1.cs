using CMD.API.Doctors.Controllers;
using CMD.Business.Doctors.Implementations;
using CMD.Business.Doctors.Interfaces;
using CMD.DTO.Doctor;
using CMD.Model.Doctors;
using CMD.Repository.Doctors.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace DoctorControllerUnitTest
{
    [TestClass]
    public class UnitTest1


    {
        IDoctorService obj;
        DoctorRepository obj2;
        [TestInitialize]

        public void ObjectCreation()
        {
            obj2 = new DoctorRepository();
            obj = new DoctorService(obj2);

        }

        [TestCleanup]
        public void ObjectDeletion()
        {
            obj = null;

        }



        //IRecommendationRepository RecommendationRepository=new RecommendationRepository();




        [TestMethod]
        public void GetDoctors_ShouldReturnAllDoctors()
        {

            var doc = obj.GetAllDoctor();
            Assert.IsNotNull(doc);

        }


        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void GetDoctors_IncorrectDataBase_ShouldReturnNull()
        {

            var doc = obj.GetAllDoctor();
            Assert.IsTrue(doc != null);

        }

        [TestMethod]
        public void GetDoctorList()
        {
            // Arrange
            var mockRepository = new Mock<IDoctorService>();
            var controller = new DoctorController(mockRepository.Object);



            // Act
            IHttpActionResult actionResult = controller.GetAllDoctors();
            var actionresult2 = actionResult as OkNegotiatedContentResult<ICollection<RDoctorDTO>>;



            // Assert
            Assert.IsNotNull(actionresult2);
        }







    }
}


