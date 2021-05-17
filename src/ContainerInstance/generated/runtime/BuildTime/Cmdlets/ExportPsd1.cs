/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell
{
    [Cmdlet(VerbsData.Export, "Psd1")]
    [DoNotExport]
    public class ExportPsd1 : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ExportsFolder { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomFolder { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Psd1Path { get; set; }

        [Parameter(Mandatory = true)]
        public Guid ModuleGuid { get; set; }

        private static readonly bool IsAzure = Convert.ToBoolean(@"true");
        private const string CustomFolderRelative = "./custom";
        private const string Indent = Psd1Indent;
        private const string Undefined = "undefined";
        private bool IsUndefined(string value) => string.Equals(Undefined, value, StringComparison.OrdinalIgnoreCase);

        protected override void ProcessRecord()
        {
            try
            {
                if (!Directory.Exists(ExportsFolder))
                {
                    throw new ArgumentException($"Exports folder '{ExportsFolder}' does not exist");
                }

                if (!Directory.Exists(CustomFolder))
                {
                    throw new ArgumentException($"Custom folder '{CustomFolder}' does not exist");
                }

                string version = Convert.ToString(@"1.0.3");
                // Validate the module version should be semantic version
                // Following regex is official from https://semver.org/
                Regex rx = new Regex(@"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$", RegexOptions.Compiled);
                if (rx.Matches(version).Count != 1)
                {
                    throw new ArgumentException("Module-version is not a valid Semantic Version");
                }

                string previewVersion = null;
                if (version.Contains('-'))
                {
                    string[] versions = version.Split("-".ToCharArray(), 2);
                    version = versions[0];
                    previewVersion = versions[1];
                }

                var sb = new StringBuilder();
                sb.AppendLine("@{");
                sb.AppendLine($@"{GuidStart} = '{ModuleGuid}'");
                sb.AppendLine($@"{Indent}RootModule = '{"./Az.ContainerInstance.psm1"}'");
                sb.AppendLine($@"{Indent}ModuleVersion = '{version}'");
                sb.AppendLine($@"{Indent}CompatiblePSEditions = 'Core', 'Desktop'");
                sb.AppendLine($@"{Indent}Author = '{"Microsoft Corporation"}'");
                sb.AppendLine($@"{Indent}CompanyName = '{"Microsoft Corporation"}'");
                sb.AppendLine($@"{Indent}Copyright = '{"Microsoft Corporation. All rights reserved."}'");
                sb.AppendLine($@"{Indent}Description = '{"Microsoft Azure PowerShell: ContainerInstance cmdlets"}'");
                sb.AppendLine($@"{Indent}PowerShellVersion = '5.1'");
                sb.AppendLine($@"{Indent}DotNetFrameworkVersion = '4.7.2'");

                // RequiredModules
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}RequiredModules = @({"undefined"})");
                }

                // RequiredAssemblies
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}RequiredAssemblies = @({"undefined"})");
                }
                else
                {
                    sb.AppendLine($@"{Indent}RequiredAssemblies = '{"./bin/Az.ContainerInstance.private.dll"}'");
                }

                // NestedModules
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}NestedModules = @({"undefined"})");
                }

                // FormatsToProcess
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}FormatsToProcess = @({"undefined"})");
                }
                else
                {
                    var customFormatPs1xmlFiles = Directory.GetFiles(CustomFolder)
                        .Where(f => f.EndsWith(".format.ps1xml"))
                        .Select(f => $"{CustomFolderRelative}/{Path.GetFileName(f)}");
                    var formatList = customFormatPs1xmlFiles.Prepend("./Az.ContainerInstance.format.ps1xml").ToPsList();
                    sb.AppendLine($@"{Indent}FormatsToProcess = {formatList}");
                }

                // TypesToProcess
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}TypesToProcess = @({"undefined"})");
                }

                // ScriptsToProcess
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}ScriptsToProcess = @({"undefined"})");
                }

                var functionInfos = GetScriptCmdlets(ExportsFolder).ToArray();
                // FunctionsToExport
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}FunctionsToExport = @({"undefined"})");
                }
                else
                {
                    var cmdletsList = functionInfos.Select(fi => fi.Name).Distinct().Append("*").ToPsList();
                    sb.AppendLine($@"{Indent}FunctionsToExport = {cmdletsList}");
                }

                // AliasesToExport
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}AliasesToExport = @({"undefined"})");
                }
                else
                {
                    var aliasesList = functionInfos.SelectMany(fi => fi.ScriptBlock.Attributes).ToAliasNames().Append("*").ToPsList();
                    sb.AppendLine($@"{Indent}AliasesToExport = {aliasesList}");
                }

                // CmdletsToExport
                if (!IsUndefined("undefined"))
                {
                    sb.AppendLine($@"{Indent}CmdletsToExport = @({"undefined"})");
                }

                sb.AppendLine($@"{Indent}PrivateData = @{{");
                sb.AppendLine($@"{Indent}{Indent}PSData = @{{");

                if (previewVersion != null)
                {
                    sb.AppendLine($@"{Indent}{Indent}{Indent}Prerelease = {previewVersion}");
                }
                sb.AppendLine($@"{Indent}{Indent}{Indent}Tags = {"Azure ResourceManager ARM PSModule ContainerInstance".Split(' ').ToPsList().NullIfEmpty() ?? "''"}");
                sb.AppendLine($@"{Indent}{Indent}{Indent}LicenseUri = '{"https://aka.ms/azps-license"}'");
                sb.AppendLine($@"{Indent}{Indent}{Indent}ProjectUri = '{"https://github.com/Azure/azure-powershell"}'");
                sb.AppendLine($@"{Indent}{Indent}{Indent}ReleaseNotes = ''");
                var profilesList = "";
                if (IsAzure && !String.IsNullOrEmpty(profilesList))
                {
                    sb.AppendLine($@"{Indent}{Indent}{Indent}Profiles = {profilesList}");
                }

                sb.AppendLine($@"{Indent}{Indent}}}");
                sb.AppendLine($@"{Indent}}}");
                sb.AppendLine(@"}");

                File.WriteAllText(Psd1Path, sb.ToString());
            }
            catch (Exception ee)
            {
                Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
                throw ee;
            }
        }
    }
}
