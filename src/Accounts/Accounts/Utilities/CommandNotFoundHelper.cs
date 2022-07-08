using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    /// <summary>
    /// Helper class to provide suggestions when the command is not found.
    /// </summary>
    public static class CommandNotFoundHelper
    {
        private static CommandInvocationIntrinsics Cii = null;
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
            return LazyCommandToModuleMappings.Value.TryGetValue(commandName, out moduleName);
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
        /// <summary>
        /// Dictionary of modules. Key is the name of the module.
        /// </summary>
        /// <value>
        /// Dictionary of commands (cmdlet, function, alias), whose key is the name of the command, value is empty for now.
        /// </value>
        [JsonProperty("modules")]
        public IDictionary<string, IDictionary<string, object>> Modules { get; set; }
    }
    #endregion
}