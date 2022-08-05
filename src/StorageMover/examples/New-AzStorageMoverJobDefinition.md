### Example 1: Create a job definition
```powershell
New-AzStorageMoverJobDefinition -Name myJob -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -AgentName myAgent -SourceName myNfsEndpoint -TargetName myContainerEndpoint -CopyMode "Additive" -Description "job definition"
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  : job definition
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageM
                               overs/myStorageMover/projects/myProject/jobDefinitions/myJob
LatestJobRunName             :
LatestJobRunResourceId       :
LatestJobRunStatus           :
Name                         : myJob
ProvisioningState            : Succeeded
SourceName                   : myNfsEndpoint
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/26/2022 6:14:43 AM
SystemDataCreatedBy          : xxxxxxxxxxxxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/26/2022 6:14:43 AM
SystemDataLastModifiedBy     : xxxxxxxxxxxxxxxxxxxx
SystemDataLastModifiedByType : User
TargetName                   : myContainerEndpoint
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command creates a job definition.

