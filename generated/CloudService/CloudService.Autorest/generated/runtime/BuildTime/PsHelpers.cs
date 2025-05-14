/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Pwsh = System.Management.Automation.PowerShell;

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell
{
    internal static class PsHelpers
    {
        public static IEnumerable<T> RunScript<T>(string script)
            => Pwsh.Create().AddScript(script).Invoke<T>();

        public static void RunScript(string script)
            => RunScript<PSObject>(script);

        public static IEnumerable<T> RunScript<T>(CommandInvocationIntrinsics cii, string script)
            => cii.InvokeScript(script).Select(o => o?.BaseObject).Where(o => o != null).OfType<T>();

        public static void RunScript(CommandInvocationIntrinsics cii, string script)
            => RunScript<PSObject>(cii, script);

        public static IEnumerable<CommandInfo> GetModuleCmdlets(PSCmdlet cmdlet, params string[] modulePaths)
        {
            var getCmdletsCommand = String.Join(" + ", modulePaths.Select(mp => $"(Get-Command -Module (Import-Module '{mp}' -PassThru))"));
            return (cmdlet?.RunScript<CommandInfo>(getCmdletsCommand) ?? RunScript<CommandInfo>(getCmdletsCommand))
                .Where(ci => ci.CommandType != CommandTypes.Alias);
        }

        public static IEnumerable<CommandInfo> GetModuleCmdlets(params string[] modulePaths)
            => GetModuleCmdlets(null, modulePaths);

        public static IEnumerable<FunctionInfo> GetScriptCmdlets(PSCmdlet cmdlet, string scriptFolder)
        {
            // https://stackoverflow.com/a/40969712/294804
            var wrappedFolder = scriptFolder.Contains("'") ? $@"""{scriptFolder}""" : $@"'{scriptFolder}'";
            var getCmdletsCommand = $@"
$currentFunctions = Get-ChildItem function:
Get-ChildItem -Path {wrappedFolder} -Recurse -Include '*.ps1' -File | ForEach-Object {{ . $_.FullName }}
Get-ChildItem function: | Where-Object {{ ($currentFunctions -notcontains $_) -and $_.CmdletBinding }}
";
            return cmdlet?.RunScript<FunctionInfo>(getCmdletsCommand) ?? RunScript<FunctionInfo>(getCmdletsCommand);
        }

        public static IEnumerable<FunctionInfo> GetScriptCmdlets(string scriptFolder)
            => GetScriptCmdlets(null, scriptFolder);

        public static IEnumerable<PSObject> GetScriptHelpInfo(PSCmdlet cmdlet, params string[] modulePaths)
        {
            var importModules = String.Join(Environment.NewLine, modulePaths.Select(mp => $"Import-Module '{mp}'"));
            var getHelpCommand = $@"
$currentFunctions = Get-ChildItem function:
{importModules}
Get-ChildItem function: | Where-Object {{ ($currentFunctions -notcontains $_) -and $_.CmdletBinding }} | ForEach-Object {{ Get-Help -Name $_.Name -Full }}
";
            return cmdlet?.RunScript<PSObject>(getHelpCommand) ?? RunScript<PSObject>(getHelpCommand);
        }

        public static IEnumerable<PSObject> GetScriptHelpInfo(params string[] modulePaths)
            => GetScriptHelpInfo(null, modulePaths);

        public static IEnumerable<CmdletAndHelpInfo> GetModuleCmdletsAndHelpInfo(PSCmdlet cmdlet, params string[] modulePaths)
        {
            var getCmdletAndHelp = String.Join(" + ", modulePaths.Select(mp => 
                    $@"(Get-Command -Module (Import-Module '{mp}' -PassThru) | Where-Object {{ $_.CommandType -ne 'Alias' }} | ForEach-Object {{ @{{ CommandInfo = $_; HelpInfo = ( invoke-command {{ try {{ Get-Help -Name $_.Name -Full }} catch{{ '' }} }} ) }} }})"
            ));
            return (cmdlet?.RunScript<Hashtable>(getCmdletAndHelp) ?? RunScript<Hashtable>(getCmdletAndHelp))
                .Select(h => new CmdletAndHelpInfo { CommandInfo = (h["CommandInfo"] as PSObject)?.BaseObject as CommandInfo, HelpInfo = h["HelpInfo"] as PSObject });
        }

        public static IEnumerable<CmdletAndHelpInfo> GetModuleCmdletsAndHelpInfo(params string[] modulePaths)
            => GetModuleCmdletsAndHelpInfo(null, modulePaths);

        public static CmdletAndHelpInfo ToCmdletAndHelpInfo(this CommandInfo commandInfo, PSObject helpInfo) => new CmdletAndHelpInfo { CommandInfo = commandInfo, HelpInfo = helpInfo };

        public const string Psd1Indent = "  ";
        public const string GuidStart = Psd1Indent + "GUID";

        public static Guid ReadGuidFromPsd1(string psd1Path)
        {
            var guid = Guid.NewGuid();
            if (File.Exists(psd1Path))
            {
                var currentGuid = File.ReadAllLines(psd1Path)
                    .FirstOrDefault(l => l.StartsWith(GuidStart))?.Split(new[] { " = " }, StringSplitOptions.RemoveEmptyEntries)
                    .LastOrDefault()?.Replace("'", String.Empty);
                guid = currentGuid != null ? Guid.Parse(currentGuid) : guid;
            }

            return guid;
        }
    }

    internal class CmdletAndHelpInfo
    {
        public CommandInfo CommandInfo { get; set; }
        public PSObject HelpInfo { get; set; }
    }
}
