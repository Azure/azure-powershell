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
* Bumped api version to `2021-06-01`
* Migrated the cmdlets from SDK-based to autorest generated.
* Deleted cmdlets
  - Disable-AzCdnCustomDomain
  - Enable-AzCdnCustomDomain
  - Get-AzCdnEdgeNodes
  - Get-AzCdnProfileSsoUrl
  - New-AzCdnDeliveryPolicy
  - Set-AzFrontDoorCdnSecret
* Added cmdlets
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
* Add cmdlets to create in-memory object
  - New-AzCdn*ParametersObject
  - New-AzCdnResourceReferenceObject
  - New-AzFrontDoorCdn*ParametersObject
  - New-AzFrontDoorCdnResourceReferenceObject
* Renamed cmdlets
  - Set-AzCdnEndpoint -> Update-AzCdnEndpoint
  - Set-AzCdnOrigin -> Update-AzCdnOrigin
  - Set-AzCdnOriginGroup -> Update-AzCdnOriginGroup
  - Set-AzCdnProfile -> Update-AzCdnProfile
  - Set-AzFrontDoorCdnCustomDomain -> Update-AzFrontDoorCdnCustomDomain
  - Set-AzFrontDoorCdnEndpoint -> Update-AzFrontDoorCdnEndpoint
  - Set-AzFrontDoorCdnOrigin -> Update-AzFrontDoorCdnOrigin
  - Set-AzFrontDoorCdnOriginGroup -> Update-AzFrontDoorCdnOriginGroup
  - Set-AzFrontDoorCdnProfile -> Update-AzFrontDoorCdnProfile
  - Set-AzFrontDoorCdnRoute -> Update-AzFrontDoorCdnRoute
  - Set-AzFrontDoorCdnSecurityPolicy -> Update-AzFrontDoorCdnSecurityPolicy
  - Validate-AzCdnCustomDomain -> Test-AzCdnEndpointCustomDomain
  - Confirm-AzCdnEndpointProbeURL -> Test-AzCdnProbe
  - Disable-AzCdnCustomDomainHttps -> Disable-AzCdnCustomDomainCustomHttps
  - Enable-AzCdnCustomDomainHttps -> Enable-AzCdnCustomDomainCustomHttps
  - Get-AzCdnEndpointNameAvailability -> Test-AzCdnNameAvailability
  - Publish-AzCdnEndpointContent -> Import-AzCdnEndpointContent
  - Test-AzCdnCustomDomain -> Test-AzCdnEndpointCustomDomain
  - Unpublish-AzCdnEndpointContent -> Clear-AzCdnEndpointContent
  - New-AzCdnDeliveryRule -> New-AzCdnDeliveryRuleObject
  - New-AzCdnDeliveryRuleAction -> New-AzCdnDeliveryRuleActionObject
  - New-AzCdnDeliveryRuleCondition -> New-AzCdnDeliveryRuleConditionObject
  - New-AzFrontDoorCdnRuleAction -> New-AzFrontDoorCdnRuleActionObject
  - New-AzFrontDoorCdnRuleCondition -> New-AzFrontDoorCdnRuleConditionObject


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

