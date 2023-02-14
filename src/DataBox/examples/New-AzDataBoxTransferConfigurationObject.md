### Example 1: In-memory object for export job transfer configuration 
```powershell
<<<<<<< HEAD
New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
=======
PS C:\>  $transferConfigurationType = New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Create a in-memory object for export jobs TransferConfiguration 

