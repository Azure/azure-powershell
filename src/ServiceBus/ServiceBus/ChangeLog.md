<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
        - Added ServiceBus NameSpace, Queue, Topic and Subscription cmdlets #1
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
## Upcoming Release

## Version 1.10.0
* Added cmdlets for manual approval of Service Bus Private Endpoint Connections. The added cmdlets include,
    -Approve-AzServiceBusPrivateEndpointConnection
    -Deny-AzServiceBusPrivateEndpointConnection
    -Get-AzServiceBusPrivateEndpointConnection
    -Remove-AzServiceBusPrivateEndpointConnection
    -Get-AzServiceBusPrivateLink

## Version 1.9.0
* Fixed miscellaneous network rule set typos across module.
* Add `TrustedServiceAccessEnabled` to `Set-AzServiceBusNetworkRuleSet`

## Version 1.8.1
* Fixed that `New-AzServiceBusAuthorizationRuleSASToken` returns invalid token. [#12975]
 
## Version 1.8.0
* Added identity and encryption properties to New-AzServiceBusNamespace and Set-AzServiceBusNamespace.
* Added New-AzServiceBusEncryptionConfig

## Version 1.7.0
* Added support to Enable or Disable  Public Network Access as optional parameter 'PublicNetworkAccess' to `Set-AzServiceBusNetworkRuleSet`
* Fixed `Set-AzServiceBusNamespace` with Tags 

## Version 1.6.0
* Added support for ZoneRedundant and optional switch parameter 'DisableLocalAuth' to `New-AzServiceBusNamespace` and `Set-AzServiceBusNamespace` 

## Version 1.5.0
* Fixed that `New-AzServiceBusAuthorizationRuleSASToken` returns invalid token. [#12975]

## Version 1.4.1
* Update references in .psd1 to use relative path

## Version 1.4.0
* Fixed miscellaneous typos across module
* Fix for issue #9658 : Typo VirtualNetworkRule parameter in Set-AzServiceBusNetworkRuleSet
* Fix for issue #9786 : cannot create a rule with Listen only rights
* Added new command 'Test-AzServiceBusNameAvailability' to check the name availability for queue and topic 

## Version 1.3.0
* Added new cmmdlet added for generating SAS token : New-AzServiceBusAuthorizationRuleSASToken
* Added verification and error message for authorizationrules rights if only 'Manage' is assigned

## Version 1.2.1
* Fix for issue #4938 - New-AzureRmServiceBusQueue returns BadRequest when setting MaxSizeInMegabytes

## Version 1.2.0
* Fix for issue #9182 - Get-AzServiceBusNamespace returns ResourceGroup instead of ResourceGroupName
* Fix spelling of Namespace in Resources.resx

## Version 1.1.0
* Added new cmdlets for NetworkRuleSet of Namespace

## Version 1.0.0
* General availability of `Az.ServiceBus` module
