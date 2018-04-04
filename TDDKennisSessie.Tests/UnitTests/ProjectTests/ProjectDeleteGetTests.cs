using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.Logic;
using TDDKennisSessieAPI.Controllers;
using TDDKennisSessieAPI.Models;
using TDDKennisSessieDataLayer.Backend.Memory;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Tests.UnitTests.ProjectTests
{
    [TestClass]
    public class ProjectDeleteGetTests : ProjectTestBase
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
            var result = ProjectsController.Delete(1) as HttpNotFoundResult;
            result.StatusDescription.Should().Be("Project does not exist");
        }

        [TestMethod]
        public void WhenTheProjectExistsThenTheProjectNameIsReturned()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ConverActionResultToProjectViewModel().Name.Should().Be("projectName");
        }

        [TestMethod]
        public void WhenTheProjectExistsThenTheProjectIdIsReturned()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ConverActionResultToProjectViewModel().Id.Should().Be(1);
        }

        private ProjectViewModel ConverActionResultToProjectViewModel()
        {
            var result = ProjectsController.Delete(1) as ViewResult;
            var model = result.Model as ProjectViewModel;
            return model;
        }
    }
}
