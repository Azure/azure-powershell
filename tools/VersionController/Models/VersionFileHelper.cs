using System.Collections.Generic;
using System.IO;
using System.Linq;
<<<<<<< HEAD
=======
using Tools.Common.Utilities;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
            _outputDirectories = new List<string>{ DebugDirectory };

            _projectDirectories = new List<string>{ SrcDirectory };
=======
            _outputDirectories = new List<string>{ ReleaseDirectory };

            _projectDirectories = new List<string>{ Path.Combine(RootDirectory, @"src") };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public string RootDirectory { get; set; }

<<<<<<< HEAD
        public string SrcDirectory => Path.Combine(RootDirectory, @"src");

        public string PackageDirectory => Path.Combine(RootDirectory, @"artifacts");

        public string DebugDirectory => Path.Combine(PackageDirectory, @"Debug");
=======
        public string SrcDirectory => Path.Combine(RootDirectory, @"src", ModuleNameWithoutAz);

        public string PackageDirectory => Path.Combine(RootDirectory, @"artifacts");

        public string ReleaseDirectory => Path.Combine(PackageDirectory, @"Release");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
=======
        private string ModuleNameWithoutAz => ModuleName.Replace("Az.", "");

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string ProjectDirectory => Directory.GetParent(ProjectModuleManifestPath).FullName;

        public string ChangeLogPath => Directory.GetFiles(ProjectDirectory, "ChangeLog.md").FirstOrDefault();

<<<<<<< HEAD
        public List<string> AssemblyInfoPaths => Directory.GetFiles(ProjectDirectory, "AssemblyInfo.cs", SearchOption.AllDirectories)
                                                            .Where(f => !f.Contains("Stack") && !f.Contains(".Test"))
                                                            .ToList();

        public string GalleryModuleDirectory => Path.Combine(OutputModuleDirectory, ModuleName);

        public string GalleryModuleVersionDirectory => Directory.GetDirectories(GalleryModuleDirectory).FirstOrDefault();
=======
        public List<string> AssemblyInfoPaths => Directory.GetFiles(SrcDirectory, "AssemblyInfo.cs", SearchOption.AllDirectories)
                                                            .Where(f => !ModuleFilter.IsAzureStackModule(f) && !f.Contains(".Test"))
                                                            .ToList();

        public string GalleryModuleDirectory => OutputModuleDirectory;

        public string GalleryModuleVersionDirectory => GalleryModuleDirectory;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
