### Example 1: Create a in-memory object for DataBoxHeavyJobDetails 
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

New-AzDataBoxHeavyJobDetailsObject -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword $password -ExpectedDataSizeInTeraByte 10
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
                                 "dataAccountType": "StorageAccount"
                               }
                             }}
DatacenterAddress          : {
                             }
DeliveryPackage            : {
                             }
DeviceErasureDetail        : {
                             }
DevicePassword             :
ExpectedDataSizeInTeraByte : 10
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
Type                       : DataBoxHeavy
```
Create a in-memory object for DataBoxHeavyJobDetails 