### Example 1: Update an agent 
```powershell
$recurrence = New-AzStorageMoverUploadLimitWeeklyRecurrenceObject -Day 'Monday','Tuesday','Friday' -LimitInMbps 100 -EndTimeHour 5 -StartTimeHour 1 -StartTimeMinute 30 -EndTimeMinute 0
Update-AzStorageMoverAgent -ResourceGroupName myresourcegroup -StorageMoverName mystoragemover -Name myagent -Description "Update description" -UploadLimitScheduleWeeklyRecurrence $recurrence
```

```output
AgentStatus                         : Online
ArcResourceId                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.HybridCompute/machines/myagent
ArcVMUuid                           : 00000000-0000-0000-0000-000000000000
Description                         : Update description
ErrorDetailCode                     :
ErrorDetailMessage                  :
Id                                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/agents/myagent
LastStatusUpdate                    : 6/12/2024 5:57:45 AM
LocalIPAddress                      : 000.000.000.00
MemoryInMb                          : 1470
Name                                : myagent
NumberOfCores                       : 8
ProvisioningState                   : Succeeded
SystemDataCreatedAt                 : 6/12/2024 5:47:26 AM
SystemDataCreatedBy                 : example@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 6/12/2024 5:57:54 AM
SystemDataLastModifiedBy            : example@microsoft.com
SystemDataLastModifiedByType        : User
TimeZone                            : UTC
Type                                : microsoft.storagemover/storagemovers/agents
UploadLimitScheduleWeeklyRecurrence : {{
                                        "startTime": {
                                          "hour": 1,
                                          "minute": 30
                                        },
                                        "endTime": {
                                          "hour": 5,
                                          "minute": 0
                                        },
                                        "days": [ "Monday", "Tuesday", "Friday" ],
                                        "limitInMbps": 100
                                      }}
UptimeInSeconds                     : 3417
Version                             : 
```

This command updates the description and the upload limit weekly recurrence of an agent. 


