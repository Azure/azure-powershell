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

        private const string MinimalVersionRequirementForBicepPublishWithNewDocumentationUriParameter = "0.24.24";

        public delegate void OutputCallback(string msg);

        private static readonly Regex VersionNumberPattern = new Regex("\\d+(\\.\\d+)+");

        private readonly IProcessInvoker processInvoker;
        private readonly IDataStore dataStore;
        private BicepInstaller bicepInstaller;
        private BicepConfigResolver configResolver;
        private string resolvedBicepExecutable;
        private string resolvedBicepVersion;

        public BicepUtility(IProcessInvoker processInvoker, IDataStore dataStore, BicepInstaller bicepInstaller = null, BicepConfigResolver configResolver = null)
        {
            this.processInvoker = processInvoker;
            this.dataStore = dataStore;
            this.bicepInstaller = bicepInstaller;
            this.configResolver = configResolver;
        }

        /// <summary>
        /// Lazily creates the default BicepInstaller only if one wasn't supplied.
        /// </summary>
        private BicepInstaller BicepInstaller
        {
            get
            {
                if (bicepInstaller == null)
                {
                    bicepInstaller = BicepInstaller.Create();
                }

                return bicepInstaller;
            }
        }

        /// <summary>
        /// Lazily creates the default BicepConfigResolver only if one wasn't supplied.
        /// </summary>
        private BicepConfigResolver ConfigResolver
        {
            get
            {
                if (configResolver == null)
                {
                    // Reuse the same IDataStore this BicepUtility was constructed with (rather than
                    // BicepConfigResolver.Create()'s own default), so that tests supplying a mock
                    // dataStore see consistent, isolated behavior for bicepconfig.json lookups.
                    configResolver = new BicepConfigResolver(dataStore);
                }

                return configResolver;
            }
        }

        /// <summary>
        /// Resolves the effective 'bicep.version' constraint (if any) that applies to the given
        /// entrypoint file, by locating the nearest bicepconfig.json and parsing its value.
        /// Returns null if no bicepconfig.json applies, or none in its 'extends' chain specifies
        /// a 'bicep.version'.
        /// </summary>
        private BicepVersionConstraint ResolveVersionConstraint(string entrypointFilePath)
        {
            if (string.IsNullOrEmpty(entrypointFilePath))
            {
                return null;
            }

            var configFilePath = ConfigResolver.FindNearestConfigFile(entrypointFilePath);
            if (configFilePath == null)
            {
                return null;
            }

            var raw = ConfigResolver.ResolveVersionConstraint(configFilePath);
            return raw == null ? null : BicepVersionConstraint.Parse(raw, configFilePath);
        }

        /// <summary>
        /// Resolves the path to a working Bicep executable for the given entrypoint file.
        /// </summary>
        /// <remarks>
        /// When no 'bicep.version' constraint applies, the system PATH is used if available,
        /// otherwise Bicep is automatically downloaded and installed. When a constraint does
        /// apply (from the nearest bicepconfig.json), the PATH executable is only used if its
        /// own version satisfies the constraint; otherwise a matching version is resolved from
        /// the managed, version-specific cache (downloading it first if necessary), leaving the
        /// PATH installation untouched.
        /// </remarks>
        private string ResolveBicepExecutablePath(string entrypointFilePath, OutputCallback writeVerbose = null)
        {
            if (resolvedBicepExecutable != null)
            {
                return resolvedBicepExecutable;
            }

            var constraint = ResolveVersionConstraint(entrypointFilePath);
            var pathExecutableExists = processInvoker.CheckExecutableExists(BicepExecutable);

            if (constraint == null)
            {
                if (pathExecutableExists)
                {
                    resolvedBicepExecutable = BicepExecutable;
                    return resolvedBicepExecutable;
                }

                resolvedBicepExecutable = BicepInstaller.EnsureInstalled(writeVerbose);
                return resolvedBicepExecutable;
            }

            if (pathExecutableExists && PathExecutableSatisfiesConstraint(constraint))
            {
                resolvedBicepExecutable = BicepExecutable;
                return resolvedBicepExecutable;
            }

            if (pathExecutableExists)
            {
                writeVerbose?.Invoke(string.Format(Properties.Resources.BicepVersionPinIgnoringPathExecutable, constraint));
            }

            resolvedBicepExecutable = BicepInstaller.EnsureInstalled(constraint, writeVerbose);
            return resolvedBicepExecutable;
        }

        /// <summary>
        /// Checks whether the Bicep executable currently on the PATH satisfies the given
        /// 'bicep.version' constraint, by invoking "bicep -v" and parsing its output.
        /// </summary>
        private bool PathExecutableSatisfiesConstraint(BicepVersionConstraint constraint)
        {
            var output = processInvoker.Invoke(new ProcessInput { Executable = BicepExecutable, Arguments = "-v" });
            var match = VersionNumberPattern.Match(output.Stdout ?? string.Empty);

            BicepSemanticVersion pathVersion;
            if (!match.Success || !BicepSemanticVersion.TryParse(match.Value, out pathVersion) || !constraint.IsSatisfiedBy(pathVersion))
            {
                return false;
            }

            // We've already invoked "bicep -v" and parsed its version above; cache it here so that
            // ResolveBicepVersion doesn't need to invoke the same command again to get the same answer.
            resolvedBicepVersion = match.Value;
            return true;
        }

        private string ResolveBicepVersion(string entrypointFilePath, OutputCallback writeVerbose = null)
        {
            if (resolvedBicepVersion != null)
            {
                return resolvedBicepVersion;
            }

            var executablePath = ResolveBicepExecutablePath(entrypointFilePath, writeVerbose);
            if (executablePath == null)
            {
                return null;
            }

            // ResolveBicepExecutablePath may already have resolved (and cached) the version as a side effect,
            // e.g. via PathExecutableSatisfiesConstraint when a 'bicep.version' constraint applies and the PATH
            // executable satisfies it. Reuse it instead of invoking "bicep -v" again for the same answer.
            if (resolvedBicepVersion != null)
            {
                return resolvedBicepVersion;
            }

            var output = processInvoker.Invoke(new ProcessInput { Executable = executablePath, Arguments = "-v" });

            resolvedBicepVersion = VersionNumberPattern.Match(output.Stdout)?.Value;
            return resolvedBicepVersion;
        }

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
                bicepTemplateFilePath,
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
                CheckMinimalVersionRequirement(bicepParamFilePath, MinimalVersionRequirementForBicepparamFileBuildWithInlineOverrides, writeVerbose);
                writeVerbose?.Invoke($"Overriding the following parameters: {string.Join(", ", overrideParams.Keys)}");
                // As per https://github.com/Azure/bicep/issues/12481, secure string parameters must be serialized.
                envVars["BICEP_PARAMETERS_OVERRIDES"] = PSJsonSerializer.Serialize(overrideParams, serializeSecureString: true);
            }

            var stdout = RunBicepCommand(
                bicepParamFilePath,
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
                CheckMinimalVersionRequirement(bicepFilePath, MinimalVersionRequirementForBicepPublishWithOptionalDocumentationUriParameter, writeVerbose);

                if (IsBicepMinimalVersion(MinimalVersionRequirementForBicepPublishWithNewDocumentationUriParameter)) {
                    bicepPublishCommand += $" --documentation-uri {GetQuotedFilePath(documentationUri)}";
                } else {
                    bicepPublishCommand += $" --documentationUri {GetQuotedFilePath(documentationUri)}";
                }
            }

            if (withSource)
            {
                CheckMinimalVersionRequirement(bicepFilePath, MinimalVersionRequirementForBicepPublishWithOptionalWithSourceParameter, writeVerbose);
                bicepPublishCommand += $" --with-source";
            }

            if (force)
            {
                CheckMinimalVersionRequirement(bicepFilePath, MinimalVersionRequirementForBicepPublishWithOptionalForceParameter, writeVerbose);
                bicepPublishCommand += $" --force";
            }
            
            var stdout = RunBicepCommand(
                bicepFilePath,
                bicepPublishCommand,
                MinimalVersionRequirementForBicepPublish,
                envVars: null,
                writeVerbose: writeVerbose,
                writeWarning: writeWarning);
        }

        private void CheckBicepExecutable(string entrypointFilePath, OutputCallback writeVerbose = null)
        {
            if (ResolveBicepVersion(entrypointFilePath, writeVerbose) == null)
            {
                throw new AzPSApplicationException(Properties.Resources.BicepNotFound);
            }
        }

        private string CheckMinimalVersionRequirement(string entrypointFilePath, string minimalVersionRequirement, OutputCallback writeVerbose = null)
        {
            CheckBicepExecutable(entrypointFilePath, writeVerbose);

            if (Version.Parse(minimalVersionRequirement).CompareTo(Version.Parse(resolvedBicepVersion)) > 0)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionRequirement, minimalVersionRequirement));
            };

            return resolvedBicepVersion;
        }

        private bool IsBicepMinimalVersion(string minimalVersionRequirement) =>
            Version.Parse(minimalVersionRequirement).CompareTo(Version.Parse(resolvedBicepVersion)) > 0;

        /// <summary>
        /// Runs a bicep command, and returns stdout as a string.
        /// </summary>
        private string RunBicepCommand(string entrypointFilePath, string arguments, string minimalVersionRequirement, Dictionary<string, string> envVars = null, OutputCallback writeVerbose = null, OutputCallback writeWarning = null)
        {
            string currentBicepVersion = CheckMinimalVersionRequirement(entrypointFilePath, minimalVersionRequirement, writeVerbose);
            writeVerbose?.Invoke($"Using Bicep v{currentBicepVersion}");

            writeVerbose?.Invoke($"Calling Bicep with arguments: {arguments}");

            var output = processInvoker.Invoke(new ProcessInput { Executable = resolvedBicepExecutable, Arguments = arguments, EnvVars = envVars });

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
