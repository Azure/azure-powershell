@{
  GUID = '6460a804-8128-4631-8c6a-62935f7058a0'
  RootModule = './Az.Appliances.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Appliances cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Appliances.private.dll'
  FormatsToProcess = './Az.Appliances.format.ps1xml'
  FunctionsToExport = 'Get-AzAppliancesAppliance', 'Get-AzAppliancesApplianceClusterUserCredential', 'Get-AzAppliancesApplianceKey', 'Get-AzAppliancesApplianceOperation', 'Get-AzAppliancesApplianceTelemetryConfig', 'Get-AzAppliancesApplianceUpgradeGraph', 'New-AzAppliancesAppliance', 'Remove-AzAppliancesAppliance', 'Update-AzAppliancesAppliance', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Appliances'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
