/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell
{
  [Cmdlet(VerbsCommon.Get, "CommonParameter")]
  [OutputType(typeof(Dictionary<string, object>))]
  [DoNotExport]
  public class GetCommonParameter : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public PSCmdlet PSCmdlet { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public Dictionary<string, object> PSBoundParameter { get; set; }

    protected override void ProcessRecord()
    {
      try
      {
        var variants = PSCmdlet.MyInvocation.MyCommand.ToVariants();
        var commonParameterNames = variants.ToParameterGroups()
            .Where(pg => pg.OrderCategory == ParameterCategory.Azure || pg.OrderCategory == ParameterCategory.Runtime)
            .Select(pg => pg.ParameterName);
        if (variants.Any(v => v.SupportsShouldProcess))
        {
          commonParameterNames = commonParameterNames.Append("Confirm").Append("WhatIf");
        }
        if (variants.Any(v => v.SupportsPaging))
        {
          commonParameterNames = commonParameterNames.Append("First").Append("Skip").Append("IncludeTotalCount");
        }

        var names = commonParameterNames.ToArray();
        var keys = PSBoundParameter.Keys.Where(k => names.Contains(k));
        WriteObject(keys.ToDictionary(key => key, key => PSBoundParameter[key]), true);
      }
      catch (System.Exception ee)
      {
        System.Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }
  }
}
