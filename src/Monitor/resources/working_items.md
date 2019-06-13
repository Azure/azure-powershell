## Monitor

### ActivityLog

* `Get-AzActivityLog`
    - [ ] Replace `-Filter` with the other parameters:
        * `StartTime`, `EndTime`, `Status`, `Caller`, `CorrelationId`, `ResourceProvider`, `ResourceGroupName`
    - [ ] Implement `-MaxRecord`
* `Get-AzTenantActivityLog`


### ActivityLogAlert

* `Get-AzActivityLogAlert`
* `Remove-AzActivityLogAlert`
* `New-AzActivityLogAlert`
* `Set-AzActivityLogAlert`
    - [ ] (?) `-Condition` is an array of two strings: `Field` and `Equals`. Create an cmdlet that creates in-memory objects for these conditions
        * According to the specs: "The possible values for this 'Field' are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties.'."
    - [ ] (?) Since the default is creating an enabled alert. Remove `-Enabled` switch parameter and add `-DisableAlert`, that disables the alert if used.
    - Verify if normal action groups (the ones created using the action groups cmdlets) can be used in the `-ActionGroup` parameter.
* `Update/Enable/Disable-AzActivityLogAlert`
    * The PATCH only works for changing the tags and the `Enabled` property thus,
    - [ ] Create `Enable/Disable-AzActivityLogAlert`
    - [ ] Remove `Update-AzActivityLogAlert`

### ActionGroup

* `Get-AzActionGroup`
* `Remove-AzActionGroup`
* `Set-AzActionGroup`
    - [ ] `-GroupShortName` -> `-ShortName`
    - [ ] Hide all the specific `Receiver` parameters i.e. `-EmailReceiver` and implement just one parameter that receives an array of generic receivers
        * Obs: It seems that the spec specify more kinds of receiver that the original code actually uses/creates with the in-memory creation cmdlet `New-AzActionGroupReceiver`
* `New-AzActionGroup`
    * Obs: This is not similar to the original `New-AzActionGroup` which is used only for `ActivityLogAlerts`
    - [ ] Apply the same changes made to `Set-AzActionGroup`
* `Update-AzActionGroup`
    - [ ] Remove this cmdlet because only updates TAG
* `Enable-AzActionGroupReceiver`
    - [ ] (?) Decide if keep or hide this cmdlet: it only changes the status from disable to enable for SMS and Email receivers of a given action group


### Metric

* `Get-AzMetric`
    - [ ] Implement the parameters from `New-AzMetricFilter` and replace it for `-Filter`
    - [ ] change `-Aggregation` type from string to `AggregationType` (defined in another resource spec `MetricDefinition`)
    - [ ] Add alias or rename `-Interval` to `-TimeGrain`
    - [ ] (?) Replace `-Timespan` for `-StartTime` and `-EndTime`
* `New-AzMetric`
* `Get-AzMetricDefinition`
    - [ ] Add `-MetricName` parameter used to filter the results
    - [ ] (?) Add `-DetailedOutput` that returns a metric definition with full details or not
* `Get-AzMetricBaseline`
* `Get-AzMetricNamespace`

### MetricAlert (metric alerts V2 API)

* `Get-AzMetricAlert`
    - [ ] Rename `-RuleName` to `-Name`
* `New-AzMetricAlert`
    - [ ] Rename `-RuleName` to `-Name`
    - [ ] (?) Rename `-CriterionOdataType` to `-Condition`
    * (?) Verify the need of creating two parameter sets here -- one for a specific resourceId or a list of scopes.
        * Specific resourceId parameter set:
            - [ ] Hide `-Scope`, `-TargetResourceRegion` and `-TargetResourceType`. Add `-TargetResourceId` parameter which value is added to `-Scope` parameter for the API call
        * Scopes parameter set:
            - [ ] (?) Rename or add alias `-Scope` to `-TargetResourceScope`
            - [ ] (?) Rename `-TargetResourceRegion` to `-TargetResourceLocation`
    - [ ] (?) Since the default is creating an enabled alert. Remove `-Enabled` switch parameter and add `-DisableAlert`, that disables the alert if used.
* `Set-AzMetricAlert`
    * Obs: The original does not implements a `Set`
    - [ ] Apply the same changes made for the `New`
* `Update-AzMetricAlert`
    - [ ] Apply the same changes made for the `New`
* `Remove-AzMetricAlert`
    - [ ] Rename `-RuleName` to `-Name`
    - [ ] Add `-AsJob`

### AlertRule (old API)

* `Get-AzAlertRule`
    - [ ] Rename `-RuleName` to `-Name`
    - [ ] Add `-TargetResourceId` and the customization to filter alerts by `ResourceId`
    - [ ] (?) Add `-DetailedOutput` that returns the alert rule information with full details or not.
        * Obs: The `PSAlertRule` and `PSAlertRuleNoDetails` classes seems to be the same class so `-DetailedOutput` would be useless
* `New-AzAlertRule`
    - [ ] Rename `-RuleName` to `-Name`
    - [ ] Investigate the need of `-DataSourceOdataType`
* `Remove-AzAlertRule`
* `Set-AzAlertRule`
* `Update-AzAlertRule`
* `Get-AzAlertRuleIncident`

### Missing in-memory objects creation cmdlets

* `New-AzActivityLogAlertCondition`
* `New-AzActionGroupReceiver`
* `New-AzMetricFilter`
* `New-AzMetricAlertRuleV2Criteria`
* `New-AzMetricAlertRuleV2DimensionSelection`
* `Add-AzWebtestAlertRule`
* `New-AzAlertRuleEmail`
* `New-AzAlertRuleWebhook`
