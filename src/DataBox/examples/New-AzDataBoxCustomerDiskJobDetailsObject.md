### Example 1: DataBoxCustomerDisk details in-memory object
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -DataAccountType "StorageAccount" -StorageAccountId "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "XXXX XXXX" -EmailList @("emailId") -Phone "0000000000"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "XXXX XXXX" -StateOrProvince "XX" -Country "XX" -City "XXXX XXXX" -PostalCode "00000" -AddressType "Commercial"

New-AzDataBoxCustomerDiskJobDetailsObject -Type "DataBoxCustomerDisk" -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -ImportDiskDetailsCollection $importDiskDetailsCollection -ReturnToCustomerPackageDetailCarrierAccountNumber "00000"
```

DataBoxCustomerDisk details in-memory object
