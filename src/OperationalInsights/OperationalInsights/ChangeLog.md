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

## Version 1.1.0
* Additional support for New and Get ApplicationInsights data source.
    - Added new 'ApplicationInsights' kind to support Get specific and Get all ApplicationInsights data sources for given workspace. 
    - Added New-AzOperationalInsightsApplicationInsightsDataSource cmdlet for creating data source by given Application-Insights resource parameters: subscription Id, resourceGroupName and name. 
## Version 1.0.0
* General availability of `Az.OperationalInsights` module
* Default parameter set for Get-AzOperationalInsightsDataSource is removed, and ByWorkspaceNameByKind has become the default parameter set
