using System.Collections.Generic;
using System.Linq;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer.Backend.Memory
{
    public class ProjectMemoryBackend : IProjectBackend
    {
        public List<Project> InternalProjects;

        public ProjectMemoryBackend()
        {
            InternalProjects = new List<Project>();
        }

        public List<Project> GetAllProjects()
        {
            return InternalProjects;
        }

        public bool ProjectExists(int id)
        {
            return InternalProjects.Any(x => x.Id == id);
        }

        public Project GetProject(int id)
        {
            return InternalProjects.Single(x => x.Id == id);
        }

        public void CreateProject(Project project)
        {
            project.Id = InternalProjects.Count > 0 ? project.Id = InternalProjects.Max(x => x.Id) + 1 : project.Id = 1;
            
            InternalProjects.Add(project);
        }

        public void UpdateProject(Project updatedProject)
        {
            var index = InternalProjects.FindIndex(x => x.Id == updatedProject.Id);
            InternalProjects[index] = updatedProject;
        }

        public void DeleteProject(int id)
        {
            var projectToRemove = InternalProjects.Single(x => x.Id == id);
            InternalProjects.Remove(projectToRemove);
        }
    }
}
