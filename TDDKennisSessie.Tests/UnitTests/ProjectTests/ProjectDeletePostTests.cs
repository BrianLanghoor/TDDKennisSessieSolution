using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessieAPI.Controllers;
using TDDKennisSessieDataLayer.Backend.Memory;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Tests.UnitTests.ProjectTests
{
    [TestClass]
    public class ProjectDeletePostTests : ProjectTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            ProjectMemoryBackend = new ProjectMemoryBackend();
            ProjectLogic = new ProjectLogic(ProjectMemoryBackend);
            ProjectsController = new ProjectsController(ProjectLogic);
        }

        [TestMethod]
        public void WhenTheProjectDoesNotExistTheResultShouldGiveAnError()
        {
            var result = ProjectsController.DeleteConfirmed(1) as HttpNotFoundResult;
            result.StatusDescription.Should().Be("Project does not exist");
        }

        [TestMethod]
        public void WhenRemovingTheProjectThenThereShouldBeNoProjectsLeft()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ProjectsController.DeleteConfirmed(1);
            ProjectMemoryBackend.InternalProjects.Count.Should().Be(0);
        }

        [TestMethod]
        public void WhenMultipleProjectsExistRemovingASingleProjectThenThereShouldBeOneProjectsLeft()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 2, Name = "projectName2" });
            ProjectsController.DeleteConfirmed(1);
            ProjectMemoryBackend.InternalProjects.Count.Should().Be(1);
        }

        [TestMethod]
        public void WhenRemovingTheProjectThenTheReturnedActionShouldBeIndex()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            var result = ProjectsController.DeleteConfirmed(1) as RedirectToRouteResult;
            result.RouteValues["action"].Should().Be("Index");
        }
    }
}