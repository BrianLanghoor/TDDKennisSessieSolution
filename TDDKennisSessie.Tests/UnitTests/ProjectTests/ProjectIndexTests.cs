using System.Collections.Generic;
using System.Linq;
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
    public class ProjectIndexTests : ProjectTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            ProjectMemoryBackend = new ProjectMemoryBackend();
            ProjectLogic = new ProjectLogic(ProjectMemoryBackend);
            ProjectsController = new ProjectsController(ProjectLogic);
        }

        [TestMethod]
        public void WhenThereAreNoProjectsThenGetAllProjectsShouldReturnZeroProjects()
        {
            ConvertActionResultToProjectModel().Count.Should().Be(0);
        }

        [TestMethod]
        public void WhenThereIsOneProjectThenGetAllProjectsShouldReturnONeProjects()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });

            ConvertActionResultToProjectModel().Count.Should().Be(1);
        }

        [TestMethod]
        public void WhenThereFiveProjectsThenGetAllProjectsShouldReturnFiveProjects()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 2, Name = "projectName2" });
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 3, Name = "projectName3" });

            ConvertActionResultToProjectModel().Count.Should().Be(3);
        }

        [TestMethod]
        public void WhenThereIsOneProjectThenGetAllProjectsShouldReturnTheCorrespondingId()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });

            ConvertActionResultToProjectModel().First().Id.Should().Be(1);
        }

        [TestMethod]
        public void WhenThereIsOneProjectThenGetAllProjectsShouldReturnTheCorrespondingName()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });

            ConvertActionResultToProjectModel().First().Name.Should().Be("projectName");
        }

        public List<ProjectViewModel> ConvertActionResultToProjectModel()
        {
            var result = ProjectsController.Index() as ViewResult;
            var model = result.Model as List<ProjectViewModel>;
            return model;
        }
    }
}
