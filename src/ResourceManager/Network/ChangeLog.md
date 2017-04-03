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
