### Example 1: Starts a SessionHostUpdate Operation on a HostPool
```powershell
Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -deleteOriginalVm `
          -maxVmsRemoved 4`
          -logOffDelayMinutes 5`
          -logOffMessage "logging off for hostpool update."
```

This command starts a sessionHostUpdate operation on the given hostpool.



