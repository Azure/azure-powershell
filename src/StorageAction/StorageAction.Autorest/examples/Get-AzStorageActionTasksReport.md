### Example 1: Get report
```powershell
Get-AzStorageActionTasksReport -ResourceGroupName joyer-test -StorageTaskName mytask1 | Format-List
```

```output
FinishTime                   : 2024-02-28T10:16:58.9261483Z
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/mytask1/reports/instance1
Name                         : instance1
ObjectFailedCount            : 0
ObjectsOperatedOnCount       : 0
ObjectsSucceededCount        : 0
ObjectsTargetedCount         : 1
RunResult                    : Succeeded
RunStatusEnum                : Finished
RunStatusError               : 0x0
StartTime                    : 2024-02-28T10:07:53.0000000Z
StorageAccountId             : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281
SummaryReportPath            : https://storagetasktest202402281.blob.core.windows.net/rrrr/mytask1/testassign1/2024-02-28T10:08:00/SummaryReport.json
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TaskAssignmentId             : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/storageTaskAssignments/testassign1
TaskId                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/mytask1 
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks/reports

FinishTime                   : 2024-02-28T10:31:54.7848950Z
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/mytask1/reports/instance2
Name                         : instance2
ObjectFailedCount            : 0
ObjectsOperatedOnCount       : 0
ObjectsSucceededCount        : 0
ObjectsTargetedCount         : 1
RunResult                    : Succeeded
RunStatusEnum                : Finished
RunStatusError               : 0x0
StartTime                    : 2024-02-28T10:21:53.0000000Z
StorageAccountId             : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281
SummaryReportPath            : https://storagetasktest202402281.blob.core.windows.net/rrrr/mytask1/testassign2/2024-02-28T10:22:05/SummaryReport.json
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TaskAssignmentId             : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/storageTaskAssignments/testassign2
TaskId                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.StorageActions/storageTasks/mytask1 
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks/reports
```

This command get assignments report.

