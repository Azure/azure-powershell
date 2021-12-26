@{
  GUID = '8520ac69-18c8-470e-9c72-dc1fd5643887'
  RootModule = './Az.Marketplace.psm1'
  ModuleVersion = '1.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Marketplace cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Marketplace.private.dll'
  FormatsToProcess = './Az.Marketplace.format.ps1xml'
  FunctionsToExport = 'Copy-AzMarketplacePrivateStoreCollectionOffer', 'Get-AzMarketplaceBillingPrivateStoreAccount', 'Get-AzMarketplaceCollectionPrivateStoreToSubscriptionMapping', 'Get-AzMarketplacePrivateStore', 'Get-AzMarketplacePrivateStoreCollection', 'Get-AzMarketplacePrivateStoreCollectionOffer', 'Get-AzMarketplaceQueryPrivateStoreOffer', 'New-AzMarketplacePrivateStore', 'New-AzMarketplacePrivateStoreCollection', 'New-AzMarketplacePrivateStoreCollectionOffer', 'Remove-AzMarketplacePrivateStoreCollection', 'Remove-AzMarketplacePrivateStoreCollectionOffer', 'Set-AzMarketplaceBulkPrivateStoreCollectionAction', 'Set-AzMarketplacePrivateStore', 'Set-AzMarketplacePrivateStoreCollection', 'Set-AzMarketplacePrivateStoreCollectionOffer', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Marketplace'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
