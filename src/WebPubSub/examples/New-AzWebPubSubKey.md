### Example 1: Regenerate the primary access key of a Web PubSub resource
```powershell
PS C:\>  New-AzWebPubSubKey  -ResourceGroupName psdemo -ResourceName psdemo-wps -KeyType 'Primary'
```


### Example 2: Regenerate the primary access key of a Web PubSub resource via identity
```powershell
PS C:\>  $identity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }
PS C:\> $identity | New-AzWebPubSubKey -KeyType Primary
```



