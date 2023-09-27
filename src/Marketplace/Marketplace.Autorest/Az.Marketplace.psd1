@{
  GUID = '4db1f51a-b835-4783-be47-0b8939492ea5'
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
  FunctionsToExport = 'Approve-AzMarketplacePrivateStoreCollectionItem', 'Copy-AzMarketplacePrivateStoreCollectionOffer', 'Disable-AzMarketplacePrivateStoreCollectionApproveItem', 'Get-AzMarketplaceBillingPrivateStoreAccount', 'Get-AzMarketplaceCollectionToSubscriptionMapping', 'Get-AzMarketplacePrivateStoreCollection', 'Get-AzMarketplacePrivateStoreCollectionOffer', 'Get-AzMarketplacePrivateStoreNewPlanNotification', 'Get-AzMarketplacePrivateStoreStopSellOfferPlanNotification', 'Get-AzMarketplacePrivateStoreSubscriptionContext', 'Get-AzMarketplacePrivateStoreV1', 'Get-AzMarketplaceQueryPrivateStoreOffer', 'Invoke-AzMarketplaceAnyPrivateStoreExistingOffer', 'Invoke-AzMarketplaceFetchPrivateStoreSubscription', 'Invoke-AzMarketplaceOfferPrivateStoreCollectionOfferUpsert', 'Invoke-AzMarketplaceQueryPrivateStoreUserOffer', 'Invoke-AzMarketplaceQueryRule', 'Invoke-AzMarketplaceQueryUserRule', 'New-AzMarketplacePrivateStore', 'New-AzMarketplacePrivateStoreCollection', 'New-AzMarketplacePrivateStoreCollectionOffer', 'Remove-AzMarketplacePrivateStoreCollection', 'Remove-AzMarketplacePrivateStoreCollectionOffer', 'Set-AzMarketplaceBulkPrivateStoreCollectionAction', 'Set-AzMarketplaceCollectionRule', 'Set-AzMarketplacePrivateStore', 'Set-AzMarketplacePrivateStoreCollection', 'Set-AzMarketplacePrivateStoreCollectionOffer', 'Update-AzMarketplacePrivateStoreCollection', 'Update-AzMarketplacePrivateStoreCollectionOffer'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Marketplace'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
