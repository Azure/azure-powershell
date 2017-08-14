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

## Version 3.2.1

## Version 3.2.0
* Issue #4215 (change request) remove the 15 days limit in the time window for the Get-AzureRmLog cmdlet. Also minor changes to the unit test names.
* Issue #3957 fixed for Get-AzureRmLog
    - Issue #1: The backend returns the records in pages of 200 records each, linked by the continuation token to the next page. The customers were seeing the cmdlet returning only 200 records when they knew there were more. This was happening regardless of the value they set for MaxEvents, unless that value was less than 200.
    - Issue #2: The documentation contained incorrect data about this cmdlet, e.g.: the default timewindow was 1 hour.
    - Fix #1: The cmdlet now follows the continuation token returned by the backend until it reaches MaxEvents or the end of the set.<br>The default value for MaxEvents is 1000 and its maximum is 100000. Any value for MaxEvents that is less than 1 is ignored and the default is used instead. These values and behavior did not change, now they are correctly documented.<br>An alias for MaxEvents has been added -MaxRecords- since the name of the cmdlet does not speak about events anymore, but only about Logs.
    - Fix #2: The documentation contains correct and more detailed information: new alias, correct time window, correct default, minimum, and maximum values.
 
## Version 3.1.0

## Version 3.0.1

## Version 3.0.0
* Add-AzureRm*AlertRule
    - Returns a single object: newResource, statusCode, requestId
* Get-AzureRmAlertRule
    - The output is now enumerated instead of considered a single object. Its type did not change, it is still a list.
* Remove-AzureRmAlertRule
    - The statusCode follows the status code returned by the request, before it was Ok always.
* Add-AzureRmAutoscaleSetting
    - Returns now a single object (not a list as before) containing statusCode, requestId, and the newly created/updated resource.
    - The status code follows the status returned by the request, before it was always Ok.
* New-AzureRmAutoscaleRule
    - The parameter ScaleActionType has been extended, it receives the following values now: ChangeCount, PercentChangeCount, ExactCount.
* Remove-AzureRmAutoscaleSetting
    - The statusCode in the output follows the statusCode returned by the request. Before it was always Ok. 
* Get-AzureRMLogProfile
    - The output is now enumerated. Before it was considered a single object. The type of the output remains a list as before.
* Remove-AzureRmLogProfile
    - The PassThru parameter has been implemented.
* Metrics API
    - The SDK now retrieves metrics from MDM.
* Get-AzureRmMetricDefinition
    - The output is still a list, but the structure of the list changed.
* Get-AzureRmMetric
    - The call has changed. This is the new syntax: Get-AzureRmMetric ResourceId [MetricNames [TimeGrain] [AggregationType] [StartTime] [EndTime]] [DetailedOutput]
    - The output is a list, and the structure of its elements has changed.

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