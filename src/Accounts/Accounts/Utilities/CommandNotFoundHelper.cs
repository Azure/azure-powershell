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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using FuzzySharp.SimilarityRatio;
using FuzzySharp.SimilarityRatio.Scorer.StrategySensitive;
using Microsoft.Azure.Commands.Profile.Properties;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    /// <summary>
    /// Helper class to provide suggestions when the command is not found.
    /// </summary>
    public static class CommandNotFoundHelper
    {
        public static bool EnableFuzzyString = true;
        private const string dataResourceName = "Microsoft.Azure.Commands.Profile.Utilities.CommandMappings.json";

        private static CommandInvocationIntrinsics Cii = null;
        private static readonly Regex AzOrAzureRMRegex = new Regex(@"^\w+-az\w+$", RegexOptions.IgnoreCase);
        private static readonly Regex AzureRMRegex = new Regex(@"^\w+-azurerm\w+$", RegexOptions.IgnoreCase);
        private static readonly Lazy<AllCommandInfo> LazyAllCommandInfo = new Lazy<AllCommandInfo>(LoadAllCommandInfo);

        /// <summary>
        /// Mappings from command names to their module names.
        /// </summary>
        private static readonly Lazy<IDictionary<string, string>> LazyCommandToModuleMappings = new Lazy<IDictionary<string, string>>(() =>
        {
            var moduleToCommandMappings = LazyAllCommandInfo.Value.Modules;
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var moduleName in moduleToCommandMappings.Keys)
            {
                foreach (var commandName in moduleToCommandMappings[moduleName].Keys)
                {
                    mappings[commandName] = moduleName;
                }
            }
            return mappings;
        });

        /// <summary>
        /// Mappings from command names to their migration guides.
        /// </summary>
        private static readonly Lazy<IDictionary<string, MemoryMigrationDetails>> LazyCommandToMigrationMappings
            = new Lazy<IDictionary<string, MemoryMigrationDetails>>(() =>
            {
                var mappings = new Dictionary<string, MemoryMigrationDetails>(StringComparer.OrdinalIgnoreCase);
                foreach (var pair in LazyAllCommandInfo.Value.Migration)
                {
                    foreach (var migration in pair.Value)
                    {
                        mappings[migration.Key] =
                            new MemoryMigrationDetails() { Replacement = migration.Value.Replacement, Release = pair.Key };
                    }
                }
                return mappings;
            });

        /// <summary>
        /// Mappings from lowercase command names to the original names.
        /// </summary>
        private static readonly Lazy<IDictionary<string, string>> LazyCommandLowercaseToNormal = new Lazy<IDictionary<string, string>>(() =>
        {
            IDictionary<string, string> mappings = new Dictionary<string, string>();
            foreach (var module in LazyAllCommandInfo.Value.Modules.Values)
            {
                foreach (var commandName in module.Keys)
                {
                    mappings[commandName.ToLowerInvariant()] = commandName;
                }
            }
            return mappings;
        });

        private static AllCommandInfo LoadAllCommandInfo()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dataResourceName))
            using (var reader = new StreamReader(stream))
            {
                try
                {
                    return JsonConvert.DeserializeObject<AllCommandInfo>(reader.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading manifest resource {dataResourceName}. Exception: {ex.Message}");
                    return new AllCommandInfo()
                    {
                        Migration = new Dictionary<string, IDictionary<string, MigrationDetails>>(),
                        Modules = new Dictionary<string, IDictionary<string, object>>()
                    };
                }
            }
        }

        /// <summary>
        /// Registers <see cref="CommandInvocationIntrinsics.CommandNotFoundAction" />
        /// to provide suggestions when command when command is not found.
        /// </summary>
        /// <param name="cii">The <see cref="CommandInvocationIntrinsics" /> object where the event is defined.</param>
        /// <remarks>
        /// Usage: [Microsoft.Azure.Commands.Profile.Utilities.CommandNotFoundHelper]::RegisterCommandNotFoundAction($ExecutionContext.InvokeCommand)
        /// </remarks>
        public static void RegisterCommandNotFoundAction(CommandInvocationIntrinsics cii)
        {
            Cii = cii;
            cii.CommandNotFoundAction -= OnCommandNotFound;
            cii.CommandNotFoundAction += OnCommandNotFound;
        }

        private static void OnCommandNotFound(object sender, CommandLookupEventArgs args)
        {
            // The command was dispatched by the msh engine as a result of a dispatch request from an already running command.
            // We are not interested in such cases.
            if (args.CommandOrigin == CommandOrigin.Runspace && IsAzOrAzureRMCmdlet(args.CommandName))
            {
                if (IsAzureRMCommand(args.CommandName))
                {
                    WriteWarning(string.Format(Resources.CommandNotFoundAzureRM, args.CommandName, Resources.AzureRMToAzMigrationGuideLink));
                }
                else if (TryGetMigrationGuide(args.CommandName, out MemoryMigrationDetails details))
                {
                    WriteWarning(FormatCommandDeprecationMessage(args.CommandName, details));
                }
                else if (TryGetModuleOfCommand(args.CommandName, out string moduleName))
                {
                    WriteWarning(string.Format(Resources.CommandNotFoundModuleNotInstalled, args.CommandName, moduleName));
                }
                else if (EnableFuzzyString && TryGetFuzzyStringSuggestions(args.CommandName, out IEnumerable<string> suggestions))
                {
                    WriteWarning(FormatFuzzyStringMessage(args.CommandName, suggestions));
                }
            }
            args.StopSearch = false;
        }

        private static bool IsAzOrAzureRMCmdlet(string commandName)
        {
            return AzOrAzureRMRegex.IsMatch(commandName);
        }

        private static bool IsAzureRMCommand(string commandName)
        {
            return AzureRMRegex.IsMatch(commandName);
        }

        private static bool TryGetMigrationGuide(string commandName, out MemoryMigrationDetails details)
        {
            return LazyCommandToMigrationMappings.Value.TryGetValue(commandName, out details);
        }

        private static string FormatCommandDeprecationMessage(string commandName, MemoryMigrationDetails details)
        {
            string message;
            if (string.IsNullOrEmpty(details.Replacement))
            {
                message = string.Format(Resources.CommandNotFoundDeprecated, commandName, details.Release);
            }
            else
            {
                message = string.Format(Resources.CommandNotFoundReplaced, commandName, details.Replacement, details.Release);
            }
            if (TryGetExternalLinkToMigrationGuide(details.Release, out string link))
            {

                message += " " + string.Format(Resources.SeeMigrationGuide, link);
            }
            return message;
        }

        private static bool TryGetExternalLinkToMigrationGuide(string release, out string link)
        {
            link = null;
            if (!string.IsNullOrEmpty(release))
            {
                // if release is like "Az x.x.x", we can provide a link to migration guide
                var match = new Regex(@"^Az\s*(\d+\.\d+\.\d+)$", RegexOptions.IgnoreCase).Match(release);
                if (match.Success && match.Groups.Count >= 2)
                {
                    // as of today fwlink does not support parameters
                    // if it will, we can have more accurate links to specific releases
                    link = "https://go.microsoft.com/fwlink/?linkid=2201860";
                }
            }
            return !string.IsNullOrEmpty(link);
        }

        private static bool TryGetModuleOfCommand(string commandName, out string moduleName)
        {
            return LazyCommandToModuleMappings.Value.TryGetValue(commandName, out moduleName);
        }

        private static bool TryGetFuzzyStringSuggestions(string commandName, out IEnumerable<string> suggestions)
        {
            var suggestionsInLowercase = FuzzySharp.Process.ExtractTop(
                commandName.ToLowerInvariant(),
                LazyCommandLowercaseToNormal.Value.Keys,
                processor: s => s, // ExtractTop by default converts strings to lowercase.
                                   // It's redundant work so we override the behavior and cache lowercase command names.
                scorer: ScorerCache.Get<DefaultRatioScorer>(),
                cutoff: 90);
            suggestions = suggestionsInLowercase.Select(x => LazyCommandLowercaseToNormal.Value[x.Value]);
            return suggestions.Any();
        }

        private static string FormatFuzzyStringMessage(string commandName, IEnumerable<string> suggestions)
        {
            StringBuilder sb = new StringBuilder();
            if (suggestions.Count() > 1)
            {
                sb.Append(string.Format(Resources.CommandNotFoundFuzzyStringPlural, commandName));
            }
            else
            {
                sb.Append(string.Format(Resources.CommandNotFoundFuzzyStringSingle, commandName));
            }
            foreach (var suggestion in suggestions)
            {
                sb.Append(Environment.NewLine);
                sb.Append("\t");
                sb.Append(suggestion);
            }
            string message = sb.ToString();
            return message;
        }

        private static void WriteWarning(string message)
        {
            Cii.InvokeScript($"Write-Warning '{message}'");
        }
    }

    #region in-memory models
    internal class MemoryMigrationDetails
    {
        /// <summary>
        /// If not null, another command to replace the deprecated command.
        /// </summary>
        public string Replacement { get; set; }
        /// <summary>
        /// The release of Az or module when the command was deprecated.
        /// </summary>
        /// <value></value>
        public string Release { get; set; }
    }
    #endregion

    #region JSON models
    public class AllCommandInfo
    {
        /// <summary>
        /// Dictionary of modules. Key is the name of the module.
        /// </summary>
        /// <value>
        /// Dictionary of commands (cmdlet, function, alias), whose key is the name of the command,
        /// value is an empty object for now.
        /// </value>
        [JsonProperty("modules")]
        public IDictionary<string, IDictionary<string, object>> Modules { get; set; }

        /// <summary>
        /// Dictionary of cmdlet deprecation/migration.
        /// Key is the release of Az or module when the command was deprecated.
        /// </summary>
        /// <value>
        /// Dictionary from commands to <see cref="MigrationDetails" /> objects describing the deprecation/migration.
        /// </value>
        [JsonProperty("migration")]
        public IDictionary<string, IDictionary<string, MigrationDetails>> Migration { get; set; }
    }

    public class MigrationDetails
    {
        /// <summary>
        /// If not null, another command to replace the deprecated command.
        /// </summary>
        [JsonProperty("replacement")]
        public string Replacement { get; set; }
    }
    #endregion
}
