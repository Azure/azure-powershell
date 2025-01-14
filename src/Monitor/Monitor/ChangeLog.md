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

## Version 6.0.0
* The parameters of the `New-AzDataCollectionEndpoint`, `New-AzDataCollectionRule`, `Update-AzDataCollectionEndpoint`, `Update-AzDataCollectionRule` commands have changed.
  * `IdentityType` has been removed. `EnableSystemAssignedIdentity` is used to enable/disable system-assigned identities.
  * The type of `UserAssignedIdentity` is simplified to an array of strings that is used to specify the user's assigned identity.

## Version 5.3.0
* Added new cmdlet for Azure Monitor Pipeline Groups
  * `Get-AzPipelineGroup`
  * `New-AzPipelineGroup`
  * `Update-AzPipelineGroup`
  * `Remove-AzPipelineGroup`

## Version 5.2.2
* Added breaking change messages:
  * `New-AzDataCollectionEndpoint`
  * `New-AzDataCollectionRule`
  * `Update-AzDataCollectionEndpoint`
  * `Update-AzDataCollectionRule`
* Updated documentation for `New-AzActionGroupLogicAppReceiverObject`

## Version 5.2.1
* Removed breaking change warning messages for Metric Management Plane
    * Get-AzMetric
    * Get-AzMetricDefinition
    * New-AzMetricFilter

## Version 5.2.0
* `-Location` parameter was removed from `Update-AzActionGroup` and `Update-AzDataCollectionRule` because they do not support updating the location.
* Introduced secrets detection feature to safeguard sensitive data.

## Version 5.1.1
* Added breaking change warning messages for Metric Management Plane
    * Get-AzMetric
    * Get-AzMetricDefinition
    * New-AzMetricFilter

## Version 5.1.0
* Added support for the Metric Data Plane

## Version 5.0.1
* Remove outdated breaking change warning [#24033]

## Version 5.0.0
  * [Breaking Change] Action Group upgraded API version to stable 2023-01-01
  * [Breaking Change] Use new and update cmdlets instead `Set-AzActionGroup` cmdlet
  * The receiver used subtype cmdlets to create a replacement for command `New-AzActionGroupReceiver`
    * New-AzActionGroupArmRoleReceiverObject
    * New-AzActionGroupAutomationRunbookReceiverObject
    * New-AzActionGroupAzureAppPushReceiverObject
    * New-AzActionGroupAzureFunctionReceiverObject
    * New-AzActionGroupEmailReceiverObject
    * New-AzActionGroupEventHubReceiverObject
    * New-AzActionGroupItsmReceiverObject
    * New-AzActionGroupLogicAppReceiverObject
    * New-AzActionGroupSmsReceiverObject
    * New-AzActionGroupVoiceReceiverObject
    * New-AzActionGroupWebhookReceiverObject
* [Breaking Change] Data collection Rule upgraded API version to stable 2022-06-01
* [Breaking Change] AMCS removed `Set-AzDataCollectionRule` cmdlet
* Added cmdlets for data collection endpoint:
    - `Get-AzDataCollectionEndpoint`
    - `New-AzDataCollectionEndpoint`
    - `Remove-AzDataCollectionEndpoint`
    - `Update-AzDataCollectionEndpoint`

## Version 4.6.0
* Fixed `Get-AzInsightsPrivateLinkScope` to support `ResourceId` parameter [#22568]
* Fixed `New-AzMetricAlertRuleV2DimensionSelection` to have "exclude" or "include" values only [#22256]
* Fixed `Add-AzMetriAlertRuleV2` and `Get-AzMetricAlertRuleV2` to support web tests criteria [#22350]
* Added parameter `Dimension` for `Get-AzMetric` to easily filter metrics by dimensions [#22320]
* Added breaking change for Data Collection Rule
* Added breaking change for Action Group

## Version 4.5.0
* Added cmdlets for monitor workspace:
    - `Get-AzMonitorWorkspace`
    - `New-AzMonitorWorkspace`
    - `Update-AzMonitorWorkspace`
    - `Remove-AzMonitorWorkspace`

## Version 4.4.1
* Removed default value for time window for autoscale profile [#20660]
  * `Get-AzAutoscaleSetting`
  * `New-AzAutoscaleSetting`

## Version 4.4.0
* Fixed bug for `Remove-AzDataCollectionRuleAssociation` [#20207]
* Added support for test notifications cmdlets
  * `Test-AzActionGroup`
* Fixed start time parameter description of `Get-AzActivityLog` [#20409]

## Version 4.3.0
* Fixed bug for `New-AzActivityLogAlert` and `Update-AzActivityLogAlert` [#19927]

## Version 4.2.1
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 4.2.0
* [Breaking Change] Upgraded API version for ActivityLogAlert from 2017-04-01 to 2020-10-01, affected cmdlets:
  * `Get-AzActivityLogAlert`
  * `Remove-AzActivityLogAlert`
  * `Set-AzActivityLogAlert` replaced by `New-AzActivityLogAlert`
  * `Disable-AzActivityLogAlert` replaced by `Update-AzActivityLogAlert`
  * `Enable-AzActivityLogAlert` replaced by `Update-AzActivityLogAlert`
  * `New-AzActionGroup` replaced by `New-AzActivityLogAlertActionGroupObject`
* [Breaking Change] Upgraded API version for DiagnosticSetting from 2017-05-01-preview to 2021-05-01-preview
  * `Get-AzDiagnosticSettingCategory`
  * `Get-AzDiagnosticSetting`
  * `New-AzDiagnosticSetting`
  * `Remove-AzDiagnosticSetting`
  * `Set-AzDiagnosticSetting` replaced by `New-AzDiagnosticSetting`
  * `New-AzDiagnosticDetailSetting` replaced by `New-AzDiagnosticSettingLogSettingsObject` and `New-AzDiagnosticSettingMetricSettingsObject`
  * `Get-AzSubscriptionDiagnosticSettingCategory` replaced by `Get-AzEventCategory`
* [Breaking Change] Upgraded API version for Autoscale from 2015-04-01 to 2022-10-01
  * `Get-AzAutoscaleSetting`
  * `Remove-AzAutoscaleSetting`
  * `Add-AzAutoscaleSetting` replaced by `New-AzAutoscaleSetting`
  * `New-AzAutoscaleNotification` replaced by `New-AzAutoscaleNotificationObject`
  * `New-AzAutoscaleProfile` replaced by `New-AzAutoscaleProfileObject`
  * `New-AzAutoscaleRule` replaced by `New-AzAutoscaleScaleRuleObject`
  * `New-AzAutoscaleWebhook` replaced by `New-AzAutoscaleWebhookNotificationObject`
* [Breaking Change] Upgraded API version for ScheduledQueryRule from 2018-04-16 to 2021-08-01
  * `Get-AzScheduledQueryRule`
  * `New-AzScheduledQueryRuleAlertingAction`
  * `New-AzScheduledQueryRuleAznActionGroup`
  * `New-AzScheduledQueryRule`
  * `New-AzScheduledQueryRuleLogMetricTrigger`
  * `New-AzScheduledQueryRuleSchedule`
  * `New-AzScheduledQueryRuleSource`
  * `New-AzScheduledQueryRuleTriggerCondition`
  * `Remove-AzScheduledQueryRule`
  * `Set-AzScheduledQueryRule`
  * `Update-AzScheduledQueryRule`

## Version 3.1.0
* Added breaking change warning messages for
    - `ActivityLogAlert`
    - `DiagnosticSetting`
    - `ScheduledQueryRule`
    - `Autoscale`

## Version 3.0.2
* Added optional parameter `Location` for Adding/Update action group cmdlet

## Version 3.0.1
* Fixed an issue where users could not correctly ignore warning messages after setting environment variables [#17013]

## Version 3.0.0
* Added new properties EventName, Category, ResourceProviderName, OperationName, Status, SubStatus with type string as output for command Get-AzLog [#15833]
* Supported event hub receiver in action group [#16348]
* Added default parameter set `GetByResourceGroup` for the command `Get-AzAlertRule` [#16356]

## Version 2.7.0
* Added parameter `ResourceGroupName` back for `Add-AzAutoscaleSetting` parameter set `AddAzureRmAutoscaleSettingUpdateParamGroup` and made it optional [#15491]

## Version 2.6.0
* Fixed null reference bug for `Get-AzMetric` when `ResultType` set to "Metadata"
* Fixed bug for `Add-AzAutoscaleSetting` not able to pipe result from `Get-AzAutoscaleSetting` [#13861]

## Version 2.5.0
* Added cmdlet to get diagnostic setting categories for subscription
    - `Get-AzSubscriptionDiagnosticSettingCategory`
* Supported subscription diagnostic setting operations with new parameter: SubscriptionId
    - 'Get-AzDiagnosticSetting'
    - 'New-AzDiagnosticSetting'
    - 'Remove-AzDiagnosticSetting'
* Supported `AutoMitigate` parameter in metric alert rule properties. The flag indicates whether the alert should be auto resolved or not.

## Version 2.4.0
* Added cmdlets for data collection rules:
    - `Get-AzDataCollectionRule`
    - `New-AzDataCollectionRule`
    - `Set-AzDataCollectionRule`
    - `Update-AzDataCollectionRule`
    - `Remove-AzDataCollectionRule`
* Added cmdlets for data collection rules associations
    - `Get-AzDataCollectionRuleAssociation`
    - `New-AzDataCollectionRuleAssociation`
    - `Remove-AzDataCollectionRuleAssociation`

## Version 2.3.0
* Changed parameter `Rule` of `New-AzAutoscaleProfile` to accept empty list. [#12903]
* Added new cmdlets to support creating diagnostic settings more flexible:
    * `Get-AzDiagnosticSettingCategory`
    * `New-AzDiagnosticSetting`
    * `New-AzDiagnosticDetailSetting`

## Version 2.2.0
* Fixed the bug that warning message cannot be suppressed. [#12889]
* Supported `SkipMetricValidation` parameter in alert rule criteria. Allows creating an alert rule on a custom metric that isn't yet emitted, by causing the metric validation to be skipped.

## Version 2.1.0
* Extended the parameter set in `Set-AzDiagnosticSetting` for separation of Logs and Metrics enablement [#12482]
* Fixed bug for `Add-AzMetricAlertRuleV2` when getting metric alert from pipeline

## Version 2.0.2
* Fixed bug for `Get-AzDiagnosticSetting` when metrics or logs are null [#12272]

## Version 2.0.1
* Fixed input object parameter for `Set-AzActivityLogAlert`
* Fixed `InputObject` parameter for `Set-AzActionGroup` [#10868]

## Version 2.0.0
* Fixed bug for `Set-AzDiagnosticSettings`, retention policy won't apply to all categories [#11589]
* Supported WebTest availability criteria for metric alert V2
	- `New-AzMetricAlertRuleV2Criteria`: an option to create webtest availability criteria was added
	- `Add-AzMetricAlertRuleV2`: supports the new webtest availability criteria
* Removed redundant definition for RetentionPolicy in PSLogProfile [#7608]
* Removed redundant properties difined in PSEventData [#11353]
* Renamed `Get-AzLog` to `Get-AzActivityLog`

## Version 1.7.0
* Added cmdlets for private link scope
    - `Get-AzInsightsPrivateLinkScope`
    - `Remove-AzInsightsPrivateLinkScope`
    - `New-AzInsightsPrivateLinkScope`
    - `Update-AzInsightsPrivateLinkScope`
    - `Get-AzInsightsPrivateLinkScopedResource`
    - `New-AzInsightsPrivateLinkScopedResource`
    - `Remove-AzInsightsPrivateLinkScopedResource`

## Version 1.6.2
* Updated documentation for `New-AzScheduledQueryRuleLogMetricTrigger`

## Version 1.6.1
* Fixed output value for `Get-AzMetricDefinition` [#9714]

## Version 1.6.0
* Fixed description of the Get-AzLog cmdlet.
* A new parameter called ActionGroupId was added to `New-AzMetricAlertRuleV2` command.
	- The user can provide either ActionGroupId(string) or ActionGorup(ActivityLogAlertActionGroup).

## Version 1.5.0
* Update references in .psd1 to use relative path
* Adding optional argument to the Add Diagnostic Settings command. A switch argument that if present indicates that the export to Log Analytics must be to a fixed schema (a.k.a. dedicated, data type)

## Version 1.4.0
* New action group receivers added for action group
	-ItsmReceiver
	-VoiceReceiver
	-ArmRoleReceiver
	-AzureFunctionReceiver
	-LogicAppReceiver
	-AutomationRunbookReceiver
	-AzureAppPushReceiver
* Use common alert schema enabled for the receivers. This is not applicable for SMS, Azure App push , ITSM and Voice recievers
* Webhooks now supports Azure active directory authentication .

## Version 1.3.0
* Pointing to the most recent Monitor SDK, i.e. 0.24.1-preview
   - Adds non-braking changes to the Metrics cmdlets, i.e. the Unit enumeration supports several new values. These are read-only cmdlets, so there would be no change in the input of the cmdlets.
   - The api-version of the **ActionGroups** requests is now **2019-06-01**, before it was **2018-03-01**. The scenario tests have been updated to accommodate for this change.
   - The constructors for the classes **EmailReceiver** and **WebhookReceiver** added one new mandatory argument, i.e. a Boolean value called **useCommonAlertSchema**. Currently, the value is fixed to **false** to hide this breaking change from the cmdlets. **NOTE**: this is a temporary change that must be validated by the Alerts team.
   - The order of the arguments for the constructor of the class **Source** (related to the **ScheduledQueryRuleSource** class) changed from the previous SDK. This change required two unit tests to the be fixed: they compiled, but failed to pass the tests.
   - The order of the arguments for the constructor of the class **AlertingAction** (related to the **ScheduledQueryRuleSource** class) changed from the previous SDK. This change required two unit tests to the be fixed: they compiled, but failed to pass the tests.
* Support Dynamic Threshold criteria for metric alert V2
	- New-AzMetricAlertRuleV2Criteria: now creats dynamic threshold criteria also
	- Add-AzMetricAlertRuleV2: now accept dynamic threshold criteria also
* Improvements in Scheduled Query Rule cmdlets (SQR)
 - Cmdlets will accept `Location` paramater in both formats, either the location (e.g. eastus) or the location display name (e.g. East US)
 - Illustrated `Enabled` parameter in help files properly
 - Added examples for `ActionGroup` optional parameter
 - Overall improved help files
* Fix bug in determining scope type for `Set-AzActionRule`


## Version 1.2.2
* Fixed miscellaneous typos across module
* Fixed incorrect parameter name in help documentation

## Version 1.2.1
* Fixed incorrect parameter names in help examples

## Version 1.2.0
* New cmdlets for SQR API (Scheduled Query Rule)
    - New-AzScheduledQueryRuleAlertingAction
	- New-AzScheduledQueryRuleAznsActionGroup
	- New-AzScheduledQueryRuleLogMetricTrigger
	- New-AzScheduledQueryRuleSchedule
	- New-AzScheduledQueryRuleSource
	- New-AzScheduledQueryRuleTriggerCondition
	- New-AzScheduledQueryRule
	- Get-AzScheduledQueryRule
	- Set-AzScheduledQueryRule
	- Update-AzScheduledQueryRule
	- Remove-AzScheduledQueryRule
	- [More](https://docs.microsoft.com/en-us/rest/api/monitor/scheduledqueryrules) information about SQR API
	- Updated Az.Monitor.md to include cmdlets for GenV2(non classic) metric-based alert rule

## Version 1.1.0
  * New cmdlets for GenV2(non classic) metric-based alert rule
      - New-AzMetricAlertRuleV2DimensionSelection
      - New-AzMetricAlertRuleV2Criteria
      - Remove-AzMetricAlertRuleV2
      - Get-AzMetricAlertRuleV2
      - Add-AzMetricAlertRuleV2
  * Updated Monitor SDK to version 0.22.0-preview

## Version 1.0.1
* Update help for Get-AzMetric

## Version 1.0.0
* General availability of `Az.Monitor` module
* Removed plural names "Categories" and "Timegrains" parameter in favor of singular parameter names
