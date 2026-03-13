### Example 1: DataBoxCustomerDisk details in-memory object
```powershell
$dataAccount = New-AzDataBoxStorageAccountDetailsObject -StorageAccountId "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "XXXX XXXX" -EmailList @("emailId") -Phone "0000000000"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "XXXX XXXX" -StateOrProvince "XX" -Country "XX" -City "XXXX XXXX" -PostalCode "00000" -AddressType "Commercial"
$importDiskDetailsCollection = @{"XXXXXX"= @{ManifestFile = "xyz.txt"; ManifestHash = "xxxx"; BitLockerKey = "xxx"}}  

New-AzDataBoxCustomerDiskJobDetailsObject -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -ImportDiskDetailsCollection $importDiskDetailsCollection -ReturnToCustomerPackageDetailCarrierAccountNumber "00000"
```

```output
Action                                            :
ChainOfCustodySasKey                              :
ContactDetail                                     : {
                                                      "contactName": "XXXX XXXX",
                                                      "phone": "0000000000",
                                                      "emailList": [ "emailId" ]
                                                    }
CopyLogDetail                                     :
CopyProgress                                      :
DataCenterCode                                    :
DataExportDetail                                  :
DataImportDetail                                  : {{
                                                      "accountDetails": {
                                                        "dataAccountType": "StorageAccount",
                                                        "storageAccountId":
                                                    "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
                                                      }
                                                    }}
DatacenterAddress                                 : {
                                                    }
DeliverToDcPackageDetailCarrierName               :
DeliverToDcPackageDetailTrackingId                :
DeliveryPackage                                   : {
                                                    }
DeviceErasureDetail                               : {
                                                    }
EnableManifestBackup                              :
ExpectedDataSizeInTeraByte                        :
ExportDiskDetailsCollection                       : {
                                                    }
ImportDiskDetailsCollection                       : {
                                                      "XXXXXX": {
                                                        "manifestFile": "xyz.txt",
                                                        "manifestHash": "xxxx",
                                                        "bitLockerKey": "xxx"
                                                      }
                                                    }
JobStage                                          :
KeyEncryptionKey                                  : {
                                                    }
LastMitigationActionOnJob                         : {
                                                    }
Preference                                        : {
                                                    }
ReturnPackage                                     : {
                                                    }
ReturnToCustomerPackageDetailCarrierAccountNumber : 00000
ReturnToCustomerPackageDetailCarrierName          :
ReturnToCustomerPackageDetailTrackingId           :
ReverseShipmentLabelSasKey                        :
ReverseShippingDetail                             : {
                                                    }
ShippingAddress                                   : {
                                                      "streetAddress1": "XXXX XXXX",
                                                      "city": "XXXX XXXX",
                                                      "stateOrProvince": "XX",
                                                      "country": "XX",
                                                      "postalCode": "00000",
                                                      "addressType": "Commercial"
                                                    }
Type                                              : DataBoxCustomerDisk
```

DataBoxCustomerDisk details in-memory object