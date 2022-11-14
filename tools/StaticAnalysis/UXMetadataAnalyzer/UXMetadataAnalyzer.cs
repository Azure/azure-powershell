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

//#define SERIALIZE

using Newtonsoft.Json;

using NJsonSchema;
using NJsonSchema.Validation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;
using Tools.Common.Utilities;

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
            var processedHelpFiles = new List<string>();
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

                    string UXFolder = Path.Combine(directory, "UX");
                    if (!Directory.Exists(UXFolder))
                    {
                        continue;
                    }

                    var UXMetadataPathList = Directory.EnumerateFiles(UXFolder, "*.json", SearchOption.AllDirectories);
                    foreach (var UXMetadataPath in UXMetadataPathList)
                    {
                        ValidateUXMetadata(moduleName, UXMetadataPath, issueLogger);
                    }
                }
            }
        }

        private void ValidateUXMetadata(string moduleName, string UXMatadataPath, ReportLogger<UXMetadataIssue> issueLogger)
        {
            string data = File.ReadAllText(UXMatadataPath);
            var result = schemaValidator.Validate(data, schema);
            string resourceType = Path.GetFileName(Path.GetDirectoryName(UXMatadataPath));
            if (result != null && result.Count != 0)
            {
                foreach (ValidationError error in result)
                {
                    issueLogger.LogUXMetadataIssue(moduleName, resourceType, UXMatadataPath, 1, error.ToString().Replace("\n", "\\n"));
                }
            }
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
            this ReportLogger<UXMetadataIssue> issueLogger, string module, string resourceType, string filePath,
            int severity, string description)
        {
            issueLogger.LogRecord(new UXMetadataIssue
            {
                Module = module,
                ResourceType = resourceType,
                FilePath = filePath,
                Description = description,
                Severity = severity,
            });
        }
    }
}