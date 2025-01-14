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
* upgraded nuget package to signed package.

## Version 5.0.1
* Migrated EventHub SDK to generated SDK
  - Removed "Microsoft.Azure.Management.EventHub" Version "5.0.0" PackageReference
  - Added EventHub.Management.Sdk ProjectReference

## Version 5.0.0
* Moved cmdlets to V4

## Version 4.2.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 4.2.1
* Added Breaking Change Warning for parameter datatype change.

## Version 4.2.0
*  Added parameter `PartitionCount` to `Set-AzEventHub`

## Version 4.1.0
* Supported EventHub MSI capture feature in cmdlets `New-AzEventHub` and `Set-AzEventHub`

## Version 4.0.0
* Aliased `New-AzEventHubNamespace`, `Remove-AzEventHubNamespace`, `Set-AzEventHubNamespace`, `Get-AzEventHubNamespace` with `New-AzEventHubNamespaceV2`, `Remove-AzEventHubNamespaceV2`, `Set-AzEventHubNamespaceV2`, `Get-AzEventHubNamespaceV2` respectively
* Replaced `New-AzEventHubEncryptionConfig` by `New-AzEventHubKeyVaultPropertiesObject`

## Version 3.2.3
* Added upcoming breaking change notifications for Az.EventHub module.

## Version 3.2.2
* Added breaking change description for parameter `MessageRetentionInDays`, which would be deprecated and would be replaced by `RetentionTimeInHours`

## Version 3.2.1
* Fixed 'New-AzEventHubAuthorizationRuleSASToken' cmdlet which was returning wrong skn value

## Version 3.2.0
* Added NamespaceV2 cmdlets for EventHub

## Version 3.1.0
* Added readonly Status property in EventHub Namespace 

## Version 3.0.0
* Most cmdlets in Az.EventHub module have been migrated to a new format and would witness breaking changes. Please refer our migration guide https://go.microsoft.com/fwlink/?linkid=2204690 to know breaking changes in detail.

## Version 2.2.1
* In the upcoming major breaking change release in October 2022, Az.EventHub would be migrating most cmdlets to a new format
for a better powershell experience and as a result would witness breaking changes. Please refer our migration guide to know more https://go.microsoft.com/fwlink/?linkid=2204690.

## Version 2.2.0
* Added -MinimumTlsVersion to New-AzEventHubNamespace and Set-AzEventHubNamespace
* Added -SupportsScaling to New-AzEventHubCluster and Set-AzEventHubCluster to support self serve clusters
* Deprecation warning on a few parameters in cluster cmdlets that will be deprecated in the November major release

## Version 2.1.0
* Added cmdlets for CRUD operations on EventHub Application Groups. The added cmdlets include,
    -New-AzEventHubApplicationGroup
    -Set-AzEventHubApplicationGroup
    -Remove-AzEventHubApplicationGroup
    -Get-AzEventHubApplicationGroup
    -New-AzEventHubThrottlingPolicyConfig
* Get-AzEventHubNamespace returned a maximum of 100 namespaces for list by resource groups or list by subscriptions so far. From here onwards, for resource groups and subscriptions with over a 100 namespaces, the cmdlet will return all the namespaces. You will not see a change in the cmdlet behaviour if your resource groups or subscriptions have less than a 100 namespaces.
* Added cmdlets for manual approval of EventHubs Private Endpoint Connections. The added cmdlets include,
    -Approve-AzEventHubPrivateEndpointConnection
    -Deny-AzEventHubPrivateEndpointConnection
    -Get-AzEventHubPrivateEndpointConnection
    -Remove-AzEventHubPrivateEndpointConnection
    -Get-AzEventHubPrivateLink

## Version 2.0.0
* Made `IPRule` and `VirtualNetworkRule` optional in `Set-AzEventHubNetworkRuleSet`.
* Deprecated older MSI properties in `Set-AzEventHubNamespace` and `New-AzEventHubNamespace`

## Version 1.11.1

* Deprecating older MSI related fields in New-AzEventHubNamespace and Set-AzEventHubNamespace

## Version 1.11.0
* Added MSI properties to New-AzEventHubNamespace and Set-AzEventHubNamespace. Adding New-AzEventHubEncryptionConfig.

## Version 1.10.0
* Added public network access to the `Set-AzEventHubNetworkRuleSet` set cmdlet
* Added `New-AzEventHubSchemaGroup`, `Remove-AzEventHubSchemaGroup` and `Get-AzEventHubSchemaGroup` in the eventhubs PS.

## Version 1.9.1
* Fixed the issue that `New-AzEventHubKey` always generates a new primary key instead of a secondary key since version 1.9.0 [#16362]

## Version 1.9.0
* Added support for Premium sku and namesapce and optional switch parameter 'DisableLocalAuth' to `New-AzEventHubNamespace` and `Set-AzEventHubNamespace` 

## Version 1.8.0
* Added functionality to accept input from pipeline for `Get-AzEventHub` from `Get-AzEventHubNamespace`.

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
