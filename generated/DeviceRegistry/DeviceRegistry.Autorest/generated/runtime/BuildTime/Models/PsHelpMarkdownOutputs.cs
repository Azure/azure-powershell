/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell.PsHelpOutputExtensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell
{
    internal class HelpMetadataOutput
    {
        public MarkdownHelpInfo HelpInfo { get; }

        public HelpMetadataOutput(MarkdownHelpInfo helpInfo)
        {
            HelpInfo = helpInfo;
        }

        public override string ToString() => $@"---
external help file:{(!String.IsNullOrEmpty(HelpInfo.ExternalHelpFilename) ? $" {HelpInfo.ExternalHelpFilename}" : String.Empty)}
Module Name: {HelpInfo.ModuleName}
online version: {HelpInfo.OnlineVersion}
schema: {HelpInfo.Schema.ToString(3)}
---

";
    }

    internal class HelpSyntaxOutput
    {
        public MarkdownSyntaxHelpInfo SyntaxInfo { get; }
        public bool HasMultipleParameterSets { get; }

        public HelpSyntaxOutput(MarkdownSyntaxHelpInfo syntaxInfo, bool hasMultipleParameterSets)
        {
            SyntaxInfo = syntaxInfo;
            HasMultipleParameterSets = hasMultipleParameterSets;
        }

        public override string ToString()
        {
            var psnText = HasMultipleParameterSets ? $"### {SyntaxInfo.ParameterSetName}{(SyntaxInfo.IsDefault ? " (Default)" : String.Empty)}{Environment.NewLine}" : String.Empty;
            return $@"{psnText}```
{SyntaxInfo.SyntaxText}
```

";
        }
    }

    internal class HelpExampleOutput
    {
        private string ExampleTemplate =
            "{0}{1}" + Environment.NewLine +
            "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine + Environment.NewLine +
            "{5}" + Environment.NewLine + Environment.NewLine;

        private string ExampleTemplateWithOutput =
             "{0}{1}" + Environment.NewLine +
            "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine + Environment.NewLine +
            "{5}" + Environment.NewLine + "{6}" + Environment.NewLine + "{7}" + Environment.NewLine + Environment.NewLine +
            "{8}" + Environment.NewLine + Environment.NewLine;

        public MarkdownExampleHelpInfo ExampleInfo { get; }

        public HelpExampleOutput(MarkdownExampleHelpInfo exampleInfo)
        {
            ExampleInfo = exampleInfo;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ExampleInfo.Output))
            {
                return string.Format(ExampleTemplate, 
                    ExampleNameHeader, ExampleInfo.Name, 
                    ExampleCodeHeader, ExampleInfo.Code, ExampleCodeFooter, 
                    ExampleInfo.Description.ToDescriptionFormat());
            }
            else
            {
                return string.Format(ExampleTemplateWithOutput,
                    ExampleNameHeader, ExampleInfo.Name,
                    ExampleCodeHeader, ExampleInfo.Code, ExampleCodeFooter, 
                    ExampleOutputHeader, ExampleInfo.Output, ExampleOutputFooter,
                    ExampleInfo.Description.ToDescriptionFormat()); ;
            }
        }
    }
    
    internal class HelpParameterOutput
    {
        public MarkdownParameterHelpInfo ParameterInfo { get; }

        public HelpParameterOutput(MarkdownParameterHelpInfo parameterInfo)
        {
            ParameterInfo = parameterInfo;
        }

        public override string ToString()
        {
            var pipelineInputTypes = new[]
            {
                ParameterInfo.AcceptsPipelineByValue ? "ByValue" : String.Empty,
                ParameterInfo.AcceptsPipelineByPropertyName ? "ByPropertyName" : String.Empty
            }.JoinIgnoreEmpty(", ");
            var pipelineInput = ParameterInfo.AcceptsPipelineByValue || ParameterInfo.AcceptsPipelineByPropertyName
                ? $@"{true} ({pipelineInputTypes})"
                : false.ToString();

            return $@"### -{ParameterInfo.Name}
{ParameterInfo.Description.ToDescriptionFormat()}

```yaml
Type: {ParameterInfo.Type.FullName}
Parameter Sets: {(ParameterInfo.HasAllParameterSets ? "(All)" : ParameterInfo.ParameterSetNames.JoinIgnoreEmpty(", "))}
Aliases:{(ParameterInfo.Aliases.Any() ? $" {ParameterInfo.Aliases.JoinIgnoreEmpty(", ")}" : String.Empty)}

Required: {ParameterInfo.IsRequired}
Position: {ParameterInfo.Position}
Default value: {ParameterInfo.DefaultValue}
Accept pipeline input: {pipelineInput}
Accept wildcard characters: {ParameterInfo.AcceptsWildcardCharacters}
```

";
        }
    }

    internal class ModulePageMetadataOutput
    {
        public PsModuleHelpInfo ModuleInfo { get; }

        private static string HelpLinkPrefix { get; } = @"https://learn.microsoft.com/powershell/module/";

        public ModulePageMetadataOutput(PsModuleHelpInfo moduleInfo)
        {
            ModuleInfo = moduleInfo;
        }

        public override string ToString() => $@"---
Module Name: {ModuleInfo.Name}
Module Guid: {ModuleInfo.Guid}
Download Help Link: {HelpLinkPrefix}{ModuleInfo.Name.ToLowerInvariant()}
Help Version: 1.0.0.0
Locale: en-US
---

";
    }

    internal class ModulePageCmdletOutput
    {
        public MarkdownHelpInfo HelpInfo { get; }

        public ModulePageCmdletOutput(MarkdownHelpInfo helpInfo)
        {
            HelpInfo = helpInfo;
        }

        public override string ToString() => $@"### [{HelpInfo.CmdletName}]({HelpInfo.CmdletName}.md)
{HelpInfo.Synopsis.ToDescriptionFormat()}

";
    }

    internal static class PsHelpOutputExtensions
    {
        public static string EscapeAngleBrackets(this string text) => text?.Replace("<", @"\<").Replace(">", @"\>");
        public static string ReplaceSentenceEndWithNewline(this string text) => text?.Replace(".  ", $".{Environment.NewLine}").Replace(". ", $".{Environment.NewLine}");
        public static string ReplaceBrWithNewline(this string text) => text?.Replace("<br>", $"{Environment.NewLine}");
        public static string ToDescriptionFormat(this string text, bool escapeAngleBrackets = true)
        {
            var description = text?.ReplaceBrWithNewline();
            description = escapeAngleBrackets ? description?.EscapeAngleBrackets() : description;
            return description?.ReplaceSentenceEndWithNewline().Trim();
        }

        public const string ExampleNameHeader = "### ";
        public const string ExampleCodeHeader = "```powershell";
        public const string ExampleCodeFooter = "```";
        public const string ExampleOutputHeader = "```output";
        public const string ExampleOutputFooter = "```";

        public static HelpMetadataOutput ToHelpMetadataOutput(this MarkdownHelpInfo helpInfo) => new HelpMetadataOutput(helpInfo);

        public static HelpSyntaxOutput ToHelpSyntaxOutput(this MarkdownSyntaxHelpInfo syntaxInfo, bool hasMultipleParameterSets) => new HelpSyntaxOutput(syntaxInfo, hasMultipleParameterSets);

        public static HelpExampleOutput ToHelpExampleOutput(this MarkdownExampleHelpInfo exampleInfo) => new HelpExampleOutput(exampleInfo);

        public static HelpParameterOutput ToHelpParameterOutput(this MarkdownParameterHelpInfo parameterInfo) => new HelpParameterOutput(parameterInfo);

        public static ModulePageMetadataOutput ToModulePageMetadataOutput(this PsModuleHelpInfo moduleInfo) => new ModulePageMetadataOutput(moduleInfo);

        public static ModulePageCmdletOutput ToModulePageCmdletOutput(this MarkdownHelpInfo helpInfo) => new ModulePageCmdletOutput(helpInfo);
    }
}
