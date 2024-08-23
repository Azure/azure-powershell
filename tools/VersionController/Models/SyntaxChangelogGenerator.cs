using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;
using Tools.Common.Utilities;

namespace VersionController.Netcore.Models
{
    public class SyntaxChangelogGenerator
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public string CmdletDiffIssueReportLoggerName { get; set; }
        private List<string> _ignoreParameters = CommonInfo.ExcludedParameters;
        private List<CmdletDiffInformation> diffInfo = new List<CmdletDiffInformation>();
        public void Analyze(String rootDirectory)
        {
            var srcDirs = Path.Combine(rootDirectory, @"src\");
            var toolsCommonDirs = Path.Combine(rootDirectory, @"tools\Tools.Common");
            // bez: Will include psd1 files under test proj
            var manifestFiles = Directory.EnumerateFiles(srcDirs, "*.psd1", SearchOption.AllDirectories)
                                         .Where(file =>
                                             !Path.GetDirectoryName(file)
                                             .EndsWith("autorest", StringComparison.OrdinalIgnoreCase))
                                         .ToList();
            foreach (var psd1 in manifestFiles)
            {
                var moduleVersion = ExtractModuleVersion(psd1);
                if (moduleVersion.CompareTo(new Version("1.0.0")) < 0) continue;
                var psd1FileName = Path.GetFileName(psd1);
                var moduleName = psd1FileName.Replace(".psd1", "");
                if (ModuleFilter.IsAzureStackModule(moduleName.Replace("Az.", ""))) continue;
                Console.WriteLine("Analyzing module: {0}", moduleName);
                var executingPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).AbsolutePath);
                Directory.SetCurrentDirectory(executingPath);
                var newModuleMetadata = MetadataLoader.GetModuleMetadata(moduleName);
                var filePath = Path.Combine(toolsCommonDirs, "SerializedCmdlets", $"{moduleName}.json");
                if (!File.Exists(filePath))  continue;
                var oldModuleMetadata = ModuleMetadata.DeserializeCmdlets(filePath);
                CmdletLoader.ModuleMetadata = oldModuleMetadata;
                CompareModuleMetedata(oldModuleMetadata, newModuleMetadata, moduleName);
            }
            var markDownPath = Path.Combine(rootDirectory, @"documentation/SyntaxChangeLog/SyntaxChangeLog.md");
            GenerateMarkdown(markDownPath);
            Console.WriteLine("Cmdlets Differences written to {0}", markDownPath);
        }

        public Version ExtractModuleVersion(string filePath)
        {
            string moduleVersion = null;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("ModuleVersion", StringComparison.OrdinalIgnoreCase))
                {
                    var versionPart = line.Split('=');
                    if (versionPart.Length == 2)
                    {
                        moduleVersion = versionPart[1].Trim().Trim('\'', '"');
                        break;
                    }
                }
            }

            return new Version(moduleVersion);
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
                        CompareCmdletsParameter(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
                        CompareCmdletsOutputChange(oldCmdletMetadataMap[cmdletName], newCmdletMetadataMap[cmdletName],
                          moduleName);
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
                    sb.AppendFormat("#### {0} \n", diffInfo[i].ModuleName);
                }
                if (i == 0 || diffInfo[i].CmdletName != diffInfo[i - 1].CmdletName)
                {
                    if (diffInfo[i].Type == ChangeType.CmdletAdd)
                    {
                        if (i != 0 && diffInfo[i].Type == diffInfo[i-1].Type) {
                            sb.AppendFormat(", `{0}`",diffInfo[i].CmdletName);
                        } else {
                            sb.AppendFormat("* Added cmdlet `{0}`", diffInfo[i].CmdletName);
                        }
                        if (i + 1 == diffInfo.Count ||diffInfo[i].Type != diffInfo[i+1].Type) {
                                sb.AppendFormat("\n");
                        }
                    }
                    else if (diffInfo[i].Type == ChangeType.CmdletRemove)
                    {
                        if (i != 0 && diffInfo[i].Type == diffInfo[i-1].Type) {
                            sb.AppendFormat(", `{0}`",diffInfo[i].CmdletName);

                        } else {
                            sb.AppendFormat("* Removed cmdlet `{0}`", diffInfo[i].CmdletName);
                        }
                        if (i + 1 == diffInfo.Count ||diffInfo[i].Type != diffInfo[i+1].Type) {
                            sb.AppendFormat("\n");
                        }                        
                    }
                    else
                    {
                        sb.AppendFormat("* Modified cmdlet `{0}`", diffInfo[i].CmdletName);
                    }
                }
                if (GetDescription(diffInfo[i]) != "")
                {
                    sb.Append("\n   - " + GetDescription(diffInfo[i]));
                    if (i < diffInfo.Count - 1 && diffInfo[i + 1].CmdletName != diffInfo[i].CmdletName)
                    {
                        sb.Append("\n");
                    }
                }
            }
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.AppendAllText(filePath, sb.ToString());
        }
        private string FormatListString(List<string> list, Func<string, string> formatter)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(formatter(list[i]));
                if (i != list.Count - 1)
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
            return $"Added {aliasString} {aliasListString} to `{info.CmdletName}`";
        }
        private string GetDescription_AliasRemove(CmdletDiffInformation info)
        {
            var aliasString = info.Before.Count() == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.Before, t => $"`{t}`");
            return $"Removed {aliasString} {aliasListString} from `{info.CmdletName}`";
        }
        private string GetDescription_ParameterAdd(CmdletDiffInformation info)
        {
            var parameterString = info.After.Count == 1 ? "parameter" : "parameters";
            var parameterListString = FormatListString(info.After, t => $"`-{t}`");
            return $"Added {parameterString} {parameterListString}";
        }
        private string GetDescription_ParameterRemove(CmdletDiffInformation info)
        {
            var parameterString = info.Before.Count == 1 ? "parameter" : "parameters";
            var parameterListString = FormatListString(info.Before, t => $"`-{t}`");
            return $"Removed {parameterString} {parameterListString}";
        }
        private string GetDescription_ParameterAliasAdd(CmdletDiffInformation info)
        {
            var aliasString = info.After.Count == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.After, t => $"`{t}`");
            return $"Added parameter {aliasString} {aliasListString} to parameter `-{info.ParameterName}`";
        }
        private string GetDescription_ParameterAliasRemove(CmdletDiffInformation info)
        {
            var aliasString = info.Before.Count == 1 ? "alias" : "aliases";
            var aliasListString = FormatListString(info.Before, t => $"`{t}`");
            return $"Removed parameter {aliasString} {aliasListString} from parameter `-{info.ParameterName}`";
        }
        private string GetDescription_ParameterTypeChange(CmdletDiffInformation info)
        {
            return $"Changed the type of parameter `-{info.ParameterName}` from `{info.Before[0]}` to `{info.After[0]}`";
        }
        private string GetDescription_ParameterAttributeChange(CmdletDiffInformation info)
        {
            return $"Parameter `-{info.ParameterName}` ValidateNotNullOrEmpty changed from `{info.Before[0]}` to `{info.After[0]}`";
        }

        private string GetDescription_OutputTypeChange(CmdletDiffInformation info)
        {
            return $"Output type changed from {FormatListString(info.Before, t => $"`{t}`")} to {FormatListString(info.After, t => $"`{t}`")}";
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
            mapper.Add(ChangeType.OutputTypeChange, GetDescription_OutputTypeChange);
            mapper.Add(ChangeType.ParameterAttributeChange, GetDescription_ParameterAttributeChange);

            if (mapper.ContainsKey(info.Type))
            {
                return mapper[info.Type](info);
            }
            return "";
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
