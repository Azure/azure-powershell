### Example 1: Get all job definitions under a Storage mover
```powershell
Get-AzStorageMoverJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover 
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1
LatestJobRunName             : 12345678-1234-1234-1234-111111111111
LatestJobRunResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
LatestJobRunStatus           : Queued
Name                         : myJob1
ProvisioningState            : Succeeded
SourceName                   : nfsEndpoint1
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/28/2022 5:47:29 AM
SystemDataCreatedBy          : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 3:09:15 AM
SystemDataLastModifiedBy     : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataLastModifiedByType : Application
TargetName                   : containerEndpoint1
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command gets all the job definitions under a specific Storage mover.

### Example 2: Get a specific job definition
```powershell
Get-AzStorageMoverJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myJob1
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1
LatestJobRunName             : 12345678-1234-1234-1234-111111111111
LatestJobRunResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
LatestJobRunStatus           : Queued
Name                         : myJob1
ProvisioningState            : Succeeded
SourceName                   : nfsEndpoint1
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/28/2022 5:47:29 AM
SystemDataCreatedBy          : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 3:09:15 AM
SystemDataLastModifiedBy     : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataLastModifiedByType : Application
TargetName                   : containerEndpoint1
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command gets a specific job definition. 

