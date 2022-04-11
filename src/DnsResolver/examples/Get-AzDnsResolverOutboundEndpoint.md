### Example 1: List all outbound endpoints under the DNS resolver in a resouce group 
```powershell
Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -ResourceGroupName sampleResouceGroup
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "0a001a28-0000-0800-0000-60e3846a0000"
sampleOutbound2 Microsoft.Network/dnsResolvers/outboundEndpoints "0a001a27-0000-0800-0000-60e3846a0000"
```
This command gets all outbound endpoints under the DNS resolver in a resouce group.

### Example 2: Get single outbound endpoint by name 
```powershell
Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResouceGroup
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "0a001a28-0000-0800-0000-60e3846a0000"
```

This command gets an outbound endpoint under the DNS resolver in a resouce group.

