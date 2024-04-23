@{
  GUID = '841c2fad-e8c0-4924-b9b9-9d27d0f40b48'
  RootModule = './Az.DedicatedHsm.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DedicatedHsm cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DedicatedHsm.private.dll'
  FormatsToProcess = './Az.DedicatedHsm.format.ps1xml'
  FunctionsToExport = 'Get-AzDedicatedHsm', 'Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint', 'New-AzDedicatedHsm', 'Remove-AzDedicatedHsm', 'Update-AzDedicatedHsm', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DedicatedHsm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
