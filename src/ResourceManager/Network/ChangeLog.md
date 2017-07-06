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
-->
## Current Release
* New-AzureRmIpsecPolicy: SALifeTimeSeconds and SADataSizeKilobytes are no longer mandatory parameters
    - SALifeTimeSeconds defaults to 27000 seconds
    - SADataSizeKilobytes defaults to 102400000 KB
* Added support for custom cipher suite configuration using ssl policy and listing all ssl options api in Application Gateway
    - Updated Add-AzureRmApplicationGatewaySslPolicy: Added optional parameter -PolicyType, -PolicyName, -MinProtocolVersion, -Ciphersuite
    - Updated New-AzureRmApplicationGatewaySslPolicy: Added optional parameter -PolicyType, -PolicyName, -MinProtocolVersion, -Ciphersuite
    - Updated Set-AzureRmApplicationGatewaySslPolicy: Added optional parameter -PolicyType, -PolicyName, -MinProtocolVersion, -Ciphersuite
    - Added Get-AzureRmApplicationGatewayAvailableSslOptions (Alias: List-AzureRmApplicationGatewayAvailableSslOptions)
    - Added Get-AzureRmApplicationGatewaySslPredefinedPolicy (Alias: List-AzureRmApplicationGatewaySslPredefinedPolicy)
* Added redirect support in Application Gateway
    - Added Add-AzureRmApplicationGatewayRedirectConfiguration
    - Added Get-AzureRmApplicationGatewayRedirectConfiguration
    - Added New-AzureRmApplicationGatewayRedirectConfiguration
    - Added Remove-AzureRmApplicationGatewayRedirectConfiguration
    - Added Set-AzureRmApplicationGatewayRedirectConfiguration
    - Updated Add-AzureRmApplicationGatewayRequestRoutingRule: Added optional parameter -RedirectConfiguration
    - Updated New-AzureRmApplicationGatewayRequestRoutingRule: Added optional parameter -RedirectConfiguration
    - Updated Set-AzureRmApplicationGatewayRequestRoutingRule: Added optional parameter -RedirectConfiguration
    - Updated Add-AzureRmApplicationGatewayUrlPathMapConfig: Added optional parameter -DefaultRedirectConfiguration
    - Updated New-AzureRmApplicationGatewayUrlPathMapConfig: Added optional parameter -DefaultRedirectConfiguration
    - Updated Set-AzureRmApplicationGatewayUrlPathMapConfig: Added optional parameter -DefaultRedirectConfiguration
    - Updated Add-AzureRmApplicationGatewayPathRuleConfig: Added optional parameter -RedirectConfiguration
    - Updated New-AzureRmApplicationGatewayPathRuleConfig: Added optional parameter -RedirectConfiguration
    - Updated Set-AzureRmApplicationGatewayPathRuleConfig: Added optional parameter -RedirectConfiguration
    - Updated New-AzureRmApplicationGateway: Added optional parameter -RedirectConfigurations
    - Updated Set-AzureRmApplicationGateway: Added optional parameter -RedirectConfigurations
* Added support for azure websites in Application Gateway
    - Added New-AzureRmApplicationGatewayProbeHealthResponseMatch
    - Updated Add-AzureRmApplicationGatewayProbeConfig: Added optional parameters -PickHostNameFromBackendHttpSettings, -MinServers, -Match
    - Updated New-AzureRmApplicationGatewayProbeConfig: Added optional parameters -PickHostNameFromBackendHttpSettings, -MinServers, -Match
    - Updated Set-AzureRmApplicationGatewayProbeConfig: Added optional parameters -PickHostNameFromBackendHttpSettings, -MinServers, -Match
    - Updated Add-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameters -PickHostNameFromBackendAddress, -AffinityCookieName, -ProbeEnabled, -Path
    - Updated New-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameters -PickHostNameFromBackendAddress, -AffinityCookieName, -ProbeEnabled, -Path
    - Updated Set-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameters -PickHostNameFromBackendAddress, -AffinityCookieName, -ProbeEnabled, -Path

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
