### Example 1: Get backup instance extension routing
```powershell
$diskARMID = "subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxx/resourceGroups/testRG/providers/Microsoft.Compute/disks/testDisk"
Get-AzDataProtectionBackupInstancesExtensionRouting -ResourceId $diskARMID
```

This command gets a list of backup instances associated with a tracked resource. To execute the cmdlet, We pass the datasource ARM ID to the parameter ResourceId.
