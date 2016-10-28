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
        /// Given a set of directory paths containing PowerShell module folders, analyzer the breaking
        /// changes in the modules and report any issues
        /// </summary>
        /// <param name="scopes"></param>
        public void Analyze(IEnumerable<string> cmdletProbingDirs)
        {
            Analyze(cmdletProbingDirs, null, null);
        }
        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<BreakingChangeIssue>("BreakingChangeIssues.csv");

            List<string> probingDirectories = new List<string>();

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") && Directory.Exists(Path.GetFullPath(s))))
            {
                foreach (var directory in Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)))
                {
                    var index = Path.GetFileName(directory).IndexOf(".");
                    var service = Path.GetFileName(directory).Substring(index + 1);

                    var helpFiles = Directory.EnumerateFiles(directory, "*.dll-Help.xml")
                        .Where(f => !processedHelpFiles.Contains(Path.GetFileName(f),
                            StringComparer.OrdinalIgnoreCase) && Path.GetFileName(f).IndexOf(service) >= 0).ToList();
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

                                string fileName = cmdletFileName + ".bin";
                                var oldCmdlets = DeserializeCmdlets(fileName);

                                if (cmdletFilter != null)
                                {
                                    newCmdlets = newCmdlets.Where<CmdletBreakingChangeMetadata>((cmdlet) => cmdletFilter(cmdlet.Name)).ToList<CmdletBreakingChangeMetadata>();
                                    oldCmdlets = oldCmdlets.Where<CmdletBreakingChangeMetadata>((cmdlet) => cmdletFilter(cmdlet.Name)).ToList<CmdletBreakingChangeMetadata>();
                                }

                                RunBreakingChangeChecks(oldCmdlets, newCmdlets, issueLogger);
                            }
                        }
                    }
                }
            }
        }

        private void SerializeCmdlets(string fileName, IList<CmdletBreakingChangeMetadata> cmdlets)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, cmdlets);
            stream.Close();
        }

        private IList<CmdletBreakingChangeMetadata> DeserializeCmdlets(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            IList<CmdletBreakingChangeMetadata> cmdlets = (IList<CmdletBreakingChangeMetadata>)formatter.Deserialize(stream);
            stream.Close();
            return cmdlets;
        }

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
                        CheckForRemovedParameters(oldCmdlet, newCmdlet, issueLogger);
                        CheckForChangedParameterType(oldCmdlet, newCmdlet, issueLogger);
                        CheckForRemovedParameterAlias(oldCmdlet, newCmdlet, issueLogger);
                    }
                }
            }
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
                
                // For each cmdlet in the new assembly, check if it contains the name of the old cmdlet or an alias to the cmdlet
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
                            problemId: 9999,
                            description: string.Format("The cmdlet {0} has been removed.", oldCmdlet.Name),
                            remediation: string.Format("Add the cmdlet {0} back to the module.", oldCmdlet.Name));
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
                    // Since the aliases are sorted, if we are past the possible location of the alias name, stop searching
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
                            problemId: 9999,
                            description: string.Format("The cmdlet {0} no longer supports the alias {1}.", oldCmdlet.Name, oldAlias),
                            remediation: string.Format("Add the alias {0} back to the cmdlet {1}.", oldAlias, oldCmdlet.Name));
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
                    problemId: 9999,
                    description: string.Format("The cmdlet {0} no longer implements SupportsShouldProcess.", oldCmdlet.Name),
                    remediation: string.Format("Make sure the cmdlet {0} implements SupportsShouldProcess.", oldCmdlet.Name));
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
                    problemId: 9999,
                    description: string.Format("The cmdlet {0} no longer implements SupportsPaging.", oldCmdlet.Name),
                    remediation: string.Format("Make sure the cmdlet {0} implements SupportsPaging.", oldCmdlet.Name));
            }
        }

        /// <summary>
        /// Check if a parameter has been removed without an alias to the original name.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
        private void CheckForRemovedParameters(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameters = oldCmdlet.Parameters;
            var newParameters = newCmdlet.Parameters;

            // For each parameter in the old cmdlet assembly, check if the parameter has been removed with no alias
            foreach (var oldParameter in oldParameters)
            {
                bool found = false;

                // For each parameter in the new assembly, check if it contains the name of the old parameter or an alias to the parameter
                foreach (var newParameter in newParameters)
                {
                    // For each alias the new parameter contains, check if it is the old parameter name
                    foreach (var alias in newParameter.AliasList)
                    {
                        if (oldParameter.Name.Equals(alias))
                        {
                            found = true;
                            break;
                        }
                    }

                    // Check if the parameter name is equal to the old parameter name
                    if (oldParameter.Name.Equals(newParameter.Name))
                    {
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
                            problemId: 9999,
                            description: string.Format("The cmdlet {0} no longer supports the parameter {1} and " +
                                                       "no alias was found for the original parameter name.", oldCmdlet.Name, oldParameter.Name),
                            remediation: string.Format("Add the parameter {0} back to the cmdlet {1} or " +
                                                       "add an alias to the original parameter name.", oldParameter.Name, oldCmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Check if the output type for a parameter has been changed.
        /// </summary>
        /// <param name="oldCmdlet"></param>
        /// <param name="newCmdlet"></param>
        /// <param name="issueLogger"></param>
        private void CheckForChangedParameterType(
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameters = oldCmdlet.Parameters;
            var newParameters = newCmdlet.Parameters;

            newParameters = newParameters.OrderBy(p => p.Name).ToList();

            // For each parameter in the old cmdlet assembly, find the corresponding parameter in the new cmdlet assembly and compare the output types
            foreach (var oldParameter in oldParameters)
            {
                foreach (var newParameter in newParameters)
                {
                    // Because the parameter list is sorted, break out of the loop once passed the possible location of the parameter
                    if (oldParameter.Name.CompareTo(newParameter.Name) < 0)
                    {
                        break;
                    }

                    // If the parameters are equal, check the output type
                    if (oldParameter.Name.Equals(newParameter.Name))
                    {
                        // If the output types are different, log an issue
                        if (!oldParameter.Type.Name.Equals(newParameter.Type.Name))
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: oldCmdlet,
                                severity: 0,
                                problemId: 9999,
                                description: string.Format("The cmdlet {0} no longer supports the output type {1} for parameter {2}.",
                                                           oldCmdlet.Name, oldParameter.Type.Name, oldParameter.Name),
                                remediation: string.Format("Change the output type for parameter {0} back to {1}.",
                                                           oldParameter.Name, oldParameter.Type.Name));
                        }

                        break;
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
            CmdletBreakingChangeMetadata oldCmdlet,
            CmdletBreakingChangeMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldParameters = oldCmdlet.Parameters;
            var newParameters = newCmdlet.Parameters;

            newParameters = newParameters.OrderBy(p => p.Name).ToList();

            // For each parameter in the old cmdlet assembly, find the corresponding parameter in the new cmdlet assembly and compare the aliases
            foreach (var oldParameter in oldParameters)
            {
                foreach (var newParameter in newParameters)
                {
                    // Because the parameter list is sorted, break out of the loop once passed the possible location of the parameter
                    if (oldParameter.Name.CompareTo(newParameter.Name) < 0)
                    {
                        break;
                    }

                    // If the parameter are equal, compare the aliases of each
                    if (oldParameter.Name.Equals(newParameter.Name))
                    {
                        var oldAliases = oldParameter.AliasList;
                        var newAliases = newParameter.AliasList;

                        newAliases = newAliases.OrderBy(a => a).ToList();
                        
                        // For each alias in the old parameter, check if it exists in the new parameter's alias list
                        foreach (var oldAlias in oldAliases)
                        {
                            bool found = false;

                            foreach (var newAlias in newAliases)
                            {
                                // Because the alias list is sorted, once we pass the possible location of the alias, stop searching
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
                                    cmdlet: oldCmdlet,
                                    severity: 0,
                                    problemId: 9999,
                                    description: string.Format("The cmdlet {0} no longer supports the alias {1} for parameter {2}.",
                                                               oldCmdlet.Name, oldAlias, oldParameter.Name),
                                    remediation: string.Format("Add the alias back to parameter {0}.",
                                                               oldParameter.Name));
                            }
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
