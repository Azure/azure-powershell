### Example 1: Get by job Id
```powershell
Get-AzMigrateHCIJob -ID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a"
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a
Name                               : 0203aa1b-1dff-4653-89a9-b90a76d1601a
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000001
ObjectInternalId                   : 13436868-1f4c-5d4e-a252-c666179bf4df
ObjectInternalName                 : testmachine1
ObjectName                         : testsite-0000-0000-00000001
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/14/2023 7:09:10 PM
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

Retrieves a job by its Id. 

### Example 2: Get by job name
```powershell
Get-AzMigrateHCIJob -ResourceGroupName "test-rg" -ProjectName "testproj" -Name "0203aa1b-1dff-4653-89a9-b90a76d1601a"
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a
Name                               : 0203aa1b-1dff-4653-89a9-b90a76d1601a
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000001
ObjectInternalId                   : 13436868-1f4c-5d4e-a252-c666179bf4df
ObjectInternalName                 : testmachine1
ObjectName                         : testsite-0000-0000-00000001
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/14/2023 7:09:10 PM
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

Retrieves a job by its name.

### Example 3: Get by job input object
```powershell
$InputObject = Get-AzMigrateHCIJob -ID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a"

Get-AzMigrateHCIJob -InputObject $InputObject

$InputObject | Get-AzMigrateHCIJob
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a
Name                               : 0203aa1b-1dff-4653-89a9-b90a76d1601a
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000001
ObjectInternalId                   : 13436868-1f4c-5d4e-a252-c666179bf4df
ObjectInternalName                 : testmachine1
ObjectName                         : testsite-0000-0000-00000001
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/14/2023 7:09:10 PM
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

Retrieves a job by the job itself as an input object.

### Example 4: List by resource group Id and project Id.
```powershell
Get-AzMigrateHCIJob -ResourceGroupID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg" -ProjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Migrate/MigrateProjects/testproj"
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a
Name                               : 0203aa1b-1dff-4653-89a9-b90a76d1601a
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000001
ObjectInternalId                   : 13436868-1f4c-5d4e-a252-c666179bf4df
ObjectInternalName                 : testmachine1
ObjectName                         : testsite-0000-0000-00000001
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/14/2023 7:09:10 PM
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

ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         :
DisplayName                        : Planned failover
EndTime                            : 8/11/2023 10:09:18 PM
Error                              :
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/f2ebb932-fa4a-47a7-b1fa-ff5aa877d5ed
Name                               : f2ebb932-fa4a-47a7-b1fa-ff5aa877d5ed
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000000/plannedFailover
ObjectInternalId                   : 4ef231a3-0774-5e44-8317-bed903d297a2
ObjectInternalName                 : testmachine2
ObjectName                         : testsite-0000-0000-00000000
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/11/2023 9:53:48 PM
State                              : Succeeded
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               :
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

Retrieves all the jobs from a project in some resource group by Ids.

### Example 5: List by resource group name and project name.
```powershell
Get-AzMigrateHCIJob -ResourceGroupName "test-rg" -ProjectName "testproj"
```

```output
ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {Cancel}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         : WorkflowDetails
DisplayName                        : Delete protected item
EndTime                            :
Error                              : {}
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/0203aa1b-1dff-4653-89a9-b90a76d1601a
Name                               : 0203aa1b-1dff-4653-89a9-b90a76d1601a
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000001
ObjectInternalId                   : 13436868-1f4c-5d4e-a252-c666179bf4df
ObjectInternalName                 : testmachine1
ObjectName                         : testsite-0000-0000-00000001
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/14/2023 7:09:10 PM
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

ActivityId                         :  ActivityId: 00000000-0000-0000-0000-000000000000
AllowedAction                      : {}
CustomPropertyAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelCustomPropertiesAffectedObjectDetails
CustomPropertyInstanceType         :
DisplayName                        : Planned failover
EndTime                            : 8/11/2023 10:09:18 PM
Error                              :
Id                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/jobs/f2ebb932-fa4a-47a7-b1fa-ff5aa877d5ed
Name                               : f2ebb932-fa4a-47a7-b1fa-ff5aa877d5ed
ObjectId                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication
                                     /replicationVaults/testproj1234replicationvault/protectedItems/testsite-0000-0000-00000000/plannedFailover
ObjectInternalId                   : 4ef231a3-0774-5e44-8317-bed903d297a2
ObjectInternalName                 : testmachine2
ObjectName                         : testsite-0000-0000-00000000
ObjectType                         : ProtectedItem
ReplicationProviderId              : 0a870516-56c7-4460-998c-f267bd579f16
SourceFabricProviderId             : a2793d98-d4f1-427f-a5a6-2d694f4a1bf7
StartTime                          : 8/11/2023 9:53:48 PM
State                              : Succeeded
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.WorkflowModelTags
TargetFabricProviderId             : 22f00372-a1b7-467f-87ce-d95e17a6e7c7
Task                               :
Type                               : Microsoft.DataReplication/replicationVaults/jobs
```

Retrieves all the jobs from a project in some resource group by names.

