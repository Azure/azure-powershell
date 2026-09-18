/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell.MarkdownTypesExtensions;
using static Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell.PsHelpers;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell
{
  [Cmdlet(VerbsData.Export, "ExampleStub")]
  [DoNotExport] 
  public class ExportExampleStub : PSCmdlet
  {
    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string ExportsFolder { get; set; }

    [Parameter(Mandatory = true)]
    [ValidateNotNullOrEmpty]
    public string OutputFolder { get; set; }

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

        var exampleText = String.Join(String.Empty, DefaultExampleHelpInfos.Select(ehi => ehi.ToHelpExampleOutput()));
        foreach (var exportDirectory in exportDirectories)
        {
          var outputFolder = OutputFolder;
          if (exportDirectory != ExportsFolder)
          {
            outputFolder = Path.Combine(OutputFolder, Path.GetFileName(exportDirectory));
            Directory.CreateDirectory(outputFolder);
          }

          var cmdletFilePaths = GetScriptCmdlets(exportDirectory).Select(fi => Path.Combine(outputFolder, $"{fi.Name}.md")).ToArray();
          var currentExamplesFilePaths = Directory.GetFiles(outputFolder).ToArray();
          // Remove examples of non-existing cmdlets
          var removedCmdletFilePaths = currentExamplesFilePaths.Except(cmdletFilePaths);
          foreach (var removedCmdletFilePath in removedCmdletFilePaths)
          {
            File.Delete(removedCmdletFilePath);
          }

          // Only create example stubs if they don't exist
          foreach (var cmdletFilePath in cmdletFilePaths.Except(currentExamplesFilePaths))
          {
            File.WriteAllText(cmdletFilePath, exampleText);
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
