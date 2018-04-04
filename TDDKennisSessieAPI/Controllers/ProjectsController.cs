using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TDDKennisSessie.Logic;
using TDDKennisSessie.Models;
using TDDKennisSessieAPI.Models;

namespace TDDKennisSessieAPI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectLogic _projectLogic;

        public ProjectsController(ProjectLogic projectLogic)
        {
            _projectLogic = projectLogic;
        }

        public ActionResult Index()
        {
            return View(GetAllProjects());
        }

        public ActionResult Details(int id)
        {
            if (!_projectLogic.ProjectExists(id)) return HttpNotFound("Project does not exist");

            return View(GetProject(id));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return View(projectViewModel);

            _projectLogic.CreateProject(new ProjectModel { Name = projectViewModel.Name });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (!_projectLogic.ProjectExists(id)) return HttpNotFound("Project does not exist");

            return View(GetProject(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return View(projectViewModel);

            if (!_projectLogic.ProjectExists(projectViewModel.Id)) return HttpNotFound("Project does not exist");

            _projectLogic.UpdateProject(new ProjectModel { Id = projectViewModel.Id, Name = projectViewModel.Name });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (!_projectLogic.ProjectExists(id)) return HttpNotFound("Project does not exist");

            return View(GetProject(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!_projectLogic.ProjectExists(id)) return HttpNotFound("Project does not exist");

            _projectLogic.DeleteProject(id);
            return RedirectToAction("Index");
        }

        private ProjectViewModel GetProject(int id)
        {
            var project = _projectLogic.GetProject(id);
            return new ProjectViewModel { Id = project.Id, Name = project.Name };
        }

        private List<ProjectViewModel> GetAllProjects()
        {
            var projects = _projectLogic.GetAllProjects();
            return projects.Select(project => new ProjectViewModel { Id = project.Id, Name = project.Name }).ToList();
        }
    }
}