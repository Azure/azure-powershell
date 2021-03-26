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
-->
## Upcoming Release

## Version 1.7.2
* Fixed that `New-AzServiceBusAuthorizationRuleSASToken` returns invalid token. [#12975]

## Version 1.7.1
* Fixed Cluster commands for EventHub cluster without tags
* Updated help text for PartnerNamespace of AzEventHubGeoDRConfiguration commands 

## Version 1.7.0
* Added optional switch parameter `TrustedServiceAccessEnabled` to `Set-AzEventHubNetworkRuleSet` cmdlet

## Version 1.6.0
* Added new Cluster cmdlets - `New-AzEventHubCluster`, `Set-AzEventHubCluster`, `Get-AzEventHubCluster`, `Remove-AzEventHubCluster`, `Get-AzEventHubClustersAvailableRegions`.
* Fixed for issue #10722 : Fix for assigning only 'Listen' to AuthorizationRule rights.

## Version 1.5.0
* Added Managed Identity parameters to `New-AzEventHubNamespace` and `Set-AzEventHubNamespace` cmdlets

## Version 1.4.3
* Fix for issue 10634 : Fix the null Object reference for remove eventhubnamespace

## Version 1.4.2
* Update references in .psd1 to use relative path

## Version 1.4.1
* Fix for issue 10301 : Fix the SAS Token date format

## Version 1.4.2
* Update references in .psd1 to use relative path

## Version 1.4.1
* Fix for issue 10301 : Fix the SAS Token date format

## Version 1.4.0
* Fixed miscellaneous typos across module
* Fix for issue #9658 : Typo VirtualNteworkRule parameter in Set-AzEventHubNetworkRuleSet
* Fix for issue #9558 : Set-AzEventHubNamespace is using PATCH instead of PUT
* added EnableKafka parameter to Set-AzEventHubNamespace cmdlet
* Fix for issue #9786 : cannot create a rule with Listen only rights

## Version 1.3.0
* Added new cmmdlet added for generating SAS token : New-AzEventHubAuthorizationRuleSASToken
* added verification and error message for authorizationrules rights if only 'Manage' is assigned

## Version 1.2.0
* Fix for #9231 - Get-AzEventHubNamespace does not return tags
* Fix for #9230 - Get-AzEventHubNamespace returns ResourceGroup instead of ResourceGroupName

## Version 1.1.0
* Added new cmdlets for NetworkRuleSet of Namespace 

## Version 1.0.1
* Added new boolean property SkipEmptyArchives to Skip Empty Archives in CaptureDescription class of Eventhub 

## Version 1.0.0
* General availability of `Az.EventHub` module
