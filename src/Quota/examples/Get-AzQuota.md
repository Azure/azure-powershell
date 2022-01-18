### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"

Name                                                LimitObjectType Unit  ETag
----                                                --------------- ----  ----
VirtualNetworks                                     LimitValue      Count
StaticPublicIPAddresses                             LimitValue      Count
NetworkSecurityGroups                               LimitValue      Count
PublicIPAddresses                                   LimitValue      Count
CustomIpPrefixes                                    LimitValue      Count
PublicIpPrefixes                                    LimitValue      Count
NatGateways                                         LimitValue      Count 
NetworkInterfaces                                   LimitValue      Count
PrivateEndpoints                                    LimitValue      Count
PrivateEndpointRedirectMaps                         LimitValue      Count
LoadBalancers                                       LimitValue      Count
PrivateLinkServices                                 LimitValue      Count
ApplicationGateways                                 LimitValue      Count
RouteTables                                         LimitValue      Count
RouteFilters                                        LimitValue      Count
NetworkWatchers                                     LimitValue      Count
PacketCaptures                                      LimitValue      Count
ApplicationSecurityGroups                           LimitValue      Count
DdosProtectionPlans                                 LimitValue      Count
DdosCustomPolicies                                  LimitValue      Count
ServiceEndpointPolicies                             LimitValue      Count
NetworkIntentPolicies                               LimitValue      Count
StandardSkuLoadBalancers                            LimitValue      Count 
StandardSkuPublicIpAddresses                        LimitValue      Count
DnsServersPerVirtualNetwork                         LimitValue      Count
CustomDnsServersPerP2SVpnGateway                    LimitValue      Count
SubnetsPerVirtualNetwork                            LimitValue      Count
IPConfigurationsPerVirtualNetwork                   LimitValue      Count
PeeringsPerVirtualNetwork                           LimitValue      Count
SecurityRulesPerNetworkSecurityGroup                LimitValue      Count
SecurityRulesPerNetworkIntentPolicy                 LimitValue      Count
RoutesPerNetworkIntentPolicy                        LimitValue      Count 
SecurityRuleAddressesOrPortsPerNetworkSecurityGroup LimitValue      Count
InboundRulesPerLoadBalancer                         LimitValue      Count
FrontendIPConfigurationPerLoadBalancer              LimitValue      Count
OutboundRulesPerLoadBalancer                        LimitValue      Count
RoutesPerRouteTable                                 LimitValue      Count
RoutesWithServiceTagPerRouteTable                   LimitValue      Count
SecondaryIPConfigurationsPerNetworkInterface        LimitValue      Count
InboundNatOrLbRulesPerNetworkInterface              LimitValue      Count
RouteFilterRulesPerRouteFilter                      LimitValue      Count
RouteFiltersPerExpressRouteBgpPeering               LimitValue      Count
MinPublicIpInterNetworkPrefixLength                 LimitValue      Count
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -ResourceName "MinPublicIpInterNetworkPrefixLength"

Name                                LimitObjectType Unit  ETag
----                                --------------- ----  ----
MinPublicIpInterNetworkPrefixLength LimitValue      Count
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}