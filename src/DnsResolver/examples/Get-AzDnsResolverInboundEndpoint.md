### Example 1: List Inbound Endpoints under a DNS Resolver
```powershell
PS C:\> Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -ResourceGroupName powershell-test-rg

Name                   Type                                            Etag
----                   ----                                            ----
sampleInboundEndpoint  Microsoft.Network/dnsResolvers/inboundEndpoints "0b008451-0000-0800-0000-60402b960000"
sampleInboundEndpoint1 Microsoft.Network/dnsResolvers/inboundEndpoints "0b0071aa-0000-0800-0000-60406a2d0000"
```

{{ Add description here }}

### Example 2: Get single Inbound Endpoint by name
```powershell
PS C:\> Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg

Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0b008451-0000-0800-0000-60402b960000"
```

This command gets single Inbound Endpoint by name
