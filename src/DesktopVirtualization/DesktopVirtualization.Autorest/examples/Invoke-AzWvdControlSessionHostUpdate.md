### Example 1: Controls a SessionHostUpdate Operation on a HostPool
```powershell
Invoke-AzWvdControlSessionHostUpdate -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -Action "Cancel"
          -cancelMessage "Stopping hostpool update operation."
```

This command controls and ongoing sessionHostUpdate operation on the given hostpool.
