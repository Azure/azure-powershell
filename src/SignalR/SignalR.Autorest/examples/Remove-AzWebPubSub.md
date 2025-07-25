### Example 1: Remove a Web PubSub resource
```powershell
Remove-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```


### Example 2: Remove a Web PubSub resource via identity
```powershell
$identity = @{ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

$identity | Remove-AzWebPubSub
```



