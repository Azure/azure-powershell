### Example 1: Remove Inbound Endpoint by name
```powershell
PS C:\> Remove-AzDnsResolverInboundEndpoint  -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg

PS C:\> 
```

This command removes Inbound Endpoint by name

### Example 2: Remove Inbound Endpoint via identity
```powershell
PS C:\> $inputobject = Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg

PS C:\>  Remove-AzDnsResolverInboundEndpoint -InputObject $inputObject
```

This command removes Inbound Endpoint via identity

