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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tools.Common.Helpers;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;
using Tools.Common.Utilities;

namespace StaticAnalysis.GeneratedSdkAnalyzer
{
    public class GeneratedSdkAnalyzer : IStaticAnalyzer
    {
        public AnalysisLogger Logger { get; set; }
        public string Name { get; set; }
        public string GeneratedSdkIssueReportLoggerName { get; set; }

// TODO: Remove IfDef code
#if !NETSTANDARD
        private AppDomain _appDomain;
#endif

        public GeneratedSdkAnalyzer()
        {
            Name = "Generated Sdk Analyzer";
            GeneratedSdkIssueReportLoggerName = "GeneratedSdkIssues.csv";
        }

        /// <summary>
        /// Given a set of directory paths containing PowerShell module folders,
        /// analyze the Generated Sdk issues in the modules and report any issues
        /// </summary>
        /// <param name="cmdletProbingDirs">Set of directory paths containing PowerShell module folders to be checked for breaking changes.</param>
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
        /// Serialize the cmdlets so they can be compared to change modules later
        /// </summary>
        /// <param name="fileName">Name of the file cmdlets are being serialized to.</param>
        /// <param name="cmdlets">List of cmdlets that are to be serialized.</param>
        private void SerializeCmdlets(string fileName, ModuleMetadata moduleMetadata)
        {
            var json = JsonConvert.SerializeObject(moduleMetadata, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public AnalysisReport GetAnalysisReport()
        {
            var analysisReport = new AnalysisReport();
            var reportLog = Logger.GetReportLogger(GeneratedSdkIssueReportLoggerName);
            if (!reportLog.Records.Any()) return analysisReport;

            foreach (var rec in reportLog.Records)
            {
                analysisReport.ProblemIdList.Add(rec.ProblemId);
            }

            return analysisReport;
        }
    }
}