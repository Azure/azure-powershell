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
* Fix bug where parameters could not be set to false for `Publish-AzWebApp`

## Version 3.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 3.2.0
* Fixed Ambiguous Positional Argument for `New-AzWebAppSlot`

## Version 3.1.2
* Adjusted `Publish-AzWebApp` default behavior

## Version 3.1.1
* Added support for XenonMV3 webapps

## Version 3.1.0
* Added AppServicePlan management support for P0V3 and P*mv3 tiers

## Version 3.0.1
* Increased timeout for Publish-AzWebApp command
* Fixed Set-AzWebApp issue with `Set-AzWebApp` when piping in Get-AzWebApp object [#21820]
* Added support for the PremiumMV3 tier to `New-AzAppServicePlan` [#21933]

## Version 3.0.0
* Removed `New-AzWebAppContainerPSSession` and `Enter-AzWebAppContainerPSSession` cmdlets

## Version 2.15.1
* Used AAD Auth instead of Basic Auth for PublishAzureWebApps
* Add support for OneDeploy API in PublishAzureWebApps while maintaining backwards compatibility with existing behavior

## Version 2.15.0
* Fixed Tag parameter issues with ASE for `New-AzWebApp`

## Version 2.14.0
* Fixed `Edit-AzWebAppBackupConfiguration` to pass backup configuration enabled or not
* Added a new parameter `-SoftRestart` for `Restart-AzWebApp` and `Restart-AzWebApp` to perform a soft restart
* Updated `Get-AzWebApp` and `Get-AzWebAppSlot` to expose `VirtualNetwork Integration Info` [#10665]
* Set default value for `-RepositoryUrl` of `New-AzStaticWebApp` [#21202]

## Version 2.13.0
* Added a new parameter `-CopyIdentity` for `New-AzWebAppSlot` to copy the identity from the parent app to the slot.
* Updated `New-AzWebAppSSLBinding` to support -WhatIf parameter

## Version 2.12.1
* Fixed `Import-AzWebAppKeyVaultCertificate` to use certificate naming convention same as portal [#19592]

## Version 2.12.0
* Added Tag parameter for `New-AzWebApp` and `New-AzWebAppSlot`
* Fixed `Set-AzWebApp` and `Set-AZWebAppSlot` to rethrow exception when Service Principal/User doesn't have permission to list web app configuration. [#19942]

## Version 2.11.5
* Fixed `Publish-AzWebApp` to use latest publish API when deploying war package [#19791]
## Version 2.11.4
* Fixed `Import-AzWebAppKeyVaultCertificate` to use certificate naming convention same as Az-CLI

## Version 2.11.3
* Fixed `Publish-AzWebapp` to handle relative paths properly [#18028]

## Version 2.11.2
* Updated `Get-AzWebApp` and `Get-AzWebAppSlot` to expose `VirtualNetworkSubnetId` property [#18042]
* Updated `Publish-AzWebApp` to avoid the false positive result when zip deploy is not reachable. 
## Version 2.11.1
* Updated 'New-AzWebAppContainerPSSession' with CmdletDeprecation Attribute [#16646]
* Updated `Restore-AzDeletedWebApp` to fix issue that prevents the cmdlet from working on hosts with a locale is anything different from `en-US`

## Version 2.11.0
* Fixed `Set-AzWebAppSlot` to support MinTlsVersion version update [#17663]
* Fixed `Set-AzAppServicePlan` to keep existing Tags when adding new Tags 
* Fixed `Set-AzWebApp`,`Set-AzWebAppSlot`, `Get-AzWebApp` and `Get-AzWebAppSlot` to expose `VnetRouteAllEnabled` property in `SiteConfig` [#15663]
* Fixed `Set-AzWebApp`, `Set-AzWebAppSlot`, `Get-AzWebApp` and `Get-AzWebAppSlot` to expose `HealthCheckPath` property in `SiteConfig` [#16325]
* Fixed DateTime conversion issue caused by culture [#17253]
* Added support for the web job feature [#661]
    - Get-AzWebAppContinuousWebJob
    - Get-AzWebAppSlotContinuousWebJob
    - Get-AzWebAppSlotTriggeredWebJob
    - Get-AzWebAppSlotTriggeredWebJobHistory
    - Get-AzWebAppSlotWebJob
    - Get-AzWebAppTriggeredWebJob
    - Get-AzWebAppTriggeredWebJobHistory
    - Get-AzWebAppWebJob
    - Remove-AzWebAppContinuousWebJob
    - Remove-AzWebAppSlotContinuousWebJob
    - Remove-AzWebAppSlotTriggeredWebJob
    - Remove-AzWebAppTriggeredWebJob
    - Start-AzWebAppContinuousWebJob
    - Start-AzWebAppSlotContinuousWebJob
    - Start-AzWebAppSlotTriggeredWebJob
    - Start-AzWebAppTriggeredWebJob
    - Stop-AzWebAppContinuousWebJob
    - Stop-AzWebAppSlotContinuousWebJob

## Version 2.10.0
* Updated `New-AzAppServicePlan`  to create an app service plan with host environment id #16094

## Version 2.9.0
* Updated the Microsoft.Azure.Management.Websites SDK to 3.1.2
## Version 2.8.3
* Updated `Import-AzWebAppKeyVaultCertificate1` to set the default name with combination of keyvault name and cert name 

## Version 2.8.2
* Fixed `Set-AzWebApp` to return a valid warning message when fails to add -Hostname #9316
* Fixed `Get-AzWebApp` to return CustomDomainVerificationId in the response. #9316

## Version 2.8.1
* Fixed `Add-AzWebAppAccessRestrictionRule` failing when users does not have permissions to get Service Tag list #15316 and #14862

## Version 2.8.0
* Fixed `Import-AzWebAppKeyVaultCertificate` to support ServerFarmId [#15091] 
* Fixed `Added an optional parameter to delete or keep Appservice plan when the last WebApp is removing from plan`

## Version 2.7.0
* Fixed issue that prevented removing rules by name and unique identifier in `Remove-AzWebAppAccessRestrictionRule`
* Fixed issue that defaults AlwaysOn to false in `Set-AzWebAppSlot`

## Version 2.6.0
* updated `Set-AzAppServicePlan` to keep existing Tags when adding new Tags
* Fixed `Set-AzWebApp` to set the AppSettings
* updated `Set-AzWebAppSlot` to set FtpsState
* Added support for StaticSites.

## Version 2.5.0
* Updated `Add-AzWebAppAccessRestrictionRule` to allow all supported Service Tags and validate against Service Tag API.

## Version 2.4.0
* Introduced an option to give custom timeout for `Publish-AzWebApp` 
* Added support for App Service Environment
    - `New-AzAppServiceEnvironment`
    - `Remove-AzAppServiceEnvironment`
    - `Get-AzAppServiceEnvironment`
    - `New-AzAppServiceEnvironmentInboundServices`
* Add-AzWebAppAccessRestrictionRule: When using subnet from another subscription, -IgnoreMissingServiceEndpoint must be used. Descriptive error message added.

## Version 2.3.0
* Added support for Importing a key vault certificate to WebApp.

## Version 2.2.0
* Added support for App Service Managed certificates
    - `New-AzWebAppCertificate`
    - `Remove-AzWebAppCertificate`
* Fixed issue that causes Docker Password to be removed from appsettings in `Set-AzWebApp` and `Set-AzWebAppSlot`

## Version 2.1.1
* Prevent duplicate access restriction rules

## Version 2.1.0
* Added support for new access restriction features: ServiceTag, multi-ip and http-headers

## Version 2.0.0
* Added support for Premium V3 pricing tier
* Updated the WebSites SDK to 3.1.0

## Version 1.11.0
* Added support to perform operations for Slots not in the same resource group as the App Service Plan

## Version 1.10.0
* Added safeguard to delete created webapp if restore failed in `Restore-AzDeletedWebApp`
* Added "SourceWebApp.Location" for `New-AzWebApp` and `New-AzWebAppSlot`
* Fixed bug that prevented changing Container settings in `Set-AzWebApp` and `Set-AzWebAppSlot`
* Fixed bug to get SiteConfig when -Name is not given for Get-AzWebApp
* Added a support to create ASP for Linux Apps
* Added exceptions for clone across resource groups
* Added support to perform operations for Slots not in the same resource group as the App Service Plan
* Added support to use Id for Restore-AzDeletedWebApp.

## Version 1.9.0
* Fixed typo on help of `Update-AzWebAppAccessRestrictionConfig`.

## Version 1.8.0
* Added support for working with webapp Traffic Routing Rules via below new cmdlets
	- `Get-AzWebAppTrafficRouting`
	- `Update-AzWebAppTrafficRouting`
	- `Add-AzWebAppTrafficRouting`
	- `Remove-AzWebAppTrafficRouting`

## Version 1.7.0
* Added Tag parameter for `New-AzAppServicePlan` and `Set-AzAppServicePlan`
* Stop cmdlet execution if an exception is thrown when adding a custom domain to a website
* Added support to perform operations for App Services not in the same resource group as the App Service Plan
* Applied access restriction to WebApp/Function in different resource groups
* Fixed issue to set custom hostnames for WebAppSlots

## Version 1.6.0
* Set-AzWebapp and Set-AzWebappSlot supports AlwaysOn, MinTls and FtpsState properties
* Fixing issue where setting HttpsOnly along with changing AppservicePlan at the same time using the single Set-AzWebApp Command, was resetting HttpsOnly to default value

## Version 1.5.1
* Update references in .psd1 to use relative path

## Version 1.5.0
* Set-AzWebApp updating ASP of an app was failing

## Version 1.4.2
* Fixing issue where webapp Tags were getting deleted when migrating App to new ASP
* Fixing the Publish-AzureWebapp to work across Linux and windows
* Update example in `Get-AzWebAppPublishingProfile` reference documentation
* Add support for working with Access Restrictions
	- New cmdlets
		- Get-AzWebAppAccessRestrictionConfig
		- Update-AzWebAppAccessRestrictionConfig
		- Add-AzWebAppAccessRestrictionRule
		- Remove-AzWebAppAccessRestrictionRule

## Version 1.4.1
* Fixed miscellaneous typos across module
* Add clarification around -AppSettings parameter in Set-AzWebApp and Set-AzWebAppSlot

## Version 1.4.0
* Fixing a bug where some SiteConfig properties were not returned by Get-AzWebApp and Set-AzWebApp
* Adds a new Location parameter to Get-AzDeletedWebApp and Restore-AzDeletedWebApp
* Fixes a bug with cloning web app slots using New-AzWebApp -IncludeSourceWebAppSlots


## Version 1.3.0
* Optimizes Get-AzWebAppCertificate to filter by resource group on the server instead of the client
* Adds -UseDisasterRecovery switch parameter to Get-AzWebAppSnapshot

## Version 1.2.2
* fixes the issue where using  Set-AzWebApp and Set-AzWebAppSlot with -WebApp property was removing the tags

## Version 1.2.1
* "Kind" property will now be set for PSSite objects returned by Get-AzWebApp
* Get-AzWebApp*Metrics and Get-AzAppServicePlanMetrics marked deprecated

## Version 1.2.0
* fixes the Set-AzWebApp and Set-AzWebAppSlot to not remove the tags on execution
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Updated the WebSites SDK.
* Removed the AdminSiteName property from PSAppServicePlan.

## Version 1.1.2
* Fix ARM template bug that breaks cloning all slots using `New-AzWebApp -IncludeSourceWebAppSlots` 

## Version 1.1.1
* Correct example in Get-AzWebAppSlotMetrics

## Version 1.1.0
* Update incorrect online help URLs
* Fixes `New-AzWebAppSSLBinding` to upload the certificate to the correct resourcegroup+location if the app is hosted on an ASE.
* Fixes `New-AzWebAppSSLBinding` to not overwrite the tags on binding an SSL certificate to an app

## Version 1.0.1
* Fixed a date parsing bug in `Get-AzDeletedWebApp`
* Fix backward compatibility issue with Az.Accounts module

## Version 1.0.0
* General availability of `Az.Websites` module
* Removed deprecated properties from PS models
