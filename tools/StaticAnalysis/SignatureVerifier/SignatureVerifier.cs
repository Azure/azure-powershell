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
using System.Threading.Tasks;

namespace StaticAnalysis.SignatureVerifier
{
    public class SignatureVerifier : IStaticAnalyzer
    {
        public SignatureVerifier()
        {
            Name = "Signature Verifier";
        }
        public AnalysisLogger Logger { get; set; }
        public string Name { get; private set; }

        private AppDomain _appDomain;

        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders, analyze the help 
        /// in the module folders and report any issues
        /// </summary>
        /// <param name="scopes"></param>
        public void Analyze(IEnumerable<string> scopes)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var issueLogger = Logger.CreateLogger<SignatureIssue>("SignatureIssues.csv");
            foreach (var baseDirectory in scopes.Where(s => !s.Contains("ServiceManagement") && Directory.Exists(Path.GetFullPath(s))))
            {
                foreach (var directory in Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)))
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
                            if (File.Exists(cmdletFile) )
                            {
                                issueLogger.Decorator.AddDecorator(a => a.AssemblyFileName = cmdletFileName, "AssemblyFileName");
                                processedHelpFiles.Add(helpFileName);
                                var proxy = EnvironmentHelpers.CreateProxy<CmdletSignatureLoader>(directory, out _appDomain);
                                var cmdlets = proxy.GetCmdlets(cmdletFile);
                                foreach (var cmdlet in cmdlets.Where(c => c.SupportsShouldProcess || c.HasForceSwitch || c.IsShouldProcessVerb))
                                {
                                    int severity = 1;
                                    string description= string.Format("Cmdlet {0} does not implement ShouldProcess or " +
                                                        "Force but may perform a destructive action.", cmdlet.Name);
                                    string remediation = "Determine if the cmdlet should implement ShouldProcess, and " +
                                                         "if so, assign an appropriate ConfirmImpact and determine if " +
                                                         "it should implement Force / ShouldContinue";
                                    if (cmdlet.HasForceSwitch)
                                    {
                                        description = string.Format("Cmdlet {0} has a Force " +
                                                                    "parameter", cmdlet.Name);
                                        remediation =
                                            "Implement ShouldProcess correctly, set appropriate ConfirmImpact, " +
                                            "and determine if cmdlet needs ShouldContinue / Force.";
                                        severity = 0;
                                    }
                                    else if (cmdlet.SupportsShouldProcess)
                                    {
                                        description = string.Format("Cmdlet {0} supports ShouldProcess", cmdlet.Name);
                                        remediation =
                                            "Implement ShouldProcess correctly, set appropriate ConfirmImpact, " +
                                            "and determine if cmdlet needs ShouldContinue / Force.";
                                        severity = 0;
                                    }

                                    issueLogger.LogRecord(new SignatureIssue
                                    {
                                        ClassName = cmdlet.ClassName,
                                        Target=cmdlet.Name,
                                        Description = description,
                                        Remediation = remediation,
                                        Severity = severity
                                    });
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

    }
}