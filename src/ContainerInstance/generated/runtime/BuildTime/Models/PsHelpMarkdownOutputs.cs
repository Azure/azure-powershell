/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell.PsHelpOutputExtensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell
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
        public MarkdownExampleHelpInfo ExampleInfo { get; }

        public HelpExampleOutput(MarkdownExampleHelpInfo exampleInfo)
        {
            ExampleInfo = exampleInfo;
        }

        public override string ToString() => $@"{ExampleNameHeader}{ExampleInfo.Name}
{ExampleCodeHeader}
{ExampleInfo.Code}
{ExampleCodeFooter}

{ExampleInfo.Description.ToDescriptionFormat()}

";
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

        private static string HelpLinkPrefix { get; } = @"https://docs.microsoft.com/powershell/module/";

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
{HelpInfo.Description.ToDescriptionFormat()}

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

        public static HelpMetadataOutput ToHelpMetadataOutput(this MarkdownHelpInfo helpInfo) => new HelpMetadataOutput(helpInfo);

        public static HelpSyntaxOutput ToHelpSyntaxOutput(this MarkdownSyntaxHelpInfo syntaxInfo, bool hasMultipleParameterSets) => new HelpSyntaxOutput(syntaxInfo, hasMultipleParameterSets);

        public static HelpExampleOutput ToHelpExampleOutput(this MarkdownExampleHelpInfo exampleInfo) => new HelpExampleOutput(exampleInfo);

        public static HelpParameterOutput ToHelpParameterOutput(this MarkdownParameterHelpInfo parameterInfo) => new HelpParameterOutput(parameterInfo);

        public static ModulePageMetadataOutput ToModulePageMetadataOutput(this PsModuleHelpInfo moduleInfo) => new ModulePageMetadataOutput(moduleInfo);

        public static ModulePageCmdletOutput ToModulePageCmdletOutput(this MarkdownHelpInfo helpInfo) => new ModulePageCmdletOutput(helpInfo);
    }
}
