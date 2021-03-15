using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VersionController.Models
{
    public class VersionFileHelper
    {
        private List<string> _outputDirectories;
        private List<string> _projectDirectories;

        public VersionFileHelper(string rootDirectory, string outputModuleManifestPath, string projectModuleManifestPath)
        {
            RootDirectory = rootDirectory;
            OutputModuleManifestPath = outputModuleManifestPath;
            ProjectModuleManifestPath = projectModuleManifestPath;

            _outputDirectories = new List<string>
            {
                Path.Combine(ReleaseDirectory, @"ResourceManager\AzureResourceManager\"),
                Path.Combine(ReleaseDirectory, @"ServiceManagement\"),
                Path.Combine(ReleaseDirectory, @"Storage\")
            };

            _projectDirectories = new List<string>
            {
                Path.Combine(SrcDirectory, @"ResourceManager\"),
                Path.Combine(SrcDirectory, @"ServiceManagement\"),
                Path.Combine(SrcDirectory, @"Storage\")
            };
        }

        public string RootDirectory { get; set; }

        public string SrcDirectory => Path.Combine(RootDirectory, @"src");

        public string PackageDirectory => Path.Combine(SrcDirectory, @"Package");

        public string DebugDirectory => Path.Combine(PackageDirectory, @"Debug");

        public string ReleaseDirectory => Path.Combine(PackageDirectory, @"Release");

        public string ExceptionsDirectory => Path.Combine(PackageDirectory, @"Exceptions");

        public List<string> OutputDirectories => _outputDirectories;

        public List<string> ProjectDirectories => _projectDirectories;

        public string ToolsDirectory => Path.Combine(RootDirectory, @"tools");

        public string CommonToolsDirectory => Path.Combine(ToolsDirectory, @"Tools.Common");

        public string SerializedCmdletsDirectory => Path.Combine(CommonToolsDirectory, @"SerializedCmdlets");

        public string RollupModuleManifestPath => Path.Combine(ToolsDirectory, @"AzureRM\AzureRM.psd1");

        public string VersionControllerDirectory => Path.Combine(ToolsDirectory, @"VersionController");

        public string OutputModuleManifestPath { get; set; }

        public string OutputModuleDirectory => Directory.GetParent(OutputModuleManifestPath).FullName;

        public string OutputResourceManagerDirectory => Directory.GetParent(OutputModuleDirectory).FullName;

        public string ProjectModuleManifestPath { get; set; }

        public string ModuleFileName => Path.GetFileName(ProjectModuleManifestPath);

        public string ModuleName => ModuleFileName.Replace(".psd1", "");

        public string ProjectDirectory => Directory.GetParent(ProjectModuleManifestPath).FullName;

        public string ChangeLogPath => Directory.GetFiles(ProjectDirectory, "ChangeLog.md").FirstOrDefault();

        public List<string> AssemblyInfoPaths => Directory.GetFiles(ProjectDirectory, "AssemblyInfo.cs", SearchOption.AllDirectories)
                                                            .Where(f => !f.Contains("Stack") && !f.Contains(".Test"))
                                                            .ToList();

        public string GalleryModuleDirectory => Path.Combine(OutputModuleDirectory, ModuleName);

        public string GalleryModuleVersionDirectory => Directory.GetDirectories(GalleryModuleDirectory).FirstOrDefault();
    }
}
