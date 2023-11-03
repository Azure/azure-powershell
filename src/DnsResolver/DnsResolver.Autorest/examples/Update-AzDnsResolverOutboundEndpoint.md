### Example 1: Update Outbound Endpoint by name (adding tag)
```powershell
Update-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResourceGroup -Tag @{"value0" = "value1"}
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "02001eab-0000-0800-0000-60e792500000"
```

This command updates Outbound Endpoint by name (adding tag)

### Example 2: Update Outbound Endpoint via identity (adding tag)
```powershell
$inputObject = Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResourceGroup
Update-AzDnsResolverOutboundEndpoint -InputObject $inputObject -Tag @{"value0" = "value1"}
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "02001eab-0000-0800-0000-60e792500000"
```

This command updates Outbound Endpoint via identity (adding tag)

