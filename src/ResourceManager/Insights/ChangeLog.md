<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0
* Allow users to unselect data sinks for Set-AzureRmDiagnosticSettings

## Version 2.5.0

## Version 2.4.0
* Parameter now accepts two more values in New-AzureRmAutoscaleRule
    - Parameter ScaleType now accepts the previous ChangeCount (default) plus two more values PercentChangeCount, and ExactCount
    - Add a warning message about this parameter accepting two more values
* Add parameter became optional in Add-AzureRmLogProfile
    - Parameter StorageAccountId is now optional
* Minor changes to the output classes to expose more properties
    - Before the user could see the properties because they were printed, but not access them programatically because they were protected for instance.

## Version 2.3.0
* Add several warning/deprecation messages about future changes to cmdlets
    - Add-AzureRmAutoscaleSetting
    - Get-AzureRmMetric
    - Get-AzureRmMetricDefinition
    - New-AzureRmAutoscaleRule
    - Remove-AzureRmAlertRule
    - Remove-AzureRmAutoscaleSetting
    - Remove-AzureRmLogProfile
* Add new parameter to Set-AzureRmDiagnosticSetting
    - Parameter WorkspaceId is the OMS workspace Id