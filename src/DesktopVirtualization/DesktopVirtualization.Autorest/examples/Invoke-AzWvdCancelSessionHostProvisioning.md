### Example 1: Cancels a SessionHostProvisioning Operation on a HostPool
```powershell
Invoke-AzWvdCancelSessionHostProvisioning -HostPoolName HostPoolName `
                            -ResourceGroupName resourceGroupName `
                            -SubscriptionId subscriptionId `
                            -CancelMessage cancelMessage
```

This command cancels an ongoing sessionHostProvisioning operation on the given hostpool.
