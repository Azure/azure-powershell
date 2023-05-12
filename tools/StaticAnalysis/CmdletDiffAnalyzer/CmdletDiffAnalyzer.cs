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
using System.Reflection;
using System.Text;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;
using Tools.Common.Utilities;

namespace StaticAnalysis.CmdletDiffAnalyzer
{
    public class CmdletDiffAnalyzer : IStaticAnalyzer
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public string CmdletDiffIssueReportLoggerName { get; set; }
        private List<string> _ignoreParameters = new List<string>
        {
            "AzureRMContext", "Break", "Debug", "DefaultProfile", "EnableTestCoverage",
            "ErrorAction", "ErrorVariable", "HttpPipelineAppend", "HttpPipelinePrepend", "InformationAction",
            "InformationVariable", "OutBuffer", "OutVariable", "PipelineVariable", "Proxy",
            "ProxyCredential", "ProxyUseDefaultCredentials", "Verbose", "WarningAction", "WarningVariable"
        };
        private List<CmdletDiffInformation> diffInfo;
        public CmdletDiffAnalyzer()
        {
            Name = "Cmdlet Diff Analyzer";
            CmdletDiffIssueReportLoggerName = "CmdletDiffIssues.csv";
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs)
        {
            Analyze(cmdletProbingDirs, null, null);
        }
        public void Analyze(IEnumerable<string> cmdletProbingDirs, IEnumerable<string> modulesToAnalyze)
        {
            Analyze(cmdletProbingDirs, null, null, modulesToAnalyze);
        }

        public void Analyze(
            IEnumerable<string> cmdletProbingDirs,
            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
            Func<string, bool> cmdletFilter)
        {
            Analyze(cmdletProbingDirs, directoryFilter, cmdletFilter, null);
        }

        public void Analyze(
            IEnumerable<string> cmdletProbingDirs,
            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
            Func<string, bool> cmdletFilter,
            IEnumerable<string> modulesToAnalyze)
        {

            var processedHelpFiles = new List<string>();
            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            var savedDirectory = Directory.GetCurrentDirectory();
            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") &&
                                                                        !ModuleFilter.IsAzureStackModule(s) && Directory.Exists(Path.GetFullPath(s))))
            {
                var probingDirectories = new List<string> { baseDirectory };
                // Add current directory for probing: .\artifacts\Debug\ && dirs under \Debug.
                probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));
                diffInfo = new List<CmdletDiffInformation>();

                foreach (var directory in probingDirectories)
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Any(m => directory.EndsWith(m)))
                    {
                        continue;
                    }

                    // find psd1 file in every dir
                    var service = Path.GetFileName(directory);

                    var manifestFiles = Directory.EnumerateFiles(directory, "*.psd1").ToList();

                    if (manifestFiles.Count > 1)
                    {
                        manifestFiles = manifestFiles.Where(f => Path.GetFileName(f).IndexOf(service) >= 0).ToList();
                    }

                    if (manifestFiles.Count == 0)
                    {
                        continue;
                    }
                    // psd1: \artifacts\Debug\Az.Compute\Az.Compute.psd1
                    var psd1 = manifestFiles.FirstOrDefault();

                    // find module info
                    var parentDirectory = Directory.GetParent(psd1).FullName;
                    var psd1FileName = Path.GetFileName(psd1);

                    string moduleName = psd1FileName.Replace(".psd1", "");
                    Directory.SetCurrentDirectory(directory);

                    Console.WriteLine("Analysing module: {0}", moduleName);
                    processedHelpFiles.Add(moduleName);

                    var newModuleMetadata = MetadataLoader.GetModuleMetadata(moduleName);
                    var fileName = $"{moduleName}.json";
                    // \artifacts\StaticAnalysis
                    var executingPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
                    var filePath = Path.Combine(executingPath, "SerializedCmdlets", fileName);

                    if (!File.Exists(filePath))
                    {
                        continue;
                    }

                    var oldModuleMetadata = ModuleMetadata.DeserializeCmdlets(filePath);
                    CmdletLoader.ModuleMetadata = newModuleMetadata;
                    CompareModuleMetedata(oldModuleMetadata, newModuleMetadata, moduleName);
                }
            }
            Directory.SetCurrentDirectory(savedDirectory);
            var reportsDirectory = Path.GetDirectoryName(Logger.CreateLogger<BreakingChangeAnalyzer.BreakingChangeIssue>("CmdletDiffIssues.csv").FileName);
            var markDownPath = Path.Combine(reportsDirectory, "CmdletChangeResult.md");
            var csvPath = Path.Combine(reportsDirectory, "CmdletDiffInformation.csv");

            GenerateMarkdown(markDownPath);
            // write infomation to csv
            GenerateCsv(csvPath);
            Console.WriteLine("Cmdlets Differences written to {0}", markDownPath);
        }

        private void CompareModuleMetedata(ModuleMetadata oldModuleMetadata,
            ModuleMetadata newModuleMetadata,
            string moduleName)
        {
            var newCmdletList = newModuleMetadata.Cmdlets;
            Dictionary<string, CmdletMetadata> newCmdletMetadataMap = new Dictionary<string, CmdletMetadata>();
            foreach (var cmdlet in newCmdletList)
            {
                newCmdletMetadataMap.Add(cmdlet.Name, cmdlet);
            }

            var oldCmdletList = oldModuleMetadata.Cmdlets;
            Dictionary<string, CmdletMetadata> oldCmdletMetadataMap = new Dictionary<string, CmdletMetadata>();
            foreach (var cmdlet in oldCmdletList)
            {
                oldCmdletMetadataMap.Add(cmdlet.Name, cmdlet);
            }
            foreach (string cmdletName in oldCmdletMetadataMap.Keys)
            {
                if (!newCmdletMetadataMap.ContainsKey(cmdletName))
                {
                    diffInfo.Add(new CmdletDiffInformation()
                    {
                        ModuleName = moduleName,
                        CmdletName = cmdletName,
                        Type = ChangeType.CmdletRemove,
                        Before = new List<string> { cmdletName },
                    });
                    oldCmdletMetadataMap.Remove(cmdletName);
                }
                else
                // both old and new module have the same cmdlet
                {
                    if (oldCmdletMetadataMap[cmdletName] == null || oldCmdletMetadataMap[cmdletName]?.Equals(newCmdletMetadataMap[cmdletName]) == false)
                    {
                        CompareCmdletsAlias(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
                        CompareCmdletsSupportsShouldProcess(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
                        CompareCmdletsSupportsPaging(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
                        CompareCmdletsParameter(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
                        CompareCmdletsOutputChange(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
                        CompareParameterSetMetadata(oldCmdletMetadataMap[cmdletName], oldCmdletMetadataMap[cmdletName].ParameterSets, newCmdletMetadataMap[cmdletName].ParameterSets, moduleName);
                    }
                    oldCmdletMetadataMap.Remove(cmdletName);
                    newCmdletMetadataMap.Remove(cmdletName);
                }
            }
            foreach (string cmdletName in newCmdletMetadataMap.Keys)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = cmdletName,
                    Type = ChangeType.CmdletAdd,
                    After = new List<string> { cmdletName },
                });
            }
        }

        private void CompareCmdletsAlias(
            CmdletMetadata oldCmdletMetadata,
            CmdletMetadata newCmdletMetadata,
            string moduleName)
        {
            var removedAliases = oldCmdletMetadata.AliasList.Except(newCmdletMetadata.AliasList).ToList();
            var addedAliases = newCmdletMetadata.AliasList.Except(oldCmdletMetadata.AliasList).ToList();

            AddAliasChangeInfo(moduleName, oldCmdletMetadata.Name, ChangeType.AliasRemove, removedAliases);
            AddAliasChangeInfo(moduleName, oldCmdletMetadata.Name, ChangeType.AliasAdd, addedAliases);
        }
        private void AddAliasChangeInfo(string moduleName, string cmdletName, ChangeType changeType, List<string> aliases)
        {
            if (aliases.Any())
            {
                if (changeType == ChangeType.AliasAdd)
                {
                    diffInfo.Add(new CmdletDiffInformation()
                    {
                        ModuleName = moduleName,
                        CmdletName = cmdletName,
                        Type = changeType,
                        After = aliases,
                    });
                }
                else
                {
                    diffInfo.Add(new CmdletDiffInformation()
                    {
                        ModuleName = moduleName,
                        CmdletName = cmdletName,
                        Type = changeType,
                        Before = aliases,
                    });
                }
            }
        }

        private void CompareCmdletsSupportsShouldProcess(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            string moduleName)
        {
            if (oldCmdlet.SupportsShouldProcess != newCmdlet.SupportsShouldProcess)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = oldCmdlet.Name,
                    Type = ChangeType.CmdletSupportsShouldProcessChange,
                    Before = new List<string> { oldCmdlet.SupportsShouldProcess.ToString() },
                    After = new List<string> { newCmdlet.SupportsShouldProcess.ToString() },
                });
            }
        }
        private void CompareCmdletsSupportsPaging(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            string moduleName)
        {
            if (oldCmdlet.SupportsPaging != newCmdlet.SupportsPaging)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = oldCmdlet.Name,
                    Type = ChangeType.CmdletSupportsPagingChange,
                    Before = new List<string> { oldCmdlet.SupportsPaging.ToString() },
                    After = new List<string> { newCmdlet.SupportsPaging.ToString() },
                });
            }
        }
        private void CompareCmdletsParameter(CmdletMetadata oldCmdletMetadata,
            CmdletMetadata newCmdletMetadata,
            string moduleName)
        {
            //  Parameter remove/ add
            List<string> oldParameterNames = new List<string>();
            List<string> newParameterNames = new List<string>();
            foreach (var parameterMetadata in oldCmdletMetadata.Parameters)
            {
                if (_ignoreParameters.Contains(parameterMetadata.Name))
                {
                    continue;
                }
                oldParameterNames.Add(parameterMetadata.Name);
            }
            foreach (var parameterMetadata in newCmdletMetadata.Parameters)
            {
                if (_ignoreParameters.Contains(parameterMetadata.Name))
                {
                    continue;
                }
                newParameterNames.Add(parameterMetadata.Name);
            }
            if (!(oldParameterNames.Count == newParameterNames.Count && oldParameterNames.Count(t => !newParameterNames.Contains(t)) == 0))
            {
                CompareChangedParameter(moduleName, oldCmdletMetadata.Name, oldParameterNames, newParameterNames);
            }
            CompareCmdletsParamProperties(oldCmdletMetadata, newCmdletMetadata, moduleName);
        }

        private void CompareChangedParameter(string moduleName, string cmdletName, List<string> oldParameterNames, List<string> newParameterNames)
        {
            var removedParameters = oldParameterNames.Except(newParameterNames).ToList();
            var addedParameters = newParameterNames.Except(oldParameterNames).ToList();

            AddParameterChangeInfo(moduleName, cmdletName, ChangeType.ParameterRemove, removedParameters);
            AddParameterChangeInfo(moduleName, cmdletName, ChangeType.ParameterAdd, addedParameters);
        }

        private void AddParameterChangeInfo(string moduleName, string cmdletName, ChangeType changeType, List<string> parameters)
        {
            if (!parameters.Any())
            {
                return;
            }
            if (changeType == ChangeType.ParameterAdd)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = cmdletName,
                    Type = changeType,
                    ParameterName = String.Join(", ", parameters),
                    After = parameters,
                });
            }
            else
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = cmdletName,
                    Type = changeType,
                    ParameterName = String.Join(", ", parameters),
                    Before = parameters,
                });
            }
        }

        private void CompareCmdletsParamProperties(CmdletMetadata oldCmdletMetadata,
            CmdletMetadata newCmdletMetadata,
            string moduleName)
        {
            // ParameterAlias remove/ add && ParameterTypeChange,
            List<ParameterMetadata> oldParameterMetadatas = oldCmdletMetadata.Parameters;
            List<ParameterMetadata> newParameterMetadatas = newCmdletMetadata.Parameters;

            var compareParameterMetadatas =
                from oldParam in oldParameterMetadatas
                where !_ignoreParameters.Contains(oldParam.Name)
                join newParam in newParameterMetadatas on oldParam.Name equals newParam.Name
                where !_ignoreParameters.Contains(newParam.Name)
                select (oldParam, newParam);

            foreach (var (oldParameterMetadata, newParameterMetadata) in compareParameterMetadatas)
            {
                CompareChangedParameterAliases(moduleName, oldCmdletMetadata.Name, oldParameterMetadata, newParameterMetadata);
                CompareChangedParameterType(moduleName, oldCmdletMetadata, oldParameterMetadata, newParameterMetadata);
                CompareChangedParameterAttribute(moduleName, oldCmdletMetadata, oldParameterMetadata, newParameterMetadata);
            }
        }

        private void CompareChangedParameterAliases(string moduleName, string cmdletName, ParameterMetadata oldParameterMetadata, ParameterMetadata newParameterMetadata)
        {
            if (!(oldParameterMetadata.AliasList.Count == newParameterMetadata.AliasList.Count
                                && oldParameterMetadata.AliasList.Count(t => !newParameterMetadata.AliasList.Contains(t)) == 0))
            {
                List<string> addedAliases = newParameterMetadata.AliasList.Except(oldParameterMetadata.AliasList).ToList();
                ProcessChangedParameterAliases(moduleName, cmdletName, ChangeType.ParameterAliasAdd, oldParameterMetadata, addedAliases);
                List<string> removedAliases = oldParameterMetadata.AliasList.Except(newParameterMetadata.AliasList).ToList();
                ProcessChangedParameterAliases(moduleName, cmdletName, ChangeType.ParameterAliasRemove, oldParameterMetadata, removedAliases);
            }
        }
        private void ProcessChangedParameterAliases(string moduleName, string cmdletName, ChangeType changeType,
            ParameterMetadata oldParameterMetadata,
            List<string> addedOrRemovedAliases)
        {
            if (!addedOrRemovedAliases.Any())
            {
                return;
            }
            if (changeType == ChangeType.ParameterAliasAdd)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = cmdletName,
                    Type = changeType,
                    ParameterName = oldParameterMetadata.Name,
                    After = addedOrRemovedAliases,
                });
            }
            else
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = cmdletName,
                    Type = changeType,
                    ParameterName = oldParameterMetadata.Name,
                    Before = addedOrRemovedAliases,
                });
            }
        }
        void CompareChangedParameterType(string moduleName, CmdletMetadata oldCmdletMetadata, ParameterMetadata oldParameterMetadata,
           ParameterMetadata newParameterMetadata)
        {
            string oldParameterTypeName = GetSimplifiedParameterTypeName(oldParameterMetadata);
            string newParameterTypeName = GetSimplifiedParameterTypeName(newParameterMetadata);
            if (oldParameterTypeName != newParameterTypeName)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = oldCmdletMetadata.Name,
                    Type = ChangeType.ParameterTypeChange,
                    ParameterName = oldParameterMetadata.Name,
                    Before = new List<string> { oldParameterTypeName },
                    After = new List<string> { newParameterTypeName },
                });
            }
        }

        void CompareChangedParameterAttribute(string moduleName, CmdletMetadata oldCmdletMetadata, ParameterMetadata oldParameterMetadata,
            ParameterMetadata newParameterMetadata)
        {
            if (oldParameterMetadata.ValidateNotNullOrEmpty != newParameterMetadata.ValidateNotNullOrEmpty)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = oldCmdletMetadata.Name,
                    Type = ChangeType.ParameterAttributeChange,
                    ParameterName = newParameterMetadata.Name,
                    Before = new List<string> { oldParameterMetadata.ValidateNotNullOrEmpty.ToString() },
                    After = new List<string> { newParameterMetadata.ValidateNotNullOrEmpty.ToString() },
                });
            }
        }

        private void CompareCmdletsOutputChange(CmdletMetadata oldCmd,
        CmdletMetadata newCmd,
        string moduleName)
        {
            // OutputTypeChange
            bool outputTypeChanged = false;
            List<String> oldOutputType = new List<string>();
            List<String> newOutputType = new List<string>();

            foreach (var outputMetadata in oldCmd.OutputTypes)
            {
                string oldOutputTypeName = GetSimplifiedOutputTypeName(outputMetadata);
                oldOutputType.Add($"`{oldOutputTypeName}`");
            }

            foreach (var outputMetadata in newCmd.OutputTypes)
            {
                string newOutputTypeName = GetSimplifiedOutputTypeName(outputMetadata);
                newOutputType.Add($"`{newOutputTypeName}`");
            }

            outputTypeChanged = oldOutputType.Any(x => !newOutputType.Contains(x));

            if (outputTypeChanged)
            {
                diffInfo.Add(new CmdletDiffInformation()
                {
                    ModuleName = moduleName,
                    CmdletName = oldCmd.Name,
                    Type = ChangeType.OutputTypeChange,
                    Before = oldOutputType,
                    After = newOutputType,
                });
            }
        }

        private void CompareParameterSetMetadata(
            CmdletMetadata cmdlet,
            List<ParameterSetMetadata> oldParameterSets,
            List<ParameterSetMetadata> newParameterSets,
            string moduleName)
        {
            foreach (var oldParameterSet in oldParameterSets)
            {
                if (oldParameterSet.Name == "__AllParameterSets")
                {
                    continue;
                }
                var newSet = newParameterSets.FirstOrDefault(t => t.Name == oldParameterSet.Name);
                if (newSet == null)
                {
                    diffInfo.Add(new CmdletDiffInformation()
                    {
                        ModuleName = moduleName,
                        CmdletName = cmdlet.Name,
                        Type = ChangeType.ParameterSetRemove,
                        ParameterSetName = oldParameterSet.Name
                    });
                    continue;
                }
                foreach (var oldParam in oldParameterSet.Parameters)
                {
                    var newParam = newSet.Parameters.FirstOrDefault(p => p.ParameterMetadata.Name == oldParam.ParameterMetadata.Name);
                    if (newParam == null)
                    {
                        diffInfo.Add(new CmdletDiffInformation()
                        {
                            ModuleName = moduleName,
                            CmdletName = cmdlet.Name,
                            Type = ChangeType.ParameterSetAttributePropertyChange,
                            ParameterSetName = oldParameterSet.Name,
                            ParameterName = oldParam.ParameterMetadata.Name,
                            PropertyName = "ParameterRemoved"
                        });
                        continue;
                    }

                    if (oldParam.Position != newParam.Position)
                    {
                        diffInfo.Add(new CmdletDiffInformation()
                        {
                            ModuleName = moduleName,
                            CmdletName = cmdlet.Name,
                            Type = ChangeType.ParameterSetAttributePropertyChange,
                            ParameterSetName = oldParameterSet.Name,
                            ParameterName = oldParam.ParameterMetadata.Name,
                            Before = new List<string> { oldParam.Position.ToString() },
                            After = new List<string> { newParam.Position.ToString() },
                            PropertyName = "Position"
                        });
                    }
                    if (oldParam.Mandatory != newParam.Mandatory)
                    {
                        diffInfo.Add(new CmdletDiffInformation()
                        {
                            ModuleName = moduleName,
                            CmdletName = cmdlet.Name,
                            Type = ChangeType.ParameterSetAttributePropertyChange,
                            ParameterSetName = oldParameterSet.Name,
                            ParameterName = oldParam.ParameterMetadata.Name,
                            Before = new List<string> { oldParam.Mandatory.ToString() },
                            After = new List<string> { newParam.Mandatory.ToString() },
                            PropertyName = "Mandatory"
                        });
                    }
                    if (oldParam.ValueFromPipeline != newParam.ValueFromPipeline)
                    {
                        diffInfo.Add(new CmdletDiffInformation()
                        {
                            ModuleName = moduleName,
                            CmdletName = cmdlet.Name,
                            Type = ChangeType.ParameterSetAttributePropertyChange,
                            ParameterSetName = oldParameterSet.Name,
                            ParameterName = oldParam.ParameterMetadata.Name,
                            Before = new List<string> { oldParam.ValueFromPipeline.ToString() },
                            After = new List<string> { newParam.ValueFromPipeline.ToString() },
                            PropertyName = "ValueFromPipeline"
                        });
                    }
                    if (oldParam.ValueFromPipelineByPropertyName != newParam.ValueFromPipelineByPropertyName)
                    {
                        diffInfo.Add(new CmdletDiffInformation()
                        {
                            ModuleName = moduleName,
                            CmdletName = cmdlet.Name,
                            Type = ChangeType.ParameterSetAttributePropertyChange,
                            ParameterSetName = oldParameterSet.Name,
                            ParameterName = oldParam.ParameterMetadata.Name,
                            Before = new List<string> { oldParam.ValueFromPipelineByPropertyName.ToString() },
                            After = new List<string> { newParam.ValueFromPipelineByPropertyName.ToString() },
                            PropertyName = "ValueFromPipelineByPropertyName"
                        });
                    }
                }
                foreach (var newParam in newSet.Parameters)
                {
                    var oldParam = oldParameterSet.Parameters.FirstOrDefault(p => p.ParameterMetadata.Name == newParam.ParameterMetadata.Name);
                    if (oldParam == null)
                    {
                        diffInfo.Add(new CmdletDiffInformation()
                        {
                            ModuleName = moduleName,
                            CmdletName = cmdlet.Name,
                            Type = ChangeType.ParameterSetAttributePropertyChange,
                            ParameterSetName = oldParameterSet.Name,
                            ParameterName = newParam.ParameterMetadata.Name,
                            PropertyName = "ParameterAdded"
                        });
                    }
                }

            }
            foreach (var newSet in newParameterSets)
            {
                if (newSet.Name == "__AllParameterSets")
                {
                    continue;
                }
                var oldSet = oldParameterSets.FirstOrDefault(t => t.Name == newSet.Name);
                if (oldSet == null)
                {
                    diffInfo.Add(new CmdletDiffInformation()
                    {
                        ModuleName = moduleName,
                        CmdletName = cmdlet.Name,
                        Type = ChangeType.ParameterSetAdd,
                        ParameterSetName = newSet.Name,
                    });
                }
            }
        }
        public AnalysisReport GetAnalysisReport()
        {
            var analysisReport = new AnalysisReport();
            var reportLog = Logger.GetReportLogger(CmdletDiffIssueReportLoggerName);
            if (!reportLog.Records.Any()) return analysisReport;

            foreach (var rec in reportLog.Records)
            {
                analysisReport.ProblemIdList.Add(rec.ProblemId);
            }

            return analysisReport;
        }

        public void GenerateMarkdown(string filePath)
        {
            var sb = new StringBuilder();
            if (diffInfo == null)
            {
                return;
            }
            for (int i = 0; i < diffInfo.Count; i++)
            {
                if (i == 0 || diffInfo[i].ModuleName != diffInfo[i - 1].ModuleName)
                {
                    sb.AppendFormat("* {0}\n", diffInfo[i].ModuleName);
                }
                if (i == 0 || diffInfo[i].CmdletName != diffInfo[i - 1].CmdletName)
                {
                    if (diffInfo[i].Type == ChangeType.CmdletAdd)
                    {
                        sb.AppendFormat("  * Added cmdlet `{0}`.\n", diffInfo[i].CmdletName);
                    }
                    else if (diffInfo[i].Type == ChangeType.CmdletRemove)
                    {
                        sb.AppendFormat("  * Removed cmdlet `{0}`.\n", diffInfo[i].CmdletName);
                    }
                    else
                    {
                        sb.AppendFormat("  * Modified cmdlet `{0}`:", diffInfo[i].CmdletName);
                    }
                }
                if (GetDescription(diffInfo[i]) != "")
                {
                    sb.Append(" " + GetDescription(diffInfo[i]));
                    if (i < diffInfo.Count - 1 && diffInfo[i + 1].CmdletName != diffInfo[i].CmdletName)
                    {
                        sb.Append("\n");
                    }
                }
            }
            File.WriteAllText(filePath, sb.ToString());
        }
        private string FormatListString(List<string> list, Func<string, string> formatter)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(formatter(list[i]));
                if (i == list.Count - 2)
                {
                    builder.Append(" and ");
                }
                else if (i != list.Count - 1)
                {
                    builder.Append(", ");
                }
            }
            return builder.ToString();
        }
        private string GetDescription_CmdletAdd(CmdletDiffInformation info)
        {
            return "";
        }
        private string GetDescription_CmdletRemove(CmdletDiffInformation info)
        {
            return "";
        }
        private string GetDescription_CmdletSupportsShouldProcessChange(CmdletDiffInformation info)
        {
            return $"`SupportsShouldProcess` changed from {info.Before[0]} to {info.After[0]}";
        }
        private string GetDescription_CmdletSupportsPagingChange(CmdletDiffInformation info)
        {
            return $"`SupportsPaging` changed from {info.Before[0]} to {info.After[0]}";
        }
        private string GetDescription_AliasAdd(CmdletDiffInformation info)
        {
            var aliasString = info.After.Count() == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.After, t => $"`{t}`");
            return $"Added {aliasString} {aliasListString} to `{info.CmdletName}`.";
        }
        private string GetDescription_AliasRemove(CmdletDiffInformation info)
        {
            var aliasString = info.Before.Count() == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.Before, t => $"`{t}`");
            return $"Removed {aliasString} {aliasListString} from `{info.CmdletName}`.";
        }
        private string GetDescription_ParameterAdd(CmdletDiffInformation info)
        {
            var parameterString = info.After.Count == 1 ? "parameter" : "parameters";
            var parameterListString = FormatListString(info.After, t => $"`-{t}`");
            return $"Added {parameterString} {parameterListString}.";
        }
        private string GetDescription_ParameterRemove(CmdletDiffInformation info)
        {
            var parameterString = info.Before.Count == 1 ? "parameter" : "parameters";
            var parameterListString = FormatListString(info.Before, t => $"`-{t}`");
            return $"Removed {parameterString} {parameterListString}.";
        }
        private string GetDescription_ParameterAliasAdd(CmdletDiffInformation info)
        {
            var aliasString = info.After.Count == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.After, t => $"`{t}`");
            return $"Added parameter {aliasString} {aliasListString} to parameter `-{info.ParameterName}`.";
        }
        private string GetDescription_ParameterAliasRemove(CmdletDiffInformation info)
        {
            var aliasString = info.Before.Count == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.Before, t => $"`{t}`");
            return $"Removed parameter {aliasString} {aliasListString} from parameter `-{info.ParameterName}`.";
        }
        private string GetDescription_ParameterTypeChange(CmdletDiffInformation info)
        {
            return $"Changed the type of parameter `-{info.ParameterName}` from `{info.Before[0]}` to `{info.After[0]}`.";
        }
        private string GetDescription_ParameterAttributeChange(CmdletDiffInformation info)
        {
            return $"Parameter `-{info.ParameterName}` ValidateNotNullOrEmpty changed from {info.Before[0]} to {info.After[0]}";
        }

        private string GetDescription_ParameterSetAdd(CmdletDiffInformation info)
        {
            return $"Added parameter set `{info.ParameterSetName}`.";
        }
        private string GetDescription_ParameterSetRemove(CmdletDiffInformation info)
        {
            return $"Removed parameter set `{info.ParameterSetName}`.";
        }
        private string GetDescription_ParameterSetAttributePropertyChange(CmdletDiffInformation info)
        {
            if (info.PropertyName == "ParameterRemoved")
            {
                return $"Parameter set `{info.ParameterSetName}` removed parameter `-{info.ParameterName}`.";
            }
            else if (info.PropertyName == "Position")
            {
                return $"The `position` of parameter `{info.ParameterName}` in parameter set `{info.ParameterSetName}` changed from {info.Before[0]} to {info.After[0]}.";
            }
            else if (info.PropertyName == "Mandatory")
            {
                return $"The `mandatory` of parameter `{info.ParameterName}` in parameter set `{info.ParameterSetName}` changed from {info.Before[0]} to {info.After[0]}.";
            }
            else if (info.PropertyName == "ValueFromPipeline")
            {
                return $"The `ValueFromPipeline` of parameter `{info.ParameterName}` in parameter set `{info.ParameterSetName}` changed from {info.Before[0]} to {info.After[0]}.";
            }
            else if (info.PropertyName == "ValueFromPipelineByPropertyName")
            {
                return $"The `ValueFromPipelineByPropertyName` of parameter `{info.ParameterName}` in parameter set `{info.ParameterSetName}` changed from {info.Before[0]} to {info.After[0]}.";
            }
            else
            {
                return $"Parameter set `{info.ParameterSetName}` added parameter `-{info.ParameterName}`.";
            }
        }

        private string GetDescription_OutputTypeChange(CmdletDiffInformation info)
        {
            return $"Output type changed from {FormatListString(info.Before, t => $"`{t}`")} to {FormatListString(info.After, t => $"`{t}`")}.";
        }
        public string GetDescription(CmdletDiffInformation info)
        {
            Dictionary<ChangeType, Func<CmdletDiffInformation, string>> mapper = new Dictionary<ChangeType, Func<CmdletDiffInformation, string>>();
            mapper.Add(ChangeType.CmdletAdd, GetDescription_CmdletAdd);
            mapper.Add(ChangeType.CmdletRemove, GetDescription_CmdletRemove);
            mapper.Add(ChangeType.CmdletSupportsShouldProcessChange, GetDescription_CmdletSupportsShouldProcessChange);
            mapper.Add(ChangeType.CmdletSupportsPagingChange, GetDescription_CmdletSupportsPagingChange);
            mapper.Add(ChangeType.AliasAdd, GetDescription_AliasAdd);
            mapper.Add(ChangeType.AliasRemove, GetDescription_AliasRemove);
            mapper.Add(ChangeType.ParameterAdd, GetDescription_ParameterAdd);
            mapper.Add(ChangeType.ParameterRemove, GetDescription_ParameterRemove);
            mapper.Add(ChangeType.ParameterAliasAdd, GetDescription_ParameterAliasAdd);
            mapper.Add(ChangeType.ParameterAliasRemove, GetDescription_ParameterAliasRemove);
            mapper.Add(ChangeType.ParameterTypeChange, GetDescription_ParameterTypeChange);
            mapper.Add(ChangeType.ParameterAttributeChange, GetDescription_ParameterAttributeChange);
            mapper.Add(ChangeType.ParameterSetAdd, GetDescription_ParameterSetAdd);
            mapper.Add(ChangeType.ParameterSetRemove, GetDescription_ParameterSetRemove);
            mapper.Add(ChangeType.ParameterSetAttributePropertyChange, GetDescription_ParameterSetAttributePropertyChange);
            mapper.Add(ChangeType.OutputTypeChange, GetDescription_OutputTypeChange);
            
            if (mapper.ContainsKey(info.Type))
            {
                return mapper[info.Type](info);
            }
            return "";
        }

        public void GenerateCsv(string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("\"ModuleName\",\"CmdletName\",\"ChangeType\",\"ParameterSetName\",\"ParameterName\",\"PropertyName\",\"Before\",\"After\"");
            if (diffInfo == null)
            {
                return;
            }
            foreach (var info in diffInfo)
            {
                string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", info.ModuleName, info.CmdletName, info.Type, info.ParameterSetName, info.ParameterName, info.PropertyName, info.Before == null ? "" : string.Join("; ", info.Before), info.After == null ? "" : string.Join("; ", info.After));
                csv.AppendLine(newLine);
            }
            File.WriteAllText(filePath, csv.ToString());
        }
        string GetSimplifiedParameterTypeName(ParameterMetadata parameterMetadata)
        {
            string parameterTypeName = parameterMetadata.Type.Name;
            if (parameterTypeName.StartsWith(parameterMetadata.Type.Namespace + "."))
            {
                parameterTypeName = parameterTypeName.Substring(parameterMetadata.Type.Namespace.Length + 1);
            }
            return parameterTypeName;
        }
        string GetSimplifiedOutputTypeName(OutputMetadata outputMetadata)
        {
            string outputTypeName = outputMetadata.Type.Name;
            if (outputTypeName.StartsWith(outputMetadata.Type.Namespace + "."))
            {
                outputTypeName = outputTypeName.Substring(outputMetadata.Type.Namespace.Length + 1);
            }
            return outputTypeName;
        }
    }
}