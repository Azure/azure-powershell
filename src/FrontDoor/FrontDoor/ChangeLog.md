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

## Version 1.11.1
* Fixed a not converting from string to base in CustomBlockResponseBody bug in updating waf policy

## Version 1.11.0
* Upgraded to api version 2024-02-01
* Added log scrubbing support and custom rules group by variable support

## Version 1.10.1
* Removed the outdated deps.json file.

## Version 1.10.0
* Fixed New-AzFrontDoorWafPolicy cmdlet to support adding Tags for the Azure Frontdoor waf policy

## Version 1.9.0
* Allowed rule engine action creation without RouteConfigurationOverride for `New-AzFrontDoorRulesEngineActionObject`.
* Fixed DynamicCompression parameter being ignored issue of `New-AzFrontDoorRulesEngineActionObject`.

## Version 1.8.0
* Allowed Enable-AzFrontDoorCustomDomainHttps's SecretVersion parameter to be optional to support bring-your-own-certificate auto-rotation
* Added Sku / RuleSetAction parameters for WAF

## Version 1.7.0
* Added FrontDoorId to properties
* Added JSON Exclusions and RequestBodyCheck support to managed rules

## Version 1.6.1
* Fixed an issue where an exception is being thrown when Enum.Parse tries to coerce a null value to an Enabled or Disabled enum values [#12344]

## Version 1.6.0
* Updated module to use API 2020-05-01
* Added Private link support for Storage, Keyvault and Web App Service resources

## Version 1.5.0
* Added new cmdlets for creation, update, retreival, and deletion of Front Door Rules Engine object
* Added helper cmdlets for construction of Front Door Rules Engine object
* Added Rules Engine reference to Front Door Routing Rule object.
* Added Private Link parameters to Front Door Backend object

## Version 1.4.0
* Added cmdlet to get managed rule definitions that can be used in WAF

## Version 1.3.0
* Update references in .psd1 to use relative path
* Added WAF managed rules exclusion support
* Add SocketAddr to auto-complete

## Version 1.2.0
* Add MinimumTlsVersion parameter to Enable-AzFrontDoorCustomDomainHttps and New-AzFrontDoorFrontendEndpointObject
* Add HealthProbeMethod and EnabledState parameters to New-AzFrontDoorHealthProbeSettingObject
* Add new cmdlet to create BackendPoolsSettings objec to pass into creation/update of Front Door
    - New-AzFrontDoorBackendPoolsSettingObject

## Version 1.1.2
* Fixed miscellaneous typos across module
* Added EnabledState parameter to New-AzFrontDoorWafCustomRuleObject

## Version 1.1.0
* New-AzFrontDoorWafMatchConditionObject
    - Add transforms support and new operator auto-complete value (RegEx)
* New-AzFrontDoorWafManagedRuleObject
    - Add new auto-complete values

## Version 1.0.0
* Rename WAF cmdlets to include 'Waf'
    - `Get-AzFrontDoorFireWallPolicy --> Get-AzFrontDoorWafPolicy`
    - `New-AzFrontDoorCustomRuleObject --> New-AzFrontDoorWafCustomRuleObject`
    - `New-AzFrontDoorFireWallPolicy --> New-AzFrontDoorWafPolicy`
    - `New-AzFrontDoorManagedRuleObject --> New-AzFrontDoorWafManagedRuleObject`
    - `New-AzFrontDoorManagedRuleOverrideObject --> New-AzFrontDoorWafManagedRuleOverrideObject`
    - `New-AzFrontDoorMatchConditionObject --> New-AzFrontDoorWafMatchConditionObject`
    - `New-AzFrontDoorRuleGroupOverrideObject --> New-AzFrontDoorWafRuleGroupOverrideObject`
    - `Remove-AzFrontDoorFireWallPolicy --> Remove-AzFrontDoorWafPolicy`
    - `Update-AzFrontDoorFireWallPolicy --> Update-AzFrontDoorWafPolicy`


## Version 0.7.4
* Change enum type parameters to string.

## Version 0.7.3
* Configure redirect routing rule.
* Enable/Disable cetificate name check for backend pools
* Modify WAF policy cmdlets to implement new swagger
    - Adds new managed rule sets capabilities
    - Adds redirect action

## Version 0.7.2
* Add cmdlets to enable/disable custom domain SSL
    - `Enable-AzFrontDoorCustomDomainHttps`
    - `Disable-AzFrontDoorCustomDomainHttps`
* Add cmdlet to get all existing frontend endpoints in the current front door resource
    - `Get-AzFrontDoorFrontendEndpoint`

## Version 0.7.1
* Add new cmdlets to enable/disable HTTPS for a custom domain
* Add new cmdlet to get frontend endpoint
