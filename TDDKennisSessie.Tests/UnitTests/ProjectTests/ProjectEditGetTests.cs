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
    public class ProjectEditGetTests : ProjectTestBase
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
            var result = ProjectsController.Edit(1) as HttpNotFoundResult;
            result.StatusDescription.Should().Be("Project does not exist");
        }

        [TestMethod]
        public void WhenTheProjectDoesExistTheIdShouldCorrespond()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project {Id = 1, Name = "projectName1"});
            ConvertActionResultToProjectModel(1).Id.Should().Be(1);
        }

        [TestMethod]
        public void WhenTheProjectDoesExistTheNameShouldCorrespond()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName1" });
            ConvertActionResultToProjectModel(1).Name.Should().Be("projectName1");
        }

        public ProjectViewModel ConvertActionResultToProjectModel(int id)
        {
            var result = ProjectsController.Edit(id) as ViewResult;
            var model = result.Model as ProjectViewModel;
            return model;
        }
    }
}
