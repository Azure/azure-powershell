# Release notes for module Az.Monitor

## Version x.x.x.-preview

## What's new

All in-memory create cmdlets were removed in favor of flatten cmdlets. Some cmdlets used flatten parameters and others require the creation of a HashTable.

### Notes

* `New-AzActionGroup` is the previously known `Set-AzActionGroup`. The `New-AzActionGroup` that existed before and were only used to create an in-memory object for Activity Log Alerts is now removed.
* The `MetricAlertRuleV2` set of cmdlets are now known as just `MetricAlert` and the old `MetricAlertRule` ones are now the `AlertRule` set of cmdlets.

## Future enhancements

Right now, the `Update-AzMetricAlert` and `Update-AzAlertRule` update existing resources but require that either more than a single parameter is provided or a hash table with multiple parameters.
Future versions will include a more complete "Update" with the ability to update more refined parameters.

## Breaking changes

## Examples

## Supported cmdlets

