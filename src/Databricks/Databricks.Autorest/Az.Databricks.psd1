@{
  GUID = 'b453c0c1-7867-4fa1-9fd0-0cf8f6c6959c'
  RootModule = './Az.Databricks.psm1'
  ModuleVersion = '1.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Databricks cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Databricks.private.dll'
  FormatsToProcess = './Az.Databricks.format.ps1xml'
  FunctionsToExport = 'Get-AzDatabricksAccessConnector', 'Get-AzDatabricksOutboundNetworkDependenciesEndpoint', 'Get-AzDatabricksVNetPeering', 'Get-AzDatabricksWorkspace', 'New-AzDatabricksAccessConnector', 'New-AzDatabricksVNetPeering', 'New-AzDatabricksWorkspace', 'New-AzDatabricksWorkspaceProviderAuthorizationObject', 'Remove-AzDatabricksAccessConnector', 'Remove-AzDatabricksVNetPeering', 'Remove-AzDatabricksWorkspace', 'Update-AzDatabricksAccessConnector', 'Update-AzDatabricksVNetPeering', 'Update-AzDatabricksWorkspace', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Databricks'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
