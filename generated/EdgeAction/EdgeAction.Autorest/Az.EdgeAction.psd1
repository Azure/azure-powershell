@{
  GUID = 'f5a7ab85-ded8-4ed5-aa41-3c88ab00edb9'
  RootModule = './Az.EdgeAction.psm1'
  ModuleVersion = '0.1.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EdgeAction cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EdgeAction.private.dll'
  FormatsToProcess = './Az.EdgeAction.format.ps1xml'
  FunctionsToExport = 'Deploy-AzEdgeActionVersionCode', 'Get-AzEdgeAction', 'Get-AzEdgeActionExecutionFilter', 'Get-AzEdgeActionVersion', 'Get-AzEdgeActionVersionCode', 'New-AzEdgeAction', 'New-AzEdgeActionExecutionFilter', 'New-AzEdgeActionVersion', 'Remove-AzEdgeAction', 'Remove-AzEdgeActionExecutionFilter', 'Remove-AzEdgeActionVersion', 'Switch-AzEdgeActionVersionDefault', 'Update-AzEdgeAction', 'Update-AzEdgeActionExecutionFilter', 'Update-AzEdgeActionVersion'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EdgeAction'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
