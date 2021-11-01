### Example 1: Create a in-memory object for DataBoxHeavyJobDetails 
```powershell
PS C:\> $details = New-AzDataBoxHeavyJobDetailsObject -Type "DataBoxHeavy"  -DataImportDetail  @(@{AccountDetail=$dataAccount; AccountDetailDataAccountType = "StorageAccount"} ) -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -DevicePassword "randm@423jarABC" -ExpectedDataSizeInTeraByte 10
```

Create a in-memory object for DataBoxHeavyJobDetails 

