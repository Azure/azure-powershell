using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using AzDev.Services;

namespace AzDev.Models.Inventory
{
    internal class Codebase : IFileSystemBasedModel
    {
        public string Path { get; internal set; }
        public IEnumerable<Module> Modules { get; internal set; }

        internal static Codebase FromFileSystem(IFileSystem fs, string path)
        {
            return new Codebase()
            {
                Path = path,
                Modules = fs.Directory.GetDirectories(path)
                    .Where(dir => !Conventions.IsExcludedModuleDirectory(dir))
                    .Select(dir => Module.FromFileSystem(fs, dir))
                    .Where(module => module != null)
            };
        }
    }
}
