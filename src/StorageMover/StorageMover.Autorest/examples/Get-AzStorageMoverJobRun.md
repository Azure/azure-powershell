### Example 1: Get all job runs with a job definition
```powershell
Get-AzStorageMoverJobRun -JobDefinitionName myJobDefinition -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -ProjectName myProject
```

```output
AgentName                    : myAgent
AgentResourceId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/agents/myAgent
BytesExcluded                : 0
BytesFailed                  : 0
BytesNoTransferNeeded        : 0
BytesScanned                 : 0
BytesTransferred             : 0
BytesUnsupported             : 0
ErrorCode                    :
ErrorMessage                 :
ExecutionEndTime             :
ExecutionStartTime           : 2/24/2023 12:27:58 AM
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob/
                               jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ItemsExcluded                : 0
ItemsFailed                  : 0
ItemsNoTransferNeeded        : 0
ItemsScanned                 : 0
ItemsTransferred             : 0
ItemsUnsupported             : 0
JobDefinitionProperty        : {
                               }
LastStatusUpdate             : 2/24/2023 12:27:39 AM
Name                         : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ProvisioningState            : Succeeded
ScanStatus                   : NotStarted
SourceName                   : sourceendpoint
SourceProperty               : {
                               }
SourceResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/sourceendpoint
Status                       : Started
SystemDataCreatedAt          : 2/24/2023 12:27:39 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2/24/2023 12:36:01 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Target                       :
TargetName                   : targetendpoint
TargetProperty               : {
                               }
TargetResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/targetendpoint
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions/jobruns
```

This command gets all the job runs under a specific job definition 

### Example 2: Get a specific job run
```powershell
Get-AzStorageMoverJobRun -Name myJobRun -JobDefinitionName myJobDefinition -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -ProjectName myProject
```

```output
AgentName                    : myAgent
AgentResourceId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/agents/myAgent
BytesExcluded                : 0
BytesFailed                  : 0
BytesNoTransferNeeded        : 0
BytesScanned                 : 0
BytesTransferred             : 0
BytesUnsupported             : 0
ErrorCode                    :
ErrorMessage                 :
ExecutionEndTime             :
ExecutionStartTime           : 2/24/2023 12:27:58 AM
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob/
                               jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ItemsExcluded                : 0
ItemsFailed                  : 0
ItemsNoTransferNeeded        : 0
ItemsScanned                 : 0
ItemsTransferred             : 0
ItemsUnsupported             : 0
JobDefinitionProperty        : {
                               }
LastStatusUpdate             : 2/24/2023 12:27:39 AM
Name                         : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ProvisioningState            : Succeeded
ScanStatus                   : NotStarted
SourceName                   : sourceendpoint
SourceProperty               : {
                               }
SourceResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/sourceendpoint
Status                       : Started
SystemDataCreatedAt          : 2/24/2023 12:27:39 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2/24/2023 12:36:01 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Target                       :
TargetName                   : targetendpoint
TargetProperty               : {
                               }
TargetResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/targetendpoint
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions/jobruns
```

This command gets a specific job run. 
