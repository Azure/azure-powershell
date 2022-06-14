@{
  GUID = '97334c5f-a942-4f92-b62b-48c22e5627b2'
  RootModule = './Az.PowerBiDedicated.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PowerBiDedicated cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PowerBiDedicated.private.dll'
  FormatsToProcess = './Az.PowerBiDedicated.format.ps1xml'
  FunctionsToExport = 'Get-AzPowerBiDedicatedAutoScaleVCore', 'Get-AzPowerBiDedicatedCapacity', 'Get-AzPowerBiDedicatedCapacityDetail', 'Get-AzPowerBiDedicatedCapacitySku', 'New-AzPowerBiDedicatedAutoScaleVCore', 'New-AzPowerBiDedicatedCapacity', 'Remove-AzPowerBiDedicatedAutoScaleVCore', 'Remove-AzPowerBiDedicatedCapacity', 'Resume-AzPowerBiDedicatedCapacity', 'Suspend-AzPowerBiDedicatedCapacity', 'Test-AzPowerBiDedicatedCapacityNameAvailability', 'Update-AzPowerBiDedicatedAutoScaleVCore', 'Update-AzPowerBiDedicatedCapacity', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PowerBiDedicated'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
