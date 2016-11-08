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
using System.IO;
using System.Linq;
using System.Management.Automation;
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

        public BreakingChangeAnalyzer()
        {
            Name = "Breaking Change Analyzer";
            BreakingChangeIssueReportLoggerName = "BreakingChangeIssues.csv";
        }

        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders, 
        /// analyze the breaking changes in the modules and report any issues
        /// </summary>
        /// <param name="scopes"></param>
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
        /// <param name="cmdletProbingDirs"></param>
        /// <param name="directoryFilter"></param>
        /// <param name="cmdletFilter"></param>
        public void Analyze(
            IEnumerable<string> cmdletProbingDirs,
            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
            Func<string, bool> cmdletFilter)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");

            List<string> probingDirectories = new List<string>();

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") && 
                                                                        Directory.Exists(Path.GetFullPath(s))))
            {
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
                                var proxy = EnvironmentHelpers.CreateProxy<CmdletBreakingChangeLoader>(directory, out _appDomain);
                                var newCmdlets = proxy.GetCmdlets(cmdletFile);

                                string fileName = cmdletFileName + ".xml";
                                var oldCmdlets = DeserializeCmdlets(fileName);

                                if (cmdletFilter != null)
                                {
                                    newCmdlets = newCmdlets.Where<CmdletBreakingChangeMetadata>(
                                        (cmdlet) => cmdletFilter(cmdlet.Name) ||
                                        cmdlet.AliasList.Where(a => cmdletFilter(a)).ToList().Count > 0)
                                        .ToList<CmdletBreakingChangeMetadata>();

                                    oldCmdlets = oldCmdlets.Where<CmdletBreakingChangeMetadata>(
                                        (cmdlet) => cmdletFilter(cmdlet.Name) ||
                                        cmdlet.AliasList.Where(a => cmdletFilter(a)).ToList().Count > 0)
                                        .ToList<CmdletBreakingChangeMetadata>();
                                }

                                RunBreakingChangeChecks(oldCmdlets, newCmdlets, issueLogger);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Serialize the cmdlets so they can be compared to change modules later
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="cmdlets"></param>
        private void SerializeCmdlets(string fileName, List<CmdletBreakingChangeMetadata> cmdlets)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CmdletBreakingChangeMetadata>));
            StreamWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, cmdlets);
            writer.Close();
        }

        /// <summary>
        /// Deserialize the cmdlets to compare them to the changed modules
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<CmdletBreakingChangeMetadata> DeserializeCmdlets(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CmdletBreakingChangeMetadata>));
            FileStream stream = new FileStream(fileName, FileMode.Open);
            List<CmdletBreakingChangeMetadata> cmdlets = (List<CmdletBreakingChangeMetadata>)serializer.Deserialize(stream);
            stream.Close();
            return cmdlets;
        }

        /// <summary>
        /// Run all of the different breaking change checks that we have for the tool
        /// </summary>
        /// <param name="oldCmdlets"></param>
        /// <param name="newCmdlets"></param>
        /// <param name="issueLogger"></param>
        private void RunBreakingChangeChecks(
            IList<CmdletBreakingChangeMetadata> oldCmdlets,
            IList<CmdletBreakingChangeMetadata> newCmdlets,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            CheckForRemovedCmdlet(oldCmdlets, newCmdlets, issueLogger);

            foreach (var oldCmdlet in oldCmdlets)
            {
                foreach (var newCmdlet in newCmdlets)
                {
                    if (oldCmdlet.Name.Equals(newCmdlet.Name))
                    {
                        CheckForRemovedCmdletAlias(oldCmdlet, newCmdlet, issueLogger);
                        CheckForRemovedSupportsShouldProcess(oldCmdlet, newCmdlet, issueLogger);
                        CheckForRemovedSupportsPaging(oldCmdlet, newCmdlet, issueLogger);
                        CheckForChangedOutputType(oldCmdlet, newCmdlet, issueLogger);

                        var oldParameters = oldCmdlet.Parameters;
                        var newParameters = newCmdlet.Parameters;

                        // For each parameter in the old cmdlet assembly, check if the parameter has been removed with no alias
                        foreach (var oldParameter in oldParameters)
                        {
                            bool found = false;

                            // For each parameter in the new assembly, check if it contains the name of 
                            // the old parameter or an alias to the parameter
                            foreach (var newParameter in newParameters)
                            {
                                // For each alias the new parameter contains, check if it is the old parameter name
                                foreach (var alias in newParameter.AliasList)
                                {
                                    if (oldParameter.Name.Equals(alias))
                                    {
                                        // Check if there are any breaking changes in the parameter
                                        CheckParameters(oldCmdlet, oldParameter, newParameter, issueLogger);
                                        found = true;
                                        break;
                                    }
                                }

                                // Check if the parameter name is equal to the old parameter name
                                if (oldParameter.Name.Equals(newParameter.Name))
                                {
                                    // Check if there are any breaking changes in the parameter
                                    CheckParameters(oldCmdlet, oldParameter, newParameter, issueLogger);
                                    found = true;
                                    break;
                                }
                            }

                            // If the parameter nor an alias to the parameter name was found, log an issue
                            if (!found)
                            {
                                issueLogger.LogBreakingChangeIssue(
                                        cmdlet: oldCmdlet,
                                        severity: 0,
                                        problemId: ProblemIds.BreakingChangeProblemId.RemovedParameter,
                                        description: string.Format(Properties.Resources.RemovedParameterDescription, oldCmdlet.Name, oldParameter.Name),
                                        remediation: string.Format(Properties.Resources.RemovedParameterRemediation, oldParameter.Name, oldCmdlet.Name));
                            }                                
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Run all of the different breaking change checks for parameters
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="oldParameter"></param>
        /// <param name="newParameter"></param>
        /// <param name="issueLogger"></param>
        private void CheckParameters(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            CheckForChangedParameterType(cmdlet, oldParameter, newParameter, issueLogger);
            CheckForRemovedParameterAlias(cmdlet, oldParameter, newParameter, issueLogger);
            CheckForMandatoryParameters(cmdlet, oldParameter, newParameter, issueLogger);
            CheckParameterValidationSets(cmdlet, oldParameter, newParameter, issueLogger);
            CheckParameterPositions(cmdlet, oldParameter, newParameter, issueLogger);
            CheckValueFromPipeline(cmdlet, oldParameter, newParameter, issueLogger);
            CheckValueFromPipelineByPropertyName(cmdlet, oldParameter, newParameter, issueLogger);
        }

        /// <summary>
        /// Checks if a cmdlet has been removed without an alias to the original name.
        /// </summary>
        /// <param name="oldCmdlets"></param>
        /// <param name="newCmdlets"></param>
        /// <param name="issueLogger"></param>
        private void CheckForRemovedCmdlet(
            IList<CmdletBreakingChangeMetadata> oldCmdlets,
            IList<CmdletBreakingChangeMetadata> newCmdlets,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // For each cmdlet in the previous assembly, check if the cmdlet has been removed with no alias
            foreach (var oldCmdlet in oldCmdlets)
            {
                bool found = false;

                // For each cmdlet in the new assembly, check if it contains the 
                // name of the old cmdlet or an alias to the cmdlet
                foreach (var newCmdlet in newCmdlets)
                {
                    // For each alias the new cmdlet contains, check if it is the old cmdlet name
                    foreach (var alias in newCmdlet.AliasList)
                    {
                        if (oldCmdlet.Name.Equals(alias))
                        {
                            found = true;
                            break;
                        }
                    }

                    // Check if the cmdlet name is equal to the old cmdlet name
                    if (oldCmdlet.Name.Equals(newCmdlet.Name))
                    {
                        found = true;
                        break;
                    }
                }

                // If the cmdlet nor an alias to the cmdlet name was found, log an issue
                if (!found)
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
        /// Checks if an alias to a cmdlet has been removed.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
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
                            description: string.Format(Properties.Resources.RemovedCmdletAliasDescription, oldCmdlet.Name, oldAlias),
                            remediation: string.Format(Properties.Resources.RemovedCmdletAliasRemediation, oldAlias, oldCmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Check if a cmdlet no longer implements SupportsShouldProcess.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
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
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
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
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
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

                        // For each property in the old output type, look for the 
                        // corresponding property in the new output type
                        foreach (var oldKey in oldOutput.Type.Properties.Keys)
                        {
                            bool foundKey = false;

                            foreach (var newKey in newOutput.Type.Properties.Keys)
                            {
                                // If the corresponding property has been found,
                                // see if the type is the same
                                if (oldKey.Equals(newKey))
                                {
                                    foundKey = true;

                                    // If the type of the property has changed, log an issue
                                    if (!oldOutput.Type.Properties.Get(oldKey).Equals(newOutput.Type.Properties.Get(newKey)))
                                    {
                                        issueLogger.LogBreakingChangeIssue(
                                            cmdlet: oldCmdlet,
                                            severity: 0,
                                            problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputTypeProperty,
                                            description: string.Format(Properties.Resources.ChangedOutputTypePropertyDescription,
                                                                        oldOutput.Type.Name, oldCmdlet.Name, oldKey, oldOutput.Type.Properties.Get(oldKey)),
                                            remediation: string.Format(Properties.Resources.ChangedOutputTypePropertyRemediation,
                                                                        oldKey, oldOutput.Type.Name, oldOutput.Type.Properties.Get(oldKey)));
                                    }

                                    break;
                                }
                            }

                            // If we were unable to find the property, log an issue
                            if (!foundKey)
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: oldCmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputTypeProperty,
                                    description: string.Format(Properties.Resources.RemovedOutputTypePropertyDescription,
                                                                oldOutput.Type.Name, oldCmdlet.Name, oldKey),
                                    remediation: string.Format(Properties.Resources.RemovedOutputTypePropertyRemediation,
                                                                oldOutput.Type.Name, oldKey));
                            }
                        }

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
                                    oldOutput.Type.Properties.Get(oldKey).Equals(newOutput.Type.Properties.Get(newKey)))
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
                        description: string.Format(Properties.Resources.ChangedOutputTypeDescription, oldCmdlet.Name, oldOutput.Type.Name),
                        remediation: string.Format(Properties.Resources.ChangedOutputTypeRemediation, oldCmdlet.Name, oldOutput.Type.Name));
                }
            }
        }

        /// <summary>
        /// Check if the type for a parameter has been changed, or if any of the
        /// type's properties have been removed or changed.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
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
                    description: string.Format(Properties.Resources.ChangedParameterTypeDescription, cmdlet.Name, oldParameter.Type.Name, oldParameter.Name),
                    remediation: string.Format(Properties.Resources.ChangedParameterTypeRemediation, oldParameter.Name, oldParameter.Type.Name));
            }
            else
            {
                // Look through each of the properties of the type
                // For each property in the old parameter type, look for
                // the corresponding property in the new parameter type
                foreach (var oldKey in oldParameter.Type.Properties.Keys)
                {
                    bool found = false;

                    foreach (var newKey in newParameter.Type.Properties.Keys)
                    {
                        // If we found the correpsonding property,
                        // check if the types are the same
                        if (oldKey.Equals(newKey))
                        {
                            found = true;

                            // If the type has changed for the property, log an issue
                            if (!oldParameter.Type.Properties.Get(oldKey).Equals(newParameter.Type.Properties.Get(newKey)))
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterTypeProperty,
                                    description: string.Format(Properties.Resources.ChangedParameterTypePropertyDescription,
                                                                oldKey, oldParameter.Type.Name, oldParameter.Name, cmdlet.Name, oldParameter.Type.Properties.Get(oldKey)),
                                    remediation: string.Format(Properties.Resources.ChangedParameterTypePropertyRemediation,
                                                                oldKey, oldParameter.Type.Properties.Get(oldKey)));
                            }
                        }
                    }

                    // If we were unable to find the property, log an issue
                    if (!found)
                    {
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterTypeProperty,
                            description: string.Format(Properties.Resources.RemovedParameterTypePropertyDescription,
                                                        oldKey, oldParameter.Type.Name, oldParameter.Name, cmdlet.Name),
                            remediation: string.Format(Properties.Resources.RemovedParameterTypePropertyRemediation,
                                                        oldKey, oldParameter.Type.Name));
                    }
                }
            }

        }

        /// <summary>
        /// Check if an alias to a parameter has been removed.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
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
                        description: string.Format(Properties.Resources.RemovedParameterAliasDescription, cmdlet.Name, oldAlias, oldParameter.Name),
                        remediation: string.Format(Properties.Resources.RemovedParameterAliasRemediation, oldAlias, oldParameter.Name));
                }
            }
        }

        /// <summary>
        /// Checks if a parameter has been made mandatory for a given parameter set.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
        private void CheckForMandatoryParameters(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameterSets = oldParameter.ParameterSets;
            var newParameterSets = newParameter.ParameterSets;

            newParameterSets = newParameterSets.OrderBy(p => p.Name).ToList();

            // For each parameter set in the old assembly, find the matching
            // parameter set in the new assembly and compare their values
            foreach (var oldParameterSet in oldParameterSets)
            {
                foreach (var newParameterSet in newParameterSets)
                {
                    if (oldParameterSet.Name.CompareTo(newParameterSet.Name) < 0)
                    {
                        break;
                    }

                    if (oldParameterSet.Name.Equals(newParameterSet.Name))
                    {
                        // If the parameter was optional in the old assembly and
                        // mandatory in the new assembly, log an issue
                        if (!oldParameterSet.Mandatory && newParameterSet.Mandatory)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.MandatoryParameter,
                                description: string.Format(Properties.Resources.MandatoryParameterDescription, oldParameter.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.MandatoryParameterRemediation, oldParameter.Name, oldParameterSet.Name));
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Check for any values that were removed from a validation set of a parameter.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
        public void CheckParameterValidationSets(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldValidateSet = oldParameter.ValidateSet;
            var newValidateSet = newParameter.ValidateSet;

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
                        problemId: ProblemIds.BreakingChangeProblemId.ValidateSet,
                        description: string.Format(Properties.Resources.ValidateSetDescription, oldParameter.Name, oldValue, cmdlet.Name),
                        remediation: string.Format(Properties.Resources.ValidateSetRemediation, oldValue, oldParameter.Name));
                }
            }
        }

        /// <summary>
        /// Check for any position changes in parameters 
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="oldParameter"></param>
        /// <param name="newParameter"></param>
        /// <param name="issueLogger"></param>
        public void CheckParameterPositions(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameterSets = oldParameter.ParameterSets;
            var newParameterSets = newParameter.ParameterSets;

            newParameterSets = newParameterSets.OrderBy(p => p.Name).ToList();

            // For each parameter set in the old assembly, find the matching
            // parameter set in the new assembly and compare their values
            foreach (var oldParameterSet in oldParameterSets)
            {
                foreach (var newParameterSet in newParameterSets)
                {
                    if (oldParameterSet.Name.CompareTo(newParameterSet.Name) < 0)
                    {
                        break;
                    }

                    if (oldParameterSet.Name.Equals(newParameterSet.Name))
                    {
                        if (oldParameterSet.Position >= 0 && oldParameterSet.Position != newParameterSet.Position)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.PositionChange,
                                description: string.Format(Properties.Resources.PositionChangeDescription, oldParameter.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.PositionChangeRemediation, oldParameter.Name, oldParameterSet.Name));
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Check if the parameter has a parameter set where it
        /// can no longer obtain its value from the pipeline
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="oldParameter"></param>
        /// <param name="newParameter"></param>
        /// <param name="issueLogger"></param>
        public void CheckValueFromPipeline(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameterSets = oldParameter.ParameterSets;
            var newParameterSets = newParameter.ParameterSets;

            newParameterSets = newParameterSets.OrderBy(p => p.Name).ToList();

            // For each parameter set in the old assembly, find the matching
            // parameter set in the new assembly and compare their values
            foreach (var oldParameterSet in oldParameterSets)
            {
                foreach (var newParameterSet in newParameterSets)
                {
                    if (oldParameterSet.Name.CompareTo(newParameterSet.Name) < 0)
                    {
                        break;
                    }

                    if (oldParameterSet.Name.Equals(newParameterSet.Name))
                    {
                        if (oldParameterSet.ValueFromPipeline && !newParameterSet.ValueFromPipeline)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.ValueFromPipeline,
                                description: string.Format(Properties.Resources.RemovedValueFromPipelineDescription, oldParameter.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.RemovedValueFromPipelineRemediation, oldParameter.Name, oldParameterSet.Name));
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Check if the parameter has a parameter set where it can no
        /// longer obtain its value from the pipeline by property name 
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="oldParameter"></param>
        /// <param name="newParameter"></param>
        /// <param name="issueLogger"></param>
        public void CheckValueFromPipelineByPropertyName(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameterSets = oldParameter.ParameterSets;
            var newParameterSets = newParameter.ParameterSets;

            newParameterSets = newParameterSets.OrderBy(p => p.Name).ToList();

            // For each parameter set in the old assembly, find the matching
            // parameter set in the new assembly and compare their values
            foreach (var oldParameterSet in oldParameterSets)
            {
                foreach (var newParameterSet in newParameterSets)
                {
                    if (oldParameterSet.Name.CompareTo(newParameterSet.Name) < 0)
                    {
                        break;
                    }

                    if (oldParameterSet.Name.Equals(newParameterSet.Name))
                    {
                        if (oldParameterSet.ValueFromPipelineByPropertyName && !newParameterSet.ValueFromPipelineByPropertyName)
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.ValueFromPipelineByPropertyName,
                                description: string.Format(Properties.Resources.RemovedValueFromPipelineByPropertyNameDescription, oldParameter.Name, oldParameterSet.Name, cmdlet.Name),
                                remediation: string.Format(Properties.Resources.RemovedValueFromPipelineByPropertyNameRemediation, oldParameter.Name, oldParameterSet.Name));
                        }

                        break;
                    }
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
        public static void LogBreakingChangeIssue(this ReportLogger<BreakingChangeIssue> issueLogger, CmdletBreakingChangeMetadata cmdlet,
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
