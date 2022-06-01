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
* Fixed parameters for Set-AzApplicationInsightsDailyCap [#18315]

## Version 2.0.0
* Upgraded API version for ApplicationInsights component to 2020-02-02
* Supported Log Analytics workspace-based component by `New-AzApplicationInsights` and `Update-AzApplicationInsights`

## Version 1.3.1
* Added breaking change warnings for upcoming Az.ApplicationInsights 2.0.0

## Version 1.3.0
* Added WebTest function. Below is the new cmdlet
    * `Get-AzApplicationInsightsWebTest`
    * `New-AzApplicationInsightsWebTest`
    * `New-AzApplicationInsightsWebTestGeolocationObject`
    * `New-AzApplicationInsightsWebTestHeaderFieldObject`
    * `Remove-AzApplicationInsightsWebTest`
    * `Update-AzApplicationInsightsWebTestTag`

## Version 1.2.0
* Added read only property `ConnectionString` and `ApplicationId` to applicationinsights component

## Version 1.1.1
* Fixed issue that `ResourcegroupName` is missed when executing below cmdlets with `InputObject` parameter [#14848]
    * `Get-AzApplicationInsightsLinkedStorageAccount`
    * `New-AzApplicationInsightsLinkedStorageAccount`
    * `Update-AzApplicationInsightsLinkedStorageAccount`
    * `Remove-AzApplicationInsightsLinkedStorageAccount` 

## Version 1.1.0
* Added Parameters: `RetentionInDays` `PublicNetworkAccessForIngestion` `PublicNetworkAccessForQuery` for `New-AzApplicationInsights`
* Created cmdlet `Update-AzApplicationInsights`
* Created cmdlets for Linked Storage Account

## Version 1.0.3
* Update references in .psd1 to use relative path

## Version 1.0.2
* Fixed miscellaneous typos across module

## Version 1.0.1
* Fix example typo in `Remove-AzApplicationInsightsApiKey` documentation 

## Version 1.0.0
* General availability of `Az.ApplicationInsights` module
