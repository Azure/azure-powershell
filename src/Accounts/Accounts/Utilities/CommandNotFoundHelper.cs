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

        private static CommandInvocationIntrinsics Cii = null;
        private static Regex AzOrAzureRMRegex = new Regex(@"^\w+-az\w+$", RegexOptions.IgnoreCase);
        private static Regex AzureRMRegex = new Regex(@"^\w+-azurerm\w+$", RegexOptions.IgnoreCase);
        private static Lazy<AllCommandInfo> LazyAllCommandInfo = new Lazy<AllCommandInfo>(LoadAllCommandInfo);
        private static Lazy<IDictionary<string, string>> LazyCommandToModuleMappings = new Lazy<IDictionary<string, string>>(() =>
        {
            var moduleToCommandMapping = LazyAllCommandInfo.Value.Modules;
            var mapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var moduleName in moduleToCommandMapping.Keys)
            {
                foreach (var commandName in moduleToCommandMapping[moduleName].Keys)
                {
                    mapping.Add(commandName, moduleName);
                }
            }
            return mapping;
        });

        private static Lazy<IDictionary<string, MigrationDetails>> LazyCommandToMigrationMappings = new Lazy<IDictionary<string, MigrationDetails>>(() =>
        {
            return MakeDictionaryCaseInsensitive(LazyAllCommandInfo.Value.Migration);
        });

        private static Lazy<IDictionary<string, string>> LazyCommandLowercaseToNormal = new Lazy<IDictionary<string, string>>(() =>
        {
            IDictionary<string, string> mapping = new Dictionary<string, string>();
            foreach (var module in LazyAllCommandInfo.Value.Modules.Values)
            {
                foreach (var commandName in module.Keys)
                {
                    mapping.Add(commandName.ToLowerInvariant(), commandName);
                }
            }
            return mapping;
        });

        private static IDictionary<string, T> MakeDictionaryCaseInsensitive<T>(IDictionary<string, T> caseSensitiveMapping)
        {
            var mapping = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in caseSensitiveMapping)
            {
                mapping.Add(pair.Key, pair.Value);
            }
            return mapping;
        }

        private static AllCommandInfo LoadAllCommandInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Microsoft.Azure.Commands.Profile.Utilities.CommandMappings.json";

            // todo: need try-catch? How much does it slow down the method?
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<AllCommandInfo>(reader.ReadToEnd());
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
                    WriteWarning($@"[todo] The command {args.CommandName} is in the AzureRM PowerShell module, which is outdated. See [todo] fwlink https://docs.microsoft.com/en-us/powershell/azure/migrate-from-azurerm-to-az?view=azps-8.1.0 for instructions to migrate to Az.");
                }
                else if (TryGetMigrationGuide(args.CommandName, out MigrationDetails details))
                {
                    // todo: fill in the migration part in CommandMappings.json
                    WriteWarning($@"[todo] The command {args.CommandName} has been deprecated and replaced by {details.Replacement} since {details.Since}. Please refer to the migration guide [todo]");
                }
                else if (TryGetModuleOfCommand(args.CommandName, out string moduleName))
                {
                    WriteWarning($@"[todo] The term {args.CommandName} is a cmdlet belongs to Azure PowerShell module {moduleName} and it is not installed.
Run 'Install-Module {moduleName}' to install it.");
                }
                else if (EnableFuzzyString && TryGetFuzzyStringSuggestions(args.CommandName, out IEnumerable<string> suggestions))
                {
                    WriteWarning(FormatFuzzyStringSuggestions(args.CommandName, suggestions));
                }
            }
            args.StopSearch = false;
        }

        private static string FormatFuzzyStringSuggestions(string commandName, IEnumerable<string> suggestions)
        {
            StringBuilder sb = new StringBuilder($"[todo] {commandName} is not found. The most similar Azure PowerShell commands are:");
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
            // todo: refactor
            var commandNamesInLowercase = LazyCommandLowercaseToNormal.Value.Keys;
            var suggestionsInLowercase = FuzzySharp.Process.ExtractTop(
                commandName.ToLowerInvariant(),
                commandNamesInLowercase,
                processor: s => s, // ExtractTop by default do ToLowercase to every candidate. It's inefficient so we override it and cache a lowercase version of command names array.
                scorer: ScorerCache.Get<DefaultRatioScorer>(),
                cutoff: 80,
                limit: 3)
                .Select(x =>
                {
                    // Console.WriteLine(x.ToString());
                    return x.Value;
                });
            suggestions = suggestionsInLowercase.Select(x => LazyCommandLowercaseToNormal.Value[x]);
            return suggestions.Any();
        }

        private static void WriteWarning(string message)
        {
            Cii.InvokeScript($"Write-Warning \"{message}\"");
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