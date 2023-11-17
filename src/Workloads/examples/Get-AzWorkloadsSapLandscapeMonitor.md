### Example 1: Get information about a SAP landscape monitor
```powershell
Get-AzWorkloadsSapLandscapeMonitor -MonitorName suha-0202-ams9 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c
```

```output
GroupingLandscape            : {{
                                 "name": "Prod",
                                 "topSid": [ "SID1", "SID2" ]
                               }}
GroupingSapApplication       : {{
                                 "name": "ERP1",
                                 "topSid": [ "SID1", "SID2" ]
                               }}
Id                           : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.
                               Workloads/monitors/suha-0202-ams9/sapLandscapeMonitor/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : suha-0802-rg1
SystemData                   : {
                               }
SystemDataCreatedAt          : 06-04-2023 05:30:54
SystemDataCreatedByType      : User
SystemDataLastModifiedByType : User
TopMetricsThreshold          : {{
                                 "name": "Instance Availability",
                                 "green": 90,
                                 "yellow": 75,
                                 "red": 50
                               }}
Type                         : microsoft.workloads/monitors/saplandscapemonitor
```

Gets information about a specific SAP landscape monitor

### Example 2: Get information about a SAP landscape monitor by Id
```powershell
Get-AzWorkloadsSapLandscapeMonitor -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0/providers/Microsoft.Workloads/monitors/suha-0202-ams9/sapLandscapeMonitor/default"
```

```output
GroupingLandscape            : {{
                                 "name": "Prod",
                                 "topSid": [ "SID1", "SID2" ]
                               }}
GroupingSapApplication       : {{
                                 "name": "ERP1",
                                 "topSid": [ "SID1", "SID2" ]
                               }}
Id                           : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.
                               Workloads/monitors/suha-0202-ams9/sapLandscapeMonitor/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : suha-0802-rg1
SystemData                   : {
                               }
SystemDataCreatedAt          : 06-04-2023 05:30:54
SystemDataCreatedByType      : User
SystemDataLastModifiedByType : User
TopMetricsThreshold          : {{
                                 "name": "Instance Availability",
                                 "green": 90,
                                 "yellow": 75,
                                 "red": 50
                               }}
Type                         : microsoft.workloads/monitors/saplandscapemonitor
```

Gets information about a specific SAP landscape monitor by ArmId