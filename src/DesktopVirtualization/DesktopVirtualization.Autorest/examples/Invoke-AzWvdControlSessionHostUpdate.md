### Example 1: Controls a SessionHostUpdate Operation on a HostPool
```powershell
Invoke-AzWvdControlSessionHostUpdate -HostPoolName HostPoolName `
                            -ResourceGroupName resourceGroupName `
                            -Action 'Cancel' `
                            -SubscriptionId subscriptionId `
                            -CancelMessage cancelMessage
```

This command controls an ongoing sessionHostUpdate operation on the given hostpool.
