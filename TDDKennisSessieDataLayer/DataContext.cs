using System.Data.Entity;
using TDDKennisSessieDataLayer.DBModels;

namespace TDDKennisSessieDataLayer
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataContext() : base("name=DataContext")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
