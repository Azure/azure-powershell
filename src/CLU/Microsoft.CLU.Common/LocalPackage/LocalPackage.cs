using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Represents details of a package exists in local file system under packages root directory.
    /// </summary>
    internal class LocalPackage
    {
        /// <summary>
        /// The base name of the package. Base name is the package name without version tag.
        /// e.g. if the FullName is Contoso.FileUtils.7.0.1 then base name is "Contoso.FileUtils"
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Full package name that includes package version tag.
        /// e.g. Contoso.FileUtils.7.0.1
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Absolute path to the package in the local file system under packages root directory.
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Backing field for Version property.
        /// </summary>
        private string _version;
        /// <summary>
        /// The version tag of the package.
        /// e.g. if the FullName of the package is Contoso.FileUtils.7.0.1 then version is "7.0.1"
        /// </summary>
        public string Version
        {
            get
            {
                if (_version == null)
                {
                    _version = FullName.Remove(0, Name.Length + 1);
                }

                return _version;
            }
        }

        /// <summary>
        /// Full path to lib directory for the current FX
        /// </summary>
        public string LibDirPath
        {
            get
            {
                return Path.Combine(FullPath, Common.Constants.LibFolder, CLUEnvironment.CLRName);
            }
        }
        /// <summary>
        /// Full path to content directory of the package.
        /// </summary>
        public string ContentDirPath
        {
            get
            {
                return Path.Combine(FullPath, Constants.ContentFolder);
            }
        }

        /// <summary>
        /// Add a reference to the package.
        /// </summary>
        public void AddReference(string referrer)
        {
            _marker.AddPackageReference(referrer);
        }

        /// <summary>
        /// Remove a reference to the package
        /// </summary>
        public void RemoveReference(string referrer)
        {
            _marker.RemovePackageReference(referrer);
        }

        /// <summary>
        /// Tells whether a package is referenced by another package or not. Used to prevent
        /// accidental removal of a dependency.
        /// </summary>
        public bool IsReferenced
        {
            get
            {
                return _marker.Exists;
            }
        }

        /// <summary>
        /// Gets all referrers for this package.
        /// </summary>
        public IEnumerable<string> Referrers
        {
            get
            {
                return _marker.PackageReferrers;
            }
        }

        /// <summary>
        /// Backing field used in LoadConfig method.
        /// </summary>
        private PackageConfig _packageConfig;
        /// <summary>
        /// Gets the package configuration associated with this package.
        /// </summary>
        public PackageConfig LoadConfig()
        {
            if (_packageConfig == null)
            {
                _packageConfig = PackageConfig.Load(FullPath);
            }

            return _packageConfig;
        }

        /// <summary>
        /// Protected constructor ensure class instances created only via
        /// LocalPackage::Load* static methods.
        /// </summary>
        protected LocalPackage(string packageBaseName, DirectoryInfo packageDirInfo)
        {
            FullName = packageBaseName + "." + packageDirInfo.Name;
            Name = packageBaseName;
            FullPath = packageDirInfo.FullName;
            _marker = new PackageMarker(packageDirInfo.FullName);
        }

        /// <summary>
        /// Enumerates all the installed packages. 
        /// </summary>
        /// <param name="packagesRootPath"></param>
        /// <returns></returns>
        public static IEnumerable<LocalPackage> FindInstalledPackages(string packagesRootPath)
        {
            Func<DirectoryInfo,LocalPackage> getBaseNameFromFullName = d => 
                {
                    // Find the third period from the end.
                    var name = d.Name;
                    int separator = -1;
                    for (int i = name.Length-1,count = 0; i >= 0; --i)
                    {
                        if (name[i] == '.') count += 1;
                        if (count == 3)
                        {
                            separator = i;
                            break;
                        }
                    }
                    return (separator > 0) ? Load(packagesRootPath, name.Substring(0, separator)) : null;
                };

            var dir = new DirectoryInfo(packagesRootPath);
            return dir.EnumerateDirectories().Select(getBaseNameFromFullName).Where(pkg => pkg != null);
        }

        /// <summary>
        /// Gets LocalPackage instance describing an existing package identified by
        /// the 'name' parameter, stored under 'packagesRootPath' in the local file
        /// system.
        /// </summary>
        /// <param name="packagesRootPath">Path to packages root directory</param>
        /// <param name="packageBaseName">The base name of the package, i.e. the name without version number</param>
        /// <returns>A local package object representing the package.</returns>
        /// <remarks>This method returns null if package not exists under 'packagesRootPath'.</remarks>
        public static LocalPackage Load(string packagesRootPath, string packageBaseName)
        {
            var packageDirInfo = FindExistingPackage(packagesRootPath, packageBaseName);
            if (packageDirInfo == null)
            {
                return null;
            }

            return new LocalPackage(packageBaseName, packageDirInfo);
        }

        /// <summary>
        /// Load LocalPackage instance describing an existing package in the local file system identified
        /// by the name parameter.
        /// </summary>
        /// <param name="packageBaseName">The base name of the package, i.e. the name without version number</param>
        /// <returns>A local package object representing the package.</returns>
        /// <remarks>This method returns null if package not exists locally.</remarks>
        public static LocalPackage Load(string packageBaseName)
        {
            return Load(CLUEnvironment.GetPackagesRootPath(), packageBaseName);
        }

        /// <summary>
        /// Loads a LocalPackage instance which will contains Cmdlets.
        /// </summary>
        /// <param name="packagesRootPath">Path to packages root directory</param>
        /// <param name="packageBaseName">he base name of the package, i.e. the name without version number</param>
        /// <returns>A local package object representing the package</returns>
        public static CmdletLocalPackage LoadCmdletPackage(string packagesRootPath, string packageBaseName)
        {
            var packageDirInfo = FindExistingPackage(packagesRootPath, packageBaseName);
            if (packageDirInfo == null)
            {
                return null;
            }

            return new CmdletLocalPackage(packageBaseName, packageDirInfo);
        }

        /// <summary>
        /// Loads a LocalPackage instance which will contains Cmdlets.
        /// </summary>
        /// <param name="packageBaseName">he base name of the package, i.e. the name without version number</param>
        /// <returns>A local package object representing the package</returns>
        public static CmdletLocalPackage LoadCmdletPackage(string packageBaseName)
        {
            return LoadCmdletPackage(CLUEnvironment.GetPackagesRootPath(), packageBaseName);
        }

        /// <summary>
        /// Load and return reference to the default package assembly. A package may contains multiple
        /// assemblies, for e.g. assemblies with command implementations, assembly with name same as
        /// the package and more. This method loads the one with name same as package (if exists).
        /// </summary>
        /// <returns></returns>
        public PackageAssembly LoadDefaultAssembly()
        {
            using (AssemblyResolver resolver = new AssemblyResolver(new string[] { CLUEnvironment.GetRootPath() }, true))
            {
                return LoadDefaultAssembly(resolver);
            }
        }

        /// <summary>
        /// Backing field used in LoadDefaultAssembly method.
        /// </summary>
        private PackageAssembly _defaultPackageAssembly;
        /// <summary>
        /// Load and return reference to the default package assembly. A package may contains multiple
        /// assemblies, for e.g. assemblies with command implementations, assembly with name same as
        /// the package and more. This method loads the one with name same as package (if exists).
        /// </summary>
        /// <param name="resolver">Assembly resolver instance</param>
        /// <returns></returns>
        public PackageAssembly LoadDefaultAssembly(AssemblyResolver resolver)
        {
            if (_defaultPackageAssembly == null)
            {
                string assemblyPath = null;
                var commandAssemblies = LoadConfig().CommandAssemblies;
                if (commandAssemblies != null && commandAssemblies.Count() > 0)
                {
                    var searchDirs = new string[] { FullPath };
                    var assemblyName = Name + ".dll";
                    assemblyPath = commandAssemblies
                        .Where(cmdAsmPath => cmdAsmPath.EndsWith(assemblyName, StringComparison.OrdinalIgnoreCase))
                        .Select(defaultAsmPath => resolver.Resolve(searchDirs, defaultAsmPath))
                        .FirstOrDefault(path => path != null);
                }

                Assembly assembly = assemblyPath != null ? resolver.Load(assemblyPath) : null;


                _defaultPackageAssembly = new PackageAssembly(Name, assembly, assemblyPath);
            }

            return _defaultPackageAssembly;
        }
        /// <summary>
        /// Load an assembly in the package and returns an instance of PackageAssembly.
        /// </summary>
        /// <param name="assemblyName">Relative path or name of the assembly file, with extension</param>
        /// <returns></returns>
        public PackageAssembly LoadAssembly(string assemblyName)
        {
            using (AssemblyResolver resolver = new AssemblyResolver(new string[] { CLUEnvironment.GetRootPath() }, true))
            {
                return LoadAssembly(assemblyName, resolver);
            }
        }

        /// <summary>
        /// Load an assembly in the package and returns an instance of PackageAssembly.
        /// </summary>
        /// <param name="assemblyName">Relative path or name of the assembly file, with extension</param>
        /// <param name="resolver">Assembly resolver instance</param>
        /// <returns></returns>
        public PackageAssembly LoadAssembly(string assemblyName, AssemblyResolver resolver)
        {
            var assemblyPath = resolver.Resolve(new string[] { LibDirPath }, assemblyName);
            return new PackageAssembly(assemblyName, resolver.Load(assemblyPath), assemblyPath);
        }

        /// <summary>
        /// Load and returns collection of PackageAssembly identified by the configuration entry 'CommandAssemblies'
        /// in package.cfg config file. The assemblies will be searched recursively under the current package
        /// root directory.
        /// </summary>
        /// <returns>
        /// Collection of CommandAssembly instances.
        /// Note: If an assembly cannot be located then corrosponding item in the collection will have null value
        /// for Assembly property
        /// </returns>
        public IEnumerable<PackageAssembly> LoadCommandAssemblies()
        {
            using (AssemblyResolver resolver = new AssemblyResolver(new string[] { CLUEnvironment.GetRootPath() }, true))
            {
                return LoadCommandAssemblies(resolver);
            }
        }

        /// <summary>
        /// Load and returns collection of PackageAssembly identified by the configuration entry 'CommandAssemblies'
        /// in package.cfg config file. The assemblies will be searched recursively under the current package
        /// root directory.
        /// </summary>
        /// <param name="resolver">Assembly resolver instance</param>
        /// <returns>
        /// Collection of CommandAssembly instances.
        /// Note: If an assembly cannot be located then corrosponding item in the collection will have null value
        /// for Assembly property
        /// </returns>
        public IEnumerable<PackageAssembly> LoadCommandAssemblies(AssemblyResolver resolver)
        {
            var commandAssemblies = LoadConfig().CommandAssemblies;

            if (commandAssemblies != null && commandAssemblies.Count() > 0)
            {
                var searchDirs = new string[] { Path.Combine(FullPath, Common.Constants.LibFolder, CLUEnvironment.CLRName) };
                var commandAssemblyPaths = commandAssemblies.Select(cmdAsmPath =>
                    new KeyValuePair<string, string>(cmdAsmPath, resolver.Resolve(searchDirs, cmdAsmPath)));

                return commandAssemblyPaths.Select(resolvedCmdAsmPath =>
                    new PackageAssembly(resolvedCmdAsmPath.Key, resolver.Load(resolvedCmdAsmPath.Value), resolvedCmdAsmPath.Value));
            }
            return new List<PackageAssembly>();
        }

#if PSCMDLET_HELP
        /// <summary>
        /// Loads the name mapping rules defined in this package.
        /// </summary>
        /// <returns>The name mapping</returns>
        public ConfigurationDictionary LoadNameMapping()
        {
           return ConfigurationDictionary.Load(Path.Combine(FullPath, Constants.IndexFolder, Constants.NameMappingFileName));
        }
#endif 

        /// <summary>
        /// Locate an existing package in the local file system under the given packages root directory.
        /// </summary>
        /// <param name="packagesRootPath">The packages root path</param>
        /// <param name="packageBaseName">The base name of the package, i.e. the name without version number </param>
        /// <returns></returns>
        private static DirectoryInfo FindExistingPackage(string packagesRootPath, string packageBaseName)
        {
            string packagePath = System.IO.Path.Combine(packagesRootPath, packageBaseName);
            if (!Directory.Exists(packagePath))
            {
                return null;
            }
            return Directory.
                EnumerateDirectories(packagePath).
                Select(d => new DirectoryInfo(d)).
                FirstOrDefault();
        }

#region Private fields

        private PackageMarker _marker;

#endregion
    }
}