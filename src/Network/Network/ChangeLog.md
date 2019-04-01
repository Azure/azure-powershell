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
