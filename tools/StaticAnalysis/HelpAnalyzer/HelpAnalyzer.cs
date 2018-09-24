﻿// ----------------------------------------------------------------------------------
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
using Tools.Common.Helpers;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;

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

        public void Analyze(IEnumerable<string> scopes)
        {
            Analyze(scopes, null);
        }

        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders, analyze the help
        /// in the module folders and report any issues
        /// </summary>
        /// <param name="scopes"></param>
        public void Analyze(IEnumerable<string> scopes, IEnumerable<string> modulesToAnalyze)
        {
            var savedDirectory = Directory.GetCurrentDirectory();
            var processedHelpFiles = new List<string>();
            var helpLogger = Logger.CreateLogger<HelpIssue>("HelpIssues.csv");
            foreach (var baseDirectory in scopes.Where(s => Directory.Exists(Path.GetFullPath(s))))
            {
                foreach (var directory in Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)))
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Where(m => directory.EndsWith(m)).Any())
                    {
                        continue;
                    }

                    var dirs = Directory.EnumerateDirectories(directory);
                    if (dirs != null && dirs.Any((d) => string.Equals(Path.GetFileName(d), "help", StringComparison.OrdinalIgnoreCase)))
                    {
                        AnalyzeMarkdownHelp(scopes, directory, helpLogger, processedHelpFiles, savedDirectory);
                    }
                }
            }
        }

        private void AnalyzeMamlHelp(
            IEnumerable<string> scopes,
            string directory,
            ReportLogger<HelpIssue> helpLogger,
            List<string> processedHelpFiles,
            string savedDirectory)
        {
            var commandAssemblies = Directory.EnumerateFiles(directory, "*.Commands.*.dll")
                        .Where(f => IsAssemblyFile(f) && !File.Exists(f + "-Help.xml"));
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
                    if (File.Exists(cmdletFile))
                    {
                        processedHelpFiles.Add(helpFileName);
                        helpLogger.Decorator.AddDecorator((h) =>
                        {
                            h.HelpFile = helpFileName;
                            h.Assembly = cmdletFileName;
                        }, "Cmdlet");
                        var proxy =
#if !NETSTANDARD
                            EnvironmentHelpers.CreateProxy<CmdletLoader>(directory, out _appDomain);
#else
                            new CmdletLoader();
#endif
                        var module = proxy.GetModuleMetadata(cmdletFile);
                        var cmdlets = module.Cmdlets;
                        var helpRecords = CmdletHelpParser.GetHelpTopics(helpFile, helpLogger);
                        ValidateHelpRecords(cmdlets, helpRecords, helpLogger);
                        helpLogger.Decorator.Remove("Cmdlet");
                        AppDomain.Unload(_appDomain);
                    }
                }

                Directory.SetCurrentDirectory(savedDirectory);
            }
        }

        private void AnalyzeMarkdownHelp(
            IEnumerable<string> scopes,
            string directory,
            ReportLogger<HelpIssue> helpLogger,
            List<string> processedHelpFiles,
            string savedDirectory)
        {
            var helpFolder = Directory.EnumerateDirectories(directory, "help").FirstOrDefault();
            var service = Path.GetFileName(directory);
            if (helpFolder == null)
            {
                helpLogger.LogRecord(new HelpIssue()
                {
                    Assembly = service,
                    Description = string.Format("{0} has no matching help folder", service),
                    Severity = 0,
                    Remediation = string.Format("Make sure a help folder for {0} exists and it is " +
                                                "being copied to the output directory.", service),
                    Target = service,
                    HelpFile = service + "/folder",
                    ProblemId = MissingHelpFile
                });

                return;
            }

            var helpFiles = Directory.EnumerateFiles(helpFolder, "*.md").Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
            if (helpFiles.Any())
            {
                Directory.SetCurrentDirectory(directory);
                var manifestFiles = Directory.EnumerateFiles(directory, "*.psd1").ToList();
                if (manifestFiles.Count > 1)
                {
                    manifestFiles = manifestFiles.Where(f => Path.GetFileName(f).IndexOf(service) >= 0).ToList();
                }

                if (manifestFiles.Count == 0)
                {
                    return;
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

                    requiredModules = requiredModules.Join(scopes,
                                                           module => 1,
                                                           dir => 1,
                                                           (module, dir) => Path.Combine(dir, module))
                                                      .Where(f => Directory.Exists(f))
                                                      .ToList();

                    requiredModules.Add(directory);
                    List<CmdletMetadata> allCmdlets = new List<CmdletMetadata>();
                    foreach (var nestedModule in nestedModules)
                    {
                        var assemblyFile = Directory.GetFiles(parentDirectory, nestedModule, SearchOption.AllDirectories).FirstOrDefault();
                        if (File.Exists(assemblyFile))
                        {
                            var assemblyFileName = Path.GetFileName(assemblyFile);
                            helpLogger.Decorator.AddDecorator((h) =>
                            {
                                h.HelpFile = assemblyFileName;
                                h.Assembly = assemblyFileName;
                            }, "Cmdlet");
                            processedHelpFiles.Add(assemblyFileName);
                            var proxy =
#if !NETSTANDARD
                                EnvironmentHelpers.CreateProxy<CmdletLoader>(directory, out _appDomain);
#else
                                new CmdletLoader();
#endif
                            var module = proxy.GetModuleMetadata(assemblyFile, requiredModules);
                            var cmdlets = module.Cmdlets;
                            allCmdlets.AddRange(cmdlets);
                            helpLogger.Decorator.Remove("Cmdlet");
                            AppDomain.Unload(_appDomain);
                        }
                    }

                    ValidateHelpRecords(allCmdlets, helpFiles, helpLogger);
                }

                Directory.SetCurrentDirectory(savedDirectory);
            }
        }

        private void ValidateHelpRecords(IList<CmdletMetadata> cmdlets, IList<string> helpRecords,
            ReportLogger<HelpIssue> helpLogger)
        {
            foreach (var cmdlet in cmdlets)
            {
                if (!helpRecords.Contains(cmdlet.Name, StringComparer.OrdinalIgnoreCase))
                {
                    helpLogger.LogRecord(new HelpIssue
                    {
                        Target = cmdlet.ClassName,
                        Severity = 1,
                        ProblemId = MissingHelp,
                        Description = string.Format("Help missing for cmdlet {0} implemented by class {1}",
                        cmdlet.Name, cmdlet.ClassName),
                        Remediation = string.Format("Add Help record for cmdlet {0} to help file.", cmdlet.Name)
                    });
                }
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
