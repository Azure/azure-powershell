### Example 1: Create a new SAP Landscape Monitor
```powershell
New-AzWorkloadsSapLandscapeMonitor -MonitorName suha-0202-ams9 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -GroupingLandscape '{"name":"Prod","topSid":["SID1","SID2"]}' -GroupingSapApplication '{"name":"ERP1","topSid":["SID1","SID2"]}' -TopMetricsThreshold '{"name":"Instance Availability","green":90,"yellow":75,"red":50}'
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
                                 "createdBy": "",
                                 "createdByType": "User",
                                 "createdAt": "2023-04-06T05:30:54.9427030Z",
                                 "lastModifiedBy": "",
                                 "lastModifiedByType": "User",
                                 "lastModifiedAt": "2023-04-06T05:31:18.7873209Z"
                               }
SystemDataCreatedAt          : 06-04-2023 05:30:54
SystemDataCreatedBy          : 
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 06-04-2023 05:31:18
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : User
TopMetricsThreshold          : {{
                                 "name": "Instance Availability",
                                 "green": 90,
                                 "yellow": 75,
                                 "red": 50
                               }}
Type                         : microsoft.workloads/monitors/saplandscapemonitor
```

Creates a new SAP landscape monitor
