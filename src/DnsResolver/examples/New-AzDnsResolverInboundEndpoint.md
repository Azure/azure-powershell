### Example 1: Create  an Inbound Endpoint for DNS Resolver
```powershell
PS C:\>  $ipConfiguration = New-AzDnsResolverIPConfigurationObject -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname31ur3isx/subnets/pssubnetname311tqweg

PS C:\>  New-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg -IPConfiguration $ipConfiguration
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0b008451-0000-0800-0000-60402b960000"
```

This command creates an Inbound Endpoint for DNS Resolver.

### Example 2: Create  an Inbound Endpoint for DNS Resolver with Metadata
```powershell
PS C:\> New-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint1 -ResourceGroupName powershell-test-rg -IPConfiguration $ipConfiguration  -Metadata @{"key0" = "value0"}

Name                   Type                                            Etag
----                   ----                                            ----
sampleInboundEndpoint1 Microsoft.Network/dnsResolvers/inboundEndpoints "0b0071aa-0000-0800-0000-60406a2d0000"
```

This command creates an Inbound Endpoint for DNS Resolver with Metadata.

