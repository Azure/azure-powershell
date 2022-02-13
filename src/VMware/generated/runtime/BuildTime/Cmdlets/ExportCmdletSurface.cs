/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell
{
  [Cmdlet(VerbsData.Export, "CmdletSurface")]
  [DoNotExport]
  public class ExportCmdletSurface : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string ModuleName { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string CmdletFolder { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string OutputFolder { get; set; }

    [Parameter]
    public bool IncludeGeneralParameters { get; set; }

    [Parameter]
    public bool UseExpandedFormat { get; set; }

    protected override void ProcessRecord()
    {
      try
      {
        var variants = GetScriptCmdlets(this, CmdletFolder)
            .SelectMany(fi => fi.ToVariants())
            .Where(v => !v.IsDoNotExport)
            .ToArray();
        var allProfiles = variants.SelectMany(v => v.Profiles).Distinct().ToArray();
        var profileGroups = allProfiles.Any()
            ? variants
                .SelectMany(v => (v.Profiles.Any() ? v.Profiles : allProfiles).Select(p => (profile: p, variant: v)))
                .GroupBy(pv => pv.profile)
                .Select(pvg => new ProfileGroup(pvg.Select(pv => pv.variant).ToArray(), pvg.Key))
            : new[] { new ProfileGroup(variants) };
        foreach (var profileGroup in profileGroups)
        {
          var variantGroups = profileGroup.Variants
              .GroupBy(v => new { v.CmdletName })
              .Select(vg => new VariantGroup(ModuleName, vg.Key.CmdletName, vg.Select(v => v).ToArray(), String.Empty, profileGroup.ProfileName));
          var sb = UseExpandedFormat ? ExpandedFormat(variantGroups) : CondensedFormat(variantGroups);
          Directory.CreateDirectory(OutputFolder);
          File.WriteAllText(Path.Combine(OutputFolder, $"CmdletSurface-{profileGroup.ProfileName}.md"), sb.ToString());
        }
      }
      catch (Exception ee)
      {
        Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }

    private StringBuilder ExpandedFormat(IEnumerable<VariantGroup> variantGroups)
    {
      var sb = new StringBuilder();
      foreach (var variantGroup in variantGroups.OrderBy(vg => vg.CmdletName))
      {
        sb.Append($"### {variantGroup.CmdletName}{Environment.NewLine}");
        var parameterGroups = variantGroup.ParameterGroups
            .Where(pg => !pg.DontShow && (IncludeGeneralParameters || (pg.OrderCategory != ParameterCategory.Azure && pg.OrderCategory != ParameterCategory.Runtime)));
        foreach (var parameterGroup in parameterGroups)
        {
          sb.Append($"  - {parameterGroup.ParameterName} `{parameterGroup.ParameterType.ToSyntaxTypeName()}`{Environment.NewLine}");
        }
        sb.AppendLine();
      }

      return sb;
    }

    private StringBuilder CondensedFormat(IEnumerable<VariantGroup> variantGroups)
    {
      var sb = new StringBuilder();
      var condensedGroups = variantGroups
          .GroupBy(vg => vg.CmdletNoun)
          .Select(vgg => (
              CmdletNoun: vgg.Key,
              CmdletVerbs: vgg.Select(vg => vg.CmdletVerb).OrderBy(cv => cv).ToArray(),
              ParameterGroups: vgg.SelectMany(vg => vg.ParameterGroups).DistinctBy(p => p.ParameterName).ToArray(),
              OutputTypes: vgg.SelectMany(vg => vg.OutputTypes).Select(ot => ot.Type).DistinctBy(t => t.Name).Select(t => t.ToSyntaxTypeName()).ToArray()))
          .OrderBy(vg => vg.CmdletNoun);
      foreach (var condensedGroup in condensedGroups)
      {
        sb.Append($"### {condensedGroup.CmdletNoun} [{String.Join(", ", condensedGroup.CmdletVerbs)}] `{String.Join(", ", condensedGroup.OutputTypes)}`{Environment.NewLine}");
        var parameterGroups = condensedGroup.ParameterGroups
            .Where(pg => !pg.DontShow && (IncludeGeneralParameters || (pg.OrderCategory != ParameterCategory.Azure && pg.OrderCategory != ParameterCategory.Runtime)));
        foreach (var parameterGroup in parameterGroups)
        {
          sb.Append($"  - {parameterGroup.ParameterName} `{parameterGroup.ParameterType.ToSyntaxTypeName()}`{Environment.NewLine}");
        }
        sb.AppendLine();
      }

      return sb;
    }
  }
}
