### Example 1: In-memory object for export job transfer configuration 
```powershell
New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
```

Create a in-memory object for export jobs TransferConfiguration 

