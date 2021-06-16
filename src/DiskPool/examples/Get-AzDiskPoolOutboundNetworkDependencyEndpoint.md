### Example 1: List network dependency endpoints for a Disk pool
```powershell
PS C:\>  Get-AzDiskPoolOutboundNetworkDependencyEndpoint -DiskPoolName disk-pool-1 -ResourceGroupName storagepool-rg-test

Category
--------
Microsoft Event Hub
Microsoft Service Bus
Microsoft Storage
Microsoft Apt Mirror
```

The command lists all outbound network dependency endpoints for a Disk pool.

