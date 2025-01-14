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

## Version 3.1.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 3.1.1
* Removed unnecessary breaking change messages.

## Version 3.1.0
* Fixed parameters' issues for `New-AzSentinelAlertRule` and `Update-AzSentinelAlertRule` [#21181][#21217][#22318]

## Version 3.0.2
* Added breaking change message for `Az.SecurityInsights`.

## Version 3.0.1
* Fixed for `Update-AzSentinelAlertRule` fails when using `-TriggerThreshold 0` [#20417]

## Version 3.0.0
* Changed `Az.SecurityInsights` to autorest-based module

## Version 1.1.0
* Updated to `Get-AzSentinelIncident` parameters
    - Added `-Filter` to support OData filter
    - Added `-OrderBy` to support OData ordering
    - Added `-Max` to support retrieving more than the default of 1000 incidents.

## Version 1.0.0
* GA release for `Az.SecurityInsights`.

## Version 0.2.0
* Added support for Teams in Office Connector
* Bug Fixes
* Updated Documentations

## Version 0.1.0
* Initial Release
