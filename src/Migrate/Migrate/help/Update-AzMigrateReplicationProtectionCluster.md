---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/update-azmigratereplicationprotectioncluster
schema: 2.0.0
---

# Update-AzMigrateReplicationProtectionCluster

## SYNOPSIS
The operation to update an ASR replication protection cluster item.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMigrateReplicationProtectionCluster -FabricName <String> -Name <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-ActiveLocation <String>] [-AgentClusterId <String>]
 [-AllowedOperation <String[]>] [-AreAllClusterNodesRegistered] [-ClusterFqdn <String>]
 [-ClusterNodeFqdn <String[]>] [-ClusterProtectedItemId <String[]>]
 [-ClusterRegisteredNode <IRegisteredClusterNodes[]>] [-CurrentScenarioName <String>]
 [-HealthError <IHealthError[]>] [-JobId <String>] [-LastSuccessfulFailoverTime <DateTime>]
 [-LastSuccessfulTestFailoverTime <DateTime>] [-PolicyFriendlyName <String>] [-PolicyId <String>]
 [-PrimaryFabricFriendlyName <String>] [-PrimaryFabricProvider <String>]
 [-PrimaryProtectionContainerFriendlyName <String>] [-ProtectionClusterType <String>]
 [-ProtectionState <String>] [-ProtectionStateDescription <String>]
 [-ProviderSpecificDetailInstanceType <String>] [-RecoveryContainerId <String>]
 [-RecoveryFabricFriendlyName <String>] [-RecoveryFabricId <String>]
 [-RecoveryProtectionContainerFriendlyName <String>] [-ReplicationHealth <String>]
 [-SharedDiskPropertiesCurrentScenarioJobId <String>] [-SharedDiskPropertiesCurrentScenarioName <String>]
 [-SharedDiskPropertiesCurrentScenarioStartTime <DateTime>] [-SharedDiskPropertyActiveLocation <String>]
 [-SharedDiskPropertyAllowedOperation <String[]>] [-SharedDiskPropertyHealthError <IHealthError[]>]
 [-SharedDiskPropertyProtectionState <String>] [-SharedDiskPropertyReplicationHealth <String>]
 [-SharedDiskPropertyTestFailoverState <String>] [-SharedDiskProviderSpecificDetailInstanceType <String>]
 [-StartTime <DateTime>] [-TestFailoverState <String>] [-TestFailoverStateDescription <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityVaultExpanded
```
Update-AzMigrateReplicationProtectionCluster -FabricName <String> -Name <String>
 -ProtectionContainerName <String> -VaultInputObject <IMigrateIdentity> [-ActiveLocation <String>]
 [-AgentClusterId <String>] [-AllowedOperation <String[]>] [-AreAllClusterNodesRegistered]
 [-ClusterFqdn <String>] [-ClusterNodeFqdn <String[]>] [-ClusterProtectedItemId <String[]>]
 [-ClusterRegisteredNode <IRegisteredClusterNodes[]>] [-CurrentScenarioName <String>]
 [-HealthError <IHealthError[]>] [-JobId <String>] [-LastSuccessfulFailoverTime <DateTime>]
 [-LastSuccessfulTestFailoverTime <DateTime>] [-PolicyFriendlyName <String>] [-PolicyId <String>]
 [-PrimaryFabricFriendlyName <String>] [-PrimaryFabricProvider <String>]
 [-PrimaryProtectionContainerFriendlyName <String>] [-ProtectionClusterType <String>]
 [-ProtectionState <String>] [-ProtectionStateDescription <String>]
 [-ProviderSpecificDetailInstanceType <String>] [-RecoveryContainerId <String>]
 [-RecoveryFabricFriendlyName <String>] [-RecoveryFabricId <String>]
 [-RecoveryProtectionContainerFriendlyName <String>] [-ReplicationHealth <String>]
 [-SharedDiskPropertiesCurrentScenarioJobId <String>] [-SharedDiskPropertiesCurrentScenarioName <String>]
 [-SharedDiskPropertiesCurrentScenarioStartTime <DateTime>] [-SharedDiskPropertyActiveLocation <String>]
 [-SharedDiskPropertyAllowedOperation <String[]>] [-SharedDiskPropertyHealthError <IHealthError[]>]
 [-SharedDiskPropertyProtectionState <String>] [-SharedDiskPropertyReplicationHealth <String>]
 [-SharedDiskPropertyTestFailoverState <String>] [-SharedDiskProviderSpecificDetailInstanceType <String>]
 [-StartTime <DateTime>] [-TestFailoverState <String>] [-TestFailoverStateDescription <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityReplicationProtectionContainerExpanded
```
Update-AzMigrateReplicationProtectionCluster -Name <String>
 -ReplicationProtectionContainerInputObject <IMigrateIdentity> [-ActiveLocation <String>]
 [-AgentClusterId <String>] [-AllowedOperation <String[]>] [-AreAllClusterNodesRegistered]
 [-ClusterFqdn <String>] [-ClusterNodeFqdn <String[]>] [-ClusterProtectedItemId <String[]>]
 [-ClusterRegisteredNode <IRegisteredClusterNodes[]>] [-CurrentScenarioName <String>]
 [-HealthError <IHealthError[]>] [-JobId <String>] [-LastSuccessfulFailoverTime <DateTime>]
 [-LastSuccessfulTestFailoverTime <DateTime>] [-PolicyFriendlyName <String>] [-PolicyId <String>]
 [-PrimaryFabricFriendlyName <String>] [-PrimaryFabricProvider <String>]
 [-PrimaryProtectionContainerFriendlyName <String>] [-ProtectionClusterType <String>]
 [-ProtectionState <String>] [-ProtectionStateDescription <String>]
 [-ProviderSpecificDetailInstanceType <String>] [-RecoveryContainerId <String>]
 [-RecoveryFabricFriendlyName <String>] [-RecoveryFabricId <String>]
 [-RecoveryProtectionContainerFriendlyName <String>] [-ReplicationHealth <String>]
 [-SharedDiskPropertiesCurrentScenarioJobId <String>] [-SharedDiskPropertiesCurrentScenarioName <String>]
 [-SharedDiskPropertiesCurrentScenarioStartTime <DateTime>] [-SharedDiskPropertyActiveLocation <String>]
 [-SharedDiskPropertyAllowedOperation <String[]>] [-SharedDiskPropertyHealthError <IHealthError[]>]
 [-SharedDiskPropertyProtectionState <String>] [-SharedDiskPropertyReplicationHealth <String>]
 [-SharedDiskPropertyTestFailoverState <String>] [-SharedDiskProviderSpecificDetailInstanceType <String>]
 [-StartTime <DateTime>] [-TestFailoverState <String>] [-TestFailoverStateDescription <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityReplicationFabricExpanded
```
Update-AzMigrateReplicationProtectionCluster -Name <String> -ProtectionContainerName <String>
 -ReplicationFabricInputObject <IMigrateIdentity> [-ActiveLocation <String>] [-AgentClusterId <String>]
 [-AllowedOperation <String[]>] [-AreAllClusterNodesRegistered] [-ClusterFqdn <String>]
 [-ClusterNodeFqdn <String[]>] [-ClusterProtectedItemId <String[]>]
 [-ClusterRegisteredNode <IRegisteredClusterNodes[]>] [-CurrentScenarioName <String>]
 [-HealthError <IHealthError[]>] [-JobId <String>] [-LastSuccessfulFailoverTime <DateTime>]
 [-LastSuccessfulTestFailoverTime <DateTime>] [-PolicyFriendlyName <String>] [-PolicyId <String>]
 [-PrimaryFabricFriendlyName <String>] [-PrimaryFabricProvider <String>]
 [-PrimaryProtectionContainerFriendlyName <String>] [-ProtectionClusterType <String>]
 [-ProtectionState <String>] [-ProtectionStateDescription <String>]
 [-ProviderSpecificDetailInstanceType <String>] [-RecoveryContainerId <String>]
 [-RecoveryFabricFriendlyName <String>] [-RecoveryFabricId <String>]
 [-RecoveryProtectionContainerFriendlyName <String>] [-ReplicationHealth <String>]
 [-SharedDiskPropertiesCurrentScenarioJobId <String>] [-SharedDiskPropertiesCurrentScenarioName <String>]
 [-SharedDiskPropertiesCurrentScenarioStartTime <DateTime>] [-SharedDiskPropertyActiveLocation <String>]
 [-SharedDiskPropertyAllowedOperation <String[]>] [-SharedDiskPropertyHealthError <IHealthError[]>]
 [-SharedDiskPropertyProtectionState <String>] [-SharedDiskPropertyReplicationHealth <String>]
 [-SharedDiskPropertyTestFailoverState <String>] [-SharedDiskProviderSpecificDetailInstanceType <String>]
 [-StartTime <DateTime>] [-TestFailoverState <String>] [-TestFailoverStateDescription <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMigrateReplicationProtectionCluster -InputObject <IMigrateIdentity> [-ActiveLocation <String>]
 [-AgentClusterId <String>] [-AllowedOperation <String[]>] [-AreAllClusterNodesRegistered]
 [-ClusterFqdn <String>] [-ClusterNodeFqdn <String[]>] [-ClusterProtectedItemId <String[]>]
 [-ClusterRegisteredNode <IRegisteredClusterNodes[]>] [-CurrentScenarioName <String>]
 [-HealthError <IHealthError[]>] [-JobId <String>] [-LastSuccessfulFailoverTime <DateTime>]
 [-LastSuccessfulTestFailoverTime <DateTime>] [-PolicyFriendlyName <String>] [-PolicyId <String>]
 [-PrimaryFabricFriendlyName <String>] [-PrimaryFabricProvider <String>]
 [-PrimaryProtectionContainerFriendlyName <String>] [-ProtectionClusterType <String>]
 [-ProtectionState <String>] [-ProtectionStateDescription <String>]
 [-ProviderSpecificDetailInstanceType <String>] [-RecoveryContainerId <String>]
 [-RecoveryFabricFriendlyName <String>] [-RecoveryFabricId <String>]
 [-RecoveryProtectionContainerFriendlyName <String>] [-ReplicationHealth <String>]
 [-SharedDiskPropertiesCurrentScenarioJobId <String>] [-SharedDiskPropertiesCurrentScenarioName <String>]
 [-SharedDiskPropertiesCurrentScenarioStartTime <DateTime>] [-SharedDiskPropertyActiveLocation <String>]
 [-SharedDiskPropertyAllowedOperation <String[]>] [-SharedDiskPropertyHealthError <IHealthError[]>]
 [-SharedDiskPropertyProtectionState <String>] [-SharedDiskPropertyReplicationHealth <String>]
 [-SharedDiskPropertyTestFailoverState <String>] [-SharedDiskProviderSpecificDetailInstanceType <String>]
 [-StartTime <DateTime>] [-TestFailoverState <String>] [-TestFailoverStateDescription <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to update an ASR replication protection cluster item.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ActiveLocation
The Current active location of the Protection cluster.

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

### -AgentClusterId
The Agent cluster Id.

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

### -AllowedOperation
The allowed operations on the Replication protection cluster.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AreAllClusterNodesRegistered
A value indicating whether all nodes of the cluster are registered or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterFqdn
The cluster FQDN.

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

### -ClusterNodeFqdn
The List of cluster Node FQDNs.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterProtectedItemId
The List of Protected Item Id's.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterRegisteredNode
The registered node details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IRegisteredClusterNodes[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CurrentScenarioName
Scenario name.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -FabricName
Fabric name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityVaultExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthError
List of health errors.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IHealthError[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobId
ARM Id of the job being executed.

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

### -LastSuccessfulFailoverTime
The last successful failover time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastSuccessfulTestFailoverTime
The last successful test failover time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Replication protection cluster name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityVaultExpanded, UpdateViaIdentityReplicationProtectionContainerExpanded, UpdateViaIdentityReplicationFabricExpanded
Aliases: ReplicationProtectionClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyFriendlyName
The name of Policy governing this PE.

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

### -PolicyId
The Policy Id.

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

### -PrimaryFabricFriendlyName
The friendly name of the primary fabric.

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

### -PrimaryFabricProvider
The fabric provider of the primary fabric.

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

### -PrimaryProtectionContainerFriendlyName
The name of primary protection container friendly name.

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

### -ProtectionClusterType
The type of protection cluster type.

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

### -ProtectionContainerName
Protection container name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityVaultExpanded, UpdateViaIdentityReplicationFabricExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionState
The protection status.

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

### -ProtectionStateDescription
The protection state description.

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

### -ProviderSpecificDetailInstanceType
Gets the Instance type.

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

### -RecoveryContainerId
The recovery container Id.

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

### -RecoveryFabricFriendlyName
The friendly name of recovery fabric.

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

### -RecoveryFabricId
The Arm Id of recovery fabric.

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

### -RecoveryProtectionContainerFriendlyName
The name of recovery container friendly name.

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

### -ReplicationFabricInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: UpdateViaIdentityReplicationFabricExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReplicationHealth
The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated with the VM's replication group into account.
This is a string representation of the ProtectionHealth enumeration.

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

### -ReplicationProtectionContainerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: UpdateViaIdentityReplicationProtectionContainerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedDiskPropertiesCurrentScenarioJobId
ARM Id of the job being executed.

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

### -SharedDiskPropertiesCurrentScenarioName
Scenario name.

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

### -SharedDiskPropertiesCurrentScenarioStartTime
Start time of the workflow.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedDiskPropertyActiveLocation
The Current active location of the PE.

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

### -SharedDiskPropertyAllowedOperation
The allowed operations on the Replication protected item.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedDiskPropertyHealthError
List of health errors.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IHealthError[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedDiskPropertyProtectionState
The protection state of shared disk.

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

### -SharedDiskPropertyReplicationHealth
The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated with the VM's replication group into account.
This is a string representation of the ProtectionHealth enumeration.

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

### -SharedDiskPropertyTestFailoverState
The tfo state of shared disk.

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

### -SharedDiskProviderSpecificDetailInstanceType
Gets the Instance type.

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

### -StartTime
Start time of the workflow.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription Id in which migrate project was created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestFailoverState
The Test failover state.

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

### -TestFailoverStateDescription
The Test failover state description.

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

### -VaultInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: UpdateViaIdentityVaultExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IReplicationProtectionCluster

## NOTES

## RELATED LINKS
