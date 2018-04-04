using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TDDKennisSessieDataLayer.Backend.Interfaces;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer.Backend.Actual
{
    public class ProjectDatabaseBackend : IProjectBackend
    {
        private readonly DataContext _db;

        public ProjectDatabaseBackend()
        {
            _db = new DataContext();
        }

        public List<Project> GetAllProjects()
        {
            return _db.Projects.ToList();
        }

        public bool ProjectExists(int id)
        {
            return _db.Projects.Any(x => x.Id == id);
        }

        public Project GetProject(int id)
        {
            return _db.Projects.Single(x => x.Id == id);
        }

        public void CreateProject(Project project)
        {
            _db.Projects.Add(project);
            SaveChanges();
        }

        public void UpdateProject(Project updatedProject)
        {
            _db.Entry(updatedProject).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = GetProject(id);
            _db.Projects.Remove(project);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
