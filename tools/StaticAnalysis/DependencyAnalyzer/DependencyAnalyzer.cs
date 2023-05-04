// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Tools.Common.Helpers;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// The static analysis tool for ensuring no runtime conflicts in assembly dependencies
    /// </summary>
    public class DependencyAnalyzer : IStaticAnalyzer
    {
        private const int NoAssemblyVersionEvidence = 1000;
        private const int ReferenceDoesNotMatchAssemblyVersion = 1010;
        private const int ExtraAssemblyRecord = 2000;
        private const int MissingAssemblyRecord = 3000;
        private const int AssemblyVersionFileVersionMismatch = 7000;
        private const int CommonAuthenticationMismatch = 7010;

        private const string ModuleAlcAssembliesDirectory = "ModuleAlcAssemblies";
        //ALC wrapper assembly must contain AlcWrapper in its name
        private const string AlcWrapperAssemblyKeyWord = "AlcWrapper";

        private static readonly HashSet<string> FrameworkAssemblies = new HashSet<string>(new[]{
            "Microsoft.CSharp",
            "Microsoft.Management.Infrastructure",
            "Microsoft.Build",
            "Microsoft.Build.Framework",
            "Microsoft.Win32.Primitives",
            "Microsoft.Win32.Registry",
            "mscorlib",
            "netstandard",
            "Microsoft.Win32.Primitives",
            "System.AppContext",
            "System.Collections",
            "System.Collections.Immutable",
            "System.Collections.Concurrent",
            "System.Collections.NonGeneric",
            "System.Collections.Specialized",
            "System.ComponentModel",
            "System.ComponentModel.EventBasedAsync",
            "System.ComponentModel.Primitives",
            "System.ComponentModel.TypeConverter",
            "System.Console",
            "System.Data.Common",
            "System.Diagnostics.Contracts",
            "System.Diagnostics.Debug",
            "System.Diagnostics.DiagnosticSource",
            "System.Diagnostics.EventLog",
            "System.Diagnostics.FileVersionInfo",
            "System.Diagnostics.Process",
            "System.Diagnostics.StackTrace",
            "System.Diagnostics.TextWriterTraceListener",
            "System.Diagnostics.Tools",
            "System.Diagnostics.TraceSource",
            "System.Diagnostics.Tracing",
            "System.Drawing.Primitives",
            "System.Dynamic.Runtime",
            "System.Globalization",
            "System.Globalization.Calendars",
            "System.Globalization.Extensions",
            "System.IO",
            "System.IO.Compression",
            "System.IO.Compression.ZipFile",
            "System.IO.FileSystem",
            "System.IO.FileSystem.DriveInfo",
            "System.IO.FileSystem.Primitives",
            "System.IO.FileSystem.Watcher",
            "System.IO.IsolatedStorage",
            "System.IO.MemoryMappedFiles",
            "System.IO.Pipes",
            "System.IO.UnmanagedMemoryStream",
            "System.Linq",
            "System.Linq.Expressions",
            "System.Linq.Parallel",
            "System.Linq.Queryable",
            "System.Management.Automation",
            "System.Net.Http",
            "System.Net.NameResolution",
            "System.Net.NetworkInformation",
            "System.Net.Ping",
            "System.Net.Primitives",
            "System.Net.Requests",
            "System.Net.Security",
            "System.Net.Sockets",
            "System.Net.WebHeaderCollection",
            "System.Net.WebSockets",
            "System.Net.WebSockets.Client",
            "System.ObjectModel",
            "System.Private.DataContractSerialization",
            "System.Reflection",
            "System.Reflection.Emit",
            "System.Reflection.Emit.ILGeneration",
            "System.Reflection.Emit.Lightweight",
            "System.Reflection.Extensions",
            "System.Reflection.Metadata",
            "System.Reflection.Primitives",
            "System.Resources.Reader",
            "System.Resources.ResourceManager",
            "System.Resources.Writer",
            "System.Runtime",
            "System.Runtime.CompilerServices.Unsafe",
            "System.Runtime.CompilerServices.VisualC",
            "System.Runtime.Extensions",
            "System.Runtime.Handles",
            "System.Runtime.InteropServices",
            "System.Runtime.InteropServices.RuntimeInformation",
            "System.Runtime.Numerics",
            "System.Runtime.Serialization.Formatters",
            "System.Runtime.Serialization.Json",
            "System.Runtime.Serialization.Primitives",
            "System.Runtime.Serialization.Xml",
            "System.Security.Claims",
            "System.Security.Cryptography.Algorithms",
            "System.Security.Cryptography.Csp",
            "System.Security.Cryptography.Encoding",
            "System.Security.Cryptography.Primitives",
            "System.Security.Cryptography.X509Certificates",
            "System.Security.Principal",
            "System.Security.SecureString",
            "System.Text.Encoding",
            "System.Text.Encoding.Extensions",
            "System.Text.RegularExpressions",
            "System.Threading",
            "System.Threading.Overlapped",
            "System.Threading.Tasks",
            "System.Threading.Tasks.Parallel",
            "System.Threading.Thread",
            "System.Threading.ThreadPool",
            "System.Threading.Timer",
            "System.ValueTuple",
            "System.Xml.ReaderWriter",
            "System.Xml.XDocument",
            "System.Xml.XmlDocument",
            "System.Xml.XmlSerializer",
            "System.Xml.XPath",
            "System.Xml.XPath.XDocument",
            "WindowsBase",
            "System.Security.Cryptography.Cng",
            "System.Security.Cryptography.Pkcs",
            "System.Private.CoreLib",
            "System.Private.ServiceModel",
            "System.Private.Xml.Linq",
            "System.Net.Http.WinHttpHandler",
            "System.Net.Mail",
            "System.Security.Permissions",
            "System.Runtime.Loader",
            "System.DirectoryServices",
            "System.Management",
            "System.Configuration",
            "System.Net.WebClient",
            "System.Memory",
            "System.Memory.Data",
            "System.Text.Encoding.CodePages",
            "System.Private.Xml",
            "System.Reflection.DispatchProxy",
            "System.ServiceModel",
            "System.ServiceModel.Syndication",
            "System.ServiceModel.Http",
            "System.ServiceModel.Duplex",
            "System.ServiceModel.NetTcp",
            "System.ServiceModel.Primitives",
            "System.ServiceModel.Security",
            "System.IO.FileSystem.AccessControl",
            "System.Security.Permissions",
            "System.Security.AccessControl",
            "System.Security.Principal.Windows",
            "System.Data.SqlClient",
            "System.Security.Cryptography.ProtectedData",
            "Microsoft.Bcl.AsyncInterfaces",
            "System.Threading.Tasks.Extensions",
            "System.Buffers",
            "System.Text.Encodings.Web",
            "System.Text.Json" //TODO: Compare Version along with Azure.Core
        }, StringComparer.OrdinalIgnoreCase);

        private HashSet<string> CommonAssemblySet = new HashSet<string>(new string[]
        {
            "Microsoft.Rest.ClientRuntime",
            "Microsoft.Rest.ClientRuntime.Azure",
            "Microsoft.Azure.PowerShell.Clients.Aks",
            "Microsoft.Azure.PowerShell.Authentication.Abstractions",
            "Microsoft.Azure.PowerShell.Clients.Authorization",
            "Microsoft.Azure.PowerShell.Common",
            "Microsoft.Azure.PowerShell.Clients.Compute",
            "Microsoft.Azure.PowerShell.Clients.Graph.Rbac",
            "Microsoft.Azure.PowerShell.Clients.KeyVault",
            "Microsoft.Azure.PowerShell.Clients.Monitor",
            "Microsoft.Azure.PowerShell.Clients.Network",
            "Microsoft.Azure.PowerShell.Clients.PolicyInsights",
            "Microsoft.Azure.PowerShell.Clients.ResourceManager",
            "Microsoft.Azure.PowerShell.Storage",
            "Microsoft.Azure.PowerShell.Clients.Storage.Management",
            "Microsoft.Azure.PowerShell.Strategies",
            "Microsoft.Azure.PowerShell.Clients.Websites",
            "Microsoft.Azure.PowerShell.Common.Share",
            "Azure.Core",
            "Microsoft.ApplicationInsights",
            "Microsoft.Azure.Common",
            "Hyak.Common",
            "PowerShellStandard.Library"
        }, StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, AssemblyRecord> _assemblies =
            new Dictionary<string, AssemblyRecord>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<AssemblyName, AssemblyRecord> _sharedAssemblyReferences =
            new Dictionary<AssemblyName, AssemblyRecord>(new AssemblyNameComparer());
        private readonly Dictionary<string, AssemblyRecord> _identicalSharedAssemblies =
            new Dictionary<string, AssemblyRecord>(StringComparer.OrdinalIgnoreCase);
        private AssemblyMetadataLoader _loader;
        private ReportLogger<AssemblyVersionConflict> _versionConflictLogger;
        private ReportLogger<SharedAssemblyConflict> _sharedConflictLogger;
        private ReportLogger<MissingAssembly> _missingAssemblyLogger;
        private ReportLogger<ExtraAssembly> _extraAssemblyLogger;
        private ReportLogger<DependencyMap> _dependencyMapLogger;

        private bool _isNetcore;

        public DependencyAnalyzer()
        {
            Name = "Dependency Analyzer";
        }

        public AnalysisLogger Logger { get; set; }
        public string Name { get; private set; }

        public void Analyze(IEnumerable<string> scopes)
        {
            Analyze(scopes, null);
        }

        public void Analyze(IEnumerable<string> directories, IEnumerable<String> modulesToAnalyze)
        {
            if (directories == null)
            {
                throw new ArgumentNullException("directories");
            }

            _versionConflictLogger = Logger.CreateLogger<AssemblyVersionConflict>("AssemblyVersionConflict.csv");
            _sharedConflictLogger = Logger.CreateLogger<SharedAssemblyConflict>("SharedAssemblyConflict.csv");
            _missingAssemblyLogger = Logger.CreateLogger<MissingAssembly>("MissingAssemblies.csv");
            _extraAssemblyLogger = Logger.CreateLogger<ExtraAssembly>("ExtraAssemblies.csv");
            _dependencyMapLogger = Logger.CreateLogger<DependencyMap>("DependencyMap.csv");
            foreach (var baseDirectory in directories)
            {
                SharedAssemblyLoader.Load(baseDirectory);
                foreach (var directoryPath in Directory.EnumerateDirectories(baseDirectory))
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Any(m => directoryPath.EndsWith(m)))
                    {
                        continue;
                    }

                    if (!Directory.Exists(directoryPath))
                    {
                        throw new InvalidOperationException("Please pass a valid directory name as the first parameter");
                    }

                    Logger.WriteMessage("Processing Directory {0}", directoryPath);
                    _assemblies.Clear();
                    _loader = new AssemblyMetadataLoader();
                    _versionConflictLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    _missingAssemblyLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    _extraAssemblyLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    _dependencyMapLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    _isNetcore = directoryPath.Contains("Az.");
                    ProcessDirectory(directoryPath);
                    _versionConflictLogger.Decorator.Remove("Directory");
                    _missingAssemblyLogger.Decorator.Remove("Directory");
                    _extraAssemblyLogger.Decorator.Remove("Directory");
                    _dependencyMapLogger.Decorator.Remove("Directory");
                }
            }
        }

        private AssemblyRecord CreateAssemblyRecord(string path)
        {
            AssemblyRecord result = null;
            var fullPath = Path.GetFullPath(path);
            try
            {
                var assembly = LoadByReflectionFromFile(fullPath);
                var versionInfo = FileVersionInfo.GetVersionInfo(fullPath);
                result = new AssemblyRecord
                {
                    AssemblyName = assembly.GetName(),
                    AssemblyFileMajorVersion = versionInfo.FileMajorPart,
                    AssemblyFileMinorVersion = versionInfo.FileMinorPart,
                    Location = fullPath
                };

                foreach (var child in assembly.GetReferencedAssemblies())
                {
                    result.Children.Add(child);
                }
            }
            catch
            {
                Logger.WriteError("Error loading assembly {0}", fullPath);
            }

            return result;
        }

        private bool AddSharedAssembly(AssemblyRecord assembly)
        {
            if (_sharedAssemblyReferences.ContainsKey(assembly.AssemblyName))
            {
                var stored = _sharedAssemblyReferences[assembly.AssemblyName];
                if (assembly.Equals(stored) || IsFrameworkAssembly(assembly.AssemblyName) && assembly.Version.Major <= 4) return true;
                //TODO: Compare Azure.Core version
                if (string.Equals(assembly.AssemblyName.Name, "Azure.Core", StringComparison.InvariantCultureIgnoreCase))
                    return true;

                _sharedConflictLogger.LogRecord(new SharedAssemblyConflict
                {
                    AssemblyName = assembly.Name,
                    AssemblyPathsAndFileVersions = new List<Tuple<string, Version>>
                    {
                        new Tuple<string, Version>(assembly.Location, new Version(assembly.AssemblyFileMajorVersion,
                            assembly.AssemblyFileMinorVersion)),
                        new Tuple<string, Version>(stored.Location, new Version(stored.AssemblyFileMajorVersion,
                            stored.AssemblyFileMinorVersion))

                    },
                    AssemblyVersion = assembly.Version,
                    Severity = 0,
                    ProblemId = AssemblyVersionFileVersionMismatch,
                    Description = "Shared assembly conflict, shared assemblies with the same assembly " +
                                  "version have differing file versions",
                    Remediation = string.Format("Update the assembly reference for {0} in one of the " +
                                                "referring assemblies", assembly.Name)
                });

                return false;
            }

            _sharedAssemblyReferences[assembly.AssemblyName] = assembly;

            return true;
        }

        private AssemblyMetadata LoadByReflectionFromFile(string assemblyPath)
        {
            var info = _loader.GetReflectedAssemblyFromFile(assemblyPath);
            if (info == null)
            {
                throw new InvalidOperationException();
            }

            return info;
        }

        private bool AddSharedAssemblyExactVersion(AssemblyRecord record)
        {
            if (_identicalSharedAssemblies.ContainsKey(record.Name))
            {
                var stored = _identicalSharedAssemblies[record.Name];
                if (record.Equals(stored) || IsFrameworkAssembly(record.AssemblyName)) return true;

                _sharedConflictLogger.LogRecord(new SharedAssemblyConflict
                {
                    AssemblyName = record.Name,
                    AssemblyVersion = record.Version,
                    Severity = 0,
                    ProblemId = CommonAuthenticationMismatch,
                    AssemblyPathsAndFileVersions = new List<Tuple<string, Version>>
                    {
                        new Tuple<string, Version>(record.Location, new Version(record.AssemblyFileMajorVersion,
                            record.AssemblyFileMinorVersion)),
                        new Tuple<string, Version>(stored.Location, new Version(stored.AssemblyFileMajorVersion,
                            stored.AssemblyFileMinorVersion)),
                    },
                    Description = string.Format("Assembly {0} has multiple versions as specified in 'Target'",
                        record.Name),
                    Remediation = string.Format("Ensure that all packages reference exactly the same package " +
                                                "version of {0}", record.Name)

                });

                return false;
            }

            _identicalSharedAssemblies[record.Name] = record;

            return true;
        }

        private static bool IsFrameworkAssembly(AssemblyName name)
        {
            return IsFrameworkAssembly(name.Name);
        }

        private static bool IsFrameworkAssembly(string name)
        {
            return FrameworkAssemblies.Contains(name);
        }

        private void ProcessDirectory(string directoryPath)
        {
            directoryPath = System.IO.Path.GetFullPath(directoryPath);
            var savedDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(directoryPath);
            var moduleAlcAssemblySet = LoadModuleAclAssembly(directoryPath);
            var moduleAlcAssemblyNameSet = moduleAlcAssemblySet?.Select(a => Path.GetFileNameWithoutExtension(a))?.ToHashSet();
            foreach (var file in Directory.GetFiles(directoryPath).Where(file => file.EndsWith(".dll")))
            {
                //Ignore ALC assemblies for special handle later
                var fileName = Path.GetFileNameWithoutExtension(file);
                if (moduleAlcAssemblyNameSet?.Contains(fileName) == true)
                    continue;

                var assembly = CreateAssemblyRecord(file);
                if (assembly?.Name != null && !IsFrameworkAssembly(assembly.Name))
                {
                    _assemblies[assembly.Name] = assembly;
                    AddSharedAssembly(assembly);
                }
            }

            // Now check for assembly mismatches
            bool alcWrapperIsReferenced = false;
            foreach (var assembly in _assemblies.Values)
            {
                foreach (var reference in assembly.Children)
                {
                    if(reference.Name.Contains(AlcWrapperAssemblyKeyWord) ||
                        moduleAlcAssemblyNameSet?.Contains(reference.Name) == true)
                    {
                        alcWrapperIsReferenced = CheckDirectReferenceToAlcWrapperAssembly(moduleAlcAssemblyNameSet, assembly, reference) || alcWrapperIsReferenced;
                    }
                    else
                    {
                        CheckAssemblyReference(reference, assembly);
                    }
                }
            }

            CheckAlcAssemblyDependency(moduleAlcAssemblySet, alcWrapperIsReferenced);

            foreach (var assembly in _assemblies.Values)
            {
                if (!assembly.Name.Contains("Microsoft.IdentityModel") && !assembly.Name.Equals("Newtonsoft.Json") && !IsFrameworkAssembly(assembly.Name))
                {
                    foreach (var parent in assembly.ReferencingAssembly)
                    {
                        _dependencyMapLogger.LogRecord(
                            new DependencyMap
                            {
                                AssemblyName = assembly.Name,
                                AssemblyVersion = assembly.Version.ToString(),
                                ReferencingAssembly = parent.Name,
                                ReferencingAssemblyVersion = parent.Version.ToString(),
                                Severity = 3
                            });
                    }
                }

            }

            FindExtraAssemblies();
            Directory.SetCurrentDirectory(savedDirectory);
        }

        //Check 1: Cmdlets assembly must not reference assembly in directory ModuleAlcAssemblies other than AlcWrapper
        //Check 2: AlcWrapper must be in directory ModuleAlcAssemblies
        //Return : Whether it is AlcWrapper assemlby and be directly referenced
        private bool CheckDirectReferenceToAlcWrapperAssembly(HashSet<string> moduleAlcAssemblyNameSet, AssemblyRecord parent, AssemblyName reference)
        {
            bool alcWrapperIsReferenced = false;
            if (moduleAlcAssemblyNameSet?.Contains(reference.Name) == true)
            {
                if (!reference.Name.Contains(AlcWrapperAssemblyKeyWord))
                {
                    //Add one error record:module assembly must not reference assembly in directory ModuleAlcAssemblies other than AlcWrapper
                    _dependencyMapLogger.LogRecord(
                        new DependencyMap
                        {
                            AssemblyName = reference.Name,
                            AssemblyVersion = reference.Version.ToString(),
                            ReferencingAssembly = parent.Name,
                            ReferencingAssemblyVersion = parent.Version.ToString(),
                            Severity = 1,
                            Description = $"Per ALC design guideline, module assembly {parent.Name} must not reference assemblies in directory ModuleAlcAssemblies other than AlcWrapper.",
                        });
                }
                else
                {
                    alcWrapperIsReferenced = true;
                }
            }
            else if (reference.Name.Contains(AlcWrapperAssemblyKeyWord))
            {
                //Add one error record, AlcWrapper is referenced by module assembly but not in directory ModuleAlcAssemblies
                _dependencyMapLogger.LogRecord(
                    new DependencyMap
                    {
                        AssemblyName = reference.Name,
                        AssemblyVersion = reference.Version.ToString(),
                        ReferencingAssembly = parent.Name,
                        ReferencingAssemblyVersion = parent.Version.ToString(),
                        Severity = 1,
                        Description = $"Per ALC design guideline, ALC assembly {reference.Name} must be put in directory ModuleAlcAssemblies.",
                    });
            }
            return alcWrapperIsReferenced;
        }

        private void CheckAlcAssemblyDependency(HashSet<string> moduleAlcAssemblySet, bool alcWrapperIsReferenced)
        {
            if (moduleAlcAssemblySet != null)
            {
                //Make sure all dependency assemblies except framework/common are available for ALC assemblies
                if (alcWrapperIsReferenced)
                {
                    var alcAssemblyRecords = new Dictionary<string, AssemblyRecord>();
                    foreach (var alcAssembly in moduleAlcAssemblySet)
                    {
                        var assemblyRecord = CreateAssemblyRecord(alcAssembly);
                        alcAssemblyRecords[assemblyRecord.Name] = assemblyRecord;
                    }
                    foreach (var parent in alcAssemblyRecords.Values)
                    {
                        foreach (var reference in parent.Children)
                        {
                            if (!alcAssemblyRecords.ContainsKey(reference.Name) && !IsFrameworkAssembly(reference.Name)
                                && !IsCommonAssembly(reference.Name))
                            {
                                _missingAssemblyLogger.LogRecord(new MissingAssembly
                                {
                                    AssemblyName = reference.Name,
                                    AssemblyVersion = reference.Version.ToString(),
                                    ReferencingAssembly = parent.Name,
                                    Severity = 0,
                                    ProblemId = MissingAssemblyRecord,
                                    Description = string.Format("Missing ALC assembly {0} referenced from {1}", reference.Name,
                                    parent.Name),
                                    Remediation = "Ensure that the assembly is included in the Wix file or directory"
                                });
                            }
                        }
                    }
                }
                else
                {
                    //Add error record, ALC wrapper assembly is never referenced
                    var alcAssemblyNames = string.Join(";", moduleAlcAssemblySet.ToArray());
                    _extraAssemblyLogger.LogRecord(new ExtraAssembly
                    {
                        AssemblyName = alcAssemblyNames,
                        Severity = 1,
                        ProblemId = ExtraAssemblyRecord,
                        Description = string.Format("ALC Assembly {0} is not referenced from any cmdlets assembly",
                            alcAssemblyNames),
                        Remediation = string.Format("Remove assembly {0} from the project and regenerate the Wix " +
                                                    "file", alcAssemblyNames)
                    });
                }
            }
        }

        private static HashSet<string> LoadModuleAclAssembly(string directoryPath)
        {
            var moduleAlcDirectory = Path.Combine(directoryPath, ModuleAlcAssembliesDirectory);
            HashSet<string> moduleAlcAssemblySet = null;
            if (Directory.Exists(moduleAlcDirectory))
            {
                moduleAlcAssemblySet = new HashSet<string>(Directory.GetFiles(moduleAlcDirectory).Where(file => file.EndsWith(".dll")), StringComparer.OrdinalIgnoreCase);
            }

            return moduleAlcAssemblySet;
        }

        private bool IsCommonAssembly(string name)
        {
            return CommonAssemblySet.Contains(name);
        }

        private static bool IsCommandAssembly(AssemblyRecord assembly)
        {
            return assembly.Name.Contains("Commands") || assembly.Name.Contains("Cmdlets");
        }

        private void FindExtraAssemblies()
        {
            if (!_assemblies.Values.Any(a =>
                !IsCommandAssembly(a)
                && (a.ReferencingAssembly == null
                || a.ReferencingAssembly.Count == 0
                || !a.GetAncestors().Any(IsCommandAssembly))))
            {
                return;
            }

            foreach (var assembly in _assemblies.Values.Where(a =>
                !IsCommandAssembly(a)
                && (a.ReferencingAssembly == null
                || a.ReferencingAssembly.Count == 0
                || !a.GetAncestors().Any(IsCommandAssembly))))
            {
                _extraAssemblyLogger.LogRecord(new ExtraAssembly
                {
                    AssemblyName = assembly.Name,
                    Severity = 2,
                    ProblemId = ExtraAssemblyRecord,
                    Description = string.Format("Assembly {0} is not referenced from any cmdlets assembly",
                        assembly.Name),
                    Remediation = string.Format("Remove assembly {0} from the project and regenerate the Wix " +
                                                "file", assembly.Name)
                });
            }
        }

        private void CheckAssemblyReference(AssemblyName reference, AssemblyRecord parent)
        {
            if (_assemblies.ContainsKey(reference.Name))
            {
                var stored = _assemblies[reference.Name];
                if (stored.Equals(reference))
                {
                    stored.ReferencingAssembly.Add(parent);
                }
                else if (reference.Version.Major == 0 && reference.Version.Minor == 0)
                {
                    Logger.WriteWarning("{0}.dll has reference to assembly {1} without any version specification.",
                        parent.Name, reference.Name);
                    _versionConflictLogger.LogRecord(new AssemblyVersionConflict
                    {
                        AssemblyName = reference.Name,
                        ActualVersion = stored.Version,
                        ExpectedVersion = reference.Version,
                        ParentAssembly = parent.Name,
                        ProblemId = NoAssemblyVersionEvidence,
                        Severity = 2,
                        Description = string.Format("Assembly {0} referenced from {1}.dll does not specify any " +
                                                   "assembly version evidence.  The assembly will use version " +
                                                   "{2} from disk.", reference.Name, parent.Name, stored.Version),
                        Remediation = string.Format("Update the reference to assembly {0} from {1} so that " +
                                                   "assembly version evidence is supplied", reference.Name,
                                                   parent.Name)
                    });
                }
                else if (_isNetcore && stored.Version < reference.Version)
                {
                    var minVersion = (stored.Version < reference.Version) ? stored.Version : reference.Version;
                    _versionConflictLogger.LogRecord(new AssemblyVersionConflict
                    {
                        AssemblyName = reference.Name,
                        ActualVersion = stored.Version,
                        ExpectedVersion = reference.Version,
                        ParentAssembly = parent.Name,
                        ProblemId = ReferenceDoesNotMatchAssemblyVersion,
                        Severity = 1,
                        Description = string.Format("Assembly {0} version {1} referenced from {2}.dll does " +
                                                    "not match assembly version on disk: {3}",
                                                    reference.Name, reference.Version, parent.Name, stored.Version),
                        Remediation = string.Format("Update any references to version {0} of assembly {1}",
                        minVersion, reference.Name)
                    });
                }
            }
            else if (!IsFrameworkAssembly(reference))
            {
                _missingAssemblyLogger.LogRecord(new MissingAssembly
                {
                    AssemblyName = reference.Name,
                    AssemblyVersion = reference.Version.ToString(),
                    ReferencingAssembly = parent.Name,
                    Severity = 0,
                    ProblemId = MissingAssemblyRecord,
                    Description = string.Format("Missing assembly {0} referenced from {1}", reference.Name,
                    parent.Name),
                    Remediation = "Ensure that the assembly is included in the Wix file or directory"
                });
            }
        }

        /// <summary>
        /// These methods will be added in a new work item that has enhancements for Static Analysis tool
        /// </summary>
        /// <param name="cmdletProbingDirs"></param>
        /// <param name="directoryFilter"></param>
        /// <param name="cmdletFilter"></param>
        void IStaticAnalyzer.Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// These methods will be added in a new work item that has enhancements for Static Analysis tool
        /// </summary>
        /// <returns></returns>
        public AnalysisReport GetAnalysisReport()
        {
            throw new NotImplementedException();
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter, IEnumerable<string> modulesToAnalyze)
        {
            throw new NotImplementedException();
        }
    }
}
