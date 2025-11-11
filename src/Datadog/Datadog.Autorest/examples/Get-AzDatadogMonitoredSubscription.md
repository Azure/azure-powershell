### Example 1: Get monitored subscriptions for a Datadog monitor
```powershell
Get-AzDatadogMonitoredSubscription -ResourceGroupName datadog-rg -MonitorName monitordd01
```

```output
Id                           : /subscriptions/YYYYYYYY-ZZZZ-AAAA-BBBB-000011112222/resourceGroups/datadog-rg/providers/Microsoft.Datadog/monitors/monitordd01/monitoredSubscriptions/default
MonitoredSubscriptionList    : {{
                                 "tagRules": {
                                   "provisioningState": "Accepted"
                                 },
                                 "subscriptionId": "/SUBSCRIPTIONS/AAAAAAAA-BBBB-CCCC-DDDD-DBDD3AB55AC5",
                                 "status": "Active"
                               }}
Name                         : default
Operation                    :
ResourceGroupName            : datadog-rg
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Datadog/monitors/monitoredSubscriptions
```

Lists the subscriptions currently being monitored by the specified Datadog monitor resource.