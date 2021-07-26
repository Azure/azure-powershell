using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tools.Common.Utilities;

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

            _outputDirectories = new List<string>{ ReleaseDirectory };

            _projectDirectories = new List<string>{ Path.Combine(RootDirectory, @"src") };
        }

        public string RootDirectory { get; set; }

        public string SrcDirectory => Path.Combine(RootDirectory, @"src", ModuleNameWithoutAz);

        public string PackageDirectory => Path.Combine(RootDirectory, @"artifacts");

        public string ReleaseDirectory => Path.Combine(PackageDirectory, @"Release");

        public string ArtifactsVersionControllerDirectory => Path.Combine(PackageDirectory, @"VersionController");

        public string ExceptionsDirectory => Path.Combine(ArtifactsVersionControllerDirectory, @"Exceptions");

        public List<string> OutputDirectories => _outputDirectories;

        public List<string> ProjectDirectories => _projectDirectories;

        public string ToolsDirectory => Path.Combine(RootDirectory, @"tools");

        public string CommonToolsDirectory => Path.Combine(ToolsDirectory, @"Tools.Common");

        public string SerializedCmdletsDirectory => Path.Combine(CommonToolsDirectory, @"SerializedCmdlets");

        public string RollupModuleManifestPath => Path.Combine(ToolsDirectory, @"Az\Az.psd1");

        public string VersionControllerDirectory => Path.Combine(ToolsDirectory, @"VersionController");

        public string OutputModuleManifestPath { get; set; }

        public string OutputModuleDirectory => Directory.GetParent(OutputModuleManifestPath).FullName;

        public string OutputResourceManagerDirectory => Directory.GetParent(OutputModuleDirectory).FullName;

        public string ProjectModuleManifestPath { get; set; }

        public string ModuleFileName => Path.GetFileName(ProjectModuleManifestPath);

        public string ModuleName => ModuleFileName.Replace(".psd1", "");

        private string ModuleNameWithoutAz => ModuleName.Replace("Az.", "");

        public string ProjectDirectory => Directory.GetParent(ProjectModuleManifestPath).FullName;

        public string ChangeLogPath => Directory.GetFiles(ProjectDirectory, "ChangeLog.md").FirstOrDefault();

        public List<string> AssemblyInfoPaths => Directory.GetFiles(SrcDirectory, "AssemblyInfo.cs", SearchOption.AllDirectories)
                                                            .Where(f => !ModuleFilter.IsAzureStackModule(f) && !f.Contains(".Test"))
                                                            .ToList();

        public string GalleryModuleDirectory => OutputModuleDirectory;

        public string GalleryModuleVersionDirectory => GalleryModuleDirectory;
    }
}
