using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell
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

        var sb = new StringBuilder();
        sb.AppendLine("@{");
        sb.AppendLine($@"{GuidStart} = '{ModuleGuid}'");
        sb.AppendLine($@"{Indent}RootModule = '{"./Az.Network.psm1"}'");
        sb.AppendLine($@"{Indent}ModuleVersion = '{"0.1.0"}'");
        sb.AppendLine($@"{Indent}CompatiblePSEditions = 'Core', 'Desktop'");
        sb.AppendLine($@"{Indent}Author = '{"Microsoft Corporation"}'");
        sb.AppendLine($@"{Indent}CompanyName = '{"Microsoft Corporation"}'");
        sb.AppendLine($@"{Indent}Copyright = '{"Microsoft Corporation. All rights reserved."}'");
        sb.AppendLine($@"{Indent}Description = '{"Microsoft Azure PowerShell: Network cmdlets"}'");
        sb.AppendLine($@"{Indent}PowerShellVersion = '5.1'");
        sb.AppendLine($@"{Indent}DotNetFrameworkVersion = '4.7.2'");
        sb.AppendLine($@"{Indent}RequiredAssemblies = '{"./bin/Az.Network.private.dll"}'");

        var customFormatPs1xmlFiles = Directory.GetFiles(CustomFolder)
            .Where(f => f.EndsWith(".format.ps1xml"))
            .Select(f => $"{CustomFolderRelative}/{Path.GetFileName(f)}");
        var formatList = customFormatPs1xmlFiles.Prepend("./Az.Network.format.ps1xml").ToPsList();
        sb.AppendLine($@"{Indent}FormatsToProcess = {formatList}");

        var functionInfos = GetScriptCmdlets(ExportsFolder).ToArray();
        var cmdletsList = functionInfos.Select(fi => fi.Name).Distinct().Append("*").ToPsList();
        sb.AppendLine($@"{Indent}CmdletsToExport = {cmdletsList}");
        var aliasesList = functionInfos.SelectMany(fi => fi.ScriptBlock.Attributes).ToAliasNames().Append("*").ToPsList();
        sb.AppendLine($@"{Indent}AliasesToExport = {aliasesList}");

        sb.AppendLine($@"{Indent}PrivateData = @{{");
        sb.AppendLine($@"{Indent}{Indent}PSData = @{{");

        sb.AppendLine($@"{Indent}{Indent}{Indent}Tags = {"Azure ResourceManager ARM PSModule Network".Split(' ').ToPsList().NullIfEmpty() ?? "''"}");
        sb.AppendLine($@"{Indent}{Indent}{Indent}LicenseUri = '{"https://aka.ms/azps-license"}'");
        sb.AppendLine($@"{Indent}{Indent}{Indent}ProjectUri = '{"https://github.com/Azure/azure-powershell"}'");
        sb.AppendLine($@"{Indent}{Indent}{Indent}ReleaseNotes = ''");
        var profilesList = "'latest-2019-04-30', 'hybrid-2019-03-01'";
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
