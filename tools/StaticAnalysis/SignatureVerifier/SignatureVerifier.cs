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

using StaticAnalysis.ProblemIds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace StaticAnalysis.SignatureVerifier
{
    public class SignatureVerifier : IStaticAnalyzer
    {
        private AppDomain _appDomain;
        AnalysisLogger _logger;
        string signatureIssueReportLoggerName;
        public SignatureVerifier()
        {
            Name = "Signature Verifier";
            signatureIssueReportLoggerName = "SignatureIssues.csv";
        }
        public AnalysisLogger Logger { get; set; }

        public string Name { get; private set; }

        public void Analyze(IEnumerable<string> cmdletProbingDirs)
        {
            Analyze(cmdletProbingDirs, null, null);
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs,
                            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
                            Func<string, bool> cmdletFilter)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<SignatureIssue>(signatureIssueReportLoggerName);
            
            List<string> probingDirectories = new List<string>();

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") && Directory.Exists(Path.GetFullPath(s))))
            {
                //Add current directory for probing
                probingDirectories.Add(baseDirectory);
                probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));

                foreach(var directory in probingDirectories)
                {
                    var helpFiles = Directory.EnumerateFiles(directory, "*.dll-Help.xml")
                        .Where(f => !processedHelpFiles.Contains(Path.GetFileName(f),
                            StringComparer.OrdinalIgnoreCase)).ToList();
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
                                var proxy = EnvironmentHelpers.CreateProxy<CmdletSignatureLoader>(directory, out _appDomain);
                                var cmdlets = proxy.GetCmdlets(cmdletFile);

                                if (cmdletFilter != null)
                                {
                                    cmdlets = cmdlets.Where<CmdletSignatureMetadata>((cmdlet) => cmdletFilter(cmdlet.Name)).ToList<CmdletSignatureMetadata>();
                                }

                                foreach (var cmdlet in cmdlets)
                                {
                                    Logger.WriteMessage("Processing cmdlet '{0}'", cmdlet.ClassName);
                                    string defaultRemediation = "Determine if the cmdlet should implement ShouldProcess and " +
                                                          "if so determine if it should implement Force / ShouldContinue";
                                    if (!cmdlet.SupportsShouldProcess && cmdlet.HasForceSwitch)
                                    {
                                        issueLogger.LogSignatureIssue(
                                           cmdlet: cmdlet,
                                           severity: 0,
                                        problemId: SignatureProblemId.ForceWithoutShouldProcessAttribute,
                                        description: string.Format("{0} Has  -Force parameter but does not set the SupportsShouldProcess " +
                                                                    "property to true in the Cmdlet attribute.", cmdlet.Name),
                                        remediation: defaultRemediation);
                                    }
                                    if (!cmdlet.SupportsShouldProcess && cmdlet.ConfirmImpact != ConfirmImpact.Medium)
                                    {
                                        issueLogger.LogSignatureIssue(
                                           cmdlet: cmdlet,
                                           severity: 2,
                                        problemId: SignatureProblemId.ConfirmLeveleWithNoShouldProcess,
                                        description:
                                            string.Format("{0} Changes the ConfirmImpact but does not set the " +
                                                "SupportsShouldProcess property to true in the cmdlet attribute.",
                                                cmdlet.Name),
                                        remediation: defaultRemediation);
                                    }
                                    if (!cmdlet.SupportsShouldProcess && cmdlet.IsShouldProcessVerb)
                                    {
                                        issueLogger.LogSignatureIssue(
                                            cmdlet: cmdlet,
                                            severity: 1,
                                            problemId: SignatureProblemId.ActionIndicatesShouldProcess,
                                            description:
                                                string.Format(
                                                    "{0} Does not support ShouldProcess but the cmdlet verb {1} indicates that it should.",
                                                    cmdlet.Name, cmdlet.VerbName),
                                            remediation: defaultRemediation);
                                    }
                                    if (cmdlet.ConfirmImpact != ConfirmImpact.Medium)
                                    {
                                        issueLogger.LogSignatureIssue(
                                           cmdlet: cmdlet,
                                           severity: 2,
                                        problemId: SignatureProblemId.ConfirmLevelChange,
                                        description:
                                        string.Format("{0} changes the confirm impact.  Please ensure that the " +
                                            "change in ConfirmImpact is justified", cmdlet.Name),
                                        remediation:
                                            "Verify that ConfirmImpact is changed appropriately by the cmdlet. " +
                                            "It is very rare for a cmdlet to change the ConfirmImpact.");
                                    }
                                    if (!cmdlet.IsApprovedVerb)
                                    {
                                        issueLogger.LogSignatureIssue(
                                            cmdlet: cmdlet,
                                            severity: 1,
                                        problemId: SignatureProblemId.CmdletWithUnapprovedVerb,
                                        description:
                                            string.Format(
                                                "{0} uses the verb '{1}', which is not on the list of approved " +
                                                "verbs for PowerShell commands. Use the cmdlet 'Get-Verb' to see " +
                                                "the full list of approved verbs and consider renaming the cmdlet.",
                                                cmdlet.Name, cmdlet.VerbName),
                                        remediation: "Consider renaming the cmdlet to use an approved verb for PowerShell.");
                                    }

                                    if (!cmdlet.HasSingularNoun)
                                    {
                                        issueLogger.LogSignatureIssue(
                                            cmdlet: cmdlet,
                                            severity: 1,
                                        problemId: SignatureProblemId.CmdletWithPluralNoun,
                                        description:
                                            string.Format(
                                                "{0} uses the noun '{1}', which does not follow the enforced " +
                                                "naming convention of using a singular noun for a cmdlet name.",
                                                cmdlet.Name, cmdlet.NounName),
                                        remediation: "Consider using a singular noun for the cmdlet name.");
                                    }

                                    foreach (var parameter in cmdlet.GetParametersWithPluralNoun())
                                    {
                                        issueLogger.LogSignatureIssue(
                                            cmdlet: cmdlet,
                                            severity: 1,
                                        problemId: SignatureProblemId.ParameterWithPluralNoun,
                                        description:
                                            string.Format(
                                                "Parameter {0} of cmdlet {1} does not follow the enforced " +
                                                "naming convention of using a singular noun for a parameter name.",
                                                parameter.Name, cmdlet.Name),
                                        remediation: "Consider using a singular noun for the parameter name.");
                                    }
                                }

                                AppDomain.Unload(_appDomain);
                                issueLogger.Decorator.Remove("AssemblyFileName");
                            }
                        }
                        Directory.SetCurrentDirectory(savedDirectory);
                    }
                }
            }
        }

        /// <summary>
        /// Creates analysis report
        /// </summary>
        /// <returns></returns>
        public AnalysisReport GetAnalysisReport()
        {
            //TODO: in next sprint, more work is scheduled to add more enhancements to this tool.
            // this report is necessary when tests needs more informaiton on results of static analysis
            // more information will be added to this report
            AnalysisReport analysisReport = new AnalysisReport();
            ReportLogger reportLog = Logger.GetReportLogger(signatureIssueReportLoggerName);
            if(reportLog.Records.Any())
            {
                foreach(IReportRecord rec in reportLog.Records)
                {
                    analysisReport.ProblemIdList.Add(rec.ProblemId);
                }
            }

            return analysisReport;
        }
    }

    public static class LogExtensions
    {
        public static void LogSignatureIssue(this ReportLogger<SignatureIssue> issueLogger, CmdletSignatureMetadata cmdlet,
            string description, string remediation, int severity, int problemId)
        {
            issueLogger.LogRecord(new SignatureIssue
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