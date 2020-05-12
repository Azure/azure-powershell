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
