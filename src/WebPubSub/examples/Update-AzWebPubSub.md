### Example 1: Update a Web PubSub resource
```powershell
PS C:\> $wps = Update-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps `
-IdentityType SystemAssigned -LiveTraceEnabled true `
-LiveTraceCategory @{ Name='ConnectivityLogs' ; Enabled = 'true' }, @{ Name='MessageLogs' ; Enabled = 'true' }

Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1

PS C:\> $wps | format-list

DisableAadAuth               : False
DisableLocalAuth             : False
EnableTlsClientCert          : False
ExternalIP                   : 20.62.134.186
HostName                     : psdemo-wps.webpubsub.azure.com
......
Version                      : 1.0
```


### Example 2: Update a Web PubSub resource via identity
```powershell
PS C:\> $identity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }
PS C:\> $identity | Update-AzWebPubSub -EnableTlsClientCert

PS C:\> $wps | format-list

DisableAadAuth               : False
DisableLocalAuth             : False
EnableTlsClientCert          : True
ExternalIP                   : 20.62.134.186
HostName                     : psdemo-wps.webpubsub.azure.com
......
Version                      : 1.0
```

The example constructs a hash table representing the identity of a Web PubSub resource, and then it pipes the identity object to the `Update` cmdlet. At last it pipes the result of `Update` cmdlet to `Format-List` to see all the property values.
