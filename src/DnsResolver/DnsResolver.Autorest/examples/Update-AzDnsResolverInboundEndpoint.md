### Example 1: Update Inbound Endpoint by name (adding tag)
```powershell
Update-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg -Tag @{"value0" = "value1"}
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0c000868-0000-0800-0000-604112230000"
```

This command updates Inbound Endpoint by name (adding tag)

### Example 2: Update Inbound Endpoint via identity (adding tag)
```powershell
$inputobject = Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg
Update-AzDnsResolverInboundEndpoint -InputObject $inputobject -Tag @{"value0" = "value1"}
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0c00e768-0000-0800-0000-604112af0000"
```

This command updates Inbound Endpoint via identity (adding tag)

