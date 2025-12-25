@{
  GUID = 'e246885c-bda4-4168-a6ca-c0f5d91dd120'
  RootModule = './Az.EdgeAction.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EdgeAction cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EdgeAction.private.dll'
  FormatsToProcess = './Az.EdgeAction.format.ps1xml'
  FunctionsToExport = 'Add-AzEdgeActionAttachment', 'Deploy-AzEdgeActionVersionCode', 'Get-AzEdgeAction', 'Get-AzEdgeActionExecutionFilter', 'Get-AzEdgeActionVersion', 'Get-AzEdgeActionVersionCode', 'New-AzEdgeAction', 'New-AzEdgeActionExecutionFilter', 'New-AzEdgeActionVersion', 'Remove-AzEdgeAction', 'Remove-AzEdgeActionAttachment', 'Remove-AzEdgeActionExecutionFilter', 'Remove-AzEdgeActionVersion', 'Switch-AzEdgeActionVersionDefault', 'Update-AzEdgeAction', 'Update-AzEdgeActionExecutionFilter', 'Update-AzEdgeActionVersion'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EdgeAction'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
