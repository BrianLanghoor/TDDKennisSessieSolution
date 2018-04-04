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
    public class ProjectCreatePostTests : ProjectTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            ProjectMemoryBackend = new ProjectMemoryBackend();
            ProjectLogic = new ProjectLogic(ProjectMemoryBackend);
            ProjectsController = new ProjectsController(ProjectLogic);
        }

        [TestMethod]
        public void WhenThereAreNoProjectsAndAProjectIsCreatedThenTheTotalNumberOffProjectsShouldBeOne()
        {
            ProjectsController.Create(new ProjectViewModel {Name = "projectName"});
            ProjectMemoryBackend.InternalProjects.Count.Should().Be(1);
        }

        [TestMethod]
        public void WhenAProjectExistsAndAProjectIsCreatedThenTheTotalNumberOffProjectsShouldBeTwo()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project {Id = 1, Name = "projectName1"});
            ProjectsController.Create(new ProjectViewModel { Name = "projectName2" });
            ProjectMemoryBackend.InternalProjects.Count.Should().Be(2);
        }

        [TestMethod]
        public void WhenAProjectIsCreatedThenResultShouldRedirectToTheIndexPage()
        {
            var result = ProjectsController.Create(new ProjectViewModel { Name = "projectName" }) as RedirectToRouteResult;
            result.RouteValues["action"].Should().Be("Index");
        }
    }
}
