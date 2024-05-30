### Example 1: Get report
```powershell
Get-AzStorageActionTasksReport -ResourceGroupName group001 -StorageTaskName mytask1 | Format-List
```

```output
FinishTime                   : 2024-02-28T10:16:58.9261483Z
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1/reports/instance1
Name                         : instance1
ObjectFailedCount            : 0
ObjectsOperatedOnCount       : 0
ObjectsSucceededCount        : 0
ObjectsTargetedCount         : 1
RunResult                    : Succeeded
RunStatusEnum                : Finished
RunStatusError               : 0x0
StartTime                    : 2024-02-28T10:07:53.0000000Z
StorageAccountId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001
SummaryReportPath            : https://account001.blob.core.windows.net/rrrr/mytask1/testassign1/2024-02-28T10:08:00/SummaryReport.json
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TaskAssignmentId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001/storageTaskAssignments/testassign1
TaskId                       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1 
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks/reports

FinishTime                   : 2024-02-28T10:31:54.7848950Z
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1/reports/instance2
Name                         : instance2
ObjectFailedCount            : 0
ObjectsOperatedOnCount       : 0
ObjectsSucceededCount        : 0
ObjectsTargetedCount         : 1
RunResult                    : Succeeded
RunStatusEnum                : Finished
RunStatusError               : 0x0
StartTime                    : 2024-02-28T10:21:53.0000000Z
StorageAccountId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001
SummaryReportPath            : https://account001.blob.core.windows.net/rrrr/mytask1/testassign2/2024-02-28T10:22:05/SummaryReport.json
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TaskAssignmentId             : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.Storage/storageAccounts/account001/storageTaskAssignments/testassign2
TaskId                       : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1 
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks/reports
```

This command get assignments report.

