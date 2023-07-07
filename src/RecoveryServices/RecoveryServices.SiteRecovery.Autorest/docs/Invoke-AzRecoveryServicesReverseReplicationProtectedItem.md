---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/switch-azrecoveryservicesreplicationprotectioncontainerprotection
schema: 2.0.0
---

# Invoke-AzRecoveryServicesReverseReplicationProtectedItem

## SYNOPSIS
Operation to switch protection from one container to another or one replication provider to another.

## SYNTAX

```
Invoke-AzRecoveryServicesReverseReplicationProtectedItem
 -ProtectionContainerMapping <IProtectionContainerMapping>
 -ReplicatedProtectedItem <IReplicationProtectedItem> -ResourceGroupName <String> -ResourceName <String>
 -LogStorageAccountId <String> -ProviderSpecificDetail <ISwitchProtectionProviderSpecificInput>
 [-SubscriptionId <String>] [-RecoveryAzureStorageAccountId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to switch protection from one container to another or one replication provider to another.

## EXAMPLES

### Example 1: Initiates reprotect to a already failover committed compute VM
```powershell
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "A2AEastUSProtectionContainer"
$protectedItem=Get-AzRecoveryServicesReplicationProtectedItem -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName "abhinavVmProtected"
$fabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
$protectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $fabric -ProtectionContainer "demoProtectionContainerA2A"
$pcmap=Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProtectionContainer $protectioncontainer -MappingName "reversemap"
$reverseInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2ASwitchProtectionInput]::new()
$reverseInput.RecoveryResourceGroupId="/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/abhinav_test"
$reverseInput.ReplicationScenario="ReplicateAzureToAzure"
Invoke-AzRecoveryServicesReverseReplicationProtectedItem -ReplicatedProtectedItem $protectedItem -ProtectionContainerMapping $pcmap -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProviderSpecificDetail $reverseInput -LogStorageAccountId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.Storage/storageAccounts/a2areversestorage"
```

```output
Id                                                                                                                                                                                                 Location Name                                 Type
--                                                                                                                                                                                                 -------- ----                                 ----
/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationJobs/fb1f7364-164d-425b-aa05-c92ba47d93f9          fb1f7364-164d-425b-aa05-c92ba47d93f9 Microsoft.RecoveryServices/vaults/replicationJobs
```

Initiates reprotect to a already failover committed compute VM

## PARAMETERS

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

### -LogStorageAccountId
Primary Staging Azure Storage Account Id.

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

### -ProtectionContainerMapping
Protection container mapping object.
To construct, see NOTES section for PROTECTIONCONTAINERMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerMapping
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderSpecificDetail
Provider specific switch protection input.
To construct, see NOTES section for PROVIDERSPECIFICDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ISwitchProtectionProviderSpecificInput
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAzureStorageAccountId
Primary Staging Azure Storage Account Id.

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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainer

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PROTECTIONCONTAINERMAPPING <IProtectionContainerMapping>`: Protection container mapping object.
  - `[Location <String>]`: Resource Location
  - `[Health <String>]`: Health of pairing.
  - `[HealthErrorDetail <IHealthError[]>]`: Health error.
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
  - `[PolicyFriendlyName <String>]`: Friendly name of replication policy.
  - `[PolicyId <String>]`: Policy ARM Id.
  - `[ProviderSpecificDetailInstanceType <String>]`: Gets the class type. Overridden in derived classes.
  - `[SourceFabricFriendlyName <String>]`: Friendly name of source fabric.
  - `[SourceProtectionContainerFriendlyName <String>]`: Friendly name of source protection container.
  - `[State <String>]`: Association Status.
  - `[TargetFabricFriendlyName <String>]`: Friendly name of target fabric.
  - `[TargetProtectionContainerFriendlyName <String>]`: Friendly name of paired container.
  - `[TargetProtectionContainerId <String>]`: Paired protection container ARM ID.

`PROVIDERSPECIFICDETAIL <ISwitchProtectionProviderSpecificInput>`: Provider specific switch protection input.
  - `ReplicationScenario <String>`: Gets the Instance type.

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

