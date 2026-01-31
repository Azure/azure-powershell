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

using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class TestCoverage : ITestCoverage
    {
        private const string CsvHeaderCommandName = "CommandName";
        private const string CsvHeaderParameterSetName = "ParameterSetName";
        private const string CsvHeaderParameters = "Parameters";
        private const string CsvHeaderSourceScript = "SourceScript";
        private const string CsvHeaderScriptLineNumber = "LineNumber";
        private const string CsvHeaderStartDateTime = "StartDateTime";
        private const string CsvHeaderEndDateTime = "EndDateTime";
        private const string CsvHeaderIsSuccess = "IsSuccess";
        private const string Delimiter = ",";

        private static readonly HashSet<string> ExcludedSource = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Common.ps1",
            "Assert.ps1",
            "AzureRM.Resources.ps1",
            "AzureRM.Storage.ps1"
        };

        private static readonly Regex ModuleNameRegex = new Regex(@"[\\/](?:artifacts[\\/]Debug|src)[\\/](?:Az\.)?(?<ModuleName>[a-zA-Z0-9]+)[\\/]", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly string s_testCoveragePath;
        
        private static readonly string s_csvHeader;

        private static readonly object s_fileLock = new object();

        static TestCoverage()
        {
            string testCoverageRootPath = null;
            if (AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager))
            {
                testCoverageRootPath = configManager.GetConfigValue<string>(ConfigKeys.TestCoverageLocation);
            }
            if (string.IsNullOrEmpty(testCoverageRootPath))
            {
                testCoverageRootPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    Resources.AzureDirectoryName);
            }

            s_testCoveragePath = Path.Combine(testCoverageRootPath, "TestCoverageAnalysis", "Raw");
            DirectoryInfo rawDir = new DirectoryInfo(s_testCoveragePath);
            if (!rawDir.Exists)
            {
                Directory.CreateDirectory(s_testCoveragePath);
            }

            s_csvHeader = GenerateCsvHeader();
        }

        private static string GenerateCsvHeader()
        {
            StringBuilder headerBuilder = new StringBuilder();
            headerBuilder.Append(CsvHeaderCommandName).Append(Delimiter)
                         .Append(CsvHeaderParameterSetName).Append(Delimiter)
                         .Append(CsvHeaderParameters).Append(Delimiter)
                         .Append(CsvHeaderSourceScript).Append(Delimiter)
                         .Append(CsvHeaderScriptLineNumber).Append(Delimiter)
                         .Append(CsvHeaderStartDateTime).Append(Delimiter)
                         .Append(CsvHeaderEndDateTime).Append(Delimiter)
                         .Append(CsvHeaderIsSuccess);

            return headerBuilder.ToString();
        }

        private string GenerateCsvItem(string commandName, string parameterSetName, string parameters, string sourceScript, int scriptLineNumber, string startDateTime, string endDateTime, bool isSuccess)
        {
            StringBuilder itemBuilder = new StringBuilder();
            itemBuilder.Append(commandName).Append(Delimiter)
                       .Append(parameterSetName).Append(Delimiter)
                       .Append(parameters).Append(Delimiter)
                       .Append(sourceScript).Append(Delimiter)
                       .Append(scriptLineNumber).Append(Delimiter)
                       .Append(startDateTime).Append(Delimiter)
                       .Append(endDateTime).Append(Delimiter)
                       .Append(isSuccess.ToString().ToLowerInvariant());

            return itemBuilder.ToString();
        }

        public void LogRawData(AzurePSQoSEvent qos)
        {
#if DEBUG || TESTCOVERAGE
            string commandName = qos.CommandName;
            string sourceScriptPath = qos.SourceScript;
            string sourceScriptName = Path.GetFileName(sourceScriptPath);

            if (string.IsNullOrEmpty(commandName) || string.IsNullOrEmpty(sourceScriptName) || ExcludedSource.Contains(sourceScriptName))
                return;

            var moduleMatch = ModuleNameRegex.Match(sourceScriptPath);
            if (!moduleMatch.Success)
                return;

            var moduleName = $"Az.{moduleMatch.Groups["ModuleName"].Value}";
            var csvFilePath = Path.Combine(s_testCoveragePath, $"{moduleName}.csv");

            lock (s_fileLock)
            {
                try
                {
                    bool fileExists = File.Exists(csvFilePath);
                    using (var writer = new StreamWriter(csvFilePath, true, Encoding.UTF8))
                    {
                        if (!fileExists)
                        {
                            writer.WriteLine(s_csvHeader);
                        }

                        var csvItem = GenerateCsvItem(commandName, qos.ParameterSetName, qos.Parameters, sourceScriptName, qos.ScriptLineNumber, qos.StartTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss"), qos.EndTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss"), qos.IsSuccess);
                        writer.WriteLine(csvItem);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"##[group]Error occurred when generating raw data of test coverage for module {moduleName}");

                    Console.WriteLine($"##[error]Exception Type: {ex.GetType().FullName}");
                    Console.WriteLine($"##[error]Error Message: {ex.Message}");
                    Console.WriteLine($"##[error]Command Name: {commandName}");
                    Console.WriteLine($"##[error]Source Script: {sourceScriptName}");
                    Console.WriteLine($"##[error]Stack Trace: {ex.StackTrace}");
                    Console.WriteLine("##[endgroup]");
                }
            }
#endif
        }
    }
}
