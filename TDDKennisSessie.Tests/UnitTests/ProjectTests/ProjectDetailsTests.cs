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
    public class ProjectDetailsTests : ProjectTestBase
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
            var result = ProjectsController.Details(1) as HttpNotFoundResult;
            result.StatusDescription.Should().Be("Project does not exist");
        }

        [TestMethod]
        public void WhenTheProjectDoesExistTheNameShouldCorrespond()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ConvertActionResultToProjectModel(1).Name.Should().Be("projectName");
        }

        [TestMethod]
        public void WhenMultipleProjectsExistTheNameShouldCorrespondWithThePropperId()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 2, Name = "projectName2" });
            ConvertActionResultToProjectModel(2).Name.Should().Be("projectName2");
        }

        private ProjectViewModel ConvertActionResultToProjectModel(int id)
        {
            var result = ProjectsController.Details(id) as ViewResult;
            var model = result.Model as ProjectViewModel;
            return model;
        }
    }
}
