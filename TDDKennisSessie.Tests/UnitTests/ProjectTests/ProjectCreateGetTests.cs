using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessieAPI.Controllers;
using TDDKennisSessieDataLayer.Backend.Memory;

namespace TDDKennisSessie.Tests.UnitTests.ProjectTests
{
    [TestClass]
    public class ProjectCreateGetTests : ProjectTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            ProjectMemoryBackend = new ProjectMemoryBackend();
            ProjectLogic = new ProjectLogic(ProjectMemoryBackend);
            ProjectsController = new ProjectsController(ProjectLogic);
        }

        [TestMethod]
        public void WhenCallingTheCreateGetThenNoModelDataShouldBeSendToTheView()
        {
            var result = ProjectsController.Create() as ViewResult;
            result.Model.Should().BeNull();
        }

        [TestMethod]
        public void WhenCallingTheCreateGetThenTheReturnedViewShouldBeCreate()
        {
            var result = ProjectsController.Create() as ViewResult;
            result.ViewName.Should().Be("Create");
        }
    }
}
