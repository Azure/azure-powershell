### Example 1: Remove an outbound endpoint by name.
```powershell
PS C:\> Remove-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -ResourceGroupName powershell-test-rg -Name psdnsresolvername33nmy1fz
```
This command removes an outbound endpoint by name.

### Example 2: Remove an outbound endpoint by identity
```powershell
PS C:\> $inputObject = Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResourceGroup
PS C:\> Remove-AzDnsResolverOutboundEndpoint -InputObject $inputObject 
```

This command removes an outbound endpoint by identity.
