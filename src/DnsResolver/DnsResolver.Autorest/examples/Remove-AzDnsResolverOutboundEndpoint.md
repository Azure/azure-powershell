### Example 1: Remove an outbound endpoint by name.
```powershell
Remove-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -ResourceGroupName powershell-test-rg -Name psdnsresolvername33nmy1fz
```
This command removes an outbound endpoint by name.

### Example 2: Remove an outbound endpoint by identity
```powershell
$inputObject = Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResourceGroup
Remove-AzDnsResolverOutboundEndpoint -InputObject $inputObject 
```

This command removes an outbound endpoint by identity.
