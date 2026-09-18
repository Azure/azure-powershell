/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
  [Cmdlet(VerbsCommon.Get, "ScriptCmdlet")]
  [OutputType(typeof(string[]))]
  [DoNotExport]
  public class GetScriptCmdlet : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string ScriptFolder { get; set; }

    [Parameter]
    public SwitchParameter IncludeDoNotExport { get; set; }

    [Parameter]
    public SwitchParameter AsAlias { get; set; }

    [Parameter]
    public SwitchParameter AsFunctionInfo { get; set; }

    protected override void ProcessRecord()
    {
      try
      {
        var functionInfos = GetScriptCmdlets(this, ScriptFolder)
            .Where(fi => IncludeDoNotExport || !fi.ScriptBlock.Attributes.OfType<DoNotExportAttribute>().Any())
            .ToArray();
        if (AsFunctionInfo)
        {
          WriteObject(functionInfos, true);
          return;
        }
        var aliases = functionInfos.SelectMany(i => i.ScriptBlock.Attributes).ToAliasNames();
        var names = functionInfos.Select(fi => fi.Name).Distinct();
        var output = (AsAlias ? aliases : names).DefaultIfEmpty("''").ToArray();
        WriteObject(output, true);
      }
      catch (System.Exception ee)
      {
        System.Console.Error.WriteLine($"{ee.GetType().Name}: {ee.Message}");
        System.Console.Error.WriteLine(ee.StackTrace);
        throw ee;
      }
    }
  }
}
