@{
  GUID = 'b5b1a166-2af2-4644-9256-804fe5574133'
  RootModule = './Az.DataLakeAnalyticsAccount.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataLakeAnalyticsAccount cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataLakeAnalyticsAccount.private.dll'
  FormatsToProcess = './Az.DataLakeAnalyticsAccount.format.ps1xml'
  FunctionsToExport = 'Add-AzDataLakeAnalyticsAccountDataLakeStoreAccount', 'Add-AzDataLakeAnalyticsAccountStorageAccount', 'Get-AzDataLakeAnalyticsAccount', 'Get-AzDataLakeAnalyticsAccountComputePolicy', 'Get-AzDataLakeAnalyticsAccountDataLakeStoreAccount', 'Get-AzDataLakeAnalyticsAccountFirewallRule', 'Get-AzDataLakeAnalyticsAccountLocationCapability', 'Get-AzDataLakeAnalyticsAccountStorageAccount', 'Get-AzDataLakeAnalyticsAccountStorageAccountSasToken', 'Get-AzDataLakeAnalyticsAccountStorageContainer', 'New-AzDataLakeAnalyticsAccount', 'New-AzDataLakeAnalyticsAccountComputePolicy', 'New-AzDataLakeAnalyticsAccountFirewallRule', 'Remove-AzDataLakeAnalyticsAccount', 'Remove-AzDataLakeAnalyticsAccountComputePolicy', 'Remove-AzDataLakeAnalyticsAccountDataLakeStoreAccount', 'Remove-AzDataLakeAnalyticsAccountFirewallRule', 'Remove-AzDataLakeAnalyticsAccountStorageAccount', 'Test-AzDataLakeAnalyticsAccountNameAvailability', 'Update-AzDataLakeAnalyticsAccount', 'Update-AzDataLakeAnalyticsAccountComputePolicy', 'Update-AzDataLakeAnalyticsAccountFirewallRule', 'Update-AzDataLakeAnalyticsAccountStorageAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataLakeAnalyticsAccount'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
