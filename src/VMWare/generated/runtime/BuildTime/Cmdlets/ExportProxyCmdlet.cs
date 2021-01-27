/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell.PsHelpers;
using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell.MarkdownRenderer;
using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell.PsProxyTypeExtensions;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell
{
    [Cmdlet(VerbsData.Export, "ProxyCmdlet", DefaultParameterSetName = "Docs")]
    [DoNotExport]
    public class ExportProxyCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ModuleName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string[] ModulePath { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ExportsFolder { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string InternalFolder { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Docs")]
        [AllowEmptyString]
        public string ModuleDescription { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Docs")]
        [ValidateNotNullOrEmpty]
        public string DocsFolder { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ExamplesFolder { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Docs")]
        public Guid ModuleGuid { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "NoDocs")]
        public SwitchParameter ExcludeDocs { get; set; }

        protected override void ProcessRecord()
        {
          try {
            var variants = GetModuleCmdletsAndHelpInfo(this, ModulePath).SelectMany(ci => ci.ToVariants()).Where(v => !v.IsDoNotExport).ToArray();
            var allProfiles = variants.SelectMany(v => v.Profiles).Distinct().ToArray();
            var profileGroups = allProfiles.Any()
                ? variants
                    .SelectMany(v => (v.Profiles.Any() ? v.Profiles : allProfiles).Select(p => (profile: p, variant: v)))
                    .GroupBy(pv => pv.profile)
                    .Select(pvg => new ProfileGroup(pvg.Select(pv => pv.variant).ToArray(), pvg.Key))
                : new[] { new ProfileGroup(variants) };
            var variantGroups = profileGroups.SelectMany(pg => pg.Variants
                .GroupBy(v => new { v.CmdletName, v.IsInternal })
                .Select(vg => new VariantGroup(ModuleName, vg.Key.CmdletName, vg.Select(v => v).ToArray(),
                    Path.Combine(vg.Key.IsInternal ? InternalFolder : ExportsFolder, pg.ProfileFolder), pg.ProfileName, isInternal: vg.Key.IsInternal)))
                .ToArray();

            foreach (var variantGroup in variantGroups)
            {
                var parameterGroups = variantGroup.ParameterGroups.ToList();
                var isValidProfile = !String.IsNullOrEmpty(variantGroup.ProfileName) && variantGroup.ProfileName != NoProfiles;
                var examplesFolder = isValidProfile ? Path.Combine(ExamplesFolder, variantGroup.ProfileName) : ExamplesFolder;
                var markdownInfo = new MarkdownHelpInfo(variantGroup, examplesFolder);
                List<PsHelpExampleInfo> examples = new List<PsHelpExampleInfo>();
                foreach (var it in markdownInfo.Examples)
                {
                    examples.Add(it);
                }
                variantGroup.HelpInfo.Examples = examples.ToArray();
                var sb = new StringBuilder();
                sb.Append(@"
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the ""License"");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an ""AS IS"" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
");
                sb.Append($"{Environment.NewLine}");
                sb.Append(variantGroup.ToHelpCommentOutput());
                sb.Append($"function {variantGroup.CmdletName} {{{Environment.NewLine}");
                sb.Append(variantGroup.Aliases.ToAliasOutput());
                sb.Append(variantGroup.OutputTypes.ToOutputTypeOutput());
                sb.Append(variantGroup.ToCmdletBindingOutput());
                sb.Append(variantGroup.ProfileName.ToProfileOutput());

                sb.Append("param(");
                sb.Append($"{(parameterGroups.Any() ? Environment.NewLine : String.Empty)}");
                foreach (var parameterGroup in parameterGroups)
                {
                    var parameters = parameterGroup.HasAllVariants ? parameterGroup.Parameters.Take(1) : parameterGroup.Parameters;
                    foreach (var parameter in parameters)
                    {
                        sb.Append(parameter.ToParameterOutput(variantGroup.HasMultipleVariants, parameterGroup.HasAllVariants));
                    }
                    sb.Append(parameterGroup.Aliases.ToAliasOutput(true));
                    sb.Append(parameterGroup.HasValidateNotNull.ToValidateNotNullOutput());
                    sb.Append(parameterGroup.CompleterInfo.ToArgumentCompleterOutput());
                    sb.Append(parameterGroup.OrderCategory.ToParameterCategoryOutput());
                    sb.Append(parameterGroup.InfoAttribute.ToInfoOutput(parameterGroup.ParameterType));
                    sb.Append(parameterGroup.ToDefaultInfoOutput());
                    sb.Append(parameterGroup.ParameterType.ToParameterTypeOutput());
                    sb.Append(parameterGroup.Description.ToParameterDescriptionOutput());
                    sb.Append(parameterGroup.ParameterName.ToParameterNameOutput(parameterGroups.IndexOf(parameterGroup) == parameterGroups.Count - 1));
                }
                sb.Append($"){Environment.NewLine}{Environment.NewLine}");

                sb.Append(variantGroup.ToBeginOutput());
                sb.Append(variantGroup.ToProcessOutput());
                sb.Append(variantGroup.ToEndOutput());

                sb.Append($"}}{Environment.NewLine}");

                Directory.CreateDirectory(variantGroup.OutputFolder);
                File.WriteAllText(variantGroup.FilePath, sb.ToString());

                File.AppendAllText(Path.Combine(variantGroup.OutputFolder, "ProxyCmdletDefinitions.ps1"), sb.ToString());
            }

            if (!ExcludeDocs)
            {
                var moduleInfo = new PsModuleHelpInfo(ModuleName, ModuleGuid, ModuleDescription);
                foreach (var variantGroupsByProfile in variantGroups.GroupBy(vg => vg.ProfileName))
                {
                    var profileName = variantGroupsByProfile.Key;
                    var isValidProfile = !String.IsNullOrEmpty(profileName) && profileName != NoProfiles;
                    var docsFolder = isValidProfile ? Path.Combine(DocsFolder, profileName) : DocsFolder;
                    var examplesFolder = isValidProfile ? Path.Combine(ExamplesFolder, profileName) : ExamplesFolder;
                    WriteMarkdowns(variantGroupsByProfile, moduleInfo, docsFolder, examplesFolder);
                }
            }
          } catch (Exception ee) { 
            Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
            throw ee;
          }
        }
    }
}
