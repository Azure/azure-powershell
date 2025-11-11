/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell.MarkdownRenderer;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
  [Cmdlet(VerbsData.Export, "HelpMarkdown")]
  [DoNotExport]
  public class ExportHelpMarkdown : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public PSModuleInfo ModuleInfo { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public PSObject[] FunctionInfo { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public PSObject[] HelpInfo { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string DocsFolder { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string ExamplesFolder { get; set; }

    [Parameter()]
    public SwitchParameter AddComplexInterfaceInfo { get; set; }

    protected override void ProcessRecord()
    {
      try
      {
        var helpInfos = HelpInfo.Select(hi => hi.ToPsHelpInfo());
        var variantGroups = FunctionInfo.Select(fi => fi.BaseObject).Cast<FunctionInfo>()
            .Join(helpInfos, fi => fi.Name, phi => phi.CmdletName, (fi, phi) => fi.ToVariants(phi))
            .Select(va => new VariantGroup(ModuleInfo.Name, va.First().CmdletName, va, String.Empty));
        WriteMarkdowns(variantGroups, ModuleInfo.ToModuleInfo(), DocsFolder, ExamplesFolder, AddComplexInterfaceInfo.IsPresent);
      }
      catch (Exception ee)
      {
        Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }
  }
}
