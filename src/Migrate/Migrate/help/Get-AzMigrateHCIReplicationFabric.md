---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehcireplicationfabric
schema: 2.0.0
---

# Get-AzMigrateHCIReplicationFabric

## SYNOPSIS
Gets the details of the fabric.

## SYNTAX

### List (Default)
```
Get-AzMigrateHCIReplicationFabric [-SubscriptionId <String[]>] [-ContinuationToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMigrateHCIReplicationFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMigrateHCIReplicationFabric -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-ContinuationToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMigrateHCIReplicationFabric -InputObject <IMigrateIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the details of the fabric.

## EXAMPLES

### EXAMPLE 1
```
Get-AzMigrateHCIReplicationFabric -ResourceGroupName "test-rg" -Name "testsrcappreplicationfabric"
```

### EXAMPLE 2
```
$InputObject = Get-AzMigrateHCIReplicationFabric -ResourceGroupName "test-rg" -Name "testsrcappreplicationfabric"
```

Get-AzMigrateHCIReplicationFabric -InputObject $InputObject

$InputObject | Get-AzMigrateHCIReplicationFabric

### EXAMPLE 3
```
Get-AzMigrateHCIReplicationFabric -ResourceGroupName "test-rg"
```

### EXAMPLE 4
```
Get-AzMigrateHCIReplicationFabric
```

## PARAMETERS

### -ContinuationToken
Continuation token from the previous call.

```yaml
Type: String
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IMigrateIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The fabric name.

```yaml
Type: String
Parameter Sets: Get
Aliases: FabricName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription Id in which migrate project was created.

```yaml
Type: String[]
Parameter Sets: List, Get, List1
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IFabricModel
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IMigrateIdentity\>: Identity Parameter
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

[https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehcireplicationfabric](https://learn.microsoft.com/powershell/module/az.migrate/get-azmigratehcireplicationfabric)

