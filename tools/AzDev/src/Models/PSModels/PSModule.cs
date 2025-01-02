using System.Linq;
using AzDev.Models.Inventory;

namespace AzDev.Models.PSModels
{
    public class PSModule
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public PSProject[] Project { get; set; }
        public ModuleType Type { get; set; }
        internal PSModule(Module module)
        {
            Name = module.Name;
            Path = module.Path;
            Type = module.Type;
            Project = module.Projects.Select(p => new PSProject(p)).ToArray();
        }
        internal PSModule() { }
        public override string ToString() => Name;
    }
}
