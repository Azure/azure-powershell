### Example 1: Creates a databox job detail in memory object 
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

New-AzDataBoxJobDetailsObject -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
```

```output
Action                     :
ChainOfCustodySasKey       :
ContactDetail              : {
                               "contactName": "random",
                               "phone": "1234567891",
                               "emailList": [ "emailId" ]
                             }
CopyLogDetail              :
CopyProgress               :
DataCenterCode             :
DataExportDetail           :
DataImportDetail           : {{
                               "accountDetails": {
                                 "dataAccountType": "StorageAccount",
                                 "storageAccountId": "/subscriptions/YourSubscriptionId/resourceGroups/YourResourceGroup/providers/Microsoft.Storage/storageAccounts/YourStorageAccount"
                               }
                             }}
DatacenterAddress          : {
                             }
DeliveryPackage            : {
                             }
DeviceErasureDetail        : {
                             }
DevicePassword             :
ExpectedDataSizeInTeraByte :
JobStage                   :
KeyEncryptionKey           : {
                             }
LastMitigationActionOnJob  : {
                             }
Preference                 : {
                             }
ReturnPackage              : {
                             }
ReverseShipmentLabelSasKey :
ReverseShippingDetail      : {
                             }
ShippingAddress            : {
                               "streetAddress1": "101 TOWNSEND ST",
                               "city": "San Francisco",
                               "stateOrProvince": "CA",
                               "country": "US",
                               "postalCode": "94107",
                               "addressType": "Commercial"
                             }
Type                       : DataBox
```

Create a in-memory object for DataBoxJobDetails 