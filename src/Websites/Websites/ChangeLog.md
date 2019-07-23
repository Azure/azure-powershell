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
