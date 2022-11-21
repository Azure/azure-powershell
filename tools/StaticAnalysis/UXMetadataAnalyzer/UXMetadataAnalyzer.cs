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

using NJsonSchema;
using NJsonSchema.Validation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;
using Tools.Common.Utilities;

using ParameterMetadata = Tools.Common.Models.ParameterMetadata;
using ParameterSetMetadata = Tools.Common.Models.ParameterSetMetadata;

namespace StaticAnalysis.UXMetadataAnalyzer
{
    public class UXMetadataAnalyzer : IStaticAnalyzer
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public string UXMetadataIssueReportLoggerName { get; set; }
        private readonly JsonSchema schema;
        private readonly JsonSchemaValidator schemaValidator = new JsonSchemaValidator();

        public UXMetadataAnalyzer()
        {
            Name = "UX Metadata Analyzer";
            UXMetadataIssueReportLoggerName = "UXMetadataIssues.csv";
            var executingPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var schemaPath = Path.Combine(executingPath, "UXMetadataAnalyzer", "PortalInputSchema.json");
            var schemaContent = File.ReadAllText(schemaPath);
            schema = JsonSchema.FromJsonAsync(schemaContent).Result;
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
            var savedDirectory = Directory.GetCurrentDirectory();
            var issueLogger = Logger.CreateLogger<UXMetadataIssue>("UXMetadataIssues.csv");

            if (directoryFilter != null)
            {
                cmdletProbingDirs = directoryFilter(cmdletProbingDirs);
            }

            foreach (var baseDirectory in cmdletProbingDirs.Where(s => !s.Contains("ServiceManagement") &&
                                                                        !ModuleFilter.IsAzureStackModule(s) && Directory.Exists(Path.GetFullPath(s))))
            {
                SharedAssemblyLoader.Load(baseDirectory);
                var probingDirectories = new List<string> {baseDirectory};

                // Add current directory for probing
                probingDirectories.AddRange(Directory.EnumerateDirectories(Path.GetFullPath(baseDirectory)));

                foreach (var directory in probingDirectories)
                {
                    if (modulesToAnalyze != null &&
                        modulesToAnalyze.Any() &&
                        !modulesToAnalyze.Any(m => directory.EndsWith(m)))
                    {
                        continue;
                    }
                    string moduleName = Path.GetFileName(directory);

                    Directory.SetCurrentDirectory(directory);

                    var moduleMetadata = MetadataLoader.GetModuleMetadata(moduleName);

                    string UXFolder = Path.Combine(directory, "UX");
                    if (!Directory.Exists(UXFolder))
                    {
                        continue;
                    }

                    var UXMetadataPathList = Directory.EnumerateFiles(UXFolder, "*.json", SearchOption.AllDirectories);
                    foreach (var UXMetadataPath in UXMetadataPathList)
                    {
                        ValidateUXMetadata(moduleName, UXMetadataPath, moduleMetadata, issueLogger);
                    }
                    Directory.SetCurrentDirectory(savedDirectory);
                }
            }
        }

        private void ValidateSchema(string moduleName, string resourceType, string subResourceType, string UXMetadataContent, ReportLogger<UXMetadataIssue> issueLogger)
        {
            var result = schemaValidator.Validate(UXMetadataContent, schema);
            if (result != null && result.Count != 0)
            {
                foreach (ValidationError error in result)
                {
                    issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, null, 1, error.ToString().Replace("\n", "\\n"));
                }
            }
        }

        private void ValidateMetadata(string moduleName, string resourceType, string subResourceType, string UXMetadataContent, ModuleMetadata moduleMetadata, ReportLogger<UXMetadataIssue> issueLogger)
        {
            UXMetadata UXMetadata = JsonConvert.DeserializeObject<UXMetadata>(UXMetadataContent);
            
            foreach (UXMetadataCommand command in UXMetadata.Commands)
            {
                string expectLearnUrl = string.Format("https://learn.microsoft.com/powershell/module/{0}/{1}", moduleName, command.Name).ToLower();
                
                if (!expectLearnUrl.Equals(command.Help.LearnMore.Url, StringComparison.OrdinalIgnoreCase))
                {
                    string description = string.Format("Doc url is expect: {0} but get: {1}", expectLearnUrl, command.Help.LearnMore.Url);
                    issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, command.Name, 1, description);
                }
                if (command.Path.IndexOf(resourceType, StringComparison.CurrentCultureIgnoreCase) == -1)
                {
                    string description = string.Format("The path {0} doesn't contains the right resource tpye: {1}", command.Path, resourceType);
                    issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, command.Name, 2, description);
                }

                CmdletMetadata cmdletMetadata = moduleMetadata.Cmdlets.Find(x => x.Name == command.Name);
                if (cmdletMetadata == null)
                {
                    string description = string.Format("Cmdlet {0} is not contained in {1}.", command.Name, moduleName);
                    issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, command.Name, 1, description);
                }
                else
                {
                    foreach (UXMetadataCommandExample example in command.Examples)
                    {
                        ValidateExample(moduleName, resourceType, subResourceType, command.Name, cmdletMetadata, example, issueLogger);
                    }
                }
            }
        }

        private void ValidateExample(string moduleName, string resourceType, string subResourceType, string commandName, CmdletMetadata cmdletMetadata, UXMetadataCommandExample example, ReportLogger<UXMetadataIssue> issueLogger)
        {
            List<string> parameterListConvertedFromAlias = example.Parameters.Select(x =>
            {
                string parameterNameInExample = x.Name.Trim('-');
                foreach (ParameterMetadata parameterMetadata in cmdletMetadata.Parameters)
                {
                    if (parameterMetadata.Name.Equals(parameterNameInExample, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return parameterMetadata.Name;
                    }
                    foreach (string alias in parameterMetadata.AliasList)
                    {
                        if (alias.Equals(parameterNameInExample, StringComparison.CurrentCultureIgnoreCase))
                        {
                            string issueDescription = string.Format("Please use parameter {0} instead of alias {1}", parameterMetadata.Name, alias);
                            issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, commandName, 2, issueDescription);
                            return parameterMetadata.Name;
                        }
                    }
                }
                string description = string.Format("Cannot find the defination of parameter {0} in example", parameterNameInExample);
                issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, commandName, 1, description);
                return null;
            }).ToList();

            HashSet<string> parametersInExample = new HashSet<string>(parameterListConvertedFromAlias.Where(x => x != null));
            foreach (string parameter in parametersInExample)
            {
                if (parameterListConvertedFromAlias.Count(x => parameter.Equals(x)) != 1)
                {
                    string description = string.Format("Multiply reference of parameter {0} in example", parameter);
                    issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, commandName, 1, description);
                }
            }
            if (parameterListConvertedFromAlias.Contains(null))
            {
                return;
            }

            bool findMatchedParameterSet = false;
            foreach (ParameterSetMetadata parameterSetMetadata in cmdletMetadata.ParameterSets)
            {
                if (IsExampleMatchParameterSet(parametersInExample, parameterSetMetadata))
                {
                    findMatchedParameterSet = true;
                }
            }

            if (!findMatchedParameterSet)
            {
                string description = string.Format("Cannot find a matched parameter set for example of {0}", commandName);
                issueLogger.LogUXMetadataIssue(moduleName, resourceType, subResourceType, commandName, 1, description);
            }
        }

        private bool IsExampleMatchParameterSet(HashSet<string> parametersInExample, ParameterSetMetadata parameterSetMetadata)
        {
            List<Parameter> mandatoryParameters = parameterSetMetadata.Parameters.Where(x => x.Mandatory).ToList();
            foreach (Parameter parameter in mandatoryParameters)
            {
                if (!parametersInExample.Contains(parameter.ParameterMetadata.Name))
                {
                    return false;
                }
            }

            foreach (string parameterName in parametersInExample)
            {
                if (!IsParameterContainedInParameterSet(parameterName, parameterSetMetadata))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsParameterContainedInParameterSet(string paramenterName, ParameterSetMetadata parameterSetMetadata)
        {
            foreach (Parameter parameterInfo in parameterSetMetadata.Parameters)
            {
                if (parameterInfo.ParameterMetadata.Name.Equals(paramenterName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void ValidateUXMetadata(string moduleName, string UXMetadataPath, ModuleMetadata moduleMetadata, ReportLogger<UXMetadataIssue> issueLogger)
        {
            string UXMetadataContent = File.ReadAllText(UXMetadataPath);
            string resourceType = Path.GetFileName(Path.GetDirectoryName(UXMetadataPath));
            string subResourceType = Path.GetFileName(UXMetadataPath).Replace(".json", "");
            ValidateSchema(moduleName, resourceType, subResourceType, UXMetadataContent, issueLogger);
            ValidateMetadata(moduleName, resourceType, subResourceType, UXMetadataContent, moduleMetadata, issueLogger);
        }


        public AnalysisReport GetAnalysisReport()
        {
            var analysisReport = new AnalysisReport();
            var reportLog = Logger.GetReportLogger(UXMetadataIssueReportLoggerName);
            if (!reportLog.Records.Any()) return analysisReport;

            foreach (var rec in reportLog.Records)
            {
                analysisReport.ProblemIdList.Add(rec.ProblemId);
            }

            return analysisReport;
        }
    }

    public static class LogExtensions
    {
        public static void LogUXMetadataIssue(
            this ReportLogger<UXMetadataIssue> issueLogger, string module, string resourceType, string subResourceType, string command,
            int severity, string description)
        {
            issueLogger.LogRecord(new UXMetadataIssue
            {
                Module = module,
                ResourceType = resourceType,
                SubResourceType = subResourceType,
                Command = command,
                Description = description,
                Severity = severity,
            });
        }
    }
}