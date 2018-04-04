using TDDKennisSessie.Logic;
using TDDKennisSessieAPI.Controllers;
using TDDKennisSessieDataLayer.Backend.Memory;

namespace TDDKennisSessie.Tests.UnitTests.ProjectTests
{
    public class ProjectTestBase
    {
        public ProjectsController ProjectsController;
        public ProjectLogic ProjectLogic;
        public ProjectMemoryBackend ProjectMemoryBackend;
    }
}