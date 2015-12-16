using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Commands;
using NuGet.Configuration;
using NuGet.ProjectModel;
using NuGet.Versioning;

namespace CLU.Packages
{
    public class Logger : NuGet.Logging.ILogger
    {
        public void LogDebug(string data) { Console.WriteLine($"Debug: {data}");  }

        public void LogVerbose(string data) { Console.WriteLine($"Verbose: {data}"); }

        public void LogInformation(string data) { Console.WriteLine($"Info: {data}"); }

        public void LogWarning(string data) { Console.WriteLine($"Warning: {data}"); }

        public void LogError(string data) { Console.WriteLine($"Error: {data}"); }

    }

    public interface IPackage
    {
        string Name { get; }

        SemanticVersion Version { get; }
    }

    public interface IPackageRepository
    {
        string Path { get; }
        IPackage FindPackage(string packageName);

        IPackage FindPackage(string packageName, SemanticVersion version);

    }

    public class PackageRepository : IPackageRepository
    {
        private string _path;

        public PackageRepository(string path)
        {
            _path = path;
        }

        string IPackageRepository.Path
        {
            get
            {
                return _path;
            }
        }

        IPackage IPackageRepository.FindPackage(string packageName)
        {
            return new Package(packageName);
        }

        IPackage IPackageRepository.FindPackage(string packageName, SemanticVersion version)
        {
            return new Package(packageName, version);
        }

    }

    public class Package : IPackage
    {
        private SemanticVersion _version;
        private string _name;

        public Package(string packageName, SemanticVersion version = null)
        {
            this._name = packageName;
            this._version = version;
        }
        public string GetFullName()
        {
            return _name;
        }

        public string Name {  get { return _name;  } }

        public IEnumerable<DependencySet> DependencySets
        {
            get
            {
                // BUGBUG - we should include all dependencies for this package. Not doing this effectively 
                // means that we are killing the package refcount functionality...
                return new DependencySet[] { };
            }
        }

        SemanticVersion IPackage.Version
        {
            get
            {
                return _version;
            }
        }

        public class DependencySet
        {
            public IEnumerable<Dependency> Dependencies
            {
                get
                {
                    // BUGBUG - we should include all dependencies for this package. Not doing this effectively 
                    // means that we are killing the package refcount functionality...
                    return new Dependency[] { };
                }
            }
        }

        public class Dependency
        {
            public string Id { get { throw new System.NotImplementedException(); } }
        }
    }

    public class PackageOperationEventArgs
    {
        private Package package;

        public PackageOperationEventArgs(Package package)
        {
            this.package = package;
        }

        public Package Package
        {
            get
            {
                return this.package;
            }
        }

        public bool Cancel { get; set; }

    }



    public class PackageManager
    {
        private string _repository;
        private string _packagePath;

        public delegate void PackageOperationHandler(object sender, PackageOperationEventArgs e);

        public event PackageOperationHandler PackageInstalled;
        public event PackageOperationHandler PackageUninstalled;
        public event PackageOperationHandler PackageUninstalling;

        public PackageManager(IPackageRepository repository, string packagePath)
        {
            this._repository = repository.Path;
            this._packagePath = packagePath;
        }

        public void UninstallPackage(string name, SemanticVersion version, bool one, bool two)
        {
            var packageUninstalling = PackageUninstalling;
            if (packageUninstalling != null)
            {
                packageUninstalling(this, new PackageOperationEventArgs(new Package(name, version)));
            }

            var localPackage = Microsoft.CLU.Common.LocalPackage.Load(name);
            if (localPackage != null) 
            {
                // The full path to the package is .../pkgs/<pkg name>/<version>
                // We intend to delete the <version> part recursively (everything in this package)
                // and then delete the parent if it is now empty...
                try 
                {
                    System.IO.Directory.Delete(localPackage.FullPath, true);
                    var parentDirectory = System.IO.Directory.GetParent(localPackage.FullPath);
                    if (parentDirectory != null)
                    {
                        parentDirectory.Delete();
                    }
                }
                catch (Exception)
                {
                    // Failed to remove directory from disk...
                }
            }
            
            var packageUninstalled = PackageUninstalled;
            if (packageUninstalled != null)
            {
                packageUninstalled(this, new PackageOperationEventArgs(new Package(name, version)));
            }
        }

        private string GetDummyProject(string package, string version)
        {
            var dummyProject = "{\"dependencies\": { \"" + package + "\": \"" + version + "\"}, \"frameworks\": { \"dnxcore50\": {}}}";
            return dummyProject;
        }

        private async System.Threading.Tasks.Task<RestoreResult> InstallPackageAsync(string packageName, string version, IEnumerable<string> sources, string packageDirectory)
        {
            PackageSpec project = JsonPackageSpecReader.GetPackageSpec(GetDummyProject(packageName, version), "command.json", packageDirectory);


            var packageSources = sources.Select(s => new PackageSource(s));

            var request = new RestoreRequest(
                project,
                packageSources,
                packagesDirectory: null);

            request.PackagesDirectory = packageDirectory;
            var command = new RestoreCommand(new Logger(), request);

            var result = await command.ExecuteAsync();

            return result;
        }


        public void InstallPackage(IPackage package, bool one, bool two)
        {
            var result = InstallPackageAsync(package.Name, package.Version != null ? package.Version.ToString() : "*", new string[] { this._repository }, this._packagePath).Result;

            var packageInstalled = PackageInstalled;
            if (packageInstalled != null)
            {
                foreach (var installedLibPackage in result.GetAllInstalled())
                {
                    var installedPackage = new Package(installedLibPackage.Name, installedLibPackage.Version);
                    packageInstalled(this, new PackageOperationEventArgs(installedPackage));
                }
            }
        }


    }
}
