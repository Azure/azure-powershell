### Example 1: Controls a SessionHostProvisioning Operation on a HostPool
```powershell
Invoke-AzWvdControlSessionHostProvisioning -HostPoolName HostPoolName `
                            -ResourceGroupName resourceGroupName `
                            -SubscriptionId subscriptionId `
                            -CancelMessage cancelMessage
```

This command controls an ongoing sessionHostProvisioning operation on the given hostpool.
