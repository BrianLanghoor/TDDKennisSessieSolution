using System.Collections.Generic;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer.Backend.Interfaces
{
    public interface IProjectBackend
    {
        List<Project> GetAllProjects();
        bool ProjectExists(int id);
        Project GetProject(int id);
        void CreateProject(Project project);
        void UpdateProject(Project updatedProject);
        void DeleteProject(int id);
    }
}