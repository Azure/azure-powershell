### Example 1: Run read-only health check command on storage appliance
```powershell
$command = @{
    command = "health"
    arguments = @()
}
Start-AzNetworkCloudStorageApplianceReadCommand -StorageApplianceName "storageApplianceName" -ResourceGroupName "resourceGroupName" -Command @($command) -LimitTimeSecond 60
```

```output
True
```

This example runs a read-only health check command on the specified storage appliance with a 60-second timeout.

### Example 2: Run multiple read-only diagnostic commands on storage appliance
```powershell
$command1 = @{
    command = "readiness"
    arguments = @()
}
$command2 = @{
    command = "logs"
    arguments = @("--level", "info")
}
Start-AzNetworkCloudStorageApplianceReadCommand -StorageApplianceName "storageApplianceName" -ResourceGroupName "resourceGroupName" -Command @($command1, $command2) -LimitTimeSecond 120
```

```output
True
```

This example runs multiple read-only diagnostic commands on the storage appliance with a 120-second timeout.

