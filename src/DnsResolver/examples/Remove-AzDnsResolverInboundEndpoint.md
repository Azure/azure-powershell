### Example 1: Remove Inbound Endpoint by name
```powershell
Remove-AzDnsResolverInboundEndpoint  -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg
```

This command removes Inbound Endpoint by name

### Example 2: Remove Inbound Endpoint via identity
```powershell
$inputobject = Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg

Remove-AzDnsResolverInboundEndpoint -InputObject $inputObject
```

This command removes Inbound Endpoint via identity

