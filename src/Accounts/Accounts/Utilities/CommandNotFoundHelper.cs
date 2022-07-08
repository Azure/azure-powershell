using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class CommandNotFoundHelper
    {
        private static CommandInvocationIntrinsics Cii = null;

        private static Lazy<AllCommandInfo> LazyAllCommandInfo = new Lazy<AllCommandInfo>(LoadAllCommandInfo);
        private static Lazy<IDictionary<string, CommandInfo>> LazyCommandMappings = new Lazy<IDictionary<string, CommandInfo>>(() =>
        {
            var caseSensitiveMapping = LazyAllCommandInfo.Value.Commands;
            var mapping = new Dictionary<string, CommandInfo>(StringComparer.CurrentCultureIgnoreCase);
            foreach (var key in caseSensitiveMapping.Keys)
            {
                mapping.Add(key, caseSensitiveMapping[key]);
            }

            return mapping;
        });

        private static AllCommandInfo LoadAllCommandInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Microsoft.Azure.Commands.Profile.Utilities.CommandMappings.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                AllCommandInfo raw = JsonConvert.DeserializeObject<AllCommandInfo>(reader.ReadToEnd());
                return raw;
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
            if (IsAzurePowerShellCommand(args.CommandName))
            {
                if (TryGetModuleOfCommand(args.CommandName, out string moduleName))
                {
                    WriteWarning($@"The term {args.CommandName} is a cmdlet belongs to Azure PowerShell module {moduleName} and it is not installed.
Run 'Install-Module {moduleName}' to install it.");
                }
            }
            args.StopSearch = false;
        }

        private static bool IsAzurePowerShellCommand(string commandName)
        {
            return new Regex(@"^\w+-az\w+$", RegexOptions.IgnoreCase).IsMatch(commandName);
        }

        private static bool TryGetModuleOfCommand(string commandName, out string moduleName)
        {
            if (LazyCommandMappings.Value.TryGetValue(commandName, out var data))
            {
                moduleName = data.Module;
                return true;
            }
            else
            {
                moduleName = null;
                return false;
            }
        }

        private static ScriptBlock GetWriteWarningScript(string message)
        {
            return ScriptBlock.Create($"Write-Warning \"{message}\"");
        }

        private static void WriteWarning(string message)
        {
            Cii.InvokeScript($"Write-Warning \"{message}\"");
        }
    }

    #region JSON models
    public class AllCommandInfo
    {
        [JsonProperty("commands")]
        public IDictionary<string, CommandInfo> Commands { get; set; }
    }

    public class CommandInfo
    {
        [JsonProperty("module")]
        public string Module { get; set; }
    }
    #endregion
}