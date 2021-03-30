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

using StaticAnalysis.ProblemIds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Tools.Common.Helpers;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;
using Tools.Common.Utilities;
using ParameterSetMetadata = Tools.Common.Models.ParameterSetMetadata;

namespace StaticAnalysis.SignatureVerifier
{
    public class SignatureVerifier : IStaticAnalyzer
    {
// TODO: Remove IfDef code
#if !NETSTANDARD
        private AppDomain _appDomain;
#endif
        private readonly string _signatureIssueReportLoggerName;
        public SignatureVerifier()
        {
            Name = "Signature Verifier";
            _signatureIssueReportLoggerName = "SignatureIssues.csv";
        }
        public AnalysisLogger Logger { get; set; }

        public string Name { get; private set; }

        public void Analyze(IEnumerable<string> scopes)
        {
            Analyze(scopes, null);
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, IEnumerable<string> modulesToAnalyze)
        {
            Analyze(cmdletProbingDirs, null, null, modulesToAnalyze);
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter)
        {
            Analyze(cmdletProbingDirs, directoryFilter, cmdletFilter, null);
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs,
                            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
                            Func<string, bool> cmdletFilter,
                            IEnumerable<string> modulesToAnalyze)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<SignatureIssue>(_signatureIssueReportLoggerName);

            var probingDirectories = new List<string>();

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") &&
                                                                       !ModuleFilter.IsAzureStackModule(s) && Directory.Exists(Path.GetFullPath(s))))
            {
                SharedAssemblyLoader.Load(baseDirectory);

                //Add current directory for probing
                probingDirectories.Add(baseDirectory);
                probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));

                foreach(var directory in probingDirectories)
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Any(m => directory.EndsWith(m)))
                    {
                        continue;
                    }

                    var service = Path.GetFileName(directory);
                    var manifestFiles = Directory.EnumerateFiles(directory, "*.psd1").ToList();
                    if (manifestFiles.Count > 1)
                    {
                        manifestFiles = manifestFiles.Where(f => Path.GetFileName(f).IndexOf(service) >= 0).ToList();
                    }

                    if (!manifestFiles.Any())
                    {
                        continue;
                    }

                    var psd1 = manifestFiles.FirstOrDefault();
                    var parentDirectory = Directory.GetParent(psd1).FullName;
                    var psd1FileName = Path.GetFileName(psd1);
                    string moduleName = psd1FileName.Replace(".psd1", "");

                    Directory.SetCurrentDirectory(directory);

                    issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = moduleName, "AssemblyFileName");
                    processedHelpFiles.Add(moduleName);

                    var module = MetadataLoader.GetModuleMetadata(moduleName);
                    CmdletLoader.ModuleMetadata = module;
                    var cmdlets = module.Cmdlets;

                    if (cmdletFilter != null)
                    {
                        cmdlets = cmdlets.Where(cmdlet => cmdletFilter(cmdlet.Name)).ToList();
                    }

                    foreach (var cmdlet in cmdlets)
                    {
                        Logger.WriteMessage("Processing cmdlet '{0}'", cmdlet.ClassName);
                        const string defaultRemediation = "Determine if the cmdlet should implement ShouldProcess and " +
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

                        if (!cmdlet.OutputTypes.Any())
                        {
                            issueLogger.LogSignatureIssue(
                                cmdlet: cmdlet,
                                severity: 1,
                                problemId: SignatureProblemId.CmdletWithNoOutputType,
                                description:
                                string.Format(
                                    "Cmdlet '{0}' has no defined output type.", cmdlet.Name),
                                remediation: "Add an OutputType attribute that declares the type of the object(s) returned " +
                                                "by this cmdlet. If this cmdlet returns no output, please set the output " +
                                                "type to 'bool' and make sure to implement the 'PassThru' parameter.");
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

                        foreach (var parameterSet in cmdlet.ParameterSets)
                        {
                            if (parameterSet.Name.Contains(" "))
                            {
                                issueLogger.LogSignatureIssue(
                                    cmdlet: cmdlet,
                                    severity: 1,
                                    problemId: SignatureProblemId.ParameterSetWithSpace,
                                    description:
                                    string.Format(
                                        "Parameter set '{0}' of cmdlet '{1}' contains a space, which " +
                                        "is discouraged for PowerShell parameter sets.",
                                        parameterSet.Name, cmdlet.Name),
                                    remediation: "Remove the space(s) in the parameter set name.");
                            }

                            if (parameterSet.Parameters.Any(p => p.Position >= 4))
                            {
                                issueLogger.LogSignatureIssue(
                                    cmdlet: cmdlet,
                                    severity: 1,
                                    problemId: SignatureProblemId.ParameterWithOutOfRangePosition,
                                    description:
                                    string.Format(
                                        "Parameter set '{0}' of cmdlet '{1}' contains at least one parameter " +
                                        "with a position larger than four, which is discouraged.",
                                        parameterSet.Name, cmdlet.Name),
                                    remediation: "Limit the number of positional parameters in a single parameter set to " +
                                                    "four or fewer.");
                            }
                        }

                        if (cmdlet.ParameterSets.Count > 2 && cmdlet.DefaultParameterSetName == "__AllParameterSets")
                        {
                            issueLogger.LogSignatureIssue(
                                cmdlet: cmdlet,
                                severity: 1,
                                problemId: SignatureProblemId.MultipleParameterSetsWithNoDefault,
                                description:
                                string.Format(
                                    "Cmdlet '{0}' has multiple parameter sets, but no defined default parameter set.",
                                    cmdlet.Name),
                                remediation: "Define a default parameter set in the cmdlet attribute.");
                        }

                        ValidateParameterSetWithMandatoryEqual(cmdlet, issueLogger);
                        ValidateParameterSetWithLenientMandatoryEqual(cmdlet, issueLogger);
                    }
                    issueLogger.Decorator.Remove("AssemblyFileName");
                    Directory.SetCurrentDirectory(savedDirectory);
                }
            }
        }

        /// <summary>
        /// Check whether there exist mandatory equal in the cmdlet.
        /// Mandatory equal means two parameter set has exactly the same mandatory parameters.
        /// If all these two parameter set are not defualt, it may cause confusion.
        /// An example: https://github.com/Azure/azure-powershell/issues/10954
        /// </summary>
        public void ValidateParameterSetWithMandatoryEqual(CmdletMetadata cmdlet, ReportLogger<SignatureIssue> issueLogger)
        {
            var defaultParameterSet = cmdlet.DefaultParameterSet;
            List<HashSet<string>> mandatoryEqualSetList = new List<HashSet<string>>();
            foreach (var parameterSet1 in cmdlet.ParameterSets)
            {
                foreach (var parameterSet2 in cmdlet.ParameterSets)
                {
                    if (!parameterSet1.Equals(parameterSet2) &&
                        cmdlet.DefaultParameterSetName != parameterSet1.Name &&
                        cmdlet.DefaultParameterSetName != parameterSet2.Name)
                    {
                        if (parameterSet1.AllMandatoryParemeterEquals(parameterSet2) && 
                            !IsParameterSetIntersectionCoveredByDefault(parameterSet1, parameterSet2, defaultParameterSet))
                        {
                            var isExistInSet = false;
                            foreach (var mandatoryEqualSet in mandatoryEqualSetList)
                            {
                                if (mandatoryEqualSet.Contains(parameterSet1.Name) || mandatoryEqualSet.Contains(parameterSet2.Name))
                                {
                                    mandatoryEqualSet.Add(parameterSet1.Name);
                                    mandatoryEqualSet.Add(parameterSet2.Name);
                                    isExistInSet = true;
                                    break;
                                }
                            }
                            if (!isExistInSet)
                            {
                                HashSet<string> newSet = new HashSet<string>();
                                newSet.Add(parameterSet1.Name);
                                newSet.Add(parameterSet2.Name);
                                mandatoryEqualSetList.Add(newSet);
                            }
                        }
                    }
                }
            }

            if (mandatoryEqualSetList.Count > 0)
            {
                foreach (var mandatoryEqualSet in mandatoryEqualSetList)
                {
                    string mandatoryEqualSetNames = "";
                    foreach (var mandatoryEqualSetName in mandatoryEqualSet)
                    {
                        if (mandatoryEqualSetNames != "")
                        {
                            mandatoryEqualSetNames += ", ";
                        }
                        mandatoryEqualSetNames += "'" + mandatoryEqualSetName + "'";
                    }
                    issueLogger.LogSignatureIssue(
                                cmdlet: cmdlet,
                                severity: 1,
                                problemId: SignatureProblemId.ParameterSetWithStrictMandatoryEqual,
                                description:
                                string.Format(
                                    "Parameter set {0} of cmdlet '{1}' have the same mandatory parameters, " +
                                    "and both of them are not default parameter set which may cause confusion.",
                                    mandatoryEqualSetNames, cmdlet.Name),
                                remediation: "Merge these parameter sets into one parameter set.");
                }
            }
        }

        /// <summary>
        /// Check whether there exist lenient mandatory equal in the cmdlet
        /// Lenient mandatory equal means for two parameter set, one parameter set's mandatory parameters can
        /// be found in another parameter set whether as mandatory or optional.
        /// If all these two parameter set are not defualt, it may cause confusion.
        /// </summary>
        public void ValidateParameterSetWithLenientMandatoryEqual(CmdletMetadata cmdlet, ReportLogger<SignatureIssue> issueLogger)
        {
            var defaultParameterSet = cmdlet.DefaultParameterSet;
            foreach (var parameterSet1 in cmdlet.ParameterSets)
            {
                foreach (var parameterSet2 in cmdlet.ParameterSets)
                {
                    if (!parameterSet1.Equals(parameterSet2) &&
                        cmdlet.DefaultParameterSetName != parameterSet1.Name &&
                        cmdlet.DefaultParameterSetName != parameterSet2.Name &&
                        parameterSet1.Name.CompareTo(parameterSet2.Name) > 0)
                    {
                        if (parameterSet1.AllMandatoryParemeterLenientEquals(parameterSet2) && 
                            !IsParameterSetIntersectionCoveredByDefault(parameterSet1, parameterSet2, defaultParameterSet))
                        {
                            issueLogger.LogSignatureIssue(
                                cmdlet: cmdlet,
                                severity: 1,
                                problemId: SignatureProblemId.ParameterSetWithLenientMandatoryEqual,
                                description:
                                string.Format(
                                    "Parameter set '{0}' and '{1}' of cmdlet '{2}', for all mandatory parameters in {0} " +
                                    "we can find mandatory and optional parameter in {1}, and all mandatory parameter in " +
                                    "{1} can find the corresponding mandatory parameter in {0}, " +
                                    "and both of them are not default parameter set which may cause confusion.",
                                    parameterSet1.Name, parameterSet2.Name, cmdlet.Name),
                                remediation: "Merge these parameter sets into one parameter set.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Judge whether the two conflict parameter sets can be covered by default parameter set.
        /// Find all parameters these two sets both contains and if anyone can't be found in default set return false.
        /// </summary>
        /// <returns>True if can be covered, false otherwise.</returns>
        public bool IsParameterSetIntersectionCoveredByDefault(ParameterSetMetadata parameterSet1, ParameterSetMetadata parameterSet2, ParameterSetMetadata defaultParameterSet)
        {
            if (defaultParameterSet == null)
            {
                return false;
            }
            foreach (var parameter1 in parameterSet1.Parameters)
            {
                foreach (var parameter2 in parameterSet2.Parameters)
                {
                    if (parameter1.ParameterMetadata.Name == parameter2.ParameterMetadata.Name)
                    {
                        var IsIntersectionCovered = false;
                        foreach (var defaultParameter in defaultParameterSet.Parameters)
                        {
                            if (defaultParameter.ParameterMetadata.Name == parameter1.ParameterMetadata.Name)
                            {
                                IsIntersectionCovered = true;
                                break;
                            }
                        }
                        if (!IsIntersectionCovered)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
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
            var analysisReport = new AnalysisReport();
            var reportLog = Logger.GetReportLogger(_signatureIssueReportLoggerName);
            if(reportLog.Records.Any())
            {
                foreach(var rec in reportLog.Records)
                {
                    analysisReport.ProblemIdList.Add(rec.ProblemId);
                }
            }

            return analysisReport;
        }
        
    }

    public static class LogExtensions
    {
        public static void LogSignatureIssue(this ReportLogger<SignatureIssue> issueLogger, CmdletMetadata cmdlet,
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