### Example 1: Remove a hub setting.
```powershell
PS C:\>  Remove-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps
```


### Example 2: Remove a hub setting via identity.
```powershell
PS C:\> $hubIdentity = @{HubName = 'testHub'
ResourceGroupName='psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id}
PS C:\> $hubIdentity | Remove-AzWebPubSubHub
```

The example first constructs a hash table standing for the hub identity. Then it passes the identity through pipeline to the `Remove-AzWebPubSubHub` cmdlet.
