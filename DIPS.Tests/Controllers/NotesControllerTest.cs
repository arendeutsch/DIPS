using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DIPS.Models;
using System.Collections.Generic;
using DIPS.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;

namespace DIPS.Tests.Controllers
{
    [TestClass]
    public class NotesControllerTest
    {
        private Mock<IRepository> _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new Mock<IRepository>();
        }

        [TestMethod]
        public void GetReturnsNoteWithSameId()
        {
            //Arrange
            _repo.Setup(n => n.getNoteById(2)).Returns(new Note { Id = 2 });

            var controller = new NotesController(_repo.Object);

            //Act
            IHttpActionResult actionResult = controller.Get(2);
            var contentResult = actionResult as OkNegotiatedContentResult<Note>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Id);
        }

        [TestMethod]
        public void PostSetsLocationHeader()
        {
            //Arrange
            var controller = new NotesController(_repo.Object);

            //Act
            IHttpActionResult actionResult = controller.Post(new Note { Id = 4, Name = "File 4", Text = "Mocking file 4" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Note>;

            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(4, createdResult.RouteValues["id"]);

        }

        [TestMethod]
        public void PutReturnsContentResult()
        {
            //Arrange
            var controller = new NotesController(_repo.Object);
            _repo.Setup(n => n.getNoteById(3)).Returns(new Note { Id = 3 });           

            //Act
            IHttpActionResult actionResult = controller.Put(3, new Note { Name = "test2", Text = "just a test"});
            var contentResult = actionResult as NegotiatedContentResult<Note>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.OK, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Id);
        }
    }
}
