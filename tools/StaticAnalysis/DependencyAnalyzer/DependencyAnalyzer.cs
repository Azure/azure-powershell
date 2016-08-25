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
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace StaticAnalysis.DependencyAnalyzer
{
    /// <summary>
    /// The static analysis tool for ensuring no runtime conflicts in assembly dependencies
    /// </summary>
    public class DependencyAnalyzer : IStaticAnalyzer
    {
        const int NoAssemblyVersionEvidence = 1000;
        const int ReferenceDoesNotMatchAssemblyVersion = 1010;
        const int ExtraAssemblyRecord = 2000;
        const int MissingAssemblyRecord = 3000;
        const int AssemblyVersionFileVersionMismatch = 7000;
        const int CommonAuthenticationMismatch = 7010;

        static List<string> FrameworkAssemblies = new List<string>
        {
            "Microsoft.CSharp",
            "Microsoft.Management.Infrastructure",
            "Microsoft.Build",
            "Microsoft.Build.Framework"
        };

        private Dictionary<string, AssemblyRecord> _assemblies =
            new Dictionary<string, AssemblyRecord>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<AssemblyName, AssemblyRecord> _sharedAssemblyReferences =
            new Dictionary<AssemblyName, AssemblyRecord>(new AssemblyNameComparer());
        private Dictionary<string, AssemblyRecord> _identicalSharedAssemblies =
            new Dictionary<string, AssemblyRecord>(StringComparer.OrdinalIgnoreCase);

        private AppDomain _testDomain;
        private AssemblyLoader _loader;
        private ReportLogger<AssemblyVersionConflict> _versionConflictLogger;
        private ReportLogger<SharedAssemblyConflict> _sharedConflictLogger;
        private ReportLogger<MissingAssembly> _missingAssemblyLogger;
        private ReportLogger<ExtraAssembly> _extraAssemblyLogger;

        public DependencyAnalyzer()
        {
            Name = "Dependency Analyzer";
        }

        public AnalysisLogger Logger { get; set; }
        public string Name { get; private set; }

        public void Analyze(IEnumerable<string> directories)
        {
            if (directories == null)
            {
                throw new ArgumentNullException("directories");
            }

            _versionConflictLogger = Logger.CreateLogger<AssemblyVersionConflict>("AssemblyVersionConflict.csv");
            _sharedConflictLogger = Logger.CreateLogger<SharedAssemblyConflict>("SharedAssemblyConflict.csv");
            _missingAssemblyLogger = Logger.CreateLogger<MissingAssembly>("MissingAssemblies.csv");
            _extraAssemblyLogger = Logger.CreateLogger<ExtraAssembly>("ExtraAssemblies.csv");
            foreach (var baseDirectory in directories)
            {
                foreach (var directoryPath in Directory.EnumerateDirectories(baseDirectory))
                {
                    if (!Directory.Exists(directoryPath))
                    {
                        throw new InvalidOperationException("Please pass a valid directory name as the first parameter");
                    }

                    Logger.WriteMessage("Processing Directory {0}", directoryPath);
                    _assemblies.Clear();
                    _versionConflictLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    _missingAssemblyLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    _extraAssemblyLogger.Decorator.AddDecorator(r => { r.Directory = directoryPath; }, "Directory");
                    ProcessDirectory(directoryPath);
                    _versionConflictLogger.Decorator.Remove("Directory");
                    _missingAssemblyLogger.Decorator.Remove("Directory");
                    _extraAssemblyLogger.Decorator.Remove("Directory");
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
                result = new AssemblyRecord()
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
                if (!assembly.Equals(stored) && !(IsFrameworkAssembly(assembly.AssemblyName) && assembly.Version.Major <= 4))
                {
                    _sharedConflictLogger.LogRecord(new SharedAssemblyConflict
                    {
                        AssemblyName = assembly.Name,
                        AssemblyPathsAndFileVersions = new List<Tuple<string, Version>>()
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
            }
            else
            {
                _sharedAssemblyReferences[assembly.AssemblyName] = assembly;
            }

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
                if (!record.Equals(stored) && !(IsFrameworkAssembly(record.AssemblyName)))
                {
                    _sharedConflictLogger.LogRecord(new SharedAssemblyConflict
                    {
                        AssemblyName = record.Name,
                        AssemblyVersion = record.Version,
                        Severity = 0,
                        ProblemId = CommonAuthenticationMismatch,
                        AssemblyPathsAndFileVersions = new List<Tuple<string, Version>>()
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
            }
            else
            {
                _identicalSharedAssemblies[record.Name] = record;
            }

            return true;
        }

        private static bool RequiresExactVersionMatch(AssemblyRecord name)
        {
            return name.Name.Contains("Microsoft.Azure.Common.Authentication");
        }

        private static bool IsFrameworkAssembly(AssemblyName name)
        {
            return name.Name.StartsWith("System") || name.Name.Equals("mscorlib") 
                || FrameworkAssemblies.Contains(name.Name);
        }

        private void ProcessDirectory(string directoryPath)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(directoryPath);
            _loader = EnvironmentHelpers.CreateProxy<AssemblyLoader>(directoryPath, out _testDomain);
            foreach (var file in Directory.GetFiles(directoryPath).Where(file => file.EndsWith(".dll")))
            {
                AssemblyRecord assembly = CreateAssemblyRecord(file);
                _assemblies[assembly.Name] = assembly;
                if (RequiresExactVersionMatch(assembly))
                {
                    AddSharedAssemblyExactVersion(assembly);
                }
                else
                {
                    AddSharedAssembly(assembly);
                }
            }

            // Now check for assembly mismatches
            foreach (var assembly in _assemblies.Values)
            {
                foreach (var reference in assembly.Children)
                {
                    CheckAssemblyReference(reference, assembly);
                }
            }

            FindExtraAssemblies();

            AppDomain.Unload(_testDomain);
            Directory.SetCurrentDirectory(savedDirectory);
        }

        private static bool IsCommandAssembly(AssemblyRecord assembly)
        {
            return assembly.Name.Contains("Commands") || assembly.Name.Contains("Cmdlets");
        }

        private void FindExtraAssemblies()
        {
            if (_assemblies.Values.Any(a => !IsCommandAssembly(a) && (a.ReferencingAssembly == null 
                || a.ReferencingAssembly.Count == 0 || !a.GetAncestors().Any(IsCommandAssembly))))
            {
                foreach (
                    var assembly in
                        _assemblies.Values.Where(a => !IsCommandAssembly(a) && (a.ReferencingAssembly == null ||
                            a.ReferencingAssembly.Count == 0 || !a.GetAncestors().Any(IsCommandAssembly))))
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
                    _versionConflictLogger.LogRecord(new AssemblyVersionConflict()
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
                else
                {
                    var minVersion = (stored.Version < reference.Version) ? stored.Version : reference.Version;
                    _versionConflictLogger.LogRecord(new AssemblyVersionConflict()
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
    }
}
