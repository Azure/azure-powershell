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

## Version 3.2.2
* Added support to enable ManagedIdentity when no BYOC in the classic front door during migration

## Version 3.2.1
* Bypassed object id validation for KeyVault access policy during `Start-AzFrontDoorCdnProfilePrepareMigration`

## Version 3.2.0
* Introduced secrets detection feature to safeguard sensitive data.
* Upgrade API version to 2024-02-01
* Added support to configure rules to scrub PII values from the AFDx logs when new or update a AFDx resource.
  
## Version 3.1.2
* Fixed the case sensitive issue when do preparing migration steps for `Start-AzFrontDoorCdnProfilePrepareMigration`

## Version 3.1.1
* Customized output property for `Get-AzCdnEdgeNode` command

## Version 3.1.0
* Upgraded API version to 2023-05-01
* Fixed known issue for `Update-AzCdnProfile`, `Update-AzFrontDoorCdnProfile`, `Remove-AzCdnProfile`, `Remove-AzCdnProfile`

## Version 3.0.0
* Upgraded API version to 2022-11-01-preview
* Added support to migrate from Azure Front Door (classic) to Azure Front Door Standard and Premium.
* Added support for AFDX upgrade from Standard tier to Premium tier.

## Version 2.1.0
* Upgraded API version to 2021-06-01
* Removed deprecated cmdlets
  - Disable-AzCdnCustomDomain
  - Enable-AzCdnCustomDomain
  - Get-AzCdnEdgeNodes
  - Get-AzCdnProfileSsoUrl
  - New-AzCdnDeliveryPolicy
  - Set-AzFrontDoorCdnSecret
* Added new cmdlets
  - Clear-AzFrontDoorCdnEndpointContent
  - Get-AzFrontDoorCdnEndpointResourceUsage
  - Get-AzFrontDoorCdnOriginGroupResourceUsage
  - Get-AzFrontDoorCdnProfileResourceUsage
  - Get-AzFrontDoorCdnRuleSetResourceUsage
  - Test-AzFrontDoorCdnEndpointCustomDomain
  - Test-AzFrontDoorCdnEndpointNameAvailability
  - Test-AzFrontDoorCdnProfileHostNameAvailability
  - Update-AzFrontDoorCdnCustomDomainValidationToken
  - Update-AzFrontDoorCdnRule
* Renamed Set cmdlets to Update cmdlets
* Renamed `Unpublish-AzCdnEndpointContent` cmdlets to `Clear-AzCdnEndpointContent`
* Added `Object` suffix to memory object creation cmdlets

## Version 1.8.3
* Added breaking change messages for all cmdlets in Az.CDN module

## Version 1.8.2
* Added breaking change messages for upcoming breaking change release of version 2.0.0

## Version 1.8.1
* Fixed null reference exception and typos in `New-AzFrontDoorCdnRule` cmdlet

## Version 1.8.0
* Fixed mandatory parameters issue in `Get-AzCdnEndpointResourceUsage` cmdlet

## Version 1.7.1
* Fixed profile missing issue in `Remove-AzCdnProfile` cmdlet

## Version 1.7.0
* Added cmdlets to support new AFD Premium / Standard SKUs
  
## Version 1.6.0
* Added cmdlets to support multi-origin and private link functionality 

## Version 1.4.3
* Fixed ChinaCDN related pricing SKU display

## Version 1.4.2
* Display error response detail in New-AzCdnEndpoint cmdlet

## Version 1.4.1
* Update references in .psd1 to use relative path

## Version 1.4.0
* Introduced UrlRewriteAction and CacheKeyQueryStringAction to RulesEngine.
* Fixed several bugs like missing "Selector" Input in New-AzDeliveryRuleCondition cmdlet.

Fixed enabling CDN custom domain HTTPS for Microsoft and Akamai SKU's

## Version 1.3.1
* Fixed miscellaneous typos across module
* Fixed a typo in CDN module conversion helper

## Version 1.3.0
* Updated cmdlets to support rulesEngine feature based on API version 2019-04-15.

## Version 1.2.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.1.0
* Added new Powershell cmdlets for Enable/Disable Custom Domain Https and deprecated the old ones

## Version 1.0.1
* Update incorrect online help URLs

## Version 1.0.0
* General availability of `Az.Cdn` module

