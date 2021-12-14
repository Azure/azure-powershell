### Example 1: Update Inbound Endpoint by name (adding metadata)
```powershell
PS C:\> Update-AzDnsResolverInboundEndpoint  -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg -Metadata @{"value0" = "value1"}


Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0c000868-0000-0800-0000-604112230000"
```

This command updates Inbound Endpoint by name (adding metadata)

### Example 2: Update Inbound Endpoint via identity (adding metadata)
```powershell
PS C:\> $inputobject = Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg   
PS C:\>  Update-AzDnsResolverInboundEndpoint   -InputObject $inputobject -Metadata @{"value0" = "value1"}
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0c00e768-0000-0800-0000-604112af0000"

```

This command updates Inbound Endpoint via identity (adding metadata)

