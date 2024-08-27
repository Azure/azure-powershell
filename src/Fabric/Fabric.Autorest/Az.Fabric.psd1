@{
  GUID = 'ae259966-6ec6-4d5c-a308-5c01a210c8a7'
  RootModule = './Az.Fabric.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Fabric cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Fabric.private.dll'
  FormatsToProcess = './Az.Fabric.format.ps1xml'
  FunctionsToExport = 'Get-AzFabricCapacity', 'Get-AzFabricCapacitySku', 'New-AzFabricCapacity', 'Remove-AzFabricCapacity', 'Resume-AzFabricCapacity', 'Suspend-AzFabricCapacity', 'Test-AzFabricCapacityNameAvailability', 'Update-AzFabricCapacity'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Fabric'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
