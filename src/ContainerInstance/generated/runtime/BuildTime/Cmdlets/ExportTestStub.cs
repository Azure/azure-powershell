/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell.PsProxyOutputExtensions;
using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell
{
  [Cmdlet(VerbsData.Export, "TestStub")]
  [DoNotExport]
  public class ExportTestStub : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string ModuleName { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string ExportsFolder { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string OutputFolder { get; set; }

    [Parameter]
    public SwitchParameter IncludeGenerated { get; set; }

    protected override void ProcessRecord()
    {
      try
      {
        if (!Directory.Exists(ExportsFolder))
        {
          throw new ArgumentException($"Exports folder '{ExportsFolder}' does not exist");
        }

        var exportDirectories = Directory.GetDirectories(ExportsFolder);
        if (!exportDirectories.Any())
        {
          exportDirectories = new[] { ExportsFolder };
        }
        var utilFile = Path.Combine(OutputFolder, "utils.ps1");
        if (!File.Exists(utilFile))
        {
          var sc = new StringBuilder();
          sc.AppendLine(@"function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}
");
          File.WriteAllText(utilFile, sc.ToString());
        }
        foreach (var exportDirectory in exportDirectories)
        {
          var outputFolder = OutputFolder;
          if (exportDirectory != ExportsFolder)
          {
            outputFolder = Path.Combine(OutputFolder, Path.GetFileName(exportDirectory));
            Directory.CreateDirectory(outputFolder);
          }

          var variantGroups = GetScriptCmdlets(exportDirectory)
              .SelectMany(fi => fi.ToVariants())
              .Where(v => !v.IsDoNotExport)
              .GroupBy(v => v.CmdletName)
              .Select(vg => new VariantGroup(ModuleName, vg.Key, vg.Select(v => v).ToArray(), outputFolder, isTest: true))
              .Where(vtg => !File.Exists(vtg.FilePath) && (IncludeGenerated || !vtg.IsGenerated));

          foreach (var variantGroup in variantGroups)
          {
            var sb = new StringBuilder();
            sb.AppendLine(@"$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)"
);
            sb.AppendLine($@"$TestRecordingFile = Join-Path $PSScriptRoot '{variantGroup.CmdletName}.Recording.json'");
            sb.AppendLine(@"$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName
");

            sb.AppendLine($"Describe '{variantGroup.CmdletName}' {{");
            var variants = variantGroup.Variants
                .Where(v => IncludeGenerated || !v.Attributes.OfType<GeneratedAttribute>().Any())
                .ToList();

            foreach (var variant in variants)
            {
              sb.AppendLine($"{Indent}It '{variant.VariantName}' -skip {{");
              sb.AppendLine($"{Indent}{Indent}{{ throw [System.NotImplementedException] }} | Should -Not -Throw");
              var variantSeparator = variants.IndexOf(variant) == variants.Count - 1 ? String.Empty : Environment.NewLine;
              sb.AppendLine($"{Indent}}}{variantSeparator}");
            }
            sb.AppendLine("}");

            File.WriteAllText(variantGroup.FilePath, sb.ToString());
          }
        }
      }
      catch (Exception ee)
      {
        Console.WriteLine($"${ee.GetType().Name}/{ee.StackTrace}");
        throw ee;
      }
    }
  }
}
