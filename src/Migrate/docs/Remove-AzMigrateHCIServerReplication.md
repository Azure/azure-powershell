---
external help file:
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/remove-azmigratehciserverreplication
schema: 2.0.0
---

# Remove-AzMigrateHCIServerReplication

## SYNOPSIS
Stops replication for the migrated server.

## SYNTAX

### ByID (Default)
```
Remove-AzMigrateHCIServerReplication -TargetObjectID <String> [-SubscriptionId <String>]
 [-ForceRemove <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzMigrateHCIServerReplication -InputObject <IMigrateIdentity> [-SubscriptionId <String>]
 [-ForceRemove <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzMigrateHCIServerReplication cmdlet stops the replication for a migrated server.

## EXAMPLES

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

### -ForceRemove
Specifies whether the replication needs to be force removed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Specifies the machine object of the replicating server.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -TargetObjectID
Specifies the replcating server for which the replicatio needs to be disabled.
The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.

```yaml
Type: System.String
Parameter Sets: ByID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMigrateIdentity>`: Specifies the machine object of the replicating server.
  - `[AccountName <String>]`: Run as account ARM name.
  - `[AlertSettingName <String>]`: The name of the email notification configuration.
  - `[ClusterName <String>]`: Cluster ARM name.
  - `[DatabaseInstanceName <String>]`: Unique name of a database instance in Azure migration hub.
  - `[DatabaseName <String>]`: Unique name of a database in Azure migration hub.
  - `[DeploymentId <String>]`: Deployment Id.
  - `[DraName <String>]`: Dra name.
  - `[EmailConfigurationName <String>]`: Email configuration name.
  - `[EventName <String>]`: Unique name of an event within a migrate project.
  - `[FabricName <String>]`: Fabric name.
  - `[HostName <String>]`: Host ARM name.
  - `[Id <String>]`: Resource identity path
  - `[IntentObjectName <String>]`: Replication protection intent name.
  - `[JobName <String>]`: Job ARM name.
  - `[Location <String>]`: The name of the Azure region.
  - `[LogicalNetworkName <String>]`: Logical network name.
  - `[MachineName <String>]`: Machine ARM name.
  - `[MappingName <String>]`: Protection Container mapping name.
  - `[MigrateProjectName <String>]`: Name of the Azure Migrate project.
  - `[MigrationItemName <String>]`: Migration item name.
  - `[MigrationRecoveryPointName <String>]`: The migration recovery point name.
  - `[NetworkMappingName <String>]`: Network mapping name.
  - `[NetworkName <String>]`: Primary network name.
  - `[OperationId <String>]`: The ID of an ongoing async operation.
  - `[OperationStatusName <String>]`: Operation status ARM name.
  - `[PolicyName <String>]`: Replication policy name.
  - `[ProtectableItemName <String>]`: Protectable item name.
  - `[ProtectedItemName <String>]`: Protected item name.
  - `[ProtectionContainerName <String>]`: Protection container name.
  - `[ProviderName <String>]`: Recovery services provider name.
  - `[RecoveryPlanName <String>]`: Name of the recovery plan.
  - `[RecoveryPointName <String>]`: The recovery point name.
  - `[ReplicatedProtectedItemName <String>]`: Replication protected item name.
  - `[ReplicationExtensionName <String>]`: Replication extension name.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the recovery services vault.
  - `[SiteName <String>]`: Site name.
  - `[SolutionName <String>]`: Unique name of a migration solution within a migrate project.
  - `[StorageClassificationMappingName <String>]`: Storage classification mapping name.
  - `[StorageClassificationName <String>]`: Storage classification name.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VaultName <String>]`: Vault name.
  - `[VaultSettingName <String>]`: Vault setting name.
  - `[VcenterName <String>]`: VCenter ARM name.
  - `[VirtualMachineName <String>]`: Virtual Machine name.
  - `[WorkflowName <String>]`: Workflow name.

## RELATED LINKS

