### Example 1: Restart a Web PubSub resource
```powershell
PS C:\> Restart-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```


### Example 2: Restart a Web PubSub resource with identity
```powershell
PS C:\> $identity = @{ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

PS C:\> $identity | Restart-AzWebPubSub
```



