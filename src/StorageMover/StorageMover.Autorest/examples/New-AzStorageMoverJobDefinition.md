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

### Example 2: Create a cross-tenant job definition
```powershell
New-AzStorageMoverJobDefinition -Name myJob -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -JobType CloudToCloud -CopyMode Additive -SourceName mySourceEndpoint -TargetName partnerTargetEndpoint -IsCrossTenantJob -CrossTenantEndpointTenantId "zzzzzzzz-zzzz-zzzz-zzzz-zzzzzzzzzzzz" -CrossTenantEndpointResourceId "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.StorageMover/storageMovers/partnerStorageMover/endpoints/partnerTargetEndpoint"
```

```output
AgentName                     :
AgentResourceId               :
Connection                    :
CopyMode                      : Additive
CrossTenantEndpointResourceId : /subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.StorageMover/storageMovers/partnerStorageMover/endpoints/partnerTargetEndpoint
CrossTenantEndpointTenantId   : zzzzzzzz-zzzz-zzzz-zzzz-zzzzzzzzzzzz
DataIntegrityValidation       :
Description                   :
ExecutionTimeHour             :
ExecutionTimeMinute           :
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob
IsCrossTenantJob              : True
JobType                       : CloudToCloud
LatestJobRunName              :
LatestJobRunResourceId        :
LatestJobRunStatus            :
MoverSyncedUntil              :
Name                          : myJob
PreservePermission            :
ProvisioningState             : Succeeded
ResourceGroupName             : myResourceGroup
ScheduleCronExpression        :
ScheduleDaysOfMonth           :
ScheduleDaysOfWeek            :
ScheduleEndDate               :
ScheduleFrequency             : None
ScheduleIsActive              : False
ScheduleRepeatInterval        :
ScheduleStartDate             :
SourceName                    : mySourceEndpoint
SourceResourceId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/mySourceEndpoint
SourceSubpath                 :
SourceTargetMapValue          :
SyncMode                      :
SystemDataCreatedAt           : 10/19/2026 10:44:02 AM
SystemDataCreatedBy           : xxxxxxxxxx
SystemDataCreatedByType       : User
SystemDataLastModifiedAt      : 10/19/2026 10:44:02 AM
SystemDataLastModifiedBy      : xxxxxxxxxx
SystemDataLastModifiedByType  : User
TargetName                    : partnerTargetEndpoint
TargetResourceId              : /subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.StorageMover/storageMovers/partnerStorageMover/endpoints/partnerTargetEndpoint
TargetSubpath                 :
Type                          : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command creates a job definition that copies data from a source endpoint in the current tenant to a target endpoint in a partner tenant. Both endpoints must enable cross-tenant data transfer and allow each other's storage accounts before a job run can start.

