### Example 1: List the subscriptions monitored by the NewRelic monitor resource
```powershell
Get-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test
```

```output
Id                        : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group-test/providers/NewRelic.Observability/monitors/test-01/monitoredSubscriptions/default
MonitoredSubscriptionList : {}
Name                      : default
PatchOperation            : 
ProvisioningState         : 
ResourceGroupName         : group-test
Type                      : NewRelic.Observability/monitors/monitoredSubscriptions
```

This command lists the subscriptions currently being monitored by the NewRelic monitor resource.

