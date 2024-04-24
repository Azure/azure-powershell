@{
  GUID = '4bdb5e8a-54be-4080-8f73-9c4e31acf7c7'
  RootModule = './Az.MixedReality.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: MixedReality cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.MixedReality.private.dll'
  FormatsToProcess = './Az.MixedReality.format.ps1xml'
  FunctionsToExport = 'Get-AzMixedRealityObjectAnchorsAccount', 'Get-AzMixedRealityObjectAnchorsAccountKey', 'Get-AzMixedRealityRemoteRenderingAccount', 'Get-AzMixedRealityRemoteRenderingAccountKey', 'Get-AzMixedRealitySpatialAnchorsAccount', 'Get-AzMixedRealitySpatialAnchorsAccountKey', 'New-AzMixedRealityObjectAnchorsAccount', 'New-AzMixedRealityObjectAnchorsAccountKey', 'New-AzMixedRealityRemoteRenderingAccount', 'New-AzMixedRealityRemoteRenderingAccountKey', 'New-AzMixedRealitySpatialAnchorsAccount', 'New-AzMixedRealitySpatialAnchorsAccountKey', 'Remove-AzMixedRealityObjectAnchorsAccount', 'Remove-AzMixedRealityRemoteRenderingAccount', 'Remove-AzMixedRealitySpatialAnchorsAccount', 'Test-AzMixedRealityNameAvailability', 'Update-AzMixedRealityObjectAnchorsAccount', 'Update-AzMixedRealityRemoteRenderingAccount', 'Update-AzMixedRealitySpatialAnchorsAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'MixedReality'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
