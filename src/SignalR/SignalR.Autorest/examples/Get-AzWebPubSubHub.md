### Example 1: List hub settings of a Web PubSub resource.
```powershell
Get-AzWebPubSubHub -ResourceGroupName psdemo -ResourceName psdemo-wps
```

```output
Name     AnonymousConnectPolicy
----     ----------------------
testHub  deny
testHub2 deny
```

### Example 2: Get a Web PubSub hub setting.
```powershell
Get-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```



### Example 3: Get a Web PubSub hub setting via identity.
```powershell
$hubIdentity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id
HubName = 'testHub' }
$hubIdentity | Get-AzWebPubSubHub
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```



