<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 6.11.2
* This module is outdated and will go out of support on 29 February 2024.
* The Az.Network module has all the capabilities of AzureRM.Network and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 6.11.0
* Added cmdlet New-AzureRmApplicationGatewayCustomError, Add-AzureRmApplicationGatewayCustomError, Get-AzureRmApplicationGatewayCustomError, Set-AzureRmApplicationGatewayCustomError, Remove-AzureRmApplicationGatewayCustomError, Add-AzureRmApplicationGatewayHttpListenerCustomError, Get-AzureRmApplicationGatewayHttpListenerCustomError, Set-AzureRmApplicationGatewayHttpListenerCustomError, Remove-AzureRmApplicationGatewayHttpListenerCustomError
* Added ICMP back to supported AzureFirewall Network Protocols
* Update cmdlet Test-AzureRmNetworkWatcherConnectivity, add validation on destination id, address and port. 
* Fix issues with memory usage in VirtualNetwork map

## Version 6.10.0
* Changed PeeringType to be a mandatory parameter for the following cmdlets:-
    - Get-AzureRmExpressRouteCircuitRouteTable
    - Get-AzureRmExpressRouteCircuitARPTable
    - Get-AzureRmExpressRouteCircuitRouteTableSummary
    - Get-AzureRMExpressRouteCrossConnectionArpTable
    - Get-AzureRMExpressRouteCrossConnectionRouteTable
    - Get-AzureRMExpressRouteCrossConnectionRouteTableSummary

## Version 6.9.1
* Update cmdlet Test-AzureRmNetworkWatcherConnectivity, pass the protocol value to backend.
* Added ResourceName argument completer to all cmdlets.
* Added WhatIf support to Set-AzureRmNetworkSecurityGroup
* Added ArgumentCompeter for Subnet's parameter ServiceEndpoints
* Added cmdlet Get-AzureRmFirewallFqdnTag
* Added Exclusion list and Global config functionality for application gateway WAF, new cmdlets added
* Fixed issue with RouteFilter not being set if it was passed to ExpressRouteCircuit Peering as resource

## Version 6.9.0
* Added NetworkProfile functionality. new cmdlets added
    - Get-AzureRMNetworkProfile
    - New-AzureRMNetworkProfile
    - Remove-AzureRMNetworkProfile
    - Set-AzureRMNetworkProfile
    - New-AzureRMContainerNicConfig
    - New-AzureRmContainerNicConfigIpConfig
* Added service association link on Subnet Model
* Added cmdlet New-AzureRmVirtualNetworkTap, Get-AzureRmVirtualNetworkTap, Set-AzureRmVirtualNetworkTap, Remove-AzureRmVirtualNetworkTap
* Added cmdlet Set-AzureRmNEtworkInterfaceTapConfig, Get-AzureRmNEtworkInterfaceTapConfig, Remove-AzureRmNEtworkInterfaceTapConfig

## Version 6.8.0
* Replaced LoadBalancer cmdlets with generated code
  - LoadBalancerInboundNatPoolConfig: added parameters IdleTimeoutInMinutes, EnableFloatingIp and EnableTcpReset
  - LoadBalancerInboundNatRuleConfig: added parameter EnableTcpReset
  - LoadBalancerRuleConfig: added parameter EnableTcpReset
  - LoadBalancerProbeConfig: added support for value "Https" for parameter Protocol
* Added new commands for new LoadBalancer's subresource OutboundRule
  - Add-AzureRmLoadBalancerOutboundRuleConfig
  - Get-AzureRmLoadBalancerOutboundRuleConfig
  - New-AzureRmLoadBalancerOutboundRuleConfig
  - Set-AzureRmLoadBalancerOutboundRuleConfig
  - Remove-AzureRmLoadBalancerOutboundRuleConfig
* Added new HostedWorkloads property for PSNetworkInterface
* Added new commands for feature: Azure Firewall via ARM
  - Added Get-AzureRmFirewall
  - Added Set-AzureRmFirewall
  - Added New-AzureRmFirewall
  - Added Remove-AzureRmFirewall
  - Added New-AzureRmFirewallApplicationRuleCollection
  - Added New-AzureRmFirewallApplicationRule
  - Added New-AzureRmFirewallNatRuleCollection
  - Added New-AzureRmFirewallNatRule
  - Added New-AzureRmFirewallNetworkRuleCollection
  - Added New-AzureRmFirewallNetworkRule
* Added support for Trusted Root certificate and Autoscale configuration in Application Gateway
  - New Cmdlets added:
      - Add-AzureRmApplicationGatewayTrustedRootCertificate
      - Get-AzureRmApplicationGatewayTrustedRootCertificate
      - New-AzureRmApplicationGatewayTrustedRootCertificate
      - Remove-AzureRmApplicationGatewayTrustedRootCertificate
      - Set-AzureRmApplicationGatewayTrustedRootCertificate
      - Get-AzureRmApplicationGatewayAutoscaleConfiguration
      - New-AzureRmApplicationGatewayAutoscaleConfiguration
      - Remove-AzureRmApplicationGatewayAutoscaleConfiguration
      - Set-AzureRmApplicationGatewayAutoscaleConfiguration
  - Cmdlets updated with optonal parameter -TrustedRootCertificate
      - New-AzureRmApplicationGateway
      - Set-AzureRmApplicationGateway
      - New-AzureRmApplicationGatewayBackendHttpSetting
      - Set-AzureRmApplicationGatewayBackendHttpSetting
  - Cmdlets updated with optonal parameter -AutoscaleConfiguration
      - New-AzureRmApplicationGateway
      - Set-AzureRmApplicationGateway
* Add cmdlet for Interface Endpoint Get-AzureInterfaceEndpoint
* Added support for multiple address prefixes in a subnet. Updated cmdlets:
  - New-AzureRmVirtualNetworkSubnetConfig
  - Set-AzureRmVirtualNetworkSubnetConfig
  - Add-AzureRmVirtualNetworkSubnetConfig
  - Get-AzureRmVirtualNetworkSubnetConfig
  - Add-AzureRmApplicationGatewayAuthenticationCertificate
  - Add-AzureRmApplicationGatewayFrontendIPConfig
  - New-AzureRmApplicationGatewayFrontendIPConfig
  - Set-AzureRmApplicationGatewayFrontendIPConfig
  - Add-AzureRmApplicationGatewayIPConfiguration
  - New-AzureRmApplicationGatewayIPConfiguration
  - Set-AzureRmApplicationGatewayIPConfiguration
  - Add-AzureRmNetworkInterfaceIpConfig
  - New-AzureRmNetworkInterfaceIpConfig
  - Set-AzureRmNetworkInterfaceIpConfig
  - New-AzureRmVirtualNetworkGatewayIpConfig
  - Add-AzureRmVirtualNetworkGatewayIpConfig
  - Set-AzureRmLoadBalancerFrontendIpConfig
  - Add-AzureRmLoadBalancerFrontendIpConfig
  - New-AzureRmLoadBalancerFrontendIpConfig
  - New-AzureRmNetworkInterface
* Adding support to perform CRUD operations for subnet delegation.
  - New-AzureRmDelegation: Creates a new delegation, which can be added to a subnet
  - Remove-AzureRmDelegation: Takes in a subnet and removes the provided delegation name from that subnet
  - Add-AzureRmDelegation: Takes in a subnet and adds the provided service name as a delegation to that subnet
  - Get-AzureRmDelegation
  - Get-AzureRmAvailableServiceDelegations

## Version 6.7.0
* Updated cmdlet New-AzureRmVirtualNetworkGatewayConnection with support for switch ExpressRouteGatewayBypass
* Added cmdlets for Azure SdWan


## Version 6.6.1
* Changed default cmdlet output presentation to table view
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 6.6.0
* Fixed issue with default resource groups not being set.
* Changed default models representation to table-view

## Version 6.5.0
* Added example for Set-AzureRmLocalNetworkGateway
* Added examples and descriptions for Add-AzureRmVirtualNetworkGatewayIpConfig, Get-AzureRmVirtualNetworkGatewayConnectionSharedKey and New-AzureRmVirtualNetworkGatewayConnection
* Added PublicIpPrefix Functionality. New cmdlets added
	- New-AzureRmPublicIpPrefix
	- Get-AzureRmPublicIpPrefix
	- Remove-AzureRmPublicIpPrefix
	- Set-AzureRmPublicIpPrefix
* Added service endpoint policies cmdlets
* Added deprecation messages for EnableVmProtection property in VirtualNetwork
* Added examples for Remove-AzureRmVirtualNetworkGatewayIpConfig and Reset-AzureRmVirtualNetworkGateway
* Added example for Reset-AzureRmVirtualNetworkGatewayConnectionSharedKey
* Added example for Set-AzureRmVirtualNetworkGatewayConnectionSharedKey
* Added example for Set-AzureRmVirtualNetworkGatewayConnection
* Re-generated cmdlets for ApplicationSecurityGroup, RouteTable and Usage using latest code generator
* Clarified error message for Get-AzureRmVirtualNetworkSubnetConfig when attempting to get a subnet that does not exist
* Improved exception messages: added more details to output
* Dropped outdated warnings

## Version 6.4.1
* Updated all help files to include full parameter types and correct input/output types.
* Updated to the latest version of the Azure ClientRuntime.
* Added examples for LoadBalancerInboundNatPoolConfig cmdlets.

## Version 6.4.0
* Updated below cmdlets for Application Gateway
    - New-AzureRmApplicationGateway : Added EnableFIPS flag and Zones support
    - New-AzureRmApplicationGatewaySku : Added new skus Standard_v2 and WAF_v2
    - Set-AzureRmApplicationGatewaySku : Added new skus Standard_v2 and WAF_v2
* Regenerated RouteTable cmdlets with the latest generator version

## Version 6.3.1
* Enable peering across Virtual Networks in multiple Tenants for Set/Add-AzureRmVirtualNetworkPeering


## Version 6.3.0
* Expose new Skus for Zone-Redundant VirtualNetworkGateways
* Fixed formatting of OutputType in help files
* Added new commands for feature: ExpressRoute Partner APIs via ARM
    - Added Get-AzureRmExpressRouteCrossConnection
    - Added Set-AzureRmExpressRouteCrossConnection
    - Added Add-AzureRmExpressRouteCrossConnectionPeering
    - Added Get-AzureRmExpressRouteCrossConnectionPeering
    - Added Remove-AzureRmExpressRouteCrossConnectionPeering
    - Added Get-AzureRMExpressRouteCrossConnectionArpTable
    - Added Get-AzureRMExpressRouteCrossConnectionRouteTable
    - Added Get-AzureRMExpressRouteCrossConnectionRouteTableSummary

## Version 6.2.0
* Enable Traffic Analytics parameters on Network Watcher cmdlets

## Version 6.1.1
* Removed Default sku setting from New-AzureRmVirtualNetworkGateway cmdlet

## Version 6.1.0
* Bump up Network SDK version from 18.0.0-preview to 19.0.0-preview
* Updated below commands for feature: Point to Site IPsec custom policy set/remove on Brooklyn Gateway.
    - Updated New-AzureRmVirtualNetworkGateway: Added optional parameter -VpnClientIpsecPolicy   [Pass the value from output of newly added command:- New-AzureRmVpnClientIpsecPolicy]
    - Updated Set-AzureRmVirtualNetworkGateway: Added optional parameter -VpnClientIPsecParameter [Pass the value from output of newly added command:- New-AzureRmVpnClientIpsecPolicy]
* Added new commands for feature: Point to Site IPsec custom policy set/remove on Brooklyn Gateway.
    - New-AzureRmVpnClientIpsecPolicy : Added for passing output from this command to existing commands: New-AzureRmVirtualNetworkGateway & Set-AzureRmVirtualNetworkGateway to set Vpn IPSec policy
    - New-AzureRmVpnClientIpsecParameter
	- Set-AzureRmVpnClientIpsecParameter
	- Get-AzureRmVpnClientIpsecParameter
	- Remove-AzureRmVpnClientIpsecParameter
* Added a warning note for existing command: Set-AzureRmVirtualNetworkGatewayVpnClientConfig to let users know of its plan of removal in next release.
* Added cmdlet to create protocol configuration
    - New-AzureRmNetworkWatcherProtocolConfiguration
* Added cmdlet to add a new circuit connection to an existing express route circuit.
    - Add-AzureRmExpressRouteCircuitConnectionConfig
* Added cmdlet to remove a circuit connection from an existing express route circuit.
    - Remove-AzureRmExpressRouteCircuitConnectionConfig
* Added cmdlet to retrieve a circuit connection
    - Get-AzureRmExpressRouteCircuitConnectionConfig

## Version 6.0.0
* Bump up network sdk version from 17.0.0.preview to 18.0.0.preview
* Set minimum dependency of module to PowerShell 5.0
* Add support for DDoS protection plan resource
* Introduced multiple breaking changes
    - Please refer to the migration guide for more information

## Version 5.4.2
* Fix error message with Network cmdlets
* Updated to the latest version of the Azure ClientRuntime

## Version 5.4.1
* Fix issue with Default Resource Group in CloudShell

## Version 5.4.0
* Updating model types for compatibility with DNS cmdlets.

## Version 5.3.0
* Fixed issue with importing aliases
* Fix bug to serialize and display IPTags

## Version 5.2.0
* Added cmdlet to create a new connection monitor
    - New-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to update a connection monitor
    - Set-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to get connection monitor or connection monitor list
    - Get-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to query connection monitor
    - Get-AzureRmNetworkWatcherConnectionMonitorReport
* Added cmdlet to start connection monitor
    - Start-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to stop connection monitor
    - Stop-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to remove connection monitor
    - Remove-AzureRmNetworkWatcherConnectionMonitor
* Updated Set-AzureRmApplicationGatewayBackendAddressPool documentation to remove deprecated example
* Fix to support 32 bit AS Numbers in the Powershell API for Public and Private Expressroute Peerings
* Added EnableHttp2 flag to Application Gateway
    - Updated New-AzureRmApplicationGateway: Added optional parameter -EnableHttp2
* Add IpTags to PublicIpAddress
    - Updated New-AzureRmPublicIpAddress: Added IpTags
    - New-AzureRmPublicIpTag to add Iptag
* Add DisableBgpRoutePropagation property in RouteTable and effectiveRoute.

## Version 5.1.1
* Fix overwrite message 'Are you sure you want to overwriteresource'

## Version 5.1.0
* Added -AsJob support for long-running Network cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 5.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* Added cmdlet to list available internet service providers for a specified Azure region
    - Get-AzureRmNetworkWatcherReachabilityProvidersList
* Added cmdlet to get the relative latency score for internet service providers from a specified location to Azure regions
    - Get-AzureRmNetworkWatcherReachabilityReport
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 4.4.1

## Version 4.4.0
* Added support for endpoint services to Virtual Network Subnets
    - Updated Add-AzureRmVirtualSubnetConfig: Added optional parameter -ServiceEndpoint
    - Updated New-AzureRmVirtualSubnetConfig: Added optional parameter -ServiceEndpoint
    - Updated Set-AzureRmVirtualSubnetConfig: Added optional parameter -ServiceEndpoint
* Added cmdlet to list endpoint services available in the location
    - Get-AzureRmVirtualNetworkAvailableEndpointService
* Added the ability to configure external radius based P2S authentication to the following commandlets
    - New-AzureVirtualNetworkGateway
    - Set-AzureVirtualNetworkGateway
    - Set-AzureRmVirtualNetworkGatewayVpnClientConfig
* Added cmdlet to allow generation of VpnProfiles for external radius based P2S
    - New-AzureRmVpnClientConfiguration
	  - Get-AzureRmVpnClientConfiguration
* Added support for SKU parameter to Public IP Addresses and Load Balancers
    - Updated New-AzureRMLoadBalancer: Added optional parameter -Sku
    - Updated New-AzureRMPublicIpAddress: Added optional parameter -Sku
* Added support for DisableOutboundSNAT to Load Balancer Rules
    - Updated New-AzureRMLoadBalancerRuleConfig: Added optional parameter DisableOutboundSNAT
    - Updated Add-AzureRMLoadBalancerRuleConfig: Added optional parameter DisableOutboundSNAT
    - Updated Set-AzureRMLoadBalancerRuleConfig: Added optional parameter DisableOutboundSNAT
* Added support for IkeV2 P2S
    - Updated New-AzureRmVirtualNetworkGateway: Added optional parameter -VpnClientProtocol, defaults to [ "SSTP", "IkeV2" ]
    - Updated Set-AzureRmVirtualNetworkGateway: Added optional parameter -VpnClientProtocol
* Added new commands for VpnDeviceConfiguration Scripts
    - Get-AzureRmVirtualNetworkGatewaySupportedVpnDevices
    - Get-AzureRmVirtualNetworkGatewayConnectionVpnDeviceConfigScript
* Added support for MultiValued rules in Network Security Rules and Effective Network Security Rules
    - Updated Add-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix parameters to accept a list of strings
    - Updated New-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix  parameter to accept a list of strings
    - Updated Set-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix parameter to accept a list of strings
    - Updated Add-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix parameter to accept a list of strings
    - Updated New-AzureRmNetworkSecurityGroup : Updated SecurityRules parameter to accept SourcePortRange, DestinationPortRange, SourceAddressPrefix parameters which are list of strings in PSSecurityRule object
    - Updated Get-AzureRmEffectiveNetworkSecurityGroup: Added parameter TagMap
    - Updated Get-AzureRmEffectiveNetworkSecurityGroup: Updated returned PSEffectiveSecurityRule object with SourcePortRange, DestinationPortRange, SourceAddressPrefix parameters which are list of strings.
* Added support for DDoS protection for virtual networks
    - Updated New-AzureRmVirtualNetwork: Added switch parameters EnableDDoSProtection and EnableVmProtection
    - Added properties EnableDDoSProtection and EnableVmProtection in PSVirtualNetwork object
* Added support for Highly Available Internal Load Balancer
    - Updated Add-AzureRmLoadBalancerRuleConfig: Added All as an acceptable value for Protocol parameter
    - Updated New-AzureRmLoadBalancerRuleConfig: Added All as an acceptable value for Protocol parameter
    - Updated Set-AzureRmLoadBalancerRuleConfig: Added All as an acceptable value for Protocol parameter
* Added support for Application Security Groups
    - Added New-AzureRmApplicationSecurityGroup
    - Added Get-AzureRmApplicationSecurityGroup
    - Added Remove-AzureRmApplicationSecurityGroup
    - Updated New-AzureRmNetworkInterface: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
    - Updated New-AzureRmNetworkInterfaceIpConfig: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
    - Updated Add-AzureRmNetworkInterfaceIpConfig: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
    - Updated Set-AzureRmNetworkInterfaceIpConfig: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
    - Updated New-AzureRmNetworkSecurityRuleConfig: Added optional parameters SourceApplicationSecurityGroup, SourceApplicationSecurityGroupId, DestinationApplicationSecurityGroup, and DestinationApplicationSecurityGroupId
    - Updated Add-AzureRmNetworkSecurityRuleConfig: Added optional parameters SourceApplicationSecurityGroup, SourceApplicationSecurityGroupId, DestinationApplicationSecurityGroup, and DestinationApplicationSecurityGroupId
    - Updated Set-AzureRmNetworkSecurityRuleConfig: Added optional parameters SourceApplicationSecurityGroup, SourceApplicationSecurityGroupId, DestinationApplicationSecurityGroup, and DestinationApplicationSecurityGroupId

## Version 4.3.1

## Version 4.3.0
* New-AzureRmExpressRouteCircuitPeeringConfig: Added IPv6 support. New optional parameter added
	- PeerAddressType
* Set-AzureRmExpressRouteCircuitPeeringConfig: Added IPv6 support. New optional parameter added
	- PeerAddressType
* Remove-AzureRmExpressRouteCircuitPeeringConfig: Added IPv6 support. New optional parameter added
	- PeerAddressType
* Marked parameter -ProbeEnabled as obsolete
    - Add-AzureRmApplicationGatewayBackendHttpSettings
    - New-AzureRmApplicationGatewayBackendHttpSettings
    - Set-AzureRmApplicationGatewayBackendHttpSettings

## Version 4.2.1

## Version 4.2.0
* New-AzureRmIpsecPolicy: SALifeTimeSeconds and SADataSizeKilobytes are no longer mandatory parameters
    - SALifeTimeSeconds defaults to 27000 seconds
    - SADataSizeKilobytes defaults to 102400000 KB
* Added support for custom cipher suite configuration using ssl policy and listing all ssl options api in Application Gateway
    - Added optional parameter -PolicyType, -PolicyName, -MinProtocolVersion, -Ciphersuite
        - Add-AzureRmApplicationGatewaySslPolicy
        - New-AzureRmApplicationGatewaySslPolicy
        - Set-AzureRmApplicationGatewaySslPolicy
    - Added Get-AzureRmApplicationGatewayAvailableSslOptions (Alias: List-AzureRmApplicationGatewayAvailableSslOptions)
    - Added Get-AzureRmApplicationGatewaySslPredefinedPolicy (Alias: List-AzureRmApplicationGatewaySslPredefinedPolicy)
* Added redirect support in Application Gateway
    - Added Add-AzureRmApplicationGatewayRedirectConfiguration
    - Added Get-AzureRmApplicationGatewayRedirectConfiguration
    - Added New-AzureRmApplicationGatewayRedirectConfiguration
    - Added Remove-AzureRmApplicationGatewayRedirectConfiguration
    - Added Set-AzureRmApplicationGatewayRedirectConfiguration
    - Added optional parameter -RedirectConfiguration
        - Add-AzureRmApplicationGatewayRequestRoutingRule
        - New-AzureRmApplicationGatewayRequestRoutingRule
        - Set-AzureRmApplicationGatewayRequestRoutingRule
    - Added optional parameter -DefaultRedirectConfiguration
        - Add-AzureRmApplicationGatewayUrlPathMapConfig
        - New-AzureRmApplicationGatewayUrlPathMapConfig
        - Set-AzureRmApplicationGatewayUrlPathMapConfig
    - Added optional parameter -RedirectConfiguration
        - Add-AzureRmApplicationGatewayPathRuleConfig
        - New-AzureRmApplicationGatewayPathRuleConfig
        - Set-AzureRmApplicationGatewayPathRuleConfig
    - Added optional parameter -RedirectConfigurations
        - New-AzureRmApplicationGateway
        - Set-AzureRmApplicationGateway
* Added support for azure websites in Application Gateway
    - Added New-AzureRmApplicationGatewayProbeHealthResponseMatch
    - Added optional parameters -PickHostNameFromBackendHttpSettings, -MinServers, -Match
        - Add-AzureRmApplicationGatewayProbeConfig
        - New-AzureRmApplicationGatewayProbeConfig
        - Set-AzureRmApplicationGatewayProbeConfig
    - Added optional parameters -PickHostNameFromBackendAddress, -AffinityCookieName, -ProbeEnabled, -Path
        - Add-AzureRmApplicationGatewayBackendHttpSettings
        - New-AzureRmApplicationGatewayBackendHttpSettings
        - Set-AzureRmApplicationGatewayBackendHttpSettings
* Update Get-AzureRmPublicIPaddress to retrieve publicipaddress resources created via VM Scale Set
* Added cmdlet to get virtual network current usage
    - Get-AzureRmVirtualNetworkUsageList

## Version 4.1.0
* Get-AzureRmNetworkUsage: New cmdlet to show network usage and capacity details
* Added new GatewaySku options for VirtualNetworkGateways
    - VpnGw1, VpnGw2, VpnGw3 are the new Skus added for Vpn gateways
* Set-AzureRmNetworkWatcherConfigFlowLog
  * Fixed  help examples

## Version 4.0.1

## Version 4.0.0
* Added Test-AzureRmNetworkWatcherConnectivity cmdlet
    - Returns connectivity information for a specified source VM and a destination
    - If connectivity between the source and destination cannot be established, the cmdlet returns details about the issue

## Version 3.7.0
* Added support for new web application firewall features to Application Gateways
    - Added New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig
    - Added Get-AzureRmApplicationGatewayAvailableWafRuleSets (Alias: List-AzureRmApplicationGatewayAvailableWafRuleSets)
    - Updated New-AzureRmApplicationGatewayWebApplicationFirewallConfiguration: Added parameter -RuleSetType -RuleSetVersion and -DisabledRuleGroups
    - Updated Set-AzureRmApplicationGatewayWebApplicationFirewallConfiguration: Added parameter -RuleSetType -RuleSetVersion and -DisabledRuleGroups

* Added support for IPSec policies to Virtual Network Gateway Connections
	- Added New-AzureRmIpsecPolicy
	- Updated New-AzureRmVirtualNetworkGatewayConnection: Added parameter -IpsecPolicies and -UsePolicyBasedTrafficSelectors

## Version 3.6.0
* Added support for connection draining to Application Gateways
    - Added Get-AzureRmApplicationGatewayConnectionDraining
    - Added New-AzureRmApplicationGatewayConnectionDraining
    - Added Remove-AzureRmApplicationGatewayConnectionDraining
    - Added Set-AzureRmApplicationGatewayConnectionDraining
    - Updated Add-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameter -ConnectionDraining
    - Updated New-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameter -ConnectionDraining
    - Updated Set-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameter -ConnectionDraining

* Remapped unused 'Name' parameter in ExpressRoute cmdlets to 'ExpressRouteCircuitName'
    - Get-AzureRmExpressRouteCircuitARPTable
    - Get-AzureRmExpressRouteCircuitRouteTable
    - Get-AzureRmExpressRouteCircuitRouteTableSummary
    - Get-AzureRmExpressRouteCircuitStats

## Version 3.5.0
* Added support for network Watcher APIs
    - New-AzureRmNetworkWatcher
    - Get-AzureRmNetworkWatcher
    - Remove-AzureRmNetworkWatcher
    - New-AzureRmPacketCaptureFilterConfig
    - New-AzureRmNetworkWatcherPacketCapture
    - Get-AzureRmNetworkWatcherPacketCapture
    - Stop-AzureRmNetworkWatcherPacketCapture
    - Remove-AzureRmNetworkWatcherPacketCapture
    - Get-AzureRmNetworkWatcherFlowLogSatus
    - Get-AzureRmNetworkWatcherNextHop
    - Get-AzureRmNetworkWatcherSecurityGroupView
    - Get-AzureRmNetworkWatcherTopology
    - Get-AzureRmNetworkWatcherTroubleshootingResult
    - Set-AzureRmNetworkWatcherConfigFlowLog
    - Start-AzureRmNetworkWatcherResourceTroubleshooting
    - Test-AzureRmNetworkWatcherIPFlow
* Add-AzureRmExpressRouteCircuitPeeringConfig
    - Added new param :-RouteFilter to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource
    - Added new param :-RouteFilterId to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource id
* New-AzureRmExpressRouteCircuitPeeringConfig
    - Added new param :-RouteFilter to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource
    - Added new param :-RouteFilterId to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource id
* Set-AzureRmExpressRouteCircuitPeeringConfig
    - Added new param :-RouteFilter to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource
    - Added new param :-RouteFilterId to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource id
* New cmdlets for selective service feature
    - Get-AzureRmRouteFilter
    - New-AzureRmRouteFilter
    - Set-AzureRmRouteFilter
    - Remove-AzureRmRouteFilter
    - Add-AzureRmRouteFilterRuleConfig
    - Get-AzureRmRouteFilterRuleConfigobject
    - New-AzureRmRouteFilterRuleConfig
    - Set-AzureRmRouteFilterRuleConfig
    - Remove-AzureRmRouteFilterRuleConfig

## Version 3.4.0

## Version 3.3.0

## Version 3.2.0
* Get-AzureRmVirtualNetworkGatewayConnection
    - Added new param :- TunnelConnectionStatus in output Connection object to show per tunnel connection health status.
* Reset-AzureRmVirtualNetworkGateway
    - Added optional input param:- gatewayVip to pass gateway vip for ResetGateway API in case of Active-Active feature enabled gateways.
    - Gateway Vip can be retrieved from PublicIPs refered in VirtualNetworkGateway object.

## Version 3.1.0
* Add-AzureRmVirtualNetworkPeering
    - Parameter AlloowGatewayTransit renamed to AllowGatewayTransit (an alias for the old parameter was created)
    - Fixed issue where UseRemoteGateway property was not being populated in the request to the server
* Get-AzureRmEffectiveNetworkSecurityGroup
    - Add warning if there is no response from GetEffectiveNSG
* Add Source property to EffectiveRoute
