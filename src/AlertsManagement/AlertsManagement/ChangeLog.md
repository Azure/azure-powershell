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

## Version 0.6.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.6.1
* Fixed null reference bug when 'ScheduleEndDateTime' was not provided

## Version 0.6.0
* Added cmdlets for Prometheus rule group

## Version 0.5.0
* Added parameter `comment` for `Update-AzAlerteState`

## Version 0.4.1
* Added support for 24-hour clock in `Set-AzAlertProcessingRule` [#17762]

## Version 
* Fixed bug for `Get-AzAlertProcessingRule` does not fetch more than 50 Alert Processing Rules
* Fixed bug for `Get-AzAlert` rounds down the number of alerts to multiple of 100

## Version 0.4.0
* Substitute cmdlets:
  - `Get-AzActionRule` with `Get-AzAlertProcessingRule`
  - `Set-AzActionRule` with `Set-AzAlertProcessingRule`
  - `Update-AzActionRule` with `Update-AzAlertProcessingRule`
  - `Remove-AzActionRule` with `Remove-AzAlertProcessingRule`

## Version 0.3.0
* Fixed bug for `Set-AzActionRule` when RecurrenceType is "Once" and no "ReccurentValue" provided [#14476]

## Version 0.2.0
* Fixed bug for `Set-AzActionRule` incorrectly parsed `TargetResourceTypeCondition` to `MonitorCondition` [#12258]

## Version 0.1.3
* Updated AlertsManagement SDK version to 0.9.2-preview.
* Added Subscription Scope Type for Set-AzActionRule.
* Updated Examples for Set-AzActionRule, to show scope types as well.

## Version 0.1.2
* Updated help messages and document for `Get-AzActionRule`

## Version 0.1.1
* Update references in .psd1 to use relative path

## Version 0.1.0
* Preview of `Az.AlertsManagement` module
* Powershell Cmdlets for Alerts Management Resource Provider to manage alerts, action rules and smart groups.

