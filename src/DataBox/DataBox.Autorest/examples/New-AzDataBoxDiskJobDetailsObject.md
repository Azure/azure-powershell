### Example 1: DataBoxDisk details in-memory object 
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

New-AzDataBoxDiskJobDetailsObject -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Passkey $password -PreferredDisk @{"8" = 8; "4" = 2} -ExpectedDataSizeInTeraByte 18
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
DisksAndSizeDetail         : {
                             }
ExpectedDataSizeInTeraByte : 18
GranularCopyLogDetail      :
GranularCopyProgress       :
JobStage                   :
KeyEncryptionKey           : {
                             }
LastMitigationActionOnJob  : {
                             }
Passkey                    :
Preference                 : {
                             }
PreferredDisk              : {
                               "4": 2,
                               "8": 8
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
Type                       : DataBoxDisk
```
DataBoxDisk details in-memory object