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
    public class ProjectEditPostTests : ProjectTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            ProjectMemoryBackend = new ProjectMemoryBackend();
            ProjectLogic = new ProjectLogic(ProjectMemoryBackend);
            ProjectsController = new ProjectsController(ProjectLogic);
        }

        [TestMethod]
        public void WhenEditingAProjectThatDoesNotExistThenTheReturnedDescriptionShouldBeProjectDoesNotExist()
        {
            var result = ProjectsController.Edit(new ProjectViewModel { Id = 1, Name = "ProjectName" }) as HttpNotFoundResult;
            result.StatusDescription.Should().Be("Project does not exist");
        }

        [TestMethod]
        public void WhenEditingAProjectThenTheNameIsUpdated()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            ProjectsController.Edit(new ProjectViewModel { Id = 1, Name = "differentProjectName" });
            ProjectMemoryBackend.InternalProjects.Single(x => x.Id == 1).Name.Should().Be("differentProjectName");
        }

        [TestMethod]
        public void WhenTheProjectIsEditedTheReturnedResultShouldRedirectToIndex()
        {
            ProjectMemoryBackend.InternalProjects.Add(new Project { Id = 1, Name = "projectName" });
            var result = ProjectsController.Edit(new ProjectViewModel { Id = 1, Name = "differentProjectName" }) as RedirectToRouteResult;
            result.RouteValues["action"].Should().Be("Index");
        }
    }
}