### Example 1: Create an in-memory object for StorageApplianceConfigurationData.
```powershell
$password = ConvertTo-SecureString "1qaz@WSX" -AsPlainText

New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword $password -AdminCredentialsUsername username -RackSlot 1 -SerialNumber serialNumber -StorageApplianceName storageApplianceName
``` 
```output
RackSlot SerialNumber StorageApplianceName
-------- ------------ --------------------
1        serialNumber storageApplianceName
```

Create an in-memory object for StorageApplianceConfigurationData.
