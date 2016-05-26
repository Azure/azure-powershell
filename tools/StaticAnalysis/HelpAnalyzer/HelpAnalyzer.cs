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
using System.Text.RegularExpressions;

namespace StaticAnalysis.HelpAnalyzer
{
    /// <summary>
    /// Static analyzer for PowerShell Help
    /// </summary>
    public class HelpAnalyzer : IStaticAnalyzer
    {
        const int MissingHelp = 6050;
        const int MissingHelpFile = 6000;
        public HelpAnalyzer()
        {
            Name = "Help Analyzer";
        }
        public AnalysisLogger Logger { get; set; }
        public string Name { get; private set; }

        private AppDomain _appDomain;

        private static bool IsAssemblyFile(string path)
        {
            var assemblyRegexes = new[]
            {
                new Regex("Microsoft.Azure.Commands.[^.]+.dll$"),
                new Regex("Microsoft.WindowsAzure.Commands.[^.]+.dll$"),
                new Regex(".Cmdlets.dll$")
            };

            var exceptionRegexes = new[]
            {
                new Regex("WindowsAzure.Commands.Sync.dll$"),
                new Regex("WindowsAzure.Commands.Utilities.dll$"),
                new Regex("Commands.Common")
            };
            var fileName = Path.GetFileName(path);
            var result = false;
            foreach (var regex in assemblyRegexes)
            {
                result = result || regex.IsMatch(fileName);
            }

            foreach (var regex in exceptionRegexes)
            {
                result = result && !regex.IsMatch(fileName);
            }

            return result;
        }
        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders, analyze the help 
        /// in the module folders and report any issues
        /// </summary>
        /// <param name="scopes"></param>
        public void Analyze(IEnumerable<string> scopes)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var helpLogger = Logger.CreateLogger<HelpIssue>("HelpIssues.csv");
            foreach (var baseDirectory in scopes.Where(s => Directory.Exists(Path.GetFullPath(s))))
            {
                foreach (var directory in Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)))
                {
                    var commandAssemblies = Directory.EnumerateFiles(directory, "*.Commands.*.dll")
                        .Where (f => IsAssemblyFile(f) && !File.Exists(f + "-Help.xml"));
                    foreach (var orphanedAssembly in commandAssemblies)
                    {
                        helpLogger.LogRecord(new HelpIssue()
                        {
                            Assembly = orphanedAssembly,
                            Description = string.Format("{0} has no matching help file", orphanedAssembly),
                            Severity = 0,
                            Remediation = string.Format("Make sure a dll Help file for {0} exists and it is " +
                                                        "being copied to the output directory.", orphanedAssembly),
                            Target = orphanedAssembly,
                            HelpFile = orphanedAssembly + "-Help.xml",
                            ProblemId = MissingHelpFile
                        });
                    }

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
                                processedHelpFiles.Add(helpFileName);
                                helpLogger.Decorator.AddDecorator((h) =>
                                {
                                    h.HelpFile = helpFileName;
                                    h.Assembly = cmdletFileName;
                                }, "Cmdlet");
                                var proxy = EnvironmentHelpers.CreateProxy<CmdletLoader>(directory, out _appDomain);
                                var cmdlets = proxy.GetCmdlets(cmdletFile);
                                var helpRecords = CmdletHelpParser.GetHelpTopics(helpFile, helpLogger);
                                ValidateHelpRecords(cmdlets, helpRecords, helpLogger);
                                helpLogger.Decorator.Remove("Cmdlet");
                                AppDomain.Unload(_appDomain);
                            }
                        }

                        Directory.SetCurrentDirectory(savedDirectory);
                    }
                }
            }
        }

        private void ValidateHelpRecords(IList<CmdletHelpMetadata> cmdlets, IList<string> helpRecords, 
            ReportLogger<HelpIssue> helpLogger)
        {
            foreach (var cmdlet in cmdlets)
            {
                if (!helpRecords.Contains(cmdlet.CmdletName, StringComparer.OrdinalIgnoreCase))
                {
                    helpLogger.LogRecord(new HelpIssue
                    {
                        Target = cmdlet.ClassName,
                        Severity = 1,
                        ProblemId = MissingHelp,
                        Description = string.Format("Help missing for cmdlet {0} implemented by class {1}", 
                        cmdlet.CmdletName, cmdlet.ClassName),
                        Remediation = string.Format("Add Help record for cmdlet {0} to help file.", cmdlet.CmdletName)
                    });
                }
            }
        }
    }
}
