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

## Version 0.2.0
* Updated API version from 2022-07-01 to 2024-01-01.
* Added cmdlets:
    - Get-AzNewRelicBillingInfo
    - Get-AzNewRelicConnectedPartnerResource
    - New-AzNewRelicFilteringTagObject
    - New-AzNewRelicMonitoredSubscription
    - Get-AzNewRelicMonitoredSubscription
    - Remove-AzNewRelicMonitoredSubscription
    - Update-AzNewRelicMonitoredSubscription
    - New-AzNewRelicMonitoredSubscriptionObject
    - Get-AzNewRelicMonitorLinkedResource
* Renamed cmdlet Get-AzNewRelicMonitorAppService to Get-AzNewRelicConnectedPartnerResource.
* Renamed cmdlet Get-AzNewRelicMonitorAppService to Get-AzNewRelicMonitoredAppService.
* Renamed cmdlet Get-AzNewRelicMonitorHost to Get-AzNewRelicMonitoredHost.
* Updated manage identity design.

## Version 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.1.0
* First preview release for module Az.NewRelic

