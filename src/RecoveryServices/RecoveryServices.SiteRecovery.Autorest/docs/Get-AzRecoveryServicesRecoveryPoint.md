---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesrecoverypoint
schema: 2.0.0
---

# Get-AzRecoveryServicesRecoveryPoint

## SYNOPSIS
Get the details of specified recovery point.

## SYNTAX

### List (Default)
```
Get-AzRecoveryServicesRecoveryPoint -ReplicatedProtectedItem <IReplicationProtectedItem>
 -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzRecoveryServicesRecoveryPoint -Name <String> -ReplicatedProtectedItem <IReplicationProtectedItem>
 -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the details of specified recovery point.

## EXAMPLES

### Example 1: List the details of specified recovery point.
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtestcheck"
Get-AzRecoveryServicesRecoveryPoint -ReplicatedProtectedItem $protectedItem  -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg"
```

```output
Id
--
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/c776987�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/cf96d85�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/987359e�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/464ff01�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/2ccdb2e�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/d99e7c6�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/02250d5�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/ab4823c�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/c920021�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/510ff5d�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/5291191�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/45750ea�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/38cb0b7�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/7cee441�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/fb6d84a�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/fe037d9�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/c98e03f�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/2065437�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/e1e3809�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/b83576a�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/bdfd930�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/9f0609d�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/f99a8bc�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/566b430�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/a0da506�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/f3088f3�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/6f81e41�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/f1cacc1�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/0044c68�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/468cc2d�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/7a45d0b�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/2bc3b2e�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/8d35d80�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/9ff7a00�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/dd0c472�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/bcef0f8�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/a4cc5cb�
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/4a2ebbd�
```

Lists the details of specified recovery point.

### Example 2: Get the details of specified recovery point with a specific name.
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "replicatedvmtestcheck"
Get-AzRecoveryServicesRecoveryPoint -ReplicatedProtectedItem $protectedItem  -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -Name "c7769878-a341-4313-996d-48773291434c"
```

```output
Id
--
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/09017a92-e19d-52bb-8740-2d910cdba430/replicationProtectedItems/replicatedvmtestcheck/recoveryPoints/c776987�
```

Gets the details of specified recovery point with a specific name.

## PARAMETERS

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

### -Name
The recovery point name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RecoveryPointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicatedProtectedItem
Replication protected item Object.
To construct, see NOTES section for REPLICATEDPROTECTEDITEM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IReplicationProtectedItem
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String[]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRecoveryPoint

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`REPLICATEDPROTECTEDITEM <IReplicationProtectedItem>`: Replication protected item Object.
  - `[Location <String>]`: Resource Location
  - `[ActiveLocation <String>]`: The Current active location of the PE.
  - `[AllowedOperation <String[]>]`: The allowed operations on the Replication protected item.
  - `[CurrentScenarioJobId <String>]`: ARM Id of the job being executed.
  - `[CurrentScenarioName <String>]`: Scenario name.
  - `[CurrentScenarioStartTime <DateTime?>]`: Start time of the workflow.
  - `[EventCorrelationId <String>]`: The correlation Id for events associated with this protected item.
  - `[FailoverHealth <String>]`: The consolidated failover health for the VM.
  - `[FailoverRecoveryPointId <String>]`: The recovery point ARM Id to which the Vm was failed over.
  - `[FriendlyName <String>]`: The name.
  - `[HealthError <IHealthError[]>]`: List of health errors.
    - `[CreationTimeUtc <DateTime?>]`: Error creation time (UTC).
    - `[CustomerResolvability <HealthErrorCustomerResolvability?>]`: Value indicating whether the health error is customer resolvable.
    - `[EntityId <String>]`: ID of the entity.
    - `[ErrorCategory <String>]`: Category of error.
    - `[ErrorCode <String>]`: Error code.
    - `[ErrorId <String>]`: The health error unique id.
    - `[ErrorLevel <String>]`: Level of error.
    - `[ErrorMessage <String>]`: Error message.
    - `[ErrorSource <String>]`: Source of error.
    - `[ErrorType <String>]`: Type of error.
    - `[InnerHealthError <IInnerHealthError[]>]`: The inner health errors. HealthError having a list of HealthError as child errors is problematic. InnerHealthError is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as Exception -&gt; InnerException.
      - `[CreationTimeUtc <DateTime?>]`: Error creation time (UTC).
      - `[CustomerResolvability <HealthErrorCustomerResolvability?>]`: Value indicating whether the health error is customer resolvable.
      - `[EntityId <String>]`: ID of the entity.
      - `[ErrorCategory <String>]`: Category of error.
      - `[ErrorCode <String>]`: Error code.
      - `[ErrorId <String>]`: The health error unique id.
      - `[ErrorLevel <String>]`: Level of error.
      - `[ErrorMessage <String>]`: Error message.
      - `[ErrorSource <String>]`: Source of error.
      - `[ErrorType <String>]`: Type of error.
      - `[PossibleCaus <String>]`: Possible causes of error.
      - `[RecommendedAction <String>]`: Recommended action to resolve error.
      - `[RecoveryProviderErrorMessage <String>]`: DRA error message.
      - `[SummaryMessage <String>]`: Summary message of the entity.
    - `[PossibleCaus <String>]`: Possible causes of error.
    - `[RecommendedAction <String>]`: Recommended action to resolve error.
    - `[RecoveryProviderErrorMessage <String>]`: DRA error message.
    - `[SummaryMessage <String>]`: Summary message of the entity.
  - `[LastSuccessfulFailoverTime <DateTime?>]`: The Last successful failover time.
  - `[LastSuccessfulTestFailoverTime <DateTime?>]`: The Last successful test failover time.
  - `[PolicyFriendlyName <String>]`: The name of Policy governing this PE.
  - `[PolicyId <String>]`: The ID of Policy governing this PE.
  - `[PrimaryFabricFriendlyName <String>]`: The friendly name of the primary fabric.
  - `[PrimaryFabricProvider <String>]`: The fabric provider of the primary fabric.
  - `[PrimaryProtectionContainerFriendlyName <String>]`: The name of primary protection container friendly name.
  - `[ProtectableItemId <String>]`: The protected item ARM Id.
  - `[ProtectedItemType <String>]`: The type of protected item type.
  - `[ProtectionState <String>]`: The protection status.
  - `[ProtectionStateDescription <String>]`: The protection state description.
  - `[ProviderSpecificDetail <IReplicationProviderSpecificSettings>]`: The Replication provider custom settings.
    - `InstanceType <String>`: Gets the Instance type.
  - `[RecoveryContainerId <String>]`: The recovery container Id.
  - `[RecoveryFabricFriendlyName <String>]`: The friendly name of recovery fabric.
  - `[RecoveryFabricId <String>]`: The Arm Id of recovery fabric.
  - `[RecoveryProtectionContainerFriendlyName <String>]`: The name of recovery container friendly name.
  - `[RecoveryServicesProviderId <String>]`: The recovery provider ARM Id.
  - `[ReplicationHealth <String>]`: The consolidated protection health for the VM taking any issues with SRS as well as all the replication units associated with the VM's replication group into account. This is a string representation of the ProtectionHealth enumeration.
  - `[SwitchProviderState <String>]`: The switch provider state.
  - `[SwitchProviderStateDescription <String>]`: The switch provider state description.
  - `[TestFailoverState <String>]`: The Test failover state.
  - `[TestFailoverStateDescription <String>]`: The Test failover state description.

## RELATED LINKS

