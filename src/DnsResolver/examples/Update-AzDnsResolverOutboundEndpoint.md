### Example 1: Update Outbound Endpoint by name (adding metadata)
```powershell
Update-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResourceGroup -Metadata @{"value0" = "value1"}
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "02001eab-0000-0800-0000-60e792500000"
```

This command updates Outbound Endpoint by name (adding metadata)

### Example 2: Update Outbound Endpoint via identity (adding metadata)
```powershell
$inputObject = Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResourceGroup
Update-AzDnsResolverOutboundEndpoint -InputObject $inputObject -Metadata @{"value0" = "value1"}
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "02001eab-0000-0800-0000-60e792500000"
```

This command updates Outbound Endpoint via identity (adding metadata)

