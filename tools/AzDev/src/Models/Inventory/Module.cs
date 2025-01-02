using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using AzDev.Services;

namespace AzDev.Models.Inventory
{
    internal class Module : IFileSystemBasedModel
    {
        public string Name { get; internal set; }
        public string Path { get; internal set; }
        public IEnumerable<Project> Projects { get; internal set; } = Enumerable.Empty<Project>();
        public ModuleType Type { get; internal set; }
        public string TypeDeductionReason { get; internal set; }

        protected IFileSystem FileSystem { get; }
        protected Module(IFileSystem fs, string path)
        {
            FileSystem = fs;
            Path = path;
        }
        internal Module() {}

        public static Module FromFileSystem(IFileSystem fs, string path)
        {
            Module m = new Module(fs, path)
            {
                Name = fs.Path.GetFileName(path),
                Projects = fs.Directory.GetDirectories(path)
                    .Where(dir => !Conventions.IsExcludedProjectDirectory(fs, dir, out _))
                    .Select(dir => Project.FromFileSystem(fs, dir))
            };

            (m.Type, m.TypeDeductionReason) = (Conventions.DeductModuleType(m.Projects, out string reason), reason);
            return m;
        }
    }
}
