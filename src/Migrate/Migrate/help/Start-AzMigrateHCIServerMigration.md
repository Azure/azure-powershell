---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/start-azmigratehciservermigration
schema: 2.0.0
---

# Start-AzMigrateHCIServerMigration

## SYNOPSIS
Starts the migration for the replicating server.

## SYNTAX

### ByID (Default)
```
Start-AzMigrateHCIServerMigration -TargetObjectID <String> [-TurnOffSourceServer] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Start-AzMigrateHCIServerMigration [-TurnOffSourceServer] [-SubscriptionId <String>]
 -InputObject <IMigrateIdentity> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Starts the migration for the replicating server.

## EXAMPLES

### EXAMPLE 1
```
Start-AzMigrateHCIServerMigration -TargetObjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851"
```

### EXAMPLE 2
```
$InputObject = Get-AzMigrateHCIServerReplication -TargetObjectID "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault/protectedItems/0ec082d5-6827-457a-bae2-f986e1b94851"
```

Start-AzMigrateHCIServerMigration -InputObject $InputObject

$InputObject | Start-AzMigrateHCIServerMigration

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Specifies the replicating server for which migration needs to be initiated.
The server object can be retrieved using the Get-AzMigrateHCIServerReplication cmdlet.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IMigrateIdentity
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetObjectID
Specifies the replcating server for which migration needs to be initiated.
The ID should be retrieved using the Get-AzMigrateHCIServerReplication cmdlet.

```yaml
Type: String
Parameter Sets: ByID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TurnOffSourceServer
Specifies whether the source server should be turned off post migration.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IMigrateIdentity\>: Specifies the replicating server for which migration needs to be initiated.
The server object can be retrieved using the Get-AzMigrateHCIServerReplication cmdlet.
  \[AccountName \<String\>\]: Run as account ARM name.
  \[AlertSettingName \<String\>\]: The name of the email notification configuration.
  \[ClusterName \<String\>\]: Cluster ARM name.
  \[DatabaseInstanceName \<String\>\]: Unique name of a database instance in Azure migration hub.
  \[DatabaseName \<String\>\]: Unique name of a database in Azure migration hub.
  \[DeploymentId \<String\>\]: Deployment Id.
  \[EmailConfigurationName \<String\>\]: The email configuration name.
  \[EventName \<String\>\]: Unique name of an event within a migrate project.
  \[FabricAgentName \<String\>\]: The fabric agent (Dra) name.
  \[FabricName \<String\>\]: Fabric name.
  \[HostName \<String\>\]: Host ARM name.
  \[Id \<String\>\]: Resource identity path
  \[IntentObjectName \<String\>\]: Replication protection intent name.
  \[JobName \<String\>\]: Job ARM name.
  \[Location \<String\>\]: The name of the Azure region.
  \[LogicalNetworkName \<String\>\]: Logical network name.
  \[MachineName \<String\>\]: Machine ARM name.
  \[MappingName \<String\>\]: Protection Container mapping name.
  \[MigrateProjectName \<String\>\]: Name of the Azure Migrate project.
  \[MigrationItemName \<String\>\]: Migration item name.
  \[MigrationRecoveryPointName \<String\>\]: The migration recovery point name.
  \[NetworkMappingName \<String\>\]: Network mapping name.
  \[NetworkName \<String\>\]: Primary network name.
  \[OperationId \<String\>\]: The ID of an ongoing async operation.
  \[OperationStatusName \<String\>\]: Operation status ARM name.
  \[PolicyName \<String\>\]: Replication policy name.
  \[ProtectableItemName \<String\>\]: Protectable item name.
  \[ProtectedItemName \<String\>\]: The protected item name.
  \[ProtectionContainerName \<String\>\]: Protection container name.
  \[ProviderName \<String\>\]: Recovery services provider name.
  \[RecoveryPlanName \<String\>\]: Name of the recovery plan.
  \[RecoveryPointName \<String\>\]: The recovery point name.
  \[ReplicatedProtectedItemName \<String\>\]: Replication protected item name.
  \[ReplicationExtensionName \<String\>\]: The replication extension name.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceName \<String\>\]: The name of the recovery services vault.
  \[SiteName \<String\>\]: Site name.
  \[SolutionName \<String\>\]: Unique name of a migration solution within a migrate project.
  \[StorageClassificationMappingName \<String\>\]: Storage classification mapping name.
  \[StorageClassificationName \<String\>\]: Storage classification name.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[VaultName \<String\>\]: The vault name.
  \[VaultSettingName \<String\>\]: Vault setting name.
  \[VcenterName \<String\>\]: VCenter ARM name.
  \[VirtualMachineName \<String\>\]: Virtual Machine name.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.migrate/start-azmigratehciservermigration](https://learn.microsoft.com/powershell/module/az.migrate/start-azmigratehciservermigration)

