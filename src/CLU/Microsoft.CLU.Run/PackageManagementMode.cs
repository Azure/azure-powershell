using CLU.Packages;

using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;

using NuGet.Versioning;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Run
{
    /// <summary>
    /// The "IRunMode" implementation for package management.
    /// </summary>
    internal class PackageManagementMode : IRunMode
    {
        /// <summary>
        /// Check if this IRunMode implementation for package management can handle the arguments.
        /// </summary>
        /// <param name="arguments">The argument to inspect to see implementation can handle it</param>
        /// <returns>True, if arguments can be handled, False otherwise</returns>
        public bool CanHandle(string[] arguments)
        {
            return _options.ContainsKey(arguments[0]);
        }

        /// <summary>
        /// Run a command that is identified by the arguments and supported by this
        /// IRunMode implementation for package managment.
        /// </summary>
        /// <param name="arguments">The arguments</param>
        public Microsoft.CLU.CommandModelErrorCode Run(string[] arguments)
        {
            _packagesRootPath = CLUEnvironment.GetPackagesRootPath();
            try
            {
                _runtimeConfiguration = CLUEnvironment.RuntimeConfig;
            }
            catch (TargetInvocationException tie)
            {
                CLUEnvironment.Console.WriteErrorLine(tie.InnerException.Message);
                CLUEnvironment.Console.WriteDebugLine($"{tie.InnerException.GetType().FullName}\n{tie.InnerException.StackTrace}");
                return Microsoft.CLU.CommandModelErrorCode.InternalFailure;
            }
            catch (Exception exc)
            {
                CLUEnvironment.Console.WriteErrorLine(exc.Message);
                CLUEnvironment.Console.WriteDebugLine($"{exc.GetType().FullName}\n{exc.StackTrace}");
                return Microsoft.CLU.CommandModelErrorCode.InternalFailure;
            }

            try
            {
                _repository = new PackageRepository(_runtimeConfiguration.RepositoryPath);
                _manager = new PackageManager(_repository, _packagesRootPath);
                _manager.PackageInstalled += PackageInstalled;
                _manager.PackageUninstalling += PackageUninstalling;
                _manager.PackageUninstalled += PackageUninstalled;

                try
                {
                    if (arguments.Length > 0)
                    {
                        int argsBase = 0;

                        string version = null;

                        switch (arguments[argsBase])
                        {
                            case "--version":
                            case "-v":
                                if (argsBase + 1 >= arguments.Length ||
                                    arguments[argsBase + 1].StartsWith("-", StringComparison.Ordinal))
                                {
                                    CLUEnvironment.Console.WriteLine(Strings.PackageManagementMode_Run_VersionIdMissing);
                                    return Microsoft.CLU.CommandModelErrorCode.MissingParameters;
                                }
                                version = arguments[argsBase + 1];
                                argsBase += 2;
                                break;
                        }

                        int selectedOption = _options[arguments[argsBase]];
                        bool packageNamesFound = arguments.Length > argsBase + 1;

                        switch (selectedOption)
                        {
                            case 0:
                                if (packageNamesFound)
                                {
                                    for (int i = argsBase + 1; i < arguments.Length; ++i)
                                    {
                                        Install(arguments[i], version);
                                    }
                                }
                                else
                                {
                                    _runtimeConfiguration.RuntimeVersion = version;
                                    Install(_runtimeConfiguration.RuntimePackage, _runtimeConfiguration.RuntimeVersion);
                                }
                                break;
                            case 1:
                                if (packageNamesFound)
                                {
                                    for (int i = argsBase + 1; i < arguments.Length; ++i)
                                    {
                                        Remove(arguments[i], version);
                                    }
                                }
                                else
                                {
                                    _runtimeConfiguration.RuntimeVersion = version;
                                    Remove(_runtimeConfiguration.RuntimePackage, _runtimeConfiguration.RuntimeVersion);
                                }
                                break;
                            case 2:
                                if (packageNamesFound)
                                {
                                    for (int i = argsBase + 1; i < arguments.Length; ++i)
                                    {
                                        Upgrade(arguments[i], version);
                                    }
                                }
                                else
                                {
                                    _runtimeConfiguration.RuntimeVersion = version;
                                    Upgrade(_runtimeConfiguration.RuntimePackage, _runtimeConfiguration.RuntimeVersion);
                                }
                                break;
                        }
                    }
                }
                finally
                {
                    _manager.PackageInstalled -= PackageInstalled;
                    _manager.PackageUninstalling -= PackageUninstalling;
                    _manager.PackageUninstalled -= PackageUninstalled;
                }
            }
            catch (TargetInvocationException tie)
            {
                CLUEnvironment.Console.WriteErrorLine(tie.InnerException.Message);
                CLUEnvironment.Console.WriteDebugLine($"{tie.InnerException.GetType().FullName}\n{tie.InnerException.StackTrace}");
                return Microsoft.CLU.CommandModelErrorCode.InternalFailure;
            }
            catch (Exception exc)
            {
                CLUEnvironment.Console.WriteErrorLine(exc.Message);
                CLUEnvironment.Console.WriteDebugLine($"{exc.GetType().FullName}\n{exc.StackTrace}");
                return Microsoft.CLU.CommandModelErrorCode.InternalFailure;
            }

            return CommandModelErrorCode.Success;
        }

        /// <summary>
        /// Nuget.PackageManager.PackageUninstalled event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackageUninstalled(object sender, PackageOperationEventArgs e)
        {
            var package = e.Package.GetFullName().Split(' ');
            var packageName = package[0];

            CLUEnvironment.Console.WriteLine(string.Format(Strings.PackageManagementMode_PackageUninstalled_PackageRemoved, packageName));
        }

        /// <summary>
        /// Nuget.PackageManager.PackageUninstalling event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackageUninstalling(object sender, PackageOperationEventArgs e)
        {
            var package = e.Package.GetFullName().Split(' ');
            var packageName = package[0];

            var existingPackage = Common.LocalPackage.Load(packageName);

            if (existingPackage == null)
                return;

            if (existingPackage.IsReferenced)
            {
                e.Cancel = true;
                CLUEnvironment.Console.WriteWarningLine(string.Format(Strings.PackageManagementMode_PackageUninstalling_CannotRemoveInUsePackage, packageName, string.Join(", ", existingPackage.Referrers)));
                return;
            }

            foreach (var depSet in e.Package.DependencySets)
            {
                foreach (var dep in depSet.Dependencies)
                {
                    var pkg = Common.LocalPackage.Load(dep.Id);
                    pkg.RemoveReference(packageName);
                }
            }

            RemoveScripts(existingPackage);

            IndexBuilder.RemoveIndexes(existingPackage);
        }

        /// <summary>
        /// Nuget.PackageManager.PackageInstalled event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackageInstalled(object sender, PackageOperationEventArgs e)
        {
            var package = e.Package.GetFullName().Split(' ');
            var packageName = package[0];

            var localPackage = Common.LocalPackage.Load(packageName);
            var packageConfig = localPackage.LoadConfig();

            if (packageConfig == null)
            {
                CLUEnvironment.Console.WriteErrorLine(string.Format(Strings.PackageManagementMode_PackageInstalled_PackageConfigNotFound, packageName));
                RemoveExistingPackage(localPackage);
                return;
            }

            foreach (var depSet in e.Package.DependencySets)
            {
                foreach (var dep in depSet.Dependencies)
                {
                    var pkg = Common.LocalPackage.Load(dep.Id);
                    pkg.AddReference(packageName);
                }
            }

            PerformInstallActions(localPackage);
        }

        /// <summary>
        /// Install given version of a package.
        /// </summary>
        /// <param name="packageName">The package name</param>
        /// <param name="version">The package version</param>
        /// <param name="caption">The message to show during installation</param>
        private void Install(string packageName, string version, string caption = "Installing '{0}'")
        {

            var existing = Common.LocalPackage.Load(_packagesRootPath, packageName);
            if (existing != null)
            {

                if (existing.Version.Equals(version))
                {
                    CLUEnvironment.Console.WriteLine(string.Format(Strings.PackageManagementMode_Install_PackageVersionAlreadyInstalled, packageName));
                    return;
                }

                existing.RemoveReference(packageName);

                RemoveExistingPackage(existing);
            }

            IPackage package = (version == null) ?
                _repository.FindPackage(packageName) :
                _repository.FindPackage(packageName, SemanticVersion.Parse(version));

            if (package == null)
            {
                CLUEnvironment.Console.WriteErrorLine(string.Format(Strings.PackageManagementMode_Install_PackageVersionNotAvailable, packageName));
                return;
            }

            CLUEnvironment.Console.WriteLine(caption, packageName);

            _manager.InstallPackage(package, false, false);

            var localPackage = Common.LocalPackage.Load(packageName);

            if (localPackage != null)
                localPackage.AddReference(packageName);
        }

        /// <summary>
        /// Upgrade an existing package to new version.
        /// </summary>
        /// <param name="packageName">The package name</param>
        /// <param name="version">The package version</param>
        private void Upgrade(string packageName, string version)
        {
            var existing = Common.LocalPackage.Load(_packagesRootPath, packageName);
            if (existing == null)
            {
                CLUEnvironment.Console.WriteWarningLine(string.Format(Strings.PackageManagementMode_Upgrade_NothingToUpdate, packageName));
                return;
            }
            IPackage package = (version == null) ?
                _repository.FindPackage(packageName) :
                _repository.FindPackage(packageName, SemanticVersion.Parse(version));

            if (package == null)
            {
                CLUEnvironment.Console.WriteWarningLine(string.Format(Strings.PackageManagmentMode_Upgrade_PackageOrVersionNotAvailable, packageName));
                return;
            }

            var currentVersion = SemanticVersion.Parse(existing.Version);
            if (package.Version != currentVersion)
            {
                RemoveExistingPackage(existing);
                Install(packageName, version, string.Format(Strings.PackageManagmentMode_Upgrade_UpdatingToVersion, package.Version));
            }
            else
            {
                CLUEnvironment.Console.WriteWarningLine(string.Format(Strings.PackageManagmentMode_Upgrade_AlreadyUpToDate, packageName));
            }
        }

        /// <summary>
        /// Remove specific version of a package.
        /// </summary>
        /// <param name="packageName">The package name</param>
        /// <param name="version">The package version</param>
        private void Remove(string packageName, string version)
        {
            var existing = Common.LocalPackage.Load(_packagesRootPath, packageName);
            if (existing == null)
            {
                CLUEnvironment.Console.WriteWarningLine(string.Format(Strings.PackageManagmentMode_Remove_NothingToRemove, packageName));
                return;
            }
            
            existing.RemoveReference(packageName);

            RemoveExistingPackage(existing);
        }

        /// <summary>
        /// Removes an installed package identified by the given LocalPackage reference.
        /// </summary>
        /// <param name="existingPackage">Reference to locally installed package</param>
        private void RemoveExistingPackage(Common.LocalPackage existingPackage)
        {
            var currentVersion = SemanticVersion.Parse(existingPackage.Version);
            _manager.UninstallPackage(existingPackage.Name, currentVersion, true, true);
        }

        /// <summary>
        /// Perform post installation actions for a given LocalPackage reference.
        /// </summary>
        /// <param name="localPackage">Reference to locally installed package</param>
        private void PerformInstallActions(Common.LocalPackage localPackage)
        {
            using (var resolver = new AssemblyResolver(CLUEnvironment.GetPackagePaths(), true))
            {
                var packageConfig = localPackage.LoadConfig();
                if (packageConfig != null)
                {
                    InvokeInstallationHooks(localPackage, packageConfig.OnInstall, resolver);

                    CopyScripts(localPackage);

                    if (packageConfig.CommandAssemblies.Count() > 0)
                        IndexBuilder.CreateIndexes(localPackage, resolver);
                }
            }
        }

        /// <summary>
        /// Runs installation hooks for a given LocalPackage reference.
        /// </summary>
        /// <param name="package">Reference to locally installed package</param>
        /// <param name="entryPoints">The entrypoint method names (hooks) to invoke</param>
        /// <param name="resolver">The assembly resolver</param>
        private static void InvokeInstallationHooks(Common.LocalPackage package, IEnumerable<string> entryPoints, AssemblyResolver resolver)
        {
            if (entryPoints.Count() > 0)
            {
                var assemblies = package.LoadCommandAssemblies(resolver);

                var failedToLocateAssemblyNames = assemblies.Where(a => a.Assembly == null).Select(a => a.Name);
                if (failedToLocateAssemblyNames.Count() > 0)
                {
                    CLUEnvironment.Console.WriteErrorLine(string.Format(Strings.PackageManagmentMode_InvokeInstallationHooks_AssembliesFailedToLocate, string.Join(", ", failedToLocateAssemblyNames)));
                }

                var loadedAssemblies = assemblies.Where(a => a.Assembly != null).Select(a => a);
                if (loadedAssemblies.Count() > 0)
                {
                    foreach (var entry in entryPoints)
                    {
                        var method = loadedAssemblies.Select(a => a.GetEntryPointMethod(entry)).Where(a => a != null).FirstOrDefault();
                        if (method == null)
                        {
                            CLUEnvironment.Console.WriteErrorLine(string.Format(Strings.PackageManagmentMode_InvokeInstallationHooks_InstallEntryPointNotFound, package.Name, entry));
                            return;
                        }

                        if (!method.IsStatic || !method.IsPublic)
                        {
                            CLUEnvironment.Console.WriteErrorLine(string.Format(Strings.PackageManagmentMode_InvokeInstallationHooks_InstallEntryPointMustBeStaticAndPublic, package.Name, entry));
                            return;
                        }

                        if (method.GetParameters().Length > 0)
                        {
                            CLUEnvironment.Console.WriteErrorLine(string.Format(Strings.PackageManagmentMode_InvokeInstallationHooks_InstallEntryPointShouldNotAcceptArguments, package.Name, entry));
                            return;
                        }

                        method.Invoke(null, new object[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Copy script files associated with a given local package to runtime root.
        /// Merge the module information of a given local package with the module information exists in the root.
        /// </summary>
        /// <param name="localPackage">Reference to the local package</param>
        private static void CopyScripts(Common.LocalPackage localPackage)
        {
            var root = CLUEnvironment.GetRootPath();
            MergeModules(Path.Combine(localPackage.FullPath, Common.Constants.ContentFolder), root, CLUEnvironment.Platform.ConfigFileSearchPattern);
        }

        /// <summary>
        /// Removes the script files associated with the given package and update the module information
        /// in the root path.
        /// </summary>
        /// <param name="localPackage">Reference to the local package</param>
        private static void RemoveScripts(Microsoft.CLU.Common.LocalPackage localPackage)
        {
            var root = CLUEnvironment.GetRootPath();
            PurgeModules(Path.Combine(localPackage.FullPath, Common.Constants.ContentFolder), root, CLUEnvironment.Platform.ConfigFileSearchPattern);
        }

        private static void MergeModules(string srcFolder, string dstFolder, string searchPattern)
        {
            if (Directory.Exists(srcFolder))
            {
                foreach (var srcPath in Directory.EnumerateFiles(srcFolder, searchPattern))
                {
                    var dstPath = Path.Combine(dstFolder, Path.GetFileName(srcPath));
                    if (!File.Exists(dstPath))
                    {
                        File.Copy(srcPath, dstPath, true);
                    }
                    else
                    {
                        // Look for a 'Modules' option in both files -- merge the lists and write out.
                        var srcLines = File.ReadAllLines(srcPath).Select(line => line.Trim()).ToList();
                        var dstLines = File.ReadAllLines(dstPath).Select(line => line.Trim()).ToList();

                        var modulesSrcLine = srcLines.Where(line => line.StartsWith(Common.Constants.CmdletModulesConfigKey)).FirstOrDefault();
                        if (modulesSrcLine == null)
                            // Don't touch the target file if there's nothing in the source.
                            return;

                        var srcModules = GetModules(modulesSrcLine);

                        for (int i = 0; i < dstLines.Count; ++i)
                        {
                            if (dstLines[i].StartsWith(Common.Constants.CmdletModulesConfigKey))
                            {
                                var dstModules = GetModules(dstLines[i]);
                                srcModules.UnionWith(dstModules);
                                dstLines[i] = $"{Common.Constants.CmdletModulesConfigKey}:{string.Join(",", srcModules)}";
                                File.WriteAllLines(dstPath, dstLines);
                                break;
                            }
                        }
                    }

                    if (!File.Exists(GetScriptPath(dstPath)))
                        GenerateScript(dstPath);
                }
            }
        }

        private static void PurgeModules(string srcFolder, string dstFolder, string searchPattern)
        {
            if (Directory.Exists(srcFolder))
            {
                foreach (var srcPath in Directory.EnumerateFiles(srcFolder, searchPattern))
                {
                    var dstPath = Path.Combine(dstFolder, Path.GetFileName(srcPath));

                    if (File.Exists(dstPath))
                    {
                        // Look for a 'Modules' option in both files -- merge the lists and write out.
                        var srcLines = File.ReadAllLines(srcPath).Select(line => line.Trim()).ToList();
                        var dstLines = File.ReadAllLines(dstPath).Select(line => line.Trim()).ToList();

                        var modulesSrcLine = srcLines.Where(line => line.StartsWith(Common.Constants.CmdletModulesConfigKey)).FirstOrDefault();
                        if (modulesSrcLine == null)
                            // Don't touch the target file if there's nothing in the source.
                            return;

                        var srcModules = GetModules(modulesSrcLine);

                        for (int i = 0; i < dstLines.Count; ++i)
                        {
                            if (dstLines[i].StartsWith(Common.Constants.CmdletModulesConfigKey))
                            {
                                var dstModules = GetModules(dstLines[i]);
                                dstModules.ExceptWith(srcModules);
                                if (dstModules.Count == 0)
                                {
                                    File.Delete(dstPath);
                                    var scriptPath = GetScriptPath(dstPath);
                                    if (File.Exists(scriptPath))
                                        File.Delete(scriptPath);
                                }
                                else
                                {
                                    dstLines[i] = $"{Common.Constants.CmdletModulesConfigKey}:{string.Join(",", dstModules)}";
                                    File.WriteAllLines(dstPath, dstLines);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void GenerateScript(string cfgPath)
        {
            var scriptPath = GetScriptPath(cfgPath);
            var scriptName = Path.GetFileNameWithoutExtension(scriptPath);

            if (File.Exists(scriptPath))
                return;

            if (CLUEnvironment.Platform.IsUnixOrMacOSX)
            {
                File.WriteAllLines(scriptPath, new string[]
                {
                    "#!/bin/bash",
                    "if [ -z ${CmdletSessionID} ]",
                    "then",
                    "  export CmdletSessionID=$PPID",
                    "fi",
                    "SCRIPTPATH=$(dirname \"$0\")",
                    $"$SCRIPTPATH/clurun -s {scriptName} -r $SCRIPTPATH/{Path.GetFileName(cfgPath)} \"$@\""
                });
                System.Diagnostics.Process.Start("chmod", $"777 {scriptPath}");
            }
            else
            {
                File.WriteAllLines(scriptPath, new string[]
                {
                    "@echo off",
                    $@"%~dp0\clurun.exe -s {scriptName} -r %~dp0\{Path.GetFileName(cfgPath)} %*"
                });
            }
        }

        private static string GetScriptPath(string configPath)
        {
            var scriptFile = Path.GetFileNameWithoutExtension(configPath) + CLUEnvironment.Platform.ScriptFileExtension;
            return Path.Combine(Path.GetDirectoryName(configPath), scriptFile);
        }

        /// <summary>
        /// Extracts the module names from the given line.
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>Set of module names</returns>
        private static HashSet<string> GetModules(string line)
        {
            var items = line.Split(':');
            if (items.Length < 2)
                return new HashSet<string>();

            return items[1].Trim().Split(',').Select(l => l.Trim()).ToSet();
        }

#region Private fields.

        /// <summary>
        /// The options those identify package management mode.
        /// </summary>
        private IDictionary<string, int> _options = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "-v", -1 },
            { "--version", -1 },
            { "-i", 0 },
            { "--install", 0 },
            { "-d", 1 },
            { "--remove", 1 },
            { "-u", 2 },
            { "--upgrade", 2 }
        };

        /// <summary>
        /// The Nuget package repository.
        /// </summary>
        private IPackageRepository _repository;

        /// <summary>
        /// The Nuget package manager.
        /// </summary>
        private PackageManager _manager;

        /// <summary>
        /// The runtime configuration.
        /// </summary>
        private RuntimeConfig _runtimeConfiguration = null;

        /// <summary>
        /// The packages root path.
        /// </summary>
        private string _packagesRootPath = null;

#endregion
    }
}
