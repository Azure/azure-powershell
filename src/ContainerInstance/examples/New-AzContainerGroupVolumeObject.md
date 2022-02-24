### Example 1: Create a Azure File volume
```powershell
New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "******" -AsPlainText -Force)
```

```output
******

Name
----
myvolume
```

This command creates a Azure File volume.