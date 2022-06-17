### Example 1: Restart a Web PubSub resource
```powershell
Restart-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```


### Example 2: Restart a Web PubSub resource with identity
```powershell
$identity = @{ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

$identity | Restart-AzWebPubSub
```



