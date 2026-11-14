### Example 1: Test a stored configuration
```powershell
$configuration = Get-AzStorageBlobAccessPointConfiguration -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Name "myaccesspoint"
Test-AzStorageBlobAccessPointConfigurationConnection -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -BlobAccessPointConfigurationName $configuration.Name -UniqueId $configuration.UniqueId
```

Tests the connection using the stored configuration's current unique ID and returns connection-test details.
