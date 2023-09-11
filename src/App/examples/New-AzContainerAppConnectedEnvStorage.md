### Example 1: Create storage for a connectedEnvironment.
```powershell
New-AzStorageAccount -ResourceGroupName azps_test_group_app -AccountName azpstestsa -Location canadacentral -SkuName Standard_GRS
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]

New-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -StorageName azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Create storage for a connectedEnvironment.