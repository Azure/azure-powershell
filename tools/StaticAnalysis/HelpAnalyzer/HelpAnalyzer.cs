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

using Microsoft.PowerShell.PlatyPS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
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
        private const int MissingHelp = 6050;
        private const int MissingHelpFile = 6000;
        private const int MissingCmdlet = 7000;
        private const int PlatyPSSchemaViolation = 8000;
        private const int MissingModuleName = 8050;
        private const int ModuleNameMismatch = 8060;
        public HelpAnalyzer()
        {
            Name = "Help Analyzer";
        }
        public AnalysisLogger Logger { get; set; }
        public string Name { get; private set; }

        // TODO: Remove IfDef code
#if !NETSTANDARD
        private AppDomain _appDomain;
#endif

        private static bool IsAssemblyFile(string path)
        {
            var assemblyRegexes = new[]
            {
                new Regex("Microsoft.Azure.PowerShell.Cmdlets.[^.]+.dll$"),
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
                SharedAssemblyLoader.Load(baseDirectory);
                foreach (var directory in Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)))
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Any(m => directory.EndsWith(m)))
                    {
                        continue;
                    }

                    var dirs = Directory.EnumerateDirectories(directory);
                    if (dirs != null && dirs.Any(d => string.Equals(Path.GetFileName(d), "help", StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"Analyzing module under {directory} ...");
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
            if (!helpFiles.Any()) return;

            Directory.SetCurrentDirectory(directory);
            foreach (var helpFile in helpFiles)
            {
                var cmdletFile = helpFile.Substring(0, helpFile.Length - "-Help.xml".Length);
                var helpFileName = Path.GetFileName(helpFile);
                var cmdletFileName = Path.GetFileName(cmdletFile);
                if (!File.Exists(cmdletFile)) continue;

                processedHelpFiles.Add(helpFileName);
                helpLogger.Decorator.AddDecorator(h =>
                {
                    h.HelpFile = helpFileName;
                    h.Assembly = cmdletFileName;
                }, "Cmdlet");

                // TODO: Remove IfDef
#if NETSTANDARD
                var proxy = new CmdletLoader();
#else
                var proxy = EnvironmentHelpers.CreateProxy<CmdletLoader>(directory, out _appDomain);
#endif
                var module = proxy.GetModuleMetadata(cmdletFile);
                var cmdlets = module.Cmdlets;
                var helpRecords = CmdletHelpParser.GetHelpTopics(helpFile, helpLogger);
                ValidateHelpRecords(module.ModuleName, cmdlets, helpRecords, helpLogger);
                helpLogger.Decorator.Remove("Cmdlet");
                // TODO: Remove IfDef code
#if !NETSTANDARD
                AppDomain.Unload(_appDomain);
#endif
            }

            Directory.SetCurrentDirectory(savedDirectory);
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

            var helpFiles = Directory.EnumerateFiles(helpFolder, "*.md").Select(Path.GetFileNameWithoutExtension).ToList();
            // Assume all cmdlets markdown file following format of VERB-AzResource. Dash is required.
            helpFiles = helpFiles.Where(c => c.Contains("-")).ToList();
            if (!helpFiles.Any()) return;

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

            var allCmdlets = new List<CmdletMetadata>();


            string moduleName = psd1FileName.Replace(".psd1", "");

            Console.WriteLine(directory);
            Directory.SetCurrentDirectory(directory);

            processedHelpFiles.Add(moduleName);

            helpLogger.Decorator.AddDecorator(h =>
            {
                h.HelpFile = moduleName;
                h.Assembly = moduleName;
            }, "Cmdlet");
            var module = MetadataLoader.GetModuleMetadata(moduleName);
            var cmdlets = module.Cmdlets;
            allCmdlets.AddRange(cmdlets);
            helpLogger.Decorator.Remove("Cmdlet");

            ValidateHelpRecords(moduleName, allCmdlets, helpFiles, helpLogger);
            ValidateHelpModuleName(helpFolder, moduleName, helpFiles, helpLogger);
            ValidateHelpMarkdown(helpFolder, helpFiles, helpLogger);

            Directory.SetCurrentDirectory(savedDirectory);

        }

        private void ValidateHelpRecords(string moduleName, IList<CmdletMetadata> cmdlets, IList<string> helpRecords,
            ReportLogger<HelpIssue> helpLogger)
        {
            var cmdletDict = new Dictionary<string, CmdletMetadata>();
            foreach (var cmdlet in cmdlets)
            {
                cmdletDict.Add(cmdlet.Name, cmdlet);
                if (!helpRecords.Contains(cmdlet.Name, StringComparer.OrdinalIgnoreCase))
                {
                    HelpIssue issue = new HelpIssue
                    {
                        Assembly = moduleName,
                        Target = cmdlet.Name,
                        Severity = 1,
                        ProblemId = MissingHelp,
                        Remediation = string.Format("Add Help record for cmdlet {0} to help file.", cmdlet.Name)
                    };
                    if (cmdlet.ClassName != null)
                    {
                        issue.Description = $"Help missing for cmdlet {cmdlet.Name} implemented by class {cmdlet.ClassName}";
                    }
                    else
                    {
                        issue.Description = $"Help missing for cmdlet {cmdlet.Name} implemented by functions";
                    }
                    helpLogger.LogRecord(issue);
                }
            }

            foreach (var helpRecord in helpRecords)
            {
                if (!cmdletDict.ContainsKey(helpRecord))
                {
                    Console.Error.WriteLine($"Help record {helpRecord} has no cmdlet.");
                }
            }
        }

        private static readonly Regex ModuleNameFrontMatterRegex = new Regex(@"^Module Name:\s*(?<name>.+?)\s*$", RegexOptions.Multiline);

        /// <summary>
        /// Validates that the 'Module Name' YAML front matter of every cmdlet help markdown file matches the on-disk module name.
        /// A mismatch causes Export-MamlCommandHelp to silently route the affected cmdlet's MAML into a stray folder named after the wrong module,
        /// so Get-Help returns nothing for it at runtime.
        /// </summary>
        private void ValidateHelpModuleName(
            string helpFolder,
            string expectedModuleName,
            IList<string> helpRecords,
            ReportLogger<HelpIssue> helpLogger)
        {
            foreach (var helpMarkdown in helpRecords)
            {
                var file = Path.Combine(helpFolder, helpMarkdown + ".md");
                if (!File.Exists(file))
                    continue;

                string content;
                try
                {
                    content = File.ReadAllText(file);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to read {file}: {ex.Message}");
                    continue;
                }

                var match = ModuleNameFrontMatterRegex.Match(content);
                if (!match.Success)
                {
                    helpLogger.LogRecord(new HelpIssue
                    {
                        Target = helpMarkdown,
                        Severity = 1,
                        ProblemId = MissingModuleName,
                        Description = "'Module Name' metadata is missing from the YAML front matter.",
                        Remediation = $"Add 'Module Name: {expectedModuleName}' to the YAML front matter at the top of {helpMarkdown}.md."
                    });
                    continue;
                }

                var actualModuleName = match.Groups["name"].Value;
                if (!string.Equals(actualModuleName, expectedModuleName, StringComparison.Ordinal))
                {
                    helpLogger.LogRecord(new HelpIssue
                    {
                        Target = helpMarkdown,
                        Severity = 1,
                        ProblemId = ModuleNameMismatch,
                        Description = $"'Module Name' metadata is '{actualModuleName}' but expected '{expectedModuleName}'.",
                        Remediation = $"Update the 'Module Name' line in the YAML front matter of {helpMarkdown}.md to '{expectedModuleName}'."
                    });
                }
            }
        }

        private void ValidateHelpMarkdown(string helpFolder, IList<string> helpRecords, ReportLogger<HelpIssue> helpLogger)
        {
            foreach (var helpMarkdown in helpRecords)
            {
                var file = Path.Combine(helpFolder, helpMarkdown + ".md");
                try
                {
                    var issues = new List<string>();
                    var isValid = MarkdownConverter.ValidateMarkdownFile(file, out issues);
                    if (!isValid)
                    {
                        HelpIssue issue = new HelpIssue
                        {
                            Target = helpMarkdown,
                            Severity = 1,
                            ProblemId = PlatyPSSchemaViolation,
                            Description = "Help content doesn't conform to PlatyPS Schema definition: " + string.Join("; ", issues),
                            Remediation = string.Format("No.")
                        };
                        helpLogger.LogRecord(issue);
                        Console.Error.WriteLine($"Failed to validate {file} by Microsoft.PowerShell.PlatyPS: {string.Join("; ", issues)}");
                    }
                }
                catch (Exception ex)
                {
                    HelpIssue issue = new HelpIssue
                    {
                        Target = helpMarkdown,
                        Severity = 1,
                        ProblemId = PlatyPSSchemaViolation,
                        Description = "Help content doesn't conform to PlatyPS Schema definition",
                        Remediation = string.Format("No.")
                    };
                    helpLogger.LogRecord(issue);
                    Console.Error.WriteLine($"Failed to parse {file} by Microsoft.PowerShell.PlatyPS, {ex.Message}");
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
