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
                    mappings.Add(commandName, moduleName);
                }
            }
            return mappings;
        });

        /// <summary>
        /// Mappings from command names to their migration guides.
        /// </summary>
        private static readonly Lazy<IDictionary<string, MigrationDetails>> LazyCommandToMigrationMappings = new Lazy<IDictionary<string, MigrationDetails>>(() =>
        {
            var mappings = new Dictionary<string, MigrationDetails>(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in LazyAllCommandInfo.Value.Migration)
            {
                mappings.Add(pair.Key, pair.Value);
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
                    mappings.Add(commandName.ToLowerInvariant(), commandName);
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
                        Migration = new Dictionary<string, MigrationDetails>(),
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
            if (IsAzOrAzureRMCmdlet(args.CommandName))
            {
                if (IsAzureRMCommand(args.CommandName))
                {
                    WriteWarning($"[todo] The command {args.CommandName} is in the AzureRM PowerShell module, which is outdated."
                        + " See [todo: fwlink] https://docs.microsoft.com/en-us/powershell/azure/migrate-from-azurerm-to-az?view=azps-8.1.0 for instructions to migrate to Az.");
                }
                else if (TryGetMigrationGuide(args.CommandName, out MigrationDetails details))
                {
                    // todo: fill in the migration part in CommandMappings.json
                    WriteWarning($"[todo] The command {args.CommandName} has been deprecated and replaced by {details.Replacement} since {details.Since}."
                        + " Please refer to the migration guide [todo]");
                }
                else if (TryGetModuleOfCommand(args.CommandName, out string moduleName))
                {
                    WriteWarning($"[todo] The command {args.CommandName} is part of Azure PowerShell module \"{moduleName}\" and it is not installed."
                        + $" Run \"Install-Module {moduleName}\" to install it.");
                }
                else if (EnableFuzzyString && TryGetFuzzyStringSuggestions(args.CommandName, out IEnumerable<string> suggestions))
                {
                    WriteWarning(FormatFuzzyStringSuggestions(args.CommandName, suggestions));
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


        private static bool TryGetMigrationGuide(string commandName, out MigrationDetails details)
        {
            return LazyCommandToMigrationMappings.Value.TryGetValue(commandName, out details);
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

        private static string FormatFuzzyStringSuggestions(string commandName, IEnumerable<string> suggestions)
        {
            StringBuilder sb = new StringBuilder($"[todo] {commandName} is not found. ");
            if (suggestions.Count() > 1)
            {
                sb.Append("The most similar Azure PowerShell commands are:");
            }
            else
            {
                sb.Append("The most similar Azure PowerShell command is:");
            }
            sb.Append(Environment.NewLine);
            foreach (var suggestion in suggestions)
            {
                sb.Append("\t");
                sb.Append(suggestion);
                sb.Append(Environment.NewLine);
            }
            string message = sb.ToString();
            return message;
        }

        private static void WriteWarning(string message)
        {
            Cii.InvokeScript($"Write-Warning '{message}'");
        }
    }

    #region JSON models
    public class AllCommandInfo
    {
        /// <summary>
        /// Dictionary of modules. Key is the name of the module.
        /// </summary>
        /// <value>
        /// Dictionary of commands (cmdlet, function, alias), whose key is the name of the command, value is empty for now.
        /// </value>
        [JsonProperty("modules")]
        public IDictionary<string, IDictionary<string, object>> Modules { get; set; }

        /// <summary>
        /// Dictionary of cmdlet deprecation and migration between Az releases.
        /// Key is the name of the command being deprecated.
        /// </summary>
        /// <value>
        /// A <see cref="MigrationDetails" /> object describing the migration.
        /// </value>
        [JsonProperty("migration")]
        public IDictionary<string, MigrationDetails> Migration { get; set; }
    }

    public class MigrationDetails
    {
        [JsonProperty("replacement")]
        public string Replacement { get; set; }
        [JsonProperty("since")]
        public string Since { get; set; }
    }
    #endregion
}