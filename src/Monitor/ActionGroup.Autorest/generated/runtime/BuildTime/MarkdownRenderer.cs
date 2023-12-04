/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.PowerShell.MarkdownTypesExtensions;
using static Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.PowerShell.PsProxyOutputExtensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.PowerShell
{
    internal static class MarkdownRenderer
    {
        public static void WriteMarkdowns(IEnumerable<VariantGroup> variantGroups, PsModuleHelpInfo moduleHelpInfo, string docsFolder, string examplesFolder, bool AddComplexInterfaceInfo = true)
        {
            Directory.CreateDirectory(docsFolder);
            var markdownInfos = variantGroups.Where(vg => !vg.IsInternal).Select(vg => new MarkdownHelpInfo(vg, examplesFolder)).OrderBy(mhi => mhi.CmdletName).ToArray();

            foreach (var markdownInfo in markdownInfos)
            {
                var sb = new StringBuilder();
                sb.Append(markdownInfo.ToHelpMetadataOutput());
                sb.Append($"# {markdownInfo.CmdletName}{Environment.NewLine}{Environment.NewLine}");
                sb.Append($"## SYNOPSIS{Environment.NewLine}{markdownInfo.Synopsis.ToDescriptionFormat()}{Environment.NewLine}{Environment.NewLine}");

                sb.Append($"## SYNTAX{Environment.NewLine}{Environment.NewLine}");
                var hasMultipleParameterSets = markdownInfo.SyntaxInfos.Length > 1;
                foreach (var syntaxInfo in markdownInfo.SyntaxInfos)
                {
                    sb.Append(syntaxInfo.ToHelpSyntaxOutput(hasMultipleParameterSets));
                }

                sb.Append($"## DESCRIPTION{Environment.NewLine}{markdownInfo.Description.ToDescriptionFormat()}{Environment.NewLine}{Environment.NewLine}");

                sb.Append($"## EXAMPLES{Environment.NewLine}{Environment.NewLine}");
                foreach (var exampleInfo in markdownInfo.Examples)
                {
                    sb.Append(exampleInfo.ToHelpExampleOutput());
                }

                sb.Append($"## PARAMETERS{Environment.NewLine}{Environment.NewLine}");
                foreach (var parameter in markdownInfo.Parameters)
                {
                    sb.Append(parameter.ToHelpParameterOutput());
                }
                if (markdownInfo.SupportsShouldProcess)
                {
                    foreach (var parameter in SupportsShouldProcessParameters)
                    {
                        sb.Append(parameter.ToHelpParameterOutput());
                    }
                }

                sb.Append($"### CommonParameters{Environment.NewLine}This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).{Environment.NewLine}{Environment.NewLine}");

                sb.Append($"## INPUTS{Environment.NewLine}{Environment.NewLine}");
                foreach (var input in markdownInfo.Inputs)
                {
                    sb.Append($"### {input}{Environment.NewLine}{Environment.NewLine}");
                }

                sb.Append($"## OUTPUTS{Environment.NewLine}{Environment.NewLine}");
                foreach (var output in markdownInfo.Outputs)
                {
                    sb.Append($"### {output}{Environment.NewLine}{Environment.NewLine}");
                }

                sb.Append($"## NOTES{Environment.NewLine}{Environment.NewLine}");
                if (markdownInfo.Aliases.Any())
                {
                    sb.Append($"ALIASES{Environment.NewLine}{Environment.NewLine}");
                }
                foreach (var alias in markdownInfo.Aliases)
                {
                    sb.Append($"{alias}{Environment.NewLine}{Environment.NewLine}");
                }

                if (AddComplexInterfaceInfo)
                {
                    if (markdownInfo.ComplexInterfaceInfos.Any())
                    {
                        sb.Append($"{ComplexParameterHeader}{Environment.NewLine}");
                    }
                    foreach (var complexInterfaceInfo in markdownInfo.ComplexInterfaceInfos)
                    {
                        sb.Append($"{complexInterfaceInfo.ToNoteOutput(includeDashes: true, includeBackticks: true)}{Environment.NewLine}{Environment.NewLine}");
                    }

                }

                sb.Append($"## RELATED LINKS{Environment.NewLine}{Environment.NewLine}");
                foreach (var relatedLink in markdownInfo.RelatedLinks)
                {
                    sb.Append($"{relatedLink}{Environment.NewLine}{Environment.NewLine}");
                }

                File.WriteAllText(Path.Combine(docsFolder, $"{markdownInfo.CmdletName}.md"), sb.ToString());
            }

            WriteModulePage(moduleHelpInfo, markdownInfos, docsFolder);
        }

        private static void WriteModulePage(PsModuleHelpInfo moduleInfo, MarkdownHelpInfo[] markdownInfos, string docsFolder)
        {
            var sb = new StringBuilder();
            sb.Append(moduleInfo.ToModulePageMetadataOutput());
            sb.Append($"# {moduleInfo.Name} Module{Environment.NewLine}");
            sb.Append($"## Description{Environment.NewLine}{moduleInfo.Description.ToDescriptionFormat()}{Environment.NewLine}{Environment.NewLine}");

            sb.Append($"## {moduleInfo.Name} Cmdlets{Environment.NewLine}");
            foreach (var markdownInfo in markdownInfos)
            {
                sb.Append(markdownInfo.ToModulePageCmdletOutput());
            }

            File.WriteAllText(Path.Combine(docsFolder, $"{moduleInfo.Name}.md"), sb.ToString());
        }
    }
}
