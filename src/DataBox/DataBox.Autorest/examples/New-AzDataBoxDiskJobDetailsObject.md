### Example 1: DataBoxDisk details in-memory object 
```powershell
$contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
$ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

New-AzDataBoxDiskJobDetailsObject -Type "DataBoxDisk"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -Passkey $password -PreferredDisk @{"8" = 8; "4" = 2} -ExpectedDataSizeInTeraByte 18
```

```output
Action ChainOfCustodySasKey ExpectedDataSizeInTeraByte ReverseShipmentLabelSasKey Type        Passkey        
------ -------------------- -------------------------- -------------------------- ----        -------        
                            18                                                    DataBoxDisk $password
```
DataBoxDisk details in-memory object 


