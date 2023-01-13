### Example 1: Create or update storage for a managedEnvironment.
```powershell
New-AzStorageAccount -ResourceGroupName azpstest_gp -AccountName azpstestsa -Location canadacentral -SkuName Standard_GRS
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azpstest_gp -AccountName azpstestsa).Value[0]

New-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azpstest_gp -StorageName azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azpstest_gp
```

Create or update storage for a managedEnvironment.