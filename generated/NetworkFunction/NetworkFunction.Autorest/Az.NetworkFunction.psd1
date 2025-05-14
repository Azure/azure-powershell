@{
  GUID = '1d339b1c-5a86-4fbd-9a2e-d0497c39b397'
  RootModule = './Az.NetworkFunction.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: NetworkFunction cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.NetworkFunction.private.dll'
  FormatsToProcess = './Az.NetworkFunction.format.ps1xml'
  FunctionsToExport = 'Get-AzNetworkFunctionCollectorPolicy', 'Get-AzNetworkFunctionTrafficCollector', 'New-AzNetworkFunctionCollectorPolicy', 'New-AzNetworkFunctionTrafficCollector', 'Remove-AzNetworkFunctionCollectorPolicy', 'Remove-AzNetworkFunctionTrafficCollector', 'Update-AzNetworkFunctionCollectorPolicy', 'Update-AzNetworkFunctionCollectorPolicyTag', 'Update-AzNetworkFunctionTrafficCollector', 'Update-AzNetworkFunctionTrafficCollectorTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'NetworkFunction'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
