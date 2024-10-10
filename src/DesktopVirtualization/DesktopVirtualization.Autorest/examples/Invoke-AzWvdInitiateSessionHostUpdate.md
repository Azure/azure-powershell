### Example 1: Starts a SessionHostUpdate Operation on a HostPool
```powershell
Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -UpdateDeleteOriginalVm `
          -UpdateMaxVmsRemoved 4 `
          -UpdateLogOffDelayMinute 5 `
          -UpdateLogOffMessage "logging off for hostpool update."
```

This command starts a sessionHostUpdate operation on the given hostpool.
