@{
  GUID = '329aa971-c12b-4d4b-abe5-3b638b0b5660'
  RootModule = './Az.ArcResourceBridge.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ArcResourceBridge cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ArcResourceBridge.private.dll'
  FormatsToProcess = './Az.ArcResourceBridge.format.ps1xml'
  FunctionsToExport = 'Get-AzArcResourceBridge', 'Get-AzArcResourceBridgeApplianceCredential', 'Get-AzArcResourceBridgeCredential', 'Get-AzArcResourceBridgeTelemetryConfig', 'Get-AzArcResourceBridgeUpgradeGraph', 'New-AzArcResourceBridge', 'Remove-AzArcResourceBridge', 'Update-AzArcResourceBridge', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ArcResourceBridge'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
