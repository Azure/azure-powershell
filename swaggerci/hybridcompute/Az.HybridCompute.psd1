@{
  GUID = '59cac58c-e32e-4b52-a9dd-5c883ad1705b'
  RootModule = './Az.HybridCompute.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HybridCompute cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HybridCompute.private.dll'
  FormatsToProcess = './Az.HybridCompute.format.ps1xml'
  FunctionsToExport = 'Get-AzHybridComputeMachine', 'Get-AzHybridComputeMachineExtension', 'Get-AzHybridComputePrivateEndpointConnection', 'Get-AzHybridComputePrivateLinkResource', 'Get-AzHybridComputePrivateLinkScope', 'Get-AzHybridComputePrivateLinkScopeValidationDetail', 'New-AzHybridComputeMachine', 'New-AzHybridComputeMachineExtension', 'New-AzHybridComputePrivateEndpointConnection', 'New-AzHybridComputePrivateLinkScope', 'Remove-AzHybridComputeMachine', 'Remove-AzHybridComputeMachineExtension', 'Remove-AzHybridComputePrivateEndpointConnection', 'Remove-AzHybridComputePrivateLinkScope', 'Update-AzHybridComputeExtension', 'Update-AzHybridComputeMachine', 'Update-AzHybridComputeMachineExtension', 'Update-AzHybridComputePrivateLinkScopeTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HybridCompute'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
