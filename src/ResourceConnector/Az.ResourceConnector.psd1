@{
  GUID = '45c7c94d-2834-49a2-b244-d2c5fe3ae2cc'
  RootModule = './Az.ResourceConnector.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ResourceConnector cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ResourceConnector.private.dll'
  FormatsToProcess = './Az.ResourceConnector.format.ps1xml'
  FunctionsToExport = 'Get-AzResourceConnectorBridge', 'Get-AzResourceConnectorBridgeKey', 'Get-AzResourceConnectorBridgeTelemetryConfig', 'Get-AzResourceConnectorBridgeUpgradeGraph', 'Get-AzResourceConnectorBridgeUserCredential', 'New-AzResourceConnectorBridge', 'Remove-AzResourceConnectorBridge', 'Update-AzResourceConnectorBridge', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ResourceConnector'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
