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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tools.Common.Helpers;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    public class BreakingChangeAnalyzer : IStaticAnalyzer
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public string BreakingChangeIssueReportLoggerName { get; set; }

        private AppDomain _appDomain;

        public BreakingChangeAnalyzer()
        {
            Name = "Breaking Change Analyzer";
            BreakingChangeIssueReportLoggerName = "BreakingChangeIssues.csv";
        }

        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders,
        /// analyze the breaking changes in the modules and report any issues
        /// </summary>
        /// <param name="cmdletProbingDirs">Set of directory paths containing PowerShell module folders to be checked for breaking changes.</param>
        public void Analyze(IEnumerable<string> cmdletProbingDirs)
        {
            Analyze(cmdletProbingDirs, null, null);
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, IEnumerable<string> modulesToAnalyze)
        {
            Analyze(cmdletProbingDirs, null, null, modulesToAnalyze);
        }

        public void Analyze(
            IEnumerable<string> cmdletProbingDirs,
            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
            Func<string, bool> cmdletFilter)
        {
            Analyze(cmdletProbingDirs, directoryFilter, cmdletFilter, null);
        }

        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders,
        /// analyze the breaking changes in the modules and report any issues
        ///
        /// Filters can be added to find breaking changes for specific modules
        /// </summary>
        /// <param name="cmdletProbingDirs">Set of directory paths containing PowerShell module folders to be checked for breaking changes.</param>
        /// <param name="directoryFilter">Function that filters the directory paths to be checked.</param>
        /// <param name="cmdletFilter">Function that filters the cmdlets to be checked.</param>
        public void Analyze(
            IEnumerable<string> cmdletProbingDirs,
            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
            Func<string, bool> cmdletFilter,
            IEnumerable<string> modulesToAnalyze)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") &&
                                                                        !s.Contains("Stack") && Directory.Exists(Path.GetFullPath(s))))
            {
                List<string> probingDirectories = new List<string>();

                // Add current directory for probing
                probingDirectories.Add(baseDirectory);
                probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));

                foreach (var directory in probingDirectories)
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Where(m => directory.EndsWith(m)).Any())
                    {
                        continue;
                    }

                    var service = Path.GetFileName(directory);

                    var manifestFiles = Directory.EnumerateFiles(directory, "*.psd1").ToList();

                    if (manifestFiles.Count > 1)
                    {
                        manifestFiles = manifestFiles.Where(f => Path.GetFileName(f).IndexOf(service) >= 0).ToList();
                    }

                    if (manifestFiles.Count == 0)
                    {
                        continue;
                    }

                    var psd1 = manifestFiles.FirstOrDefault();
                    var parentDirectory = Directory.GetParent(psd1).FullName;
                    var psd1FileName = Path.GetFileName(psd1);
                    IEnumerable<string> nestedModules = null;
                    List<string> requiredModules = null;
                    PowerShell powershell = PowerShell.Create();
                    powershell.AddScript("Import-LocalizedData -BaseDirectory " + parentDirectory +
                                         " -FileName " + psd1FileName +
                                         " -BindingVariable ModuleMetadata; $ModuleMetadata.NestedModules; $ModuleMetadata.RequiredModules | % { $_[\"ModuleName\"] };");
                    var cmdletResult = powershell.Invoke();
                    nestedModules = cmdletResult.Where(c => c.ToString().StartsWith(".")).Select(c => c.ToString().Substring(2));
                    requiredModules = cmdletResult.Where(c => !c.ToString().StartsWith(".")).Select(c => c.ToString()).ToList();

                    if (nestedModules.Any())
                    {
                        Directory.SetCurrentDirectory(directory);

                        requiredModules = requiredModules.Join(cmdletProbingDirs,
                                                               module => 1,
                                                               dir => 1,
                                                               (module, dir) => Path.Combine(dir, module))
                                                          .Where(f => Directory.Exists(f))
                                                          .ToList();

                        requiredModules.Add(directory);

                        foreach (var nestedModule in nestedModules)
                        {
                            var assemblyFile = Directory.GetFiles(parentDirectory, nestedModule, SearchOption.AllDirectories).FirstOrDefault();
                            var assemblyFileName = Path.GetFileName(assemblyFile);
                            if (File.Exists(assemblyFile))
                            {
                                issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = assemblyFileName, "AssemblyFileName");
                                processedHelpFiles.Add(assemblyFileName);
                                var proxy = EnvironmentHelpers.CreateProxy<CmdletLoader>(directory, out _appDomain);
                                var newModuleMetadata = proxy.GetModuleMetadata(assemblyFile, requiredModules);

                                string fileName = assemblyFileName + ".json";
                                string executingPath =
                                    Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);

                                string filePath = executingPath + "\\SerializedCmdlets\\" + fileName;
                                bool serialize = false;

                                if (serialize)
                                {
                                    SerializeCmdlets(filePath, newModuleMetadata);
                                }
                                else
                                {
                                    if (!File.Exists(filePath))
                                    {
                                        continue;
                                    }

                                    var oldModuleMetadata = DeserializeCmdlets(filePath);

                                    if (cmdletFilter != null)
                                    {
                                        string output = string.Format("Before filter\nOld module cmdlet count: {0}\nNew module cmdlet count: {1}",
                                            oldModuleMetadata.Cmdlets.Count, newModuleMetadata.Cmdlets.Count);

                                        output += string.Format("\nCmdlet file: {0}", assemblyFileName);

                                        oldModuleMetadata.FilterCmdlets(cmdletFilter);
                                        newModuleMetadata.FilterCmdlets(cmdletFilter);

                                        output += string.Format("After filter\nOld module cmdlet count: {0}\nNew module cmdlet count: {1}",
                                            oldModuleMetadata.Cmdlets.Count, newModuleMetadata.Cmdlets.Count);

                                        foreach (var cmdlet in oldModuleMetadata.Cmdlets)
                                        {
                                            output += string.Format("\n\tOld cmdlet - {0}", cmdlet.Name);
                                        }

                                        foreach (var cmdlet in newModuleMetadata.Cmdlets)
                                        {
                                            output += string.Format("\n\tNew cmdlet - {0}", cmdlet.Name);
                                        }

                                        issueLogger.WriteMessage(output + Environment.NewLine);
                                    }

                                    RunBreakingChangeChecks(oldModuleMetadata, newModuleMetadata, issueLogger);
                                }

                                AppDomain.Unload(_appDomain);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Serialize the cmdlets so they can be compared to change modules later
        /// </summary>
        /// <param name="fileName">Name of the file cmdlets are being serialized to.</param>
        /// <param name="cmdlets">List of cmdlets that are to be serialized.</param>
        private void SerializeCmdlets(string fileName, ModuleMetadata moduleMetadata)
        {
            string json = JsonConvert.SerializeObject(moduleMetadata, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Deserialize the cmdlets to compare them to the changed modules
        /// </summary>
        /// <param name="fileName">Name of the file we are to deserialize the cmdlets from.</param>
        /// <returns></returns>
        private ModuleMetadata DeserializeCmdlets(string fileName)
        {
           return JsonConvert.DeserializeObject<ModuleMetadata>(File.ReadAllText(fileName));
        }

        /// <summary>
        /// Run all of the different breaking change checks that we have for the tool
        /// </summary>
        /// <param name="oldModuleMetadata">Information about the module from the old (serialized) assembly.</param>
        /// <param name="newModuleMetadata">Information about the module from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void RunBreakingChangeChecks(
            ModuleMetadata oldModuleMetadata,
            ModuleMetadata newModuleMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // Get the list of cmdlet metadata from each module
            var oldCmdlets = oldModuleMetadata.Cmdlets;
            var newCmdlets = newModuleMetadata.Cmdlets;

            // Get the type dictionary from each module
            var oldTypeDictionary = oldModuleMetadata.TypeDictionary;
            var newTypeDictionary = newModuleMetadata.TypeDictionary;

            // Initialize a TypeMetadataHelper object that knows how to compare types
            TypeMetadataHelper typeMetadataHelper = new TypeMetadataHelper(oldTypeDictionary, newTypeDictionary);

            // Initialize a CmdletMetadataHelper object that knows how to compare cmdlets
            CmdletMetadataHelper cmdletMetadataHelper = new CmdletMetadataHelper(typeMetadataHelper);

            // Compare the cmdlet metadata
            cmdletMetadataHelper.CompareCmdletMetadata(oldCmdlets, newCmdlets, issueLogger);
        }

        public AnalysisReport GetAnalysisReport()
        {
            AnalysisReport analysisReport = new AnalysisReport();
            ReportLogger reportLog = Logger.GetReportLogger(BreakingChangeIssueReportLoggerName);
            if (reportLog.Records.Any())
            {
                foreach (IReportRecord rec in reportLog.Records)
                {
                    analysisReport.ProblemIdList.Add(rec.ProblemId);
                }
            }

            return analysisReport;
        }
    }

    public static class LogExtensions
    {
        public static void LogBreakingChangeIssue(
            this ReportLogger<BreakingChangeIssue> issueLogger, CmdletMetadata cmdlet,
            string description, string remediation, int severity, int problemId)
        {
            issueLogger.LogRecord(new BreakingChangeIssue
            {
                ClassName = cmdlet.ClassName,
                Target = cmdlet.Name,
                Description = description,
                Remediation = remediation,
                Severity = severity,
                ProblemId = problemId
            });
        }
    }
}