using System.Management.Automation;
using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell
{
  [Cmdlet(VerbsCommon.Get, "ModuleGuid")]
  [DoNotExport]
  public class GetModuleGuid : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string Psd1Path { get; set; }

    protected override void ProcessRecord()
    {
      try
      {
        WriteObject(ReadGuidFromPsd1(Psd1Path));
      }
      catch (System.Exception ee)
      {
        System.Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }
  }
}
