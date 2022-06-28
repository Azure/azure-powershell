### Example 1: Create a Azure File volume
```powershell
New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "******" -AsPlainText -Force)
```

```output
Name
----
myvolume
```

This command creates a Azure File volume.

### Example 2: Create an empty directory volume
```powershell
New-AzContainerGroupVolumeObject -Name "emptyvolume" -EmptyDir @{} | fl
```

```output
AzureFileReadOnly           : 
AzureFileShareName          : 
AzureFileStorageAccountKey  : 
AzureFileStorageAccountName : 
EmptyDir                    : {
                              }
GitRepoDirectory            : 
GitRepoRepository           : 
GitRepoRevision             : 
Name                        : emptyvolume
Secret                      : {
                              }
```

This command creates an empty directory volume.