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

using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using StaticAnalysis.BreakingChangeAnalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools.Common.Helpers;
using Tools.Common.Issues;
using Tools.Common.Loggers;

namespace StaticAnalysis.BreakingChangeAttributesAnalyzer
{
    class BreakingChangeAttributesAnalyzer : IStaticAnalyzer
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public bool CleanBreakingChangesFileBeforeWriting { get; set; }
        public string OutputFilePath { get; set; }
        public string BreakingChangeAttributeReportLoggerName { get; protected set; }

        private AppDomain _appDomain;

        public BreakingChangeAttributesAnalyzer()
        {
            Name = "Breaking Change Attribute Analyzer";
            BreakingChangeAttributeReportLoggerName = "UpcomingBreakingChanges.md";

            //We default to creating a new file each time
            CleanBreakingChangesFileBeforeWriting = true;

            //We default to the current folder to output the file
            OutputFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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
        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter)
        {
            var savedDirectory = Directory.GetCurrentDirectory();

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            var logFileName = Path.Combine(OutputFilePath, BreakingChangeAttributeReportLoggerName);
            //Init the log file
            TextFileLogger logger = TextFileLogger.GetTextFileLogger(logFileName, CleanBreakingChangesFileBeforeWriting);

            try
            {
                foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") &&
                                                                            !s.Contains("Stack") && Directory.Exists(Path.GetFullPath(s))))
                {
                    List<string> probingDirectories = new List<string>();

                    // Add current directory for probing
                    probingDirectories.Add(baseDirectory);
                    probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));


                    foreach (var directory in probingDirectories)
                    {
                        IEnumerable<string> cmdlets = GetCmdletsFilesInFolder(directory);
                        if (cmdlets.Any())
                        {
                            foreach (var cmdletFileName in cmdlets)
                            {
                                var cmdletFileFullPath = Path.Combine(directory, Path.GetFileName(cmdletFileName));

                                if (File.Exists(cmdletFileFullPath))
                                {
                                    var proxy =
                                        EnvironmentHelpers.CreateProxy<CmdletBreakingChangeAttributeLoader>(directory, out _appDomain);
                                    var cmdletDataForModule = proxy.GetModuleBreakingChangeAttributes(cmdletFileFullPath);

                                    //If there is nothing in this module just onctinue
                                    if (cmdletDataForModule == null)
                                    {
                                        Console.WriteLine("No breaking change attributes found in module " + cmdletFileName);
                                        continue;
                                    }

                                    if (cmdletFilter != null)
                                    {
                                        string output = string.Format("Before filter\nmodule cmdlet count: {0}\n",
                                            cmdletDataForModule.CmdletList.Count);

                                        output += string.Format("\nCmdlet file: {0}", cmdletFileFullPath);

                                        cmdletDataForModule.FilterCmdlets(cmdletFilter);

                                        output += string.Format("After filter\nmodule cmdlet count: {0}\n",
                                            cmdletDataForModule.CmdletList.Count);

                                        foreach (var cmdlet in cmdletDataForModule.CmdletList)
                                        {
                                            output += string.Format("\n\tcmdlet - {0}", cmdlet.CmdletName);
                                        }

                                        Console.WriteLine(output);
                                    }

                                    LogBreakingChangesInModule(cmdletDataForModule, logger);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (logger != null)
                {
                    TextFileLogger.CloseLogger(logFileName);
                    logger = null;
                }
            }
        }

        public AnalysisReport GetAnalysisReport()
        {
            AnalysisReport report = new AnalysisReport();
            //We dont really generate a report, instead we just generate the .md file for the current directory as we go along in Analyze and output it
            //each directory is analyzed
            return report;
        }

        //Gets the list of all modules in a folder
        static IEnumerable<string> GetCmdletsFilesInFolder(string folderName)
        {
            var service = Path.GetFileName(folderName);

            var manifestFiles = Directory.EnumerateFiles(folderName, "*.psd1").ToList();
            
            if (manifestFiles.Count > 1)
            {
                manifestFiles = manifestFiles.Where(f => Path.GetFileName(f).IndexOf(service) >= 0).ToList();
            }

            if (manifestFiles.Count == 0)
            {
                return null;
            }

            var psd1 = manifestFiles.FirstOrDefault();

            var parentDirectory = Directory.GetParent(psd1);
            var psd1FileName = Path.GetFileName(psd1);

            PowerShell powershell = PowerShell.Create();
            powershell.AddScript("Import-LocalizedData -BaseDirectory " + parentDirectory +
                                " -FileName " + psd1FileName +
                                " -BindingVariable ModuleMetadata; $ModuleMetadata.NestedModules");

            var cmdletResult = powershell.Invoke();
            return cmdletResult.Select(c => c.ToString().Substring(2));
        }

        const string BREAKING_CHANGE_MODUE_HEADER_FORMAT_STRING = @"## Breaking changes in module {0}\n\n The following cmdlets were affected this release:\n\n";
        const string BREAKING_CHANGE_CMDLET_HEADER_FORMAT_STRING = @"**{0}**\n";

        //Logs all the breaking changes in a module as a unit (all cmdlets in the same module appear contigously)
        private void LogBreakingChangesInModule(BreakingChangeAttributesInModule moduleData, TextFileLogger logger)
        {
            string textForBreakingChangesInModule = string.Format(BREAKING_CHANGE_MODUE_HEADER_FORMAT_STRING, Path.GetFileName(moduleData.ModuleName));

            foreach (BreakingChangeAttributesInCmdlet cmdletData in moduleData.CmdletList)
            {
                textForBreakingChangesInModule += string.Format(BREAKING_CHANGE_CMDLET_HEADER_FORMAT_STRING, cmdletData.CmdletName);
                foreach (GenericBreakingChangeAttribute attribute in cmdletData.BreakingChangeAttributes)
                {
                    textForBreakingChangesInModule += attribute.GetBreakingChangeTextFromAttribute(cmdletData.CmdletType, true) + "\n\n";
                }
            }

            //Now that we have the text, add it to the log file
            logger.LogMessage(textForBreakingChangesInModule);
        }
    }
}