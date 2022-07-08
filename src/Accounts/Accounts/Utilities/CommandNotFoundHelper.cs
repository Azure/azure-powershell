using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class CommandNotFoundHelper
    {
        private static CommandInvocationIntrinsics _cii = null;

        // usage: [Microsoft.Azure.Commands.Profile.Utilities.CommandNotFoundHelper]::RegisterCommandNotFoundAction($ExecutionContext.InvokeCommand)
        public static void RegisterCommandNotFoundAction(CommandInvocationIntrinsics cii)
        {
            _cii = cii;
            cii.CommandNotFoundAction -= OnCmdletNotFound;
            cii.CommandNotFoundAction += OnCmdletNotFound;
        }

        private static void OnCmdletNotFound(object sender, CommandLookupEventArgs args)
        {
            if (new Regex(@"^\w+-az\w+$", RegexOptions.IgnoreCase).IsMatch(args.CommandName))
            {
                if (CmdletToModule.TryGetValue(args.CommandName, out string module))
                {
                    WriteWarning($@"The term {args.CommandName} is a cmdlet belongs to Azure PowerShell module {module} and it is not installed.
Run 'Install-Module {module}' to install it.");
                }
            }
            args.StopSearch = false;
        }

        private static IDictionary<string, string> CmdletToModule = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
            {"Get-AzCommandNotFound", "Az.NotFound"}
        };

        private static ScriptBlock GetWriteWarningScript(string message)
        {
            return ScriptBlock.Create($"Write-Warning \"{message}\"");
        }

        private static void WriteWarning(string message)
        {
            _cii.InvokeScript($"Write-Warning \"{message}\"");
        }
    }
}