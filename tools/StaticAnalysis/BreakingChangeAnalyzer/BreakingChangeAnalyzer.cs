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

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    public class BreakingChangeAnalyzer : IStaticAnalyzer
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public string BreakingChangeIssueReportLoggerName { get; set; }

        private AppDomain _appDomain;
        private HashSet<string> _typeSet;
        private Dictionary<string, TypeMetadata> _oldTypeDictionary;
        private Dictionary<string, TypeMetadata> _newTypeDictionary;

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
            Func<string, bool> cmdletFilter)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") && 
                                                                        Directory.Exists(Path.GetFullPath(s))))
            {
                List<string> probingDirectories = new List<string>();

                // Add current directory for probing
                probingDirectories.Add(baseDirectory);
                probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));

                foreach (var directory in probingDirectories)
                {
                    var index = Path.GetFileName(directory).IndexOf(".");
                    var service = Path.GetFileName(directory).Substring(index + 1);

                    var helpFiles = Directory.EnumerateFiles(directory, "*.dll-Help.xml")
                        .Where(f => !processedHelpFiles.Contains(Path.GetFileName(f),
                            StringComparer.OrdinalIgnoreCase)).ToList();

                    if (helpFiles.Count > 1)
                    {
                        helpFiles = helpFiles.Where(f => Path.GetFileName(f).IndexOf(service) >= 0).ToList();
                    }

                    if (helpFiles.Any())
                    {
                        Directory.SetCurrentDirectory(directory);
                        foreach (var helpFile in helpFiles)
                        {
                            var cmdletFile = helpFile.Substring(0, helpFile.Length - "-Help.xml".Length);
                            var helpFileName = Path.GetFileName(helpFile);
                            var cmdletFileName = Path.GetFileName(cmdletFile);
                            if (File.Exists(cmdletFile))
                            {
                                issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = cmdletFileName, "AssemblyFileName");
                                processedHelpFiles.Add(helpFileName);
                                var proxy = 
                                    EnvironmentHelpers.CreateProxy<CmdletBreakingChangeLoader>(directory, out _appDomain);
                                var newModuleMetadata = proxy.GetModuleMetadata(cmdletFile);

                                string fileName = cmdletFileName + ".json";
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
                                    var oldModuleMetadata = DeserializeCmdlets(filePath);

                                    if (cmdletFilter != null)
                                    {
                                        oldModuleMetadata.FilterCmdlets(cmdletFilter);
                                        newModuleMetadata.FilterCmdlets(cmdletFilter);
                                    }

                                    RunBreakingChangeChecks(oldModuleMetadata, newModuleMetadata, issueLogger);
                                }
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
        /// <param name="oldCmdlets">List of cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlets">List of cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void RunBreakingChangeChecks(
            ModuleMetadata oldModuleMetadata,
            ModuleMetadata newModuleMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldCmdlets = oldModuleMetadata.Cmdlets;
            var newCmdlets = newModuleMetadata.Cmdlets;

            _typeSet = new HashSet<String>();
            _oldTypeDictionary = oldModuleMetadata.TypeDictionary;
            _newTypeDictionary = newModuleMetadata.TypeDictionary;

            // Create a dictionary that maps a cmdlet name (and alias) to the corresponding metadata
            IDictionary<string, CmdletBreakingChangeMetadata> cmdletMap = 
                new Dictionary<string, CmdletBreakingChangeMetadata>();

            // For each cmdlet in the new assembly, add it to the dictionary
            foreach (var newCmdlet in newCmdlets)
            {
                cmdletMap.Add(newCmdlet.Name, newCmdlet);

                foreach (var alias in newCmdlet.AliasList)
                {
                    if (!cmdletMap.ContainsKey(alias))
                    {
                        cmdletMap.Add(alias, newCmdlet);
                    }
                }
            }

            // For each cmdlet in the old assembly, check to see if it's in the new
            // assembly, and if so, do the necessary breaking change checks
            foreach (var oldCmdlet in oldCmdlets)
            {
                // If the cmdlet is in the new assembly, carry out the breaking change checks
                if (cmdletMap.ContainsKey(oldCmdlet.Name))
                {
                    // Get the cmdlet metadata from the new assembly
                    var newCmdlet = cmdletMap[oldCmdlet.Name];

                    CheckForRemovedCmdletAlias(oldCmdlet, newCmdlet, issueLogger);
                    CheckForRemovedSupportsShouldProcess(oldCmdlet, newCmdlet, issueLogger);
                    CheckForRemovedSupportsPaging(oldCmdlet, newCmdlet, issueLogger);
                    CheckForChangedOutputType(oldCmdlet, newCmdlet, issueLogger);
                    CheckDefaultParameterName(oldCmdlet, newCmdlet, issueLogger);

                    // Create a dictionary that maps a parameter name (and alias) to the corresponding metadata
                    IDictionary<string, ParameterMetadata> parameterMap = new Dictionary<string, ParameterMetadata>();

                    // For each parameter in the new assembly, add it to the dictionary
                    foreach (var newParameter in newCmdlet.Parameters)
                    {
                        parameterMap.Add(newParameter.Name, newParameter);

                        foreach (var alias in newParameter.AliasList)
                        {
                            parameterMap.Add(alias, newParameter);
                        }
                    }

                    // For each parameter in the old assembly, check to see if it's in the new
                    // assembly, and if so, do the necessary breaking change checks
                    foreach (var oldParameter in oldCmdlet.Parameters)
                    {
                        // If the parameter is in the new assembly, carry out the breaking change checks
                        if (parameterMap.ContainsKey(oldParameter.Name))
                        {
                            var newParameter = parameterMap[oldParameter.Name];

                            CheckParameters(oldCmdlet, oldParameter, newParameter, issueLogger);
                        }
                        // If the parameter is not in the new assembly, log an issue
                        else
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: oldCmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.RemovedParameter,
                                description: string.Format(Properties.Resources.RemovedParameterDescription, 
                                    oldCmdlet.Name, oldParameter.Name),
                                remediation: string.Format(Properties.Resources.RemovedParameterRemediation, 
                                    oldParameter.Name, oldCmdlet.Name));
                        }
                    }

                    // Create a dictionary that maps a parameter set name to the corresponding metadata
                    IDictionary<string, ParameterSetMetadata> parameterSetMap = 
                        new Dictionary<string, ParameterSetMetadata>();

                    // For each parameter set in the new assembly, add it to the dictionary
                    foreach (var newParameterSet in newCmdlet.ParameterSets)
                    {
                        parameterSetMap.Add(newParameterSet.Name, newParameterSet);
                    }

                    // For each parameter set in the old assembly, check to see if it's in the new
                    // assembly, and if so, do the necessary breaking change checks
                    foreach (var oldParameterSet in oldCmdlet.ParameterSets)
                    {
                        // If the parameter set is in the new assembly, carry out the breaking change checks
                        if (parameterSetMap.ContainsKey(oldParameterSet.Name))
                        {
                            var newParameterSet = parameterSetMap[oldParameterSet.Name];

                            CheckParameterSets(oldCmdlet, oldParameterSet, newParameterSet, issueLogger);
                        }
                        // If the parameter set is not in the new assembly, log an issue
                        // If the only parameter set in the old assembly was "__AllParameterSets" (none),
                        // don't log an issue
                        else if (!parameterSetMap.ContainsKey(oldParameterSet.Name) && 
                                    !oldParameterSet.Name.Equals("__AllParameterSets"))
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: oldCmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterSet,
                                description: string.Format(Properties.Resources.RemovedParameterSetDescription, 
                                    oldParameterSet.Name, oldCmdlet.Name),
                                remediation: string.Format(Properties.Resources.RemovedParameterSetRemediation, 
                                    oldParameterSet.Name, oldCmdlet.Name));
                        }
                    }
                }
                // If the cmdlet is not in the new assembly, log an issue
                else
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: oldCmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedCmdlet,
                        description: string.Format(Properties.Resources.RemovedCmdletDescription, oldCmdlet.Name),
                        remediation: string.Format(Properties.Resources.RemovedCmdletRemediation, oldCmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Run all of the different breaking change checks for parameters
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly. </param>
        /// <param name="newParameter">The parameter metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckParameters(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            CheckForChangedParameterType(cmdlet, oldParameter, newParameter, issueLogger);
            CheckForRemovedParameterAlias(cmdlet, oldParameter, newParameter, issueLogger);
            CheckParameterValidationSets(cmdlet, oldParameter, newParameter, issueLogger);
            CheckForValidateNotNullOrEmpty(cmdlet, oldParameter, newParameter, issueLogger);
        }

        /// <summary>
        /// Run all of the different breaking change checks for parameter sets
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="oldParameterSet">The parameter set metadata from the old (serialized) assembly.</param>
        /// <param name="newParameterSet">The parameter set metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckParameterSets(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterSetMetadata oldParameterSet,
            ParameterSetMetadata newParameterSet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // For each of the parameters in the old parameter set assembly, find the parameter
            // in the new parameter set assembly that either has the same name, or an alias to
            // the original name
            foreach (var oldParameter in oldParameterSet.Parameters)
            {
                bool found = false;

                foreach (var newParameter in newParameterSet.Parameters)
                {
                    if (oldParameter.ParameterMetadata.Name.Equals(newParameter.ParameterMetadata.Name) ||
                        newParameter.ParameterMetadata.AliasList
                            .Where(alias => alias.Equals(oldParameter.ParameterMetadata.Name))
                            .ToList().Count > 0)
                    {
                        found = true;

                        // If the parameter was optional in the old assembly and
                        // mandatory in the new assembly, log an issue
                        if (!oldParameter.Mandatory && newParameter.Mandatory)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.MandatoryParameter,
                                description: string.Format(Properties.Resources.MandatoryParameterDescription, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.MandatoryParameterRemediation, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                        }

                        // If the parameter had a position and it has changed in the
                        // new assembly, log an issue
                        if (oldParameter.Position >= 0 && oldParameter.Position != newParameter.Position)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.PositionChange,
                                description: string.Format(Properties.Resources.PositionChangeDescription, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.PositionChangeRemediation, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                        }

                        // If the parameter can no longer get its value from
                        // the pipeline, log an issue
                        if (oldParameter.ValueFromPipeline && !newParameter.ValueFromPipeline)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.ValueFromPipeline,
                                description: string.Format(Properties.Resources.RemovedValueFromPipelineDescription, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.RemovedValueFromPipelineRemediation, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                        }

                        // If the parameter can no longer get its value from
                        // the pipeline by property name, log an issue
                        if (oldParameter.ValueFromPipelineByPropertyName && !newParameter.ValueFromPipelineByPropertyName)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.ValueFromPipelineByPropertyName,
                                description: string.Format(Properties.Resources.RemovedValueFromPipelineByPropertyNameDescription, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.RemovedValueFromPipelineByPropertyNameRemediation, 
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                        }

                        break;
                    }
                }

                // If we were unable to find the parameter in the new
                // parameter set assembly, log an issue
                if (!found)
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterFromParameterSet,
                        description: string.Format(Properties.Resources.RemovedParameterFromParameterSetDescription, 
                            oldParameter.ParameterMetadata.Name, cmdlet.Name, oldParameterSet.Name),
                        remediation: string.Format(Properties.Resources.RemovedParameterFromParameterSetRemediation, 
                            oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                }
            }
        }

        /// <summary>
        /// Checks if an alias to a cmdlet has been removed.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedCmdletAlias(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldAliasList = oldCmdlet.AliasList;
            var newAliasList = newCmdlet.AliasList;

            newAliasList = newAliasList.OrderBy(a => a).ToList();

            // For each alias in the old cmdlet, check if it still exists in the new cmdlet alias list
            foreach (var oldAlias in oldAliasList)
            {
                bool found = false;

                foreach (var newAlias in newAliasList)
                {
                    if (oldAlias.CompareTo(newAlias) < 0)
                    {
                        break;
                    }

                    if (oldAlias.Equals(newAlias))
                    {
                        found = true;
                        break;
                    }
                }

                // If we weren't able to find the alias, log an issue
                if (!found)
                {
                    issueLogger.LogBreakingChangeIssue(
                            cmdlet: oldCmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.RemovedCmdletAlias,
                            description: string.Format(Properties.Resources.RemovedCmdletAliasDescription, 
                                oldCmdlet.Name, oldAlias),
                            remediation: string.Format(Properties.Resources.RemovedCmdletAliasRemediation, 
                                oldAlias, oldCmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Check if a cmdlet no longer implements SupportsShouldProcess.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedSupportsShouldProcess(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the old cmdlet implements SupportsShouldProcess and the new cmdlet does not, log an issue
            if (oldCmdlet.SupportsShouldProcess && !newCmdlet.SupportsShouldProcess)
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: oldCmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.RemovedShouldProcess,
                    description: string.Format(Properties.Resources.RemovedShouldProcessDescription, oldCmdlet.Name),
                    remediation: string.Format(Properties.Resources.RemovedShouldProcessRemediation, oldCmdlet.Name));
            }
        }

        /// <summary>
        /// Check if a cmdlet no longer implements SupportsPaging.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedSupportsPaging(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the old cmdlet implements SupportsPaging and the new cmdlet does not, log an issue
            if (oldCmdlet.SupportsPaging && !newCmdlet.SupportsPaging)
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: oldCmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.RemovedPaging,
                    description: string.Format(Properties.Resources.RemovedPagingDescription, oldCmdlet.Name),
                    remediation: string.Format(Properties.Resources.RemovedPagingRemediation, oldCmdlet.Name));
            }
        }

        /// <summary>
        /// Check if the OutputType of the cmdlet has been removed, or if any property
        /// of the OutputType has been removed or changed
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForChangedOutputType(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // For each output in the old cmdlet assembly, look for the corresponding
            // output in the new cmdlet assembly
            foreach (var oldOutput in oldCmdlet.OutputTypes)
            {
                bool found = false;

                foreach (var newOutput in newCmdlet.OutputTypes)
                {
                    // If the corresponding output has been found in the new assembly,
                    // look for through all of the properties
                    if (oldOutput.Type.Name.Equals(newOutput.Type.Name))
                    {
                        found = true;

                        // Recursively look at the properties of each type and their
                        // types to see if there are any breaking changes
                        CompareTypes(oldCmdlet, oldOutput.Type, newOutput.Type, issueLogger);

                        break;
                    }
                    else
                    {
                        // Check to see if the output type name has changed,
                        // but all of the properties are the same
                        bool sameOutput = true;

                        foreach (var oldKey in oldOutput.Type.Properties.Keys)
                        {
                            bool foundKey = false;

                            foreach (var newKey in newOutput.Type.Properties.Keys)
                            {
                                if (oldKey.Equals(newKey) && 
                                    oldOutput.Type.Properties[oldKey].Equals(newOutput.Type.Properties[newKey]))
                                {
                                    foundKey = true;
                                    break;
                                }
                            }

                            if (!foundKey)
                            {
                                sameOutput = false;
                                break;
                            }
                        }

                        if (sameOutput)
                        {
                            found = true;
                        }
                    }
                }

                // If we were unable to find the output type, log an issue
                if (!found)
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: oldCmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputType,
                        description: string.Format(Properties.Resources.ChangedOutputTypeDescription, 
                            oldCmdlet.Name, oldOutput.Type.Name),
                        remediation: string.Format(Properties.Resources.ChangedOutputTypeRemediation, 
                            oldCmdlet.Name, oldOutput.Type.Name));
                }
            }
        }

        /// <summary>
        /// Check if the default parameter set has changed, and if so, make sure
        /// that the parameters are the same
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckDefaultParameterName(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the default parameter name hasn't changed, or if there wasn't a
            // default parameter set defined before, return
            if (oldCmdlet.DefaultParameterSetName.Equals(newCmdlet.DefaultParameterSetName) ||
                oldCmdlet.DefaultParameterSetName.Equals("__AllParameterSets"))
            {
                return;
            }

            ParameterSetMetadata oldDefaultParameterSet = null;
            ParameterSetMetadata newDefaultParameterSet = null;

            // Get the ParameterSetMetadata object corresponding to the
            // default parameter set for the old assembly
            foreach (var oldParameterSet in oldCmdlet.ParameterSets)
            {
                if (oldParameterSet.Name.Equals(oldCmdlet.DefaultParameterSetName))
                {
                    oldDefaultParameterSet = oldParameterSet;
                    break;
                }
            }

            // Get the ParameterSetMetadata object corresponding to the
            // default parameter set for the new assembly
            foreach (var newParameterSet in newCmdlet.ParameterSets)
            {
                if (newParameterSet.Name.Equals(newCmdlet.DefaultParameterSetName))
                {
                    newDefaultParameterSet = newParameterSet;
                    break;
                }
            }

            bool issue = false;

            // For each parameter in the old default parameter set, find
            // the corresponding parameter in the new default parameter set
            foreach (var oldParameter in oldDefaultParameterSet.Parameters)
            {
                bool found = false;

                foreach (var newParameter in newDefaultParameterSet.Parameters)
                {
                    if (oldParameter.ParameterMetadata.Name.Equals(newParameter.ParameterMetadata.Name) ||
                        newParameter.ParameterMetadata.AliasList
                            .Where(alias => alias.Equals(oldParameter.ParameterMetadata.Name))
                            .ToList().Count > 0)
                    {
                        found = true;
                        break;
                    }
                }

                // If we weren't able to find the parameter, file an issue
                if (!found)
                {
                    issue = true;
                    break;
                }
            }

            // File an issue if a parameter in the old default parameter set
            // has been removed in the new default parameter set
            if (issue)
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: oldCmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.ChangeDefaultParameter,
                    description: string.Format(Properties.Resources.ChangeDefaultParameterDescription, 
                        oldCmdlet.DefaultParameterSetName, oldCmdlet.Name),
                    remediation: string.Format(Properties.Resources.ChangeDefaultParameterRemediation, 
                        oldCmdlet.Name, oldCmdlet.DefaultParameterSetName));
            }            
        }

        /// <summary>
        /// Check if the type for a parameter has been changed, or if any of the
        /// type's properties have been removed or changed.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForChangedParameterType(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the types are different, log an issue
            if (!oldParameter.Type.Name.Equals(newParameter.Type.Name))
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: cmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterType,
                    description: string.Format(Properties.Resources.ChangedParameterTypeDescription, 
                        cmdlet.Name, oldParameter.Type.Name, oldParameter.Name),
                    remediation: string.Format(Properties.Resources.ChangedParameterTypeRemediation, 
                        oldParameter.Name, oldParameter.Type.Name));
            }
            else
            {
                // Recursively look at the properties of each type and their
                // types to see if there are any breaking changes
                CompareTypes(cmdlet, oldParameter.Type, newParameter.Type, issueLogger);
            }

        }

        /// <summary>
        /// Check if an alias to a parameter has been removed.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from new assembly</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedParameterAlias(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldAliases = oldParameter.AliasList;
            var newAliases = newParameter.AliasList;

            newAliases = newAliases.OrderBy(a => a).ToList();

            // For each alias in the old parameter, check if it exists in 
            // the new parameter's alias list
            foreach (var oldAlias in oldAliases)
            {
                bool found = false;

                foreach (var newAlias in newAliases)
                {
                    if (oldAlias.CompareTo(newAlias) < 0)
                    {
                        break;
                    }

                    if (oldAlias.Equals(newAlias))
                    {
                        found = true;
                        break;
                    }
                }

                // If we were unable to find the alias, log an issue
                if (!found)
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterAlias,
                        description: string.Format(Properties.Resources.RemovedParameterAliasDescription, 
                            cmdlet.Name, oldAlias, oldParameter.Name),
                        remediation: string.Format(Properties.Resources.RemovedParameterAliasRemediation, 
                            oldAlias, oldParameter.Name));
                }
            }
        }

        /// <summary>
        /// Check for any values that were removed from a validation set of a parameter.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckParameterValidationSets(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldValidateSet = oldParameter.ValidateSet;
            var newValidateSet = newParameter.ValidateSet;

            // If there was no validate set in the old assembly, but there is
            // one in the new assembly, log an issue
            if (oldValidateSet.Count == 0 && newValidateSet.Count > 0)
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: cmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.AddedValidateSet,
                    description: string.Format(Properties.Resources.AddedValidateSetDescription, 
                        oldParameter.Name, cmdlet.Name),
                    remediation: string.Format(Properties.Resources.AddedValidateSetRemediation, 
                        oldParameter.Name));

                return;
            }

            newValidateSet = newValidateSet.OrderBy(v => v).ToList();

            // For each value in the validation set of the old assembly, check
            // that the value is still in the validation set of the new assembly
            foreach (var oldValue in oldValidateSet)
            {
                bool found = false;

                foreach (var newValue in newValidateSet)
                {
                    if (oldValue.CompareTo(newValue) < 0)
                    {
                        break;
                    }

                    if (oldValue.Equals(newValue))
                    {
                        found = true;
                        break;
                    }
                }

                // Log an issue if the value is not in the validation set
                if (!found)
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedValidateSetValue,
                        description: string.Format(Properties.Resources.RemovedValidateSetValueDescription, 
                            oldParameter.Name, oldValue, cmdlet.Name),
                        remediation: string.Format(Properties.Resources.RemovedValidateSetValueRemediation, 
                            oldValue, oldParameter.Name));
                }
            }
        }

        /// <summary>
        /// Check if the parameter now supports the ValidateNotNullOrEmpty attribute
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly.</param>
        /// <param name="newParameter">The parameter metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForValidateNotNullOrEmpty(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the parameter didn't have the ValidateNotNullOrEmpty attribute in the
            // old assembly, but has it in the new assembly, log an issue
            if (!oldParameter.ValidateNotNullOrEmpty && newParameter.ValidateNotNullOrEmpty)
            {
                issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.AddedValidateNotNullOrEmpty,
                        description: string.Format(Properties.Resources.AddedValidateNotNullOrEmptyDescription, 
                            oldParameter.Name, cmdlet.Name),
                        remediation: string.Format(Properties.Resources.AddedValidateNotNullOrEmptyRemediation, 
                            oldParameter.Name));
            }
        }

        /// <summary>
        /// Compare two types by recursively checking their properties and property
        /// types, making sure that nothing has been removed or changed.
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldType">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newType">The type metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CompareTypes(
            CmdletBreakingChangeMetadata cmdlet,
            TypeMetadata oldType,
            TypeMetadata newType,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // For each property in the old assembly type, find the corresponding
            // property in the new assembly type
            foreach (var oldProperty in oldType.Properties.Keys)
            {
                if (newType.Properties.ContainsKey(oldProperty))
                {
                    var oldPropertyType = oldType.Properties[oldProperty];
                    var newPropertyType = newType.Properties[oldProperty];

                    // If the types are the same, compare their properties
                    if (oldPropertyType.Equals(newPropertyType))
                    {
                        if (!_typeSet.Contains(oldPropertyType))
                        {
                            _typeSet.Add(oldPropertyType);

                            var oldTypeMetadata = _oldTypeDictionary[oldPropertyType];
                            var newTypeMetadata = _newTypeDictionary[newPropertyType];

                            CompareTypes(cmdlet, oldTypeMetadata, newTypeMetadata, issueLogger);
                        }
                    }
                    else
                    {
                        // If the type of the property has been changed, log an issue
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.ChangedPropertyType,
                            description: string.Format(Properties.Resources.ChangedPropertyTypeDescription, 
                                oldProperty, oldType.Name, oldPropertyType, newPropertyType),
                            remediation: string.Format(Properties.Resources.ChangedPropertyTypeRemediation, 
                                oldProperty, oldPropertyType));
                    }
                }
                else
                {
                    // If the property has been removed, log an issue
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedProperty,
                        description: string.Format(Properties.Resources.RemovedPropertyDescription, 
                            oldProperty, oldType.Name),
                        remediation: string.Format(Properties.Resources.RemovedPropertyRemediation, 
                            oldProperty, oldType.Name));
                }
            }
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
            this ReportLogger<BreakingChangeIssue> issueLogger, CmdletBreakingChangeMetadata cmdlet,
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