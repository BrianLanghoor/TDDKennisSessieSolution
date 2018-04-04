using System.Collections.Generic;
using System.Linq;
using TDDKennisSessie.Models;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessie.Logic
{
    public class ProjectLogic
    {
        private readonly IProjectBackend _projectBackend;

        public ProjectLogic(IProjectBackend projectBackend)
        {
            _projectBackend = projectBackend;
        }

        public List<ProjectModel> GetAllProjects()
        {
            var dbProjects = _projectBackend.GetAllProjects();
            return dbProjects.Select(project => new ProjectModel { Id = project.Id, Name = project.Name }).ToList();
        }

        public bool ProjectExists(int id)
        {
            return _projectBackend.ProjectExists(id);
        }

        public ProjectModel GetProject(int id)
        {
            var project = _projectBackend.GetProject(id);
            return new ProjectModel { Id = project.Id, Name = project.Name };
        }

        public void CreateProject(ProjectModel projectModel)
        {
            _projectBackend.CreateProject(new Project { Name = projectModel.Name });
        }

        public void UpdateProject(ProjectModel projectModel)
        {
            _projectBackend.UpdateProject(new Project { Id = projectModel.Id, Name = projectModel.Name });
        }

        public void DeleteProject(int id)
        {
            _projectBackend.DeleteProject(id);
        }
    }
}