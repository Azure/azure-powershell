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

## Version 0.3.0
* Added AutoRest-generated NewRelic PowerShell module using API version 2025-05-01-preview
    - Generated 30 cmdlets covering complete NewRelic Observability service functionality
    - Added support for all NewRelic monitor management operations
    - Implemented comprehensive test coverage with record/playback capabilities
    - Added complete help documentation and usage examples
    - Updated test configuration for live Azure resource integration
* Enhanced module capabilities:
    - Initialize-AzNewRelicSaaSResource for SaaS resource activation
    - Invoke-AzNewRelicLatestMonitorLinkedSaaS for linked SaaS operations
    - Invoke-AzNewRelicLinkMonitorSaaS for SaaS linking
    - Invoke-AzNewRelicResubscribeMonitor for subscription management
    - Update-AzNewRelicMonitorIngestionKey for key refresh operations
    - Comprehensive tag rule, billing, and monitoring functionality

## Version 0.2.1
* Upgraded nuget package to signed package.

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

