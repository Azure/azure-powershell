### Example 1: List Inbound Endpoints under a DNS Resolver
```powershell
Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -ResourceGroupName powershell-test-rg
```

```output
Name                   Type                                            Etag
----                   ----                                            ----
sampleInboundEndpoint  Microsoft.Network/dnsResolvers/inboundEndpoints "0b008451-0000-0800-0000-60402b960000"
sampleInboundEndpoint1 Microsoft.Network/dnsResolvers/inboundEndpoints "0b0071aa-0000-0800-0000-60406a2d0000"
```

This command lists Inbound Endpoints under a DNS Resolver

### Example 2: Get single Inbound Endpoint by name
```powershell
Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0b008451-0000-0800-0000-60402b960000"
```

This command gets single Inbound Endpoint by name
