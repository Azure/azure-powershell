@{
  GUID = 'ed90c36c-f150-4ad2-96ae-57e0ebb0a376'
  RootModule = './Az.ElasticSan.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ElasticSan cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ElasticSan.private.dll'
  FormatsToProcess = './Az.ElasticSan.format.ps1xml'
  FunctionsToExport = 'Add-AzElasticSanVolumeGroupNetworkRule', 'Get-AzElasticSan', 'Get-AzElasticSanSkuList', 'Get-AzElasticSanVolume', 'Get-AzElasticSanVolumeGroup', 'Get-AzElasticSanVolumeSnapshot', 'New-AzElasticSan', 'New-AzElasticSanVirtualNetworkRuleObject', 'New-AzElasticSanVolume', 'New-AzElasticSanVolumeGroup', 'New-AzElasticSanVolumeSnapshot', 'Remove-AzElasticSan', 'Remove-AzElasticSanVolume', 'Remove-AzElasticSanVolumeGroup', 'Remove-AzElasticSanVolumeGroupNetworkRule', 'Remove-AzElasticSanVolumeSnapshot', 'Update-AzElasticSan', 'Update-AzElasticSanVolume', 'Update-AzElasticSanVolumeGroup'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ElasticSan'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
