### Example 1: List hub settings of a Web PubSub resource.
```powershell
PS C:\>  Get-AzWebPubSubHub -ResourceGroupName psdemo -ResourceName psdemo-wps

Name     AnonymousConnectPolicy
----     ----------------------
testHub  deny
testHub2 deny
```

### Example 2: Get a Web PubSub hub setting.
```powershell
PS C:\>  Get-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps

Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```



### Example 3: Get a Web PubSub hub setting via identity.
```powershell
PS C:\>  $hubIdentity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id
HubName = 'testHub' }
PS C:\>   $hubIdentity | Get-AzWebPubSubHub

Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```



