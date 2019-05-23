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
* Update ResourceId and InputObject for Nat Gateway
    - Add alias for ResourceId and InputObject
* Updated below commands for feature: UseLocalAzureIpAddress flag on VpnConnection
	- Updated New-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
	- Updated Set-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
* Added readonly field PeeredConnections in ExpressRoute peering.
* Added readonly field GlobalReachEnabled in ExpressRoute.
* Added breaking change attribute to call out deprecation of AllowGlobalReach field in ExpressRouteCircuit model
* Fixed Issue 8756 Error using TargetListenerID with AzApplicationGatewayRedirectConfiguration cmdlets
* Fixed bug in New-AzApplicationGatewayPathRuleConfig that prevented the rewrite ruleset from being set.

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
* Added Update cmdlets which work like incremental Set i.e. you needn't to re-specify all the parameters to avoid nullifying of the corresponding properties
    - New cmdlets added:
        - Update-AzApplicationGatewayAutoscaleConfiguration
        - Update-AzApplicationGatewayBackendHttpSettings
        - Update-AzApplicationGatewayConnectionDraining
        - Update-AzApplicationGatewayWebApplicationFirewallConfiguration
        - Update-AzApplicationGatewayFrontendIPConfig
        - Update-AzApplicationGatewayHttpListener
        - Update-AzApplicationGatewayProbeConfig
        - Update-AzApplicationGatewayRequestRoutingRule
        - Update-AzApplicationGatewayRedirectConfiguration
        - Update-AzApplicationGatewaySku
        - Update-AzApplicationGatewaySslPolicy
        - Update-AzApplicationGatewayUrlPathMapConfig
        - Update-AzLoadBalancerInboundNatPoolConfig
        - Update-AzExpressRouteCircuitPeeringConfig
        - Update-AzNetworkInterfaceIpConfig
        - Update-AzRouteConfig
        - Update-AzLoadBalancerFrontendIpConfig
        - Update-AzLoadBalancerInboundNatRuleConfig
        - Update-AzRouteFilterRuleConfig
        - Update-AzLoadBalancerRuleConfig
        - Update-AzLoadBalancerProbeConfig
        - Update-AzLoadBalancerOutboundRuleConfig
        - Update-AzNetworkSecurityRuleConfig
        - Update-AzVirtualNetworkSubnetConfig
        - Update-AzServiceEndpointPolicyDefinition


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
