### Example 1: List the reports of a task assignment in an account
```powershell
Get-AzStorageTaskAssignmentInstancesReport -AccountName myaccount -ResourceGroupName myresourcegroup -StorageTaskAssignmentName mytaskassignment
```

```output
FinishTime             : 2024-07-02T08:19:51.9238839Z
Id                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment/reports/instance1
Name                   : instance1
ObjectFailedCount      : 0
ObjectsOperatedOnCount : 0
ObjectsSucceededCount  : 0
ObjectsTargetedCount   : 0
RunResult              : Succeeded
RunStatusEnum          : Finished
RunStatusError         : 0x0
StartTime              : 2024-07-02T08:10:55.0000000Z
StorageAccountId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount
SummaryReportPath      : https://myaccount.blob.core.windows.net/testc2/mytask/assignment1/2024-07-02T08:11:20/SummaryReport.json
TaskAssignmentId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
TaskId                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TaskVersion            : 1
Type                   : Microsoft.Storage/storageAccounts/storageTaskAssignments/reports
```

This command lists the reports of task assignment "mytaskassignment".

### Example 2: List the reports of all storage task assignments and instances in an account
```powershell
Get-AzStorageTaskAssignmentInstancesReport -AccountName myaccount -ResourceGroupName myresourcegroup
```

```output
FinishTime             : 2024-07-03T08:19:23.1774164Z
Id                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/reports/instance1
Name                   : instance1
ObjectFailedCount      : 0
ObjectsOperatedOnCount : 0
ObjectsSucceededCount  : 0
ObjectsTargetedCount   : 0
RunResult              : Succeeded
RunStatusEnum          : Finished
RunStatusError         : 0x0
StartTime              : 2024-07-03T08:10:11.0000000Z
StorageAccountId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount
SummaryReportPath      : https://myaccount.blob.core.windows.net/testc2/mytask/mytaskassignment/2024-07-03T08:10:41/SummaryReport.json
TaskAssignmentId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment
TaskId                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TaskVersion            : 1
Type                   : Microsoft.Storage/storageAccounts/reports

FinishTime             : 2024-07-02T08:19:51.9238839Z
Id                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/reports/instance2
Name                   : instance2
ObjectFailedCount      : 0
ObjectsOperatedOnCount : 0
ObjectsSucceededCount  : 0
ObjectsTargetedCount   : 0
RunResult              : Succeeded
RunStatusEnum          : Finished
RunStatusError         : 0x0
StartTime              : 2024-07-02T08:10:55.0000000Z
StorageAccountId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount
SummaryReportPath      : https://myaccount.blob.core.windows.net/testc2/mytaskassignment2/assignment1/2024-07-02T08:11:20/SummaryReport.json
TaskAssignmentId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount/storageTaskAssignments/mytaskassignment2
TaskId                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageActions/storageTasks/mytask
TaskVersion            : 1
Type                   : Microsoft.Storage/storageAccounts/reports
```

This command lists the reports of all storage task assignments and instances under storage account "myaccount".

