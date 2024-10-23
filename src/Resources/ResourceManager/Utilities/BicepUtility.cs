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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using Newtonsoft.Json;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Common.Exceptions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    public class BicepBuildParamsStdout
    {
        public string parametersJson { get; set; }

        public string templateJson { get; set; }

        public string templateSpecId { get; set; }
    }

    internal class BicepUtility
    {
        public static BicepUtility Create()
            => new BicepUtility(ProcessInvoker.Create(), FileUtilities.DataStore);

        /// <summary>
        /// The Bicep executable to use. By default, this'll be resolved from the system PATH.
        /// </summary>
        /// <remarks>
        /// If you want to test locally with a private build, you can replace this with a fully-qualified file path (e.g. "/Users/ant/.azure/bin/bicep").
        /// </remarks>
        private const string BicepExecutable = "bicep";

        private const string MinimalVersionRequirement = "0.3.1";

        private const string MinimalVersionRequirementForBicepPublish = "0.4.1008";

        private const string MinimalVersionRequirementForBicepPublishWithOptionalDocumentationUriParameter = "0.14.46";

        private const string MinimalVersionRequirementForBicepPublishWithOptionalForceParameter = "0.17.1";

        private const string MinimalVersionRequirementForBicepPublishWithOptionalWithSourceParameter = "0.23.1";

        private const string MinimalVersionRequirementForBicepparamFileBuild = "0.16.1";

        private const string MinimalVersionRequirementForBicepparamFileBuildWithInlineOverrides = "0.22.6";

        public delegate void OutputCallback(string msg);

        private readonly IProcessInvoker processInvoker;
        private readonly IDataStore dataStore;
        private readonly Lazy<string> bicepVersionLazy;

        public BicepUtility(IProcessInvoker processInvoker, IDataStore dataStore)
        {
            this.processInvoker = processInvoker;
            this.dataStore = dataStore;
            this.bicepVersionLazy = new Lazy<string>(() => {
                if (!processInvoker.CheckExecutableExists(BicepExecutable))
                {
                    return null;
                }

                var output = processInvoker.Invoke(new ProcessInput { Executable = BicepExecutable, Arguments = "-v" });            
                
                var pattern = new Regex("\\d+(\\.\\d+)+");
                return pattern.Match(output.Stdout)?.Value;
            });
        }

        private string BicepVersion => bicepVersionLazy.Value;

        public static bool IsBicepFile(string templateFilePath) =>
            ".bicep".Equals(Path.GetExtension(templateFilePath), StringComparison.OrdinalIgnoreCase);

        public static bool IsBicepparamFile(string parametersFilePath) =>
            ".bicepparam".Equals(Path.GetExtension(parametersFilePath), StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Builds a .bicep file and returns the result as a JSON string.
        /// </summary>
        public string BuildBicepFile(string bicepTemplateFilePath, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            if (!dataStore.FileExists(bicepTemplateFilePath))
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "TemplateFile");
            }

            var stdout = RunBicepCommand(
                $"build {GetQuotedFilePath(bicepTemplateFilePath)} --stdout",
                MinimalVersionRequirement,
                envVars: null,
                writeVerbose: writeVerbose,
                writeWarning: writeWarning);

            return stdout;
        }

        /// <summary>
        /// Builds a .bicepparam file and returns the result.
        /// </summary>
        public BicepBuildParamsStdout BuildBicepParamFile(string bicepParamFilePath, IReadOnlyDictionary<string, object> overrideParams, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            if (!dataStore.FileExists(bicepParamFilePath))
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepparamFilePath, "TemplateParameterFile");
            }

            var envVars = new Dictionary<string, string>();
            if (overrideParams.Any())
            {
                CheckMinimalVersionRequirement(MinimalVersionRequirementForBicepparamFileBuildWithInlineOverrides);
                writeVerbose?.Invoke($"Overriding the following parameters: {string.Join(", ", overrideParams.Keys)}");
                // As per https://github.com/Azure/bicep/issues/12481, secure string parameters must be serialized.
                envVars["BICEP_PARAMETERS_OVERRIDES"] = PSJsonSerializer.Serialize(overrideParams, serializeSecureString: true);
            }

            var stdout = RunBicepCommand(
                $"build-params {GetQuotedFilePath(bicepParamFilePath)} --stdout",
                MinimalVersionRequirementForBicepparamFileBuild,
                envVars: envVars,
                writeVerbose: writeVerbose,
                writeWarning: writeWarning);

            return stdout.FromJson<BicepBuildParamsStdout>();
        }

        public void PublishFile(string bicepFilePath, string target, string documentationUri = null, bool withSource = false, bool force = false, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            if (!dataStore.FileExists(bicepFilePath))
            {
                throw new AzPSArgumentException(Properties.Resources.InvalidBicepFilePath, "File");
            }

            string bicepPublishCommand = $"publish {GetQuotedFilePath(bicepFilePath)} --target {GetQuotedFilePath(target)}";
            if (!string.IsNullOrWhiteSpace(documentationUri))
            {
                CheckMinimalVersionRequirement(MinimalVersionRequirementForBicepPublishWithOptionalDocumentationUriParameter);
                bicepPublishCommand += $" --documentationUri {GetQuotedFilePath(documentationUri)}";
            }

            if (withSource)
            {
                CheckMinimalVersionRequirement(MinimalVersionRequirementForBicepPublishWithOptionalWithSourceParameter);
                bicepPublishCommand += $" --with-source";
            }

            if (force)
            {
                CheckMinimalVersionRequirement(MinimalVersionRequirementForBicepPublishWithOptionalForceParameter);
                bicepPublishCommand += $" --force";
            }
            
            var stdout = RunBicepCommand(
                bicepPublishCommand,
                MinimalVersionRequirementForBicepPublish,
                envVars: null,
                writeVerbose: writeVerbose,
                writeWarning: writeWarning);
        }

        private void CheckBicepExecutable()
        {
            if (BicepVersion == null)
            {
                throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
            }
        }

        private string CheckMinimalVersionRequirement(string minimalVersionRequirement)
        {
            CheckBicepExecutable();

            if (Version.Parse(minimalVersionRequirement).CompareTo(Version.Parse(BicepVersion)) > 0)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionRequirement, minimalVersionRequirement));
            };

            return BicepVersion;
        }

        /// <summary>
        /// Runs a bicep command, and returns stdout as a string.
        /// </summary>
        private string RunBicepCommand(string arguments, string minimalVersionRequirement, Dictionary<string, string> envVars = null, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            string currentBicepVersion = CheckMinimalVersionRequirement(minimalVersionRequirement);
            writeVerbose?.Invoke($"Using Bicep v{currentBicepVersion}");

            writeVerbose?.Invoke($"Calling Bicep with arguments: {arguments}");

            var output = processInvoker.Invoke(new ProcessInput { Executable = BicepExecutable, Arguments = arguments, EnvVars = envVars });

            if (output.ExitCode != 0)
            {
                throw new AzPSApplicationException(output.Stderr);
            }

            // print warning message
            if (!string.IsNullOrWhiteSpace(output.Stderr))
            {
                writeWarning?.Invoke(output.Stderr);
            }

            return output.Stdout;
        }

        private static string GetQuotedFilePath(string filePath)
            => $"\"{filePath.Replace("\"", "\\\"")}\"";        
    }
}