### Example 1: Get a task assignment
```powershell
Get-AzStorageTaskAssignment -ResourceGroupName myresourcegroup -AccountName myaccount -Name myassignment
```

```output
Description                     : This is a task assignment
Enabled                         : True
EndBy                           : 7/2/2025 6:17:38 AM
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/myassignment
Interval                        : 1
IntervalUnit                    : days
Name                            : myassignment
ProvisioningState               : Succeeded
ReportPrefix                    : testc1
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
StartFrom                       : 7/2/2024 6:17:38 AM
StartOn                         :
TargetExcludePrefix             : {}
TargetPrefix                    : {test}
TaskId                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mystoragetask1
TriggerType                     : OnSchedule
Type                            : Microsoft.Storage/storageAccounts/storageTaskAssignments
```

This command gets the task assignment "myassignment" under storage account "myaccount".

### Example 2: List task assignments under a storage account 
```powershell
Get-AzStorageTaskAssignment -ResourceGroupName myresourcegroup -AccountName myaccount
```

```output
Name              ResourceGroupName
----              -----------------
assignment1       myresourcegroup
assignment2       myresourcegroup
assignment3       myresourcegroup
```

This command lists task assignments under the storage account "myaccount".

