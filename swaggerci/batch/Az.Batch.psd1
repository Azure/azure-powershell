@{
  GUID = 'f05875ea-2664-4699-89f7-c02394189dbc'
  RootModule = './Az.Batch.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Batch cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Batch.private.dll'
  FormatsToProcess = './Az.Batch.format.ps1xml'
  FunctionsToExport = 'Disable-AzBatchPoolAutoScale', 'Get-AzBatchAccount', 'Get-AzBatchAccountDetector', 'Get-AzBatchAccountKey', 'Get-AzBatchAccountOutboundNetworkDependencyEndpoint', 'Get-AzBatchApplication', 'Get-AzBatchApplicationPackage', 'Get-AzBatchCertificate', 'Get-AzBatchLocationQuota', 'Get-AzBatchLocationSupportedCloudServiceSku', 'Get-AzBatchLocationSupportedVirtualMachineSku', 'Get-AzBatchPool', 'Get-AzBatchPrivateEndpointConnection', 'Get-AzBatchPrivateLinkResource', 'Initialize-AzBatchApplicationPackage', 'New-AzBatchAccount', 'New-AzBatchAccountKey', 'New-AzBatchApplication', 'New-AzBatchApplicationPackage', 'New-AzBatchCertificate', 'New-AzBatchPool', 'Remove-AzBatchAccount', 'Remove-AzBatchApplication', 'Remove-AzBatchApplicationPackage', 'Remove-AzBatchCertificate', 'Remove-AzBatchPool', 'Stop-AzBatchCertificateDeletion', 'Stop-AzBatchPoolResize', 'Sync-AzBatchAccountAutoStorageKey', 'Test-AzBatchLocationNameAvailability', 'Update-AzBatchAccount', 'Update-AzBatchApplication', 'Update-AzBatchCertificate', 'Update-AzBatchPool', 'Update-AzBatchPrivateEndpointConnection', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Batch'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
