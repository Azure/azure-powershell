### Example 1: Remove replication by Id
```powershell
Remove-AzMigrateHCIServerReplication -TargetObjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851"
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/jobs/2b0b356e-d106-43af-ad26-02631fcaebba
Name                               : 2b0b356e-d106-43af-ad26-02631fcaebba
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/c1a34301-3bff-4ec6-97f1-6c4bd5adcde0
ObjectInternalId                   : a40ecd8e-6413-574d-b1f8-2ef925e087fc
ObjectInternalName                 : testmachine
ObjectName                         : c1a34301-3bff-4ec6-97f1-6c4bd5adcde0
ObjectType                         : ProtectedItem
ReplicationProviderId              : 4de0fddc-bdfe-40d9-b60e-678bdce89630
SourceFabricProviderId             : b35da11c-d69e-4220-9a90-d81ed93ad2fc
StartTime                          : 7/25/2023 10:14:42 PM
State                              : Started
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               : {Prerequisite check, Deleting protected item}
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

Remove AzStackHCI replication by Id.

### Example 2: Remove replication by input object
```powershell
$InputObject = Get-AzMigrateHCIServerReplication -TargetObjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851"

Remove-AzMigrateHCIServerReplication -InputObject $InputObject

$InputObject | Remove-AzMigrateHCIServerReplication
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/jobs/2b0b356e-d106-43af-ad26-02631fcaebba
Name                               : 2b0b356e-d106-43af-ad26-02631fcaebba
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/c1a34301-3bff-4ec6-97f1-6c4bd5adcde0
ObjectInternalId                   : a40ecd8e-6413-574d-b1f8-2ef925e087fc
ObjectInternalName                 : testmachine
ObjectName                         : c1a34301-3bff-4ec6-97f1-6c4bd5adcde0
ObjectType                         : ProtectedItem
ReplicationProviderId              : 4de0fddc-bdfe-40d9-b60e-678bdce89630
SourceFabricProviderId             : b35da11c-d69e-4220-9a90-d81ed93ad2fc
StartTime                          : 7/25/2023 10:14:42 PM
State                              : Started
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               : {Prerequisite check, Deleting protected item}
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

Remove AzStackHCI replication by replication input object.

