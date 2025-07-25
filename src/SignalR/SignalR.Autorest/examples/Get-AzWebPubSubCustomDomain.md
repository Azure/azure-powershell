### Example 1: List all the custom domains of a Azure Web PubSub resource
```powershell
Get-AzWebPubSubCustomDomain -ResourceGroupName rg -ResourceName wps
```

```output
Name     DomainName                                    ProvisioningState
----     ----------                                    -----------------
mydomain wps.manual-test.dev.signalr.azure.com Succeeded
```

We can see this Web PubSub resource only contains one custom domain.

### Example 2: Get a custom domain by its name
```powershell
Get-AzWebPubSubCustomDomain -ResourceGroupName rg -ResourceName wps -Name mydomain
```

```output
Name     DomainName                                    ProvisioningState
----     ----------                                    -----------------
mydomain wps.manual-test.dev.signalr.azure.com Succeeded
```



### Example 2: Get a custom domain by its identity
```powershell
$customDomain = Get-AzWebPubSubCustomDomain -ResourceGroupName rg -ResourceName wps -Name mydomain
$customDomain | Get-AzWebPubSubCustomDomain
```

```output
Name     DomainName                                    ProvisioningState
----     ----------                                    -----------------
mydomain wps.manual-test.dev.signalr.azure.com Succeeded
```


