### Example 1: Start migration by Id
```powershell
Start-AzMigrateHCIServerMigration -TargetObjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851"
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api2021
                                     0216Preview.WorkflowModelCustomPropertiesAffectedObjectDe
                                     tails
CustomPropertyInstanceType         : FailoverWorkflowDetails
DisplayName                        : Planned failover
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/af0e1bf6-e3e6-482c-8345-b1a06d87af96
Name                               : af0e1bf6-e3e6-482c-8345-b1a06d87af96
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851/plannedFai
                                     lover
ObjectInternalId                   : a8b5ee68-102c-5aae-9499-c57a475a8fc4
ObjectInternalName                 : testmachine
ObjectName                         : 0ec082d5-6827-457a-bae2-f986e1b94851
ObjectType                         : ProtectedItem
ReplicationProviderId              : 4de0fddc-bdfe-40d9-b60e-678bdce89630
SourceFabricProviderId             : b35da11c-d69e-4220-9a90-d81ed93ad2fc
StartTime                          : 8/1/2023 12:42:19 AM
State                              : Started
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api2021
                                     0216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               : {Prerequisite check, Turning off resource on primary,
                                     Starting failover, Preparing protected entities...}
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

Start AzStackHCI server migration by Id.

### Example 2: Start migration by input object
```powershell
$InputObject = Get-AzMigrateHCIServerReplication -TargetObjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851"

Start-AzMigrateHCIServerMigration -InputObject $InputObject

$InputObject | Start-AzMigrateHCIServerMigration
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api2021
                                     0216Preview.WorkflowModelCustomPropertiesAffectedObjectDe
                                     tails
CustomPropertyInstanceType         : FailoverWorkflowDetails
DisplayName                        : Planned failover
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/af0e1bf6-e3e6-482c-8345-b1a06d87af96
Name                               : af0e1bf6-e3e6-482c-8345-b1a06d87af96
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851/plannedFai
                                     lover
ObjectInternalId                   : a8b5ee68-102c-5aae-9499-c57a475a8fc4
ObjectInternalName                 : testmachine
ObjectName                         : 0ec082d5-6827-457a-bae2-f986e1b94851
ObjectType                         : ProtectedItem
ReplicationProviderId              : 4de0fddc-bdfe-40d9-b60e-678bdce89630
SourceFabricProviderId             : b35da11c-d69e-4220-9a90-d81ed93ad2fc
StartTime                          : 8/1/2023 12:42:19 AM
State                              : Started
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api2021
                                     0216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               : {Prerequisite check, Turning off resource on primary,
                                     Starting failover, Preparing protected entities...}
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

Start AzStackHCI server migration by replication input object.

