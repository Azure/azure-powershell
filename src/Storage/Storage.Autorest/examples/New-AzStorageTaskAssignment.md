### Example 1: Create a task assignment that runs once 
```powershell
$taskid = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask"
New-AzStorageTaskAssignment -ResourceGroupName myresourcegroup -AccountName myaccount -name mytaskassignment -TaskId $taskid -ReportPrefix "test" -TriggerType RunOnce -StartOn (Get-Date).ToUniversalTime() -Description "task assignment" -Enabled:$false
```

```output
Description                     : task assignment
Enabled                         : False
EndBy                           :
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
Interval                        :
IntervalUnit                    :
Name                            : mytaskassignment
ProvisioningState               : Succeeded
ReportPrefix                    : test
ResourceGroupName               : myresourcegroup
RunStatusEnum                   :
RunStatusError                  :
RunStatusFinishTime             :
RunStatusObjectFailedCount      :
RunStatusObjectsOperatedOnCount :
RunStatusObjectsSucceededCount  :
RunStatusObjectsTargetedCount   :
RunStatusRunResult              :
RunStatusStartTime              :
RunStatusStorageAccountId       :
RunStatusSummaryReportPath      :
RunStatusTaskAssignmentId       :
RunStatusTaskId                 :
RunStatusTaskVersion            :
StartFrom                       :
StartOn                         : 7/2/2024 4:39:15 AM
TargetExcludePrefix             :
TargetPrefix                    :
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TriggerType                     : RunOnce
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command creates a task assignment that runs once. 

### Example 2: Create a task assignment that runs on schedule
```powershell
$start = Get-Date -Year 2024 -Month 8 -Day 7 -Hour 1 -Minute 30
$end = Get-Date -Year 2024 -Month 12 -Day 25 -Hour 2 -Minute 45
$taskid = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask"
New-AzStorageTaskAssignment -accountname myaccount -name mytaskassignment -resourcegroupname myresourcegroup -TaskId $taskid -ReportPrefix test -StartFrom $start.ToUniversalTime() -TriggerType OnSchedule -Interval 10 -IntervalUnit Days -Description "my task assignment" -Enabled:$false -EndBy $end.ToUniversalTime()
```

```output
Description                     : my task assignment
Enabled                         : False
EndBy                           : 12/24/2024 6:45:03 PM
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/myassignment
Interval                        : 10
IntervalUnit                    : days
Name                            : mytaskassignment
ProvisioningState               : Succeeded
ReportPrefix                    : test
ResourceGroupName               : myresourcegroup
RunStatusEnum                   :
RunStatusError                  :
RunStatusFinishTime             :
RunStatusObjectFailedCount      :
RunStatusObjectsOperatedOnCount :
RunStatusObjectsSucceededCount  :
RunStatusObjectsTargetedCount   :
RunStatusRunResult              :
RunStatusStartTime              :
RunStatusStorageAccountId       :
RunStatusSummaryReportPath      :
RunStatusTaskAssignmentId       :
RunStatusTaskId                 :
RunStatusTaskVersion            :
StartFrom                       : 8/6/2024 5:30:39 PM
StartOn                         :
TargetExcludePrefix             :
TargetPrefix                    :
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/
                                  mytask
TriggerType                     : OnSchedule
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command creates a task assignment that runs every 10 days from 8/6/2024 5:30:39 PM to 12/24/2024 6:45:03 PM.
