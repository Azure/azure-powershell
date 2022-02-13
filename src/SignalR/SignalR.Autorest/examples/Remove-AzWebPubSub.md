### Example 1: Remove a Web PubSub resource
```powershell
PS C:\> Remove-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```


### Example 2: Remove a Web PubSub resource via identity
```powershell
PS C:\> $identity = @{ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

PS C:\> $identity | Remove-AzWebPubSub
```



