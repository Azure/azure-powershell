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

## Version 2.3.1
* Added one extra parameter note for parameter `-EnableProxyProtocol` for `New-AzPrivateLinkService` cmdlet.
* Fixed FilterData example in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Added Packet Capture example for capture all inner and outer packets in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Supported Azure Firewall Policy on VNet Firewalls
    - No new cmdlets are added. Relaxing the restriction for firewall policy on VNet firewalls

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

