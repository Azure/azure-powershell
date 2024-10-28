---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehcijob
schema: 2.0.0
---

# Get-AzMigrateHCIJob

## SYNOPSIS
Retrieves the status of an Azure Migrate job.

## SYNTAX

### ListByName (Default)
```
Get-AzMigrateHCIJob -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByName
```
Get-AzMigrateHCIJob -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>] -Name <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetById
```
Get-AzMigrateHCIJob [-SubscriptionId <String>] -ID <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByInputObject
```
Get-AzMigrateHCIJob [-SubscriptionId <String>] -InputObject <IMigrateIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListById
```
Get-AzMigrateHCIJob [-SubscriptionId <String>] -ResourceGroupID <String> -ProjectID <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateHCIJob cmdlet retrives the status of an Azure Migrate job.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ID
Specifies the job id for which the details needs to be retrieved.

```yaml
Type: System.String
Parameter Sets: GetById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Specifies the job object of the replicating server.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: GetByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Job identifier

```yaml
Type: System.String
Parameter Sets: GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectID
Specifies the Azure Migrate Project in which servers are replicating.

```yaml
Type: System.String
Parameter Sets: ListById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The name of the migrate project.

```yaml
Type: System.String
Parameter Sets: ListByName, GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupID
Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: System.String
Parameter Sets: ListById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: ListByName, GetByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IWorkflowModel

## NOTES

## RELATED LINKS
