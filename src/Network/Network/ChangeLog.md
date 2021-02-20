<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
--->

## Upcoming Release
* Registered 8 new privatelink configurations
    - `Microsoft.Automation/automationAccounts`
    - `Microsoft.Compute/diskAccesses`
    - `Microsoft.EventHub/namespaces`
    - `Microsoft.Media/mediaservices`
    - `Microsoft.Search/searchServices`
    - `Microsoft.ServiceBus/namespaces`
    - `Microsoft.Synapse/workspaces`
    - `Microsoft.Purview/accounts`
* Updated the privatelink configurations of 'Microsoft.Keyvault/vaults' and 'Microsoft.Web/sites' to higher quality ones

## Version 4.6.0
* Added new cmdlets to replace old product name `virtual router` with new name `route server` in the future.
    - `New-AzRouteServer`
    - `Get-AzRouteServer`
    - `Remove-AzRouteServer`
    - `Update-AzRouteServer`
    - `Get-AzRouteServerPeer`
    - `Add-AzRouteServerPeer`
    - `Update-AzRouteServerPeer`
    - `Remove-AzRouteServerPeer`
    - Added deprecation attribute warning to the old cmdlets.
* Bug fix in ExpressRouteLink MacSecConfig. Added new property `SciState` to `PSExpressRouteLinkMacSecConfig`
* Updated format list and format table views for Get-AzVirtualNetworkGatewayConnectionIkeSa
* Updated `set-azExpressRouteGateway` to allow parameter -MinScaleUnits without specifying -MaxScaleUnits
* Updated cmdlets to enable setting of VpnLinkConnectionMode on VpnSiteLinkConnections.
    - `New-AzVpnSiteLinkConnection`
    - `Update-AzVpnConnection`

## Version 4.5.0
* Added new cmdlets for CRUD of VpnGatewayNATRule.
    - `New-AzAzVpnGatewayNatRule`
    - `Update-AzAzVpnGatewayNatRule`
    - `Get-AzAzVpnGatewayNatRule`
    - `Remove-AzAzVpnGatewayNatRule`	
* Updated cmdlets to set NATRule on VpnGateway resource and associate it with VpnSiteLinkConnection resource.
    - `New-AzVpnGateway`
    - `Update-AzVpnGateway`	
    - `New-AzVpnSiteLinkConnection`
* Updated cmdlets to enable setting of ConnectionMode on Virtual Network Gateway Connections.
    - `New-AzVirtualNetworkGatewayConnection`
    - `Set-AzVirtualNetworkGatewayConnection`
* Updated `New-AzFirewallPolicyApplicationRule` cmdlet:
    - Added parameter TargetUrl
    - Added parameter TerminateTLS
* Added new cmdlets for Azure Firewall Premium Features
    - `New-AzFirewallPolicyIntrusionDetection`
    - `New-AzFirewallPolicyIntrusionDetectionBypassTraffic`
    - `New-AzFirewallPolicyIntrusionDetectionSignatureOverride`
* Updated New-AzFirewallPolicy cmdlet:
    - Added parameter -SkuTier
    - Added parameter -Identity
    - Added parameter -UserAssignedIdentityId
    - Added parameter -IntrusionDetection
    - Added parameter -TransportSecurityName
    - Added parameter -TransportSecurityKeyVaultSecretId
* Added new cmdlet to fetch IKE Security Associations for Virtual Network Gateway Connections.
    - `Get-AzVirtualNetworkGatewayConnectionIkeSa`
* Added multiple Authentication support for p2sVpnGateway
    - Updated New-AzVpnServerConfiguration and Update-AzVpnServerConfiguration to allow multiple authentication parameters to be set.
* Updated `New-AzVpnGateway` and `New-AzP2sVpnGateway` cmdlet:
    - Added parameter EnableRoutingPreferenceInternetFlag

## Version 4.4.0
* Fixed issue in remove peering and connection cmdlet for ExpressRouteCircuit scenario
    - `Remove-AzExpressRouteCircuitPeeringConfig` and `Remove-AzExpressRouteCircuitConnectionConfig`

## Version 4.3.0
* Updated below cmdlet 
    - `New-AzLoadBalancerFrontendIpConfigCommand`, `Set-AzLoadBalancerFrontendIpConfigCommand`, `Add-AzLoadBalancerFrontendIpConfigCommand`:
        - Added PublicIpAddressPrefix property
        - Added PublicIpAddressPrefixId property
* Added new properties to the following cmdlets to allow for global load balancing
    - `New-AzLoadBalancer`:
        - Added Sku Tier property
    - `New-AzPuplicIpAddress`:
        - Added Sku Tier property
    - `New-AzPublicIpPrefix`:
        - Added Sku Tier property
    - `New-AzLoadBalancerBackendAddressConfig`:
        - Added LoadBalancerFrontendIPConfigurationId property
* Updated planning to deprecate warnings for the following cmdlets
    -`New-AzVirtualHubRoute`
    -`New-AzVirtualHubRouteTable`
    -`Add-AzVirtualHubRoute`
    -`Add-AzVirtualHubRouteTable`
    -`Get-AzVirtualHubRouteTable`
    -`Remove-AzVirtualHubRouteTable`
* Added planning to deprecate warnings on the argument `RouteTable` for the following cmdlets
    -`New-AzVirtualHub`
    -`Set-AzVirtualHub`
    -`Update-AzVirtualHub`
* Made arguments `-MinScaleUnits` and `-MaxScaleUnits` optional in `Set-AzExpressRouteGateway`
* Added new cmdlets to support Mutual Authentication and SSL Profiles on Application Gateway
    - `Get-AzApplicationGatewayClientAuthConfiguration`
    - `New-AzApplicationGatewayClientAuthConfiguration`
    - `Remove-AzApplicationGatewayClientAuthConfiguration`
    - `Set-AzApplicationGatewayClientAuthConfiguration`
    - `Add-AzApplicationGatewayTrustedClientCertificate` 
    - `Get-AzApplicationGatewayTrustedClientCertificate` 
    - `New-AzApplicationGatewayTrustedClientCertificate` 
    - `Remove-AzApplicationGatewayTrustedClientCertificate` 
    - `Set-AzApplicationGatewayTrustedClientCertificate`
    - `Add-AzApplicationGatewaySslProfile`
    - `Get-AzApplicationGatewaySslProfile`
    - `New-AzApplicationGatewaySslProfile`
    - `Remove-AzApplicationGatewaySslProfile`
    - `Set-AzApplicationGatewaySslProfile`
    - `Get-AzApplicationGatewaySslProfilePolicy`
    - `Remove-AzApplicationGatewaySslProfilePolicy`
    - `Set-AzApplicationGatewaySslProfilePolicy`
* Added new parameter 'Priority' to support Rule Priority in Application Gateway RequestRoutingRule for the below cmdlets
    - `Add-AzApplicationGatewayRequestRoutingRule`
    - `New-AzApplicationGatewayRequestRoutingRule`
    - `Set-AzApplicationGatewayRequestRoutingRule`

## Version 4.2.0
* Added warning messages for upcoming breaking change for Virtual Router Peer Routes
    - `Get-AzVirtualRouterPeerLearnedRoute`
    - `Get-AzVirtualRouterPeerAdvertisedRoute`
* Added new cmdlet for virtual router
    - `Update-AzVirtualRouter`: to allow branch to branch traffic
* Updated New-AzFirewallPolicyNatRule cmdlet:
    - Added parameter Translated FQDN

## Version 4.1.0
* [Breaking Change] Removed parameter `HostedSubnet` and added `Subnet` instead
* Added new cmdlets for Virtual Router Peer Routes
    - `Get-AzVirtualRouterPeerLearnedRoute`
    - `Get-AzVirtualRouterPeerAdvertisedRoute`
* Updated New-AzFirewall cmdlet:
    - Added parameter `-SkuTier`
    - Added parameter `-SkuName` and made Sku as Alias for this
    - Removed parameter `-Sku`
* [Breaking Change] Made `Connectionlink` argument mandatory in `Start-AzVpnConnectionPacketCapture` and `Stop-AzVpnConnectionPacketCapture`
* [Breaking Change] Updated `New-AzNetworkWatcherConnectionMonitorEndPointObject` to remove parameter `-Filter`
* [Breaking Change] Replaced `New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject` cmdlet with `New-AzNetworkWatcherConnectionMonitorEndpointScopeItemObject`
* Updated `New-AzNetworkWatcherConnectionMonitorEndPointObject` cmdlet:
	- Added parameter `-Type`
	- Added parameter `-CoverageLevel`
	- Added parameter `-Scope`
* Updated `New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject` cmdlet with new parameter `-DestinationPortBehavior` 
    
## Version 3.5.0
* Added Office365 Policy to VPNSite Resource
    - `New-AzO365PolicyProperty`
* Added example to New-AzVirtualHubVnetConnection
    - `Example details how to create a new routing config and static routes and apply it to a connection`
* Added example to New-AzVHubRoute
    - `Example details how to set static route on HubVnet connection`
    
## Version 3.4.0
* [Breaking Change] Updated below cmdlets to align resource virtual router and virtual hub
    - `New-AzVirtualRouter`: 
        - Added -HostedSubnet parameter to support IP configuration child resource
        - deleted -HostedGateway and -HostedGatewayId
    - `Get-AzVirtualRouter`:
        - Added subscription level parameter set
    - `Remove-AzVirtualRouter`
    - `Add-AzVirtualRouterPeer`
    - `Get-AzVirtualRouterPeer`
    - `Remove-AzVirtualRouterPeer`
* Added new cmdlet for Azure Express Route Port
    - `New-AzExpressRoutePortLOA`
* Added RemoteBgpCommunities property to the VirtualNetwork Peering Resource
* Modified the warning message for `New-AzLoadBalancerFrontendIpConfig`, `New-AzPublicIpAddress` and `New-AzPublicIpPrefix`.
* Added VpnGatewayIpConfigurations to `Get-AzVpnGateway` output
* Fixed bug for `Set-AzApplicationGatewaySslCertificate` [#9488]
* Added `AllowActiveFTP` parameter to `AzureFirewall`
* Updated below commands for feature: Enable internet security set/remove on VirtualWan P2SVpnGateway.
- Updated `New-AzP2sVpnGateway`: Added optional switch parameter `EnableInternetSecurityFlag` for customers to set true to enable internet security on P2SVpnGateway, which will be applied for Point to site clients.
- Updated `Update-AzP2sVpnGateway`: Added optional switch parameters `EnableInternetSecurityFlag` or `DisableInternetSecurityFlag` for customers to set true/false to enable/disable internet security on P2SVpnGateway, which will be applied for Point to site clients.
* Added new cmdlet `Reset-AzP2sVpnGateway` for customers to reset/reboot their VirtualWan P2SVpnGateway for troubleshooting.
* Added new cmdlet `Reset-AzVpnGateway` for customers to reset/reboot their VirtualWan VpnGateway for troubleshooting.
* Updated `Set-AzVirtualNetworkSubnetConfig`
    - Set NSG and Route Table properties of subnet to null if explicitly set in parameters [#1548][#9718]
* [Breaking Change] Deprecated a switch parameter in below cmdlets
    - `New-AzFirewall`:
        - Deprecated `-DnsProxyNotRequiredForNetworkRule` switch paramemter
    - `New-AzFirewallPolicyDnsSetting`:
        - Deprecated `-ProxyNotRequiredForNetworkRule` switch parameter

## Version 3.3.0
* Added support for AddressPrefixType parameter to `Remove-AzExpressRouteCircuitConnectionConfig`
* Added non-breaking changes: PeerAddressType functionality for Private Peering in `Remove-AzExpressRouteCircutPeeringConfig`.
* Code changed to ignore case for AddressPrefixType and PeerAddressType parameter.
* Modified the warning message for `New-AzLoadBalancerFrontendIpConfig`, `New-AzPublicIpAddress` and `New-AzPublicIpPrefix`.

## Version 3.2.0
* Fixed parameters swap in VWan HubVnet connection
* Added new cmdlets for Azure Network Virtual Appliance Sites
    - `Get-AzVirtualApplianceSite`
    - `New-AzVirtualApplianceSite`
    - `Remove-AzVirtualApplianceSite`
    - `Update-AzVirtualApplianceSite`
    - `New-AzOffice365PolicyProperty`
* Added new cmdlets for Azure Network Virtual Appliance
    - `Get-AzNetworkVirtualAppliance`
    - `New-AzNetworkVirtualAppliance`
    - `Remove-AzNetworkVirtualAppliance`
    - `Update-AzNetworkVirtualAppliance`
    - `Get-AzNetworkVirtualApplianceSku`
    - `New-AzVirtualApplianceSkuProperty`
* Added new cmdlets for VirtualWan
    - `Start-AzVpnGatewayPacketCapture`
    - `Stop-AzVpnGatewayPacketCapture`
    - `Start-AzVpnConnectionPacketCapture`
    - `Stop-AzVpnConnectionPacketCapture`
* Onboard Application Gateway to Private Link Common Cmdlets
* Onboard StorageSync to Private Link Common Cmdlets
* Onboarded SignalR to Private Link Common Cmdlets

## Version 3.1.0
* Added support for AddressPrefixType parameter to `Remove-AzExpressRouteCircuitConnectionConfig`
* Added new cmdlets for Azure FirewallPolicy
    - `New-AzFirewallPolicyDnsSetting`
    - Support for Destination FQDN in Network Rules for Firewall Policy
* Added support for backend address pool operations
    - `New-AzLoadBalancerBackendAddressConfig`
    - `New-AzLoadBalancerBackendAddressPool`
    - `Set-AzLoadBalancerBackendAddressPool`
    - `Remove-AzLoadBalancerBackendAddressPool`
    - `Get-AzLoadBalancerBackendAddressPool`
* Added name validation for `New-AzIpGroup`
* Added new cmdlets for Azure FirewallPolicy
    - `New-AzFirewallPolicyThreatIntelWhitelist`
* Updated below commands for feature: Custom dns servers set/remove on VirtualWan P2SVpnGateway.
    - Updated New-AzP2sVpnGateway: Added optional parameter `-CustomDnsServer` for customers to specify their dns servers to set on P2SVpnGateway, which can be used by Point to site clients.
    - Updated Update-AzP2sVpnGateway: Added optional parameter `-CustomDnsServer` for customers to specify their dns servers to set on P2SVpnGateway, which can be used by Point to site clients.
* Updated `Update-AzVpnGateway`
    - Added optional parameter `-BgpPeeringAddress` for customers to specify their custom bgps to set on VpnGateway.
* Added new cmdlet to support resetting the routing state of a VirtualHub resource:
    - `Reset-AzHubRouter`
* Updated below things based on recent swagger change for Firewall Policy
    - Changes names for RuleGroup, RuleCollectionGroup and RuleType
    - Added support for Firewall Policy NAT Rule Collections to support multiple NAT Rule Collection
* [Breaking Change] Added mandatory parameter `SourceIpGroup` for `New-AzFirewallPolicyApplicationRule` and `New-AzFirewallPolicyNetworkRule`.
* [Breaking Change] Fixed `New-AzFirewallPolicyApplicationRule`, parameter `SourceAddress` to be mandatory.
* [Breaking Change] Fixed `New-AzFirewallPolicyApplicationRule`, parameter `SourceAddress` to be mandatory.
* [Breaking Change] Removed mandatory parameters: `TranslatedAddress`, `TranslatedPort` for `New-AzFirewallPolicyNatRuleCollection`.
* Added new cmdlets to support PrivateLink On Application Gateway
    - `New-AzApplicationGatewayPrivateLinkConfiguration`
    - `Get-AzApplicationGatewayPrivateLinkConfiguration`
    - `New-AzApplicationGatewayPrivateLinkConfiguration`
    - `Set-AzApplicationGatewayPrivateLinkConfiguration`
    - `Remove-AzApplicationGatewayPrivateLinkConfiguration`
    - `New-AzApplicationGatewayPrivateLinkIpConfiguration`
* Added new cmdlets for HubRouteTables child resource of VirtualHub.
    - `New-AzVHubRoute`
    - `New-AzVHubRouteTable`
    - `Get-AzVHubRouteTable`
    - `Update-AzVHubRouteTable`
    - `Remove-AzVHubRouteTable`
* Updated existing cmdlets to support optional RoutingConfiguration input parameter for custom routing in VirtualWan.
    - `New-AzExpressRouteConnection`
    - `Set-AzExpressRouteConnection`
    - `New-AzVirtualHubVnetConnection`
    - `Update-AzVirtualHubVnetConnection`
    - `New-AzVpnConnection`
    - `Update-AzVpnConnection`
    - `New-AzP2sVpnGateway`
    - `Update-AzP2sVpnGateway`

## Version 3.0.0
* Added breaking change attribute to notify that Zone default behaviour will be changed
    - `New-AzPublicIpAddress`
    - `New-AzPublicIpPrefix`
    - `New-AzLoadBalancerFrontendIpConfig`
* Added support for a new top level resource SecurityPartnerProvider
    - New cmdlets added:
        - New-AzSecurityPartnerProvider
        - Remove-AzSecurityPartnerProvider
        - Get-AzSecurityPartnerProvider
        - Set-AzSecurityPartnerProvider
* Added `RequiredZoneNames` on `PSPrivateLinkResource` and `GroupId` on `PSPrivateEndpointConnection`
* Fixed incorrect type of SuccessThresholdRoundTripTimeMs parameter for New-AzNetworkWatcherConnectionMonitorTestConfigurationObject
* Updated VirtualWan cmdlets to set default value of AllowVnetToVnetTraffic argument to True.
    - `New-AzVirtualWan`
    - `Update-AzVirtualWan`
* Added new cmdlets to support DNS zone group for private endpoint
    - `New-AzPrivateDnsZoneConfig`
    - `Get-AzPrivateDnsZoneGroup`
    - `New-AzPrivateDnsZoneGroup`
    - `Set-AzPrivateDnsZoneGroup`
    - `Remove-AzPrivateDnsZoneGroup`
* Add `DNSEnableProxy`, 'DNSRequireProxyForNetworkRules' and 'DNSServers' parameters to `AzureFirewall`
* Add `EnableDnsProxy`, 'DnsProxyNotRequiredForNetworkRule' and 'DnsServer' parameters to `AzureFirewall`
    - Updated cmdlet:
        - New-AzFirewall
* Add deprecation warning for `HubVnetConnection` parameter in following cmdlets
    - NewAzureRmVirtualHubCommand
    - UpdateAzureRmVirtualHubCommand
* Use HubVnetConnection create/update APIs instead of VirtualHub create/update APIs for following cmdlets
    - NewAzureRmVirtualHubCommand
    - UpdateAzureRmVirtualHubCommand
    - NewHubVirtualNetworkConnectionCommand
    - UpdateAzureRmHubVirtualNetworkConnectionCommand
    - RemoveHubVirtualNetworkConnectionCommand
* Deprecate `EnableInternetSecurity` switch parameter and instead introduce `EnableInternetSecurityFlag` boolean in
    - NewHubVirtualNetworkConnectionCommand.
    The flag is also made true by default for newly created connections.

## Version 2.5.0
* Updated cmdlets to enable connection on private IP for Virtual Network Gateway.
    - `New-AzVirtualNetworkGateway`
    - `Set-AzVirtualNetworkGateway`
    - `New-AzVirtualNetworkGatewayConnection`
    - `Set-AzVirtualNetworkGatewayConnection`
* Updated cmdlets to enable FQDN based LocalNetworkGateways and VpnSites
    - `New-AzLocalNetworkGateway`
    - `New-AzVpnSiteLink`
* Added support for IPv6 address family in ExpressRouteCircuitConnectionConfig (Global Reach)
    - Added `Set-AzExpressRouteCircuitConnectionConfig`
        - allows setting of all the existing properties including the IPv6CircuitConnectionProperties
    - Updated `Add-AzExpressRouteCircuitConnectionConfig`
        - Added another optional parameter AddressPrefixType to specify the address family of address prefix
* Updated cmdlets to enable setting of DPD Timeout on Virtual Network Gateway Connections.
    - New-AzVirtualNetworkGatewayConnection
    - Set-AzVirtualNetworkGatewayConnection
* Added resource type IpAllocation 
* Added properties to Subnet
    - Added property 'IpAllocations' as type of PSResourceId to PSIpAllocation
* Added properties to Virtual Network
    - Added property 'IpAllocations' as type of PSResourceId to PSIpAllocation
* Added support for IpAllocation resource
    - New cmdlet added:
        - Get-AzIpAllocation
        - New-AzIpAllocation
        - Remove-AzIpAllocation
        - Get-AzIpAllocation
    - Updated `New-AzVirtualNetwork`
        - Added another optional parameter IpAllocations to specify the IpAllocation
    - Updated `New-AzVirtualNetworkSubnetConfig`
        - Added another optional parameter IpAllocations to specify the IpAllocation
    - Updated `Set-AzVirtualNetworkSubnetConfig`
        - Added another optional parameter IpAllocations to specify the IpAllocation
    - Updated `Add-AzVirtualNetworkSubnetConfig`
        - Added another optional parameter IpAllocations to specify the IpAllocation

## Version 2.4.0
* Updated cmdlets to allow cross-tenant VirtualHubVnetConnections
    - `New-AzVirtualHubVnetConnection`
    - `Update-AzVirtualHubVnetConnection`
    - `New-AzVirtualHub`
    - `Update-AzVirtualHub`
* Removed Sql Management SDK dependency
* Added 'New-AzIpConfigurationBgpPeeringAddressObject'
* Updated 'Set-AzVirtualNetworkGateway' and 'New-AzVirtualNetworkGateway'

## Version 2.3.2
* Updated Sql Management SDK.
* Fixed a naming-difference issue in PrivateLinkServiceConnectionState class.
    - Mapping the field ActionsRequired to ActionRequired.
* Added PublicNetworkAccess to `New-AzSqlServer` and `Set-AzSqlServer`

## Version 2.3.1
* Added one extra parameter note for parameter `-EnableProxyProtocol` for `New-AzPrivateLinkService` cmdlet.
* Fixed FilterData example in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Added Packet Capture example for capture all inner and outer packets in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Supported Azure Firewall Policy on VNet Firewalls
    - No new cmdlets are added. Relaxing the restriction for firewall policy on VNet firewalls
* Added support to disconnect vpn connection in virtual network gateway and p2s vpn gateway
    - New cmdlets added:
        - Disconnect-AzVirtualNetworkGatewayVpnConnection
        - Disconnect-AzP2sVpnGatewayVpnConnection

## Version 2.3.0
* New example added to Set-AzNetworkWatcherConfigFlowLog.md to demonstrate Traffic Analytics disable scenario.
* Add support for assigning management IP configuration to Azure Firewall - a dedicated subnet and Public IP that the firewall will use for its management traffic
    - Updated New-AzFirewall cmdlet:
        - Added parameter -ManagementPublicIpAddress (not mandatory) which accepts a Public IP Address object
        - Added method SetManagementIpConfiguration on firewall object - requires a subnet and a Public IP address as input - subnet name must be "AzureFirewallManagementSubnet"
* Corrected Get-AzNetworkSecurityGroup examples to show examples for NSG's instead of network interfaces.
* Fixed typo in New-AzureRmVpnSite command that was preventing resource id completer from completing a parameter.
* Added support for Url Confiugration in Rewrite Rules Action Set in the Application Gateway
    - New cmdlets added:
        - New-AzApplicationGatewayRewriteRuleUrlConfiguration
    - Cmdlets updated with optional parameter - UrlConfiguration
        - New-AzApplicationGatewayRewriteRuleActionSet
* Add suppport for NetworkWatcher ConnectionMonitor version 2 resources

## Version 2.2.1
* Upgrade dependancy of Microsoft.Azure.Management.Sql from 1.36-preview to 1.37-preview

## Version 2.2.0
* Update references in .psd1 to use relative path
* Support for IpGroups in AzureFirewall Application,Nat & Network Rules.

## Version 2.1.0
* Change `Start-AzVirtualNetworkGatewayConnectionPacketCapture.md` and `Start-AzVirtualnetworkGatewayPacketCapture.md` FilterData option examples.
* Add `PrivateRange` parameter to `AzureFirewall`
    - Updated cmdlet:
        - New-AzFirewall

## Version 2.0.0
* Change all cmdlets for PrivateEndpointConnection to support generic service provider.
    - Updated cmdlet:
        - Approve-AzPrivateEndpointConnection
        - Deny-AzPrivateEndpointConnection
        - Get-AzPrivateEndpointConnection
        - Remove-AzPrivateEndpointConnection
        - Set-AzPrivateEndpointConnection
* Add new cmdlet for PrivateLinkResource and it also support generic service provider.
    - New cmdlet:
        - Get-AzPrivateLinkResource
* Add new fields and parameter for the feature Proxy Protocol V2.
    - Add property EnableProxyProtocol in PrivateLinkService
    - Add property LinkIdentifier in PrivateEndpointConnection
    - Updated New-AzPrivateLinkService to add a new optional parameter EnableProxyProtocol.
* Fix incorrect parameter description in `New-AzApplicationGatewaySku` reference documentation
* New cmdlets to support the azure firewall policy
* Add support for ThreatIntelWhitelist property for AzFirewall
    - New cmdlet added:
        - New-AzFirewallThreatIntelWhitelist
    - Cmdlets updated with optional parameters:
        - New-AzFirewall : added parameter ThreatIntelWhitelist
* Add support for child resource RouteTables of VirtualHub
    - New cmdlets added:
        - Add-AzVirtualHubRoute
        - Add-AzVirtualHubRouteTable
        - Get-AzVirtualHubRouteTable
        - Remove-AzVirtualHubRouteTable
        - Set-AzVirtualHub
* Add support for new properties Sku of VirtualHub and VirtualWANType of VirtualWan
    - Cmdlets updated with optional parameters:
        - New-AzVirtualHub : added parameter Sku
        - Update-AzVirtualHub : added parameter Sku
        - New-AzVirtualWan : added parameter VirtualWANType
        - Update-AzVirtualWan : added parameter VirtualWANType
* Add support for EnableInternetSecurity property for HubVnetConnection, VpnConnection and ExpressRouteConnection
    - New cmdlets added:
        - Update-AzureRmVirtualHubVnetConnection
    - Cmdlets updated with optional parameters:
        - New-AzureRmVirtualHubVnetConnection : added parameter EnableInternetSecurity
        - New-AzureRmVpnConnection : added parameter EnableInternetSecurity
        - Update-AzureRmVpnConnection : added parameter EnableInternetSecurity
        - New-AzureRmExpressRouteConnection : added parameter EnableInternetSecurity
        - Set-AzureRmExpressRouteConnection : added parameter EnableInternetSecurity
* Add support for Configuring TopLevel WebApplicationFirewall Policy
    - New cmdlets added:
        - New-AzApplicationGatewayFirewallPolicySetting
        - New-AzApplicationGatewayFirewallPolicyExclusion
        - New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride
        - New-AzApplicationGatewayFirewallPolicyManagedRuleOverride
        - New-AzApplicationGatewayFirewallPolicyManagedRule
        - New-AzApplicationGatewayFirewallPolicyManagedRuleSet
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayFirewallPolicy : added parameter PolicySetting, ManagedRule
* Added support for Geo-Match operator on CustomRule
    - Added GeoMatch to the operator on the FirewallCondition
* Added support for perListener and perSite Firewall policy
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayHttpListener : added parameter FirewallPolicy, FirewallPolicyId
        - New-AzApplicationGatewayPathRuleConfig : added parameter FirewallPolicy, FirewallPolicyId
* Added support for perListener HostNames
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayHttpListener : added parameter HostNames
        - Add-AzApplicationGatewayHttpListener : added parameter HostNames
* Fix required subnet with name AzureBastionSubnet in `PSBastion` can be case insensitive
* Support for Destination FQDNs in Network Rules and Translated FQDN in NAT Rules for Azure Firewall
* Add support for top level resource RouteTables of IpGroup
    - New cmdlets added:
        - New-AzIpGroup
        - Remove-AzIpGroup
        - Get-AzIpGroup
        - Set-AzIpGroup
* Virtual Wan Point to site feature release.
  - Introduce new command lets for managing point to site VpnServerConfiguraiton resource
    - Get-AzVpnServerConfiguration
    - New-AzVpnServerConfiguration
    - Remove-AzVpnServerConfiguration
    - Update-AzVpnServerConfiguration
  - Introduce new command lets for managing P2SVpnGateway resource that will be used for Point to site connectivity from Virtual wan perspective
    - Get-AzP2sVpnGateway
    - Get-AzP2sVpnGatewayConnectionHealth
    - Get-AzP2sVpnGatewayDetailedConnectionHealth
    - New-AzP2sVpnGateway
    - Remove-AzP2sVpnGateway
    - Update-AzP2sVpnGateway
  - Introduce new command lets for VirtualWan resource to get all associated VpnServerConfigurations and download Wan level Point to site client profile.
    - Get-AzVirtualWanVpnServerConfiguration
    - Get-AzVirtualWanVpnServerConfigurationVpnProfile

## Version 1.15.0
* Add new cmdlet Get-AzAvailableServiceAlias which can be called to get the aliases that can be used for Service Endpoint Policies.
* Added support for the adding traffic selectors to Virtual Network Gateway Connections
    - New cmdlets added:
        - New-AzureRmTrafficSelectorPolicy
    - Cmdlets updated with optional parameter -TrafficSelectorPolicies
        -New-AzureRmVirtualNetworkGatewayConnection
        -Set-AzureRmVirtualNetworkGatewayConnection
* Add support for ESP and AH protocols in network security rule configurations
    - Updated cmdlets:
        - Add-AzNetworkSecurityRuleConfig
        - New-AzNetworkSecurityRuleConfig
        - Set-AzNetworkSecurityRuleConfig
* Improve handling of exceptions in Cortex cmdlets
* New Generations and SKUs for VirtualNetworkGateways
  - Introduce new Generations for VirtualNetworkGateways.
  - Introduce new high throughput SKUs for VirtualNetworkGateways.

## Version 1.14.0
* Fix incorrect example in `New-AzApplicationGateway` reference documentation
* Add note in `Get-AzNetworkWatcherPacketCapture` reference documentation about retrieving all properties for a packet capture
* Fixed example in `Test-AzNetworkWatcherIPFlow` reference documentation to correctly enumerate NICs
* Improved cloud exception parsing to display additional details if they are present
* Improved cloud exception parsing to handle additional type of SDK exception
* Fixed incorrect mapping of Security Rule models
* Added properties to network interface for private ip feature
    - Added property 'PrivateEndpoint' as type of PSResourceId to PSNetworkInterface
    - Added property 'PrivateLinkConnectionProperties' as type of PSIpConfigurationConnectivityInformation to PSNetworkInterfaceIPConfiguration
    - Added new model class PSIpConfigurationConnectivityInformation
* Added new ApplicationRuleProtocolType "mssql" for Azure Firewall resource
* MultiLink support in Virtual WAN
    - New cmdlets
        - New-AzVpnSiteLink
        - New-AzVpnSiteLinkConnection
    - Updated cmdlet:
        - New-VpnSite
        - Update-VpnSite
        - New-VpnConnection
        - Update-VpnConnection
* Fixed documents for some PowerShell examples to use Az cmdlets instead of AzureRM cmdlets

## Version 1.13.0
* Updated New-AzPrivateLinkServiceIpConfig
    - Deprecated the parameter 'PublicIpAddress' since this is never used in the server side.
    - Added one optional parameter 'Primary' that indicate the current ip configuration is primary one or not.
* Improved handling of request error exception from SDK
    -Fixes the issue that previously SDK exceptions aren't handled correctly which results in key error details not being displayed
* Fixed miscellaneous typos across module
* Adjusted validation logic for Ipv6 IP Prefix to check for correct IPv6 prefix length.
* Updated Get-AzVirtualNetworkSubnetConfig: Added parameter set to get by subnet resource id.
* Updated description of Location parameter for AzNetworkServiceTag

## Version 1.12.0
* Add support for private endpoint and private link service
    - New cmdlets
        - Set-AzPrivateEndpoint
        - Set-AzPrivateLinkService
        - Approve-AzPrivateEndpointConnection
        - Deny-AzPrivateEndpointConnection
        - Get-AzPrivateEndpointConnection
        - Remove-AzPrivateEndpointConnection
        - Test-AzPrivateLinkServiceVisibility
        - Get-AzAutoApprovedPrivateLinkService
* Updated below commands for feature: PrivateEndpointNetworkPolicies/PrivateLinkServiceNetworkPolicies flag on Subnet in Virtualnetwork
    - Updated New-AzVirtualNetworkSubnetConfig/Set-AzVirtualNetworkSubnetConfig/Add-AzVirtualNetworkSubnetConfig
        - Added optional parameter -PrivateEndpointNetworkPoliciesFlag to indicate that enable or disable apply network policies on pivate endpoint in this subnet.
        - Added optional parameter -PrivateLinkServiceNetworkPoliciesFlag to indicate that enable or disable apply network policies on private link service in this subnet.
* AzPrivateLinkService's cmdlet parameter `ServiceName` was renamed to `Name` with an alias `ServiceName` for backward compatibility
* Enable ICMP protocol for network security rule configurations
    - Updated cmdlets
        - Add-AzNetworkSecurityRuleConfig
        - New-AzNetworkSecurityRuleConfig
        - Set-AzNetworkSecurityRuleConfig
* Add ConnectionProtocolType (Ikev1/Ikev2) as a configurable parameter for New-AzVirtualNetworkGatewayConnection
* Add PrivateIpAddressVersion in LoadBalancerFrontendIpConfiguration
    - Updated cmdlet:
        - New-AzLoadBalancerFrontendIpConfig
        - Add-AzLoadBalancerFrontendIpConfig
        - Set-AzLoadBalancerFrontendIpConfig
* Application Gateway New-AzApplicationGatewayProbeConfig command update for supporting custom port in Probe
    - Updated New-AzApplicationGatewayProbeConfig: Added optional parameter Port which is used for probing backend server. This parameter is applicable for Standard_V2 and WAF_V2 SKU.


## Version 1.11.0
* Added `RoutingPreference` to public ip tags
* Improve examples for `Get-AzNetworkServiceTag` reference documentation

## Version 1.10.0
* Add support for Virtual Network Gateway Resource
    - New cmdlets
        - Get-AzVirtualNetworkGatewayVpnClientConnectionHealth
* Add AvailablePrivateEndpointType
    - New cmdlets
        - Get-AzAvailablePrivateEndpointType
* Add PrivatePrivateLinkService
    - New cmdlets
        - Get-AzPrivateLinkService
        - New-AzPrivateLinkService
        - Remove-AzPrivateLinkService
        - New-AzPrivateLinkServiceIpConfig
        - Set-AzPrivateEndpointConnection
* Add PrivateEndpoint
    - New cmdlets
        - Get-AzPrivateEndpoint
        - New-AzPrivateEndpoint
        - Remove-AzPrivateEndpoint
        - New-AzPrivateLinkServiceConnection
* Updated below commands for feature: UseLocalAzureIpAddress flag on VpnConnection
    - Updated New-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
    - Updated Set-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
* Added readonly field PeeredConnections in ExpressRoute peering.
* Added readonly field GlobalReachEnabled in ExpressRoute.
* Added breaking change attribute to call out deprecation of AllowGlobalReach field in ExpressRouteCircuit model
* Fixed Issue 8756 Error using TargetListenerID with AzApplicationGatewayRedirectConfiguration cmdlets
* Fixed bug in New-AzApplicationGatewayPathRuleConfig that prevented the rewrite ruleset from being set.
* Fixed displaying of VirtualNetworkTaps in NetworkInterfaceIpConfiguration
* Fixed Cortex Get cmdlets for list all part
* Fixed VirtualHub reference creation for ExpressRouteGateways, VpnGateway
* Added support for Availability Zones in AzureFirewall and NatGateway
* Added cmdlet Get-AzNetworkServiceTag
* Add support for multiple public IP addresses for Azure Firewall
    - Updated New-AzFirewall cmdlet:
        - Added parameter -PublicIpAddress which accepts one or more Public IP Address objects
        - Added parameter -VirtualNetwork which accepts a Virtual Network object
        - Added methods AddPublicIpAddress and RemovePublicIpAddress on firewall object - these accept a Public IP Address object as input
        - Deprecated parameters -PublicIpName and -VirtualNetworkName
* Updated below commands for feature: Set VpnClient AAD authentication options to Virtual network gateway resource.
    - Updated New-AzVirtualNetworkGateway: Added optional parameters AadTenantUri,AadAudienceId,AadIssuerUri to set VpnClient AAD authentication options on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional parameter AadTenantUri,AadAudienceId,AadIssuerUri to set VpnClient AAD authentication options on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional switch parameter RemoveAadAuthentication to remove VpnClient AAD authentication options from Gateway.

## Version 1.9.0
* Update ResourceId and InputObject for Nat Gateway
    - Add alias for ResourceId and InputObject
* Removed WAF RuleSetVersion validation

## Version 1.8.1
* Add DisableBgpRoutePropagation flag to Effective Route Table output
    - Updated cmdlet:
        - Get-AzEffectiveRouteTable
* Fix double dash in New-AzApplicationGatewayTrustedRootCertificate documentation

## Version 1.8.0
* Add support for Nat Gateway Resource
    - New cmdlets
        - New-AzNatGateway
        - Get-AzNatGateway
        - Set-AzNatGateway
        - Remove-AzNatGateway
   - Updated cmdlets
        - New-AzureVirtualNetworkSubnetConfigCommand
        - Add-AzureVirtualNetworkSubnetConfigCommand
* Updated below commands for feature: Custom routes set/remove on Brooklyn Gateway.
    - Updated New-AzVirtualNetworkGateway: Added optional parameter -CustomRoute to set the address prefixes as custom routes to set on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional parameter -CustomRoute to set the address prefixes as custom routes to set on Gateway.

## Version 1.7.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

## Version 1.6.0
* Add Alert action type for Azure Firewall Network and Application Rule Collections

* Added support for conditions in RewriteRules in the Application Gateway
    - New cmdlets added:
        - New-AzApplicationGatewayRewriteRuleCondition
    - Cmdlets updated with optional parameter - RuleSequence and Condition
        - New-AzApplicationGatewayRewriteRule

## Version 1.5.0
* Add Threat Intelligence support for Azure Firewall
* Add Application Gateway Firewall Policy top level resource and Custom Rules


## Version 1.4.0
* Add ResourceId parameter to Get-AzNetworkInterface
* Improved error handling for Get-AzVpnClientRevokedCertificate, Get-AzVpnClientRootCertificate
* Improved Subnet, Primary, PrivateIpAddressVersion parameters processing in
    - Add-AzNetworkInterfaceIpConfig
    - Set-AzNetworkInterfaceIpConfig

## Version 1.3.0
* Add wildcard support to Network cmdlets

## Version 1.2.1
* Update help example for Add-AzApplicationGatewayCustomError

## Version 1.2.0
* Added Cmdlets for Identity on Application Gateway.
    - New cmdlets added:
        - Set-AzApplicationGatewayIdentity
        - Get-AzApplicationGatewayIdentity
        - New-AzApplicationGatewayIdentity
        - Remove-AzApplicationGatewayIdentity
    - New-AzApplicationGateway cmdlet updated with optional parameter -Identity

## Version 1.1.0
* Update incorrect online help URLs

## Version 1.0.0
* Added support for the configuring RewriteRuleSets in the Application Gateway
    - New cmdlets added:
        - Add-AzureRmApplicationGatewayRewriteRuleSet
        - Get-AzureRmApplicationGatewayRewriteRuleSet
        - New-AzureRmApplicationGatewayRewriteRuleSet
        - Remove-AzureRmApplicationGatewayRewriteRuleSet
        - Set-AzureRmApplicationGatewayRewriteRuleSet
        - New-AzureRmApplicationGatewayRewriteRule
        - New-AzureRmApplicationGatewayRewriteRuleActionSet
        - New-AzureRmApplicationGatewayRewriteRuleHeaderConfiguration
    - Cmdlets updated with optional parameter -RewriteRuleSet
        - New-AzureRmApplicationGateway
        - New-AzureRmApplicationGatewayRequestRoutingRule
        - Add-AzureRmApplicationGatewayRequestRoutingRule
        - New-AzureRmApplicationGatewayPathRuleConfig
        - Add-AzureRmApplicationGatewayUrlPathMapConfig
        - New-AzureRmApplicationGatewayUrlPathMapConfig
* Removed deprecated -ResourceId parameter from Get-AzServiceEndpointPolicyDefinition
* Removed deprecated EnableVmProtection property from PSVirtualNetwork
* Removed deprecated Set-AzVirtualNetworkGatewayVpnClientConfig cmdlet
* Added KeyVault Support to Application Gateway using Identity.
    - Cmdlets updated with optonal parameter -KeyVaultSecretId, -KeyVaultSecret
        - Add-AzApplicationGatewaySslCertificate
        - New-AzApplicationGatewaySslCertificate
        - Set-AzApplicationGatewaySslCertificate
    - New-AzApplicationGateway cmdlet updated with optional parameter -UserAssignedIdentityId, -UserAssignedIdentity
* Add MaxCapacity property in ApplicationGatewayAutoscaleConfiguration
