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
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 4.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* **Add-AzureRMLogAlertRule**
    - After October 1st using this cmdlet no longer had any effect as this functionality was transitioned to Activity Log Alerts. Please see https://aka.ms/migratemealerts for more information.
* **Get-AzureRMUsage**
    - Deprecated as announced since April 2017
* **Add-AzureRmMetricAlertRule** / **Add-AzureRmWebtestAlertRule**
    - The argument ResourceGroup has been renamed as ResourceGroupName
    - The parameter Actions has been renamed to Action and the Actions has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **Add-AzureRmAutoscaleSetting**
    - The argument ResourceGroup has been renamed as ResourceGroupName, i.e. a non-breaking change.
    - The parameter AutoscaleProfiles has been renamed to AutoscaleProfiles and the AutoscaleProfiles has been added to the alias list
    - The parameter Notifications has been renamed to Notification and the Notifications has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **Remove-AzureRmAutoscaleSetting**
    - The argument ResourceGroup has been renamed as ResourceGroupName
* **Get-AzureRmAlertRule**
    - The argument ResourceGroup has been renamed as ResourceGroupName
    - Warning message added for the future deprecation of the DetailedOutput parameter.
* **Remove-AzureRmAlertRule**
    - The argument ResourceGroup has been renamed as ResourceGroupName
    - The cmdlet now implements the ShouldProcess protocol.
* **Get-AzureRmAutoscaleSetting**
    - The argument ResourceGroup has been renamed as ResourceGroupName
    - Warning message added for the future deprecation of the DetailedOutput parameter.
* **Remove-AzureRmLogProfile**
    - The cmdlet now implements the ShouldProcess protocol.
* **Add-AzureRmLogProfile**
    - The parameter Locations has been renamed to Location and the Locations has been added to the alias list
    - The parameter RetentionInDays has been renamed to RetentionInDay and the RetentionInDays has been added to the alias list
    - The parameter Categories has been renamed to Category and the Categories has been added to the alias list
    - The cmdlet now implements the ShouldProcess protocol.
    - Warning message about the future deprecation of the plural parameter names added.
* **Get-AzureRmMetricDefinition** / **Get-AzureRmMetric**
    - The parameter MetricNames has been renamed to MetricName and the MetricNames has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **Get-AzureRmLog**
    - Warning message added for the future deprecation of the DetailedOutput parameter.
    - The parameter MaxEvents has been renamed as MaxRecord (there was already an alias MaxRecords which is kept.) MaxEvents has been moved to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **Get-AzureRmAlertHistory** / **GetAzureRmAutoscaleHistory**
    - Warning message added for the future deprecation of the DetailedOutput parameter.
* **New-AzureRmAutoscaleNotification**
    - The parameter SendEmailToSubscriptionCoAdministrators has been renamed to SendEmailToSubscriptionCoAdministrator and the SendEmailToSubscriptionCoAdministrators has been added to the alias list
    - The parameter CustomEmails has been renamed to CustomEmail and the CustomEmails has been added to the alias list
    - The parameter Webhooks has been renamed to Webhook and the Webhooks has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **New-AzureRmAutoscaleProfile**
    - The parameter ScheduleDays has been renamed to ScheduleDay and the ScheduleDays has been added to the alias list
    - The parameter ScheduleHours has been renamed to ScheduleHour and the ScheduleHours has been added to the alias list
    - The parameter ScheduleMinutes has been renamed to ScheduleMinute and the ScheduleMinutes has been added to the alias list
    - The parameter Rules has been renamed to Rule and the Rules has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **New-AzureRmAutoscaleWebhook**
    - The parameter Properties has been renamed to Property and the Properties has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **New-AzureRmAlertRuleEmail**
    - The parameter CustomEmails has been renamed to CustomEmail and the CustomEmails has been added to the alias list
    - The parameter SendToServiceOwners has been renamed to SendToServiceOwner and the SendToServiceOwners has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* **New-AzureRmAlertRuleWebhook**
    - The parameter Properties has been renamed to Property and the Properties has been added to the alias list
    - Warning message about the future deprecation of the plural parameter names added.
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 3.4.1
    * Add-AzureRmLogAlertRule
        - Adding details to deprecation warning introduced in April 2017: the cmdlet will stop having effect: its functionality is moved to the "ActivityLogAlerts" cmdlets.
        - Help file modified to include the deprecation warning and the details.
    * Disable-AzureRmActivityLogAlert, Disable-AzureRmActivityLogAlert, Remove-AzureRmActivityLogAlert, Set-AzureRmActivityLogAlert
        - Help file modified: removed text stating that the Force arguments was accepted since that argument is not accepted.

## Version 3.4.0
    * New cmdlet Disable-AzureRmActivityLogAlert
        - A new cmdlet to disable an existing activity log alert.
        - Optionally the Tags are settable with this cmdlet too.
    * New cmdlet Enable-AzureRmActivityLogAlert
        - A new cmdlet to enable an existing activity log alert.
        - Optionally the Tags are settable with this cmdlet too.
    * New cmdlet Get-AzureRmActivityLogAlert
        - A new cmdlet to retrieve one or more activity log alerts.
        - The alerts can be retrieved by name, resource group, or subscription.
    * New cmdlet New-AzureRmActionGroup
        - A new cmdlet to create an ActionGroup object in memory (no request involved.)
    * New cmdlet New-AzureRmActivityLogAlertCondition
        - A new cmdlet to create an activity log alert leaf condition object in memory (no request involved.)
    * New cmdlet Set-AzureRmActivityLogAlert
        - A new cmdlet to create or update an activity log alert.
    * New cmdlet Remove-AzureRmActivityLogAlert
        - A new cmdlet to remove one activity log alert.
    * New cmdlet Set-AzureRmActionGroup
        - A new cmdlet to create a new or update an existing action group.
    * New cmdlet Get-AzureRmActionGroup
        - A new cmdlet to retrieve one or more action groups.
        - The action groups can be retrieved by name, resource group, or subscription.
    * New cmdlet Remove-AzureRmActionGroup
        - A new cmdlet to remove one action group.
    * New cmdlet New-AzureRmActionGroupReceiver
        - A new cmdlet to create an new action group receiver in memory.

## Version 3.3.1

## Version 3.3.0

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