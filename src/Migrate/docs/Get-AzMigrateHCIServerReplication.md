---
external help file:
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehciserverreplication
schema: 2.0.0
---

# Get-AzMigrateHCIServerReplication

## SYNOPSIS
Retrieves the details of the replicating server.

## SYNTAX

### ListByName (Default)
```
Get-AzMigrateHCIServerReplication -ProjectName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Filter <String>] [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByInputObject
```
Get-AzMigrateHCIServerReplication -InputObject <IMigrateIdentity> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByItemID
```
Get-AzMigrateHCIServerReplication -TargetObjectID <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByMachineName
```
Get-AzMigrateHCIServerReplication -MachineName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetBySDSID
```
Get-AzMigrateHCIServerReplication -DiscoveredMachineId <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListById
```
Get-AzMigrateHCIServerReplication -ProjectID <String> -ResourceGroupID <String> [-SubscriptionId <String>]
 [-Filter <String>] [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateHCIServerReplication cmdlet retrieves the object for the replicating server.

## EXAMPLES

### Example 1: Get details by id
```powershell
Get-AzMigrateHCIServerReplication -TargetObjectID '/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5'
```

```output
Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5
Name                         : 503a4f02-916c-d6b0-8d14-222bbd4767e5
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems
```

Get by id.

### Example 2: Get detail by discovered machine id
```powershell
Get-AzMigrateHCIServerReplication -DiscoveredMachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.OffAzure/HyperVSites/siteName1/machines/503a4f02-916c-d6b0-8d14-222bbd4767e5" 

```

```output
Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5
Name                         : 503a4f02-916c-d6b0-8d14-222bbd4767e5
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems
```

Get by discovered machine id.

### Example 3: List all in project by name
```powershell
Get-AzMigrateServerReplication -ResourceGroupName testResourceGroup -ProjectName testProjectName
```

```output

Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5
Name                         : 503a4f02-916c-d6b0-8d14-222bbd4767e5
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems

Id                           : /subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/d758f4fb-ae5e-4ac8-bb97-1e114555fe9f
Name                         : d758f4fb-ae5e-4ac8-bb97-1e114555fe9f
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelProperties
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.ProtectedItemModelTags
Type                         : Microsoft.DataReplication/replicationVaults/protectedItems
```

List all.

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

### -DiscoveredMachineId
Specifies the machine ID of the discovered server.

```yaml
Type: System.String
Parameter Sets: GetBySDSID
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter options.

```yaml
Type: System.String
Parameter Sets: ListById, ListByName
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
Parameter Sets: GetByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineName
Specifies the display name of the replicating machine.

```yaml
Type: System.String
Parameter Sets: GetByMachineName
Aliases:

Required: True
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
Specifies the Azure Migrate project  in the current subscription.

```yaml
Type: System.String
Parameter Sets: GetByMachineName, ListByName
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
Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: System.String
Parameter Sets: GetByMachineName, ListByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
The pagination token.

```yaml
Type: System.String
Parameter Sets: ListById, ListByName
Aliases:

Required: False
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

### -TargetObjectID
Specifies the replicating server.

```yaml
Type: System.String
Parameter Sets: GetByItemID
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IProtectedItemModel

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

