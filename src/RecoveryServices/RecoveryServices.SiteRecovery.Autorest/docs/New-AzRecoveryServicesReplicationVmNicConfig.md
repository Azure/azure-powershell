---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesreplicationvmnicconfig
schema: 2.0.0
---

# New-AzRecoveryServicesReplicationVmNicConfig

## SYNOPSIS


## SYNTAX

```
New-AzRecoveryServicesReplicationVmNicConfig -NicId <String>
 -ReplicatedProtectedItem <IReplicationProtectedItem> [-IPConfig <IIPConfigInputDetails>]
 [-RecoveryNetworkSecurityGroupId <String>] [-RecoveryNicName <String>]
 [-RecoveryNicResourceGroupName <String>] [-RecoveryVMNetworkId <String>] [-SelectionType <String>]
 [-TargetNicName <String>] [-TfoNetworkSecurityGroupId <String>] [-TfoNicName <String>]
 [-TfoNicResourceGroupName <String>] [-TfoVMNetworkId <String>] [-EnableAcceleratedNetworkingOnRecovery]
 [-EnableAcceleratedNetworkingOnTfo] [-ReuseExistingNic] [-TfoReuseExistingNic] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -EnableAcceleratedNetworkingOnRecovery


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

### -EnableAcceleratedNetworkingOnTfo


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

### -IPConfig
To construct, see NOTES section for IPCONFIG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IIPConfigInputDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicId


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

### -RecoveryNetworkSecurityGroupId


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

### -RecoveryNicName


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

### -RecoveryNicResourceGroupName


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

### -RecoveryVMNetworkId


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

### -ReuseExistingNic


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

### -SelectionType


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

### -TargetNicName


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

### -TfoNetworkSecurityGroupId


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

### -TfoNicName


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

### -TfoNicResourceGroupName


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

### -TfoReuseExistingNic


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

### -TfoVMNetworkId


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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.VMNicConfig

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`IPCONFIG <IIPConfigInputDetails>`: 
  - `[IPConfigName <String>]`: 
  - `[IsPrimary <Boolean?>]`: 
  - `[IsSeletedForFailover <Boolean?>]`: 
  - `[RecoveryLbBackendAddressPoolId <String[]>]`: 
  - `[RecoveryPublicIPAddressId <String>]`: 
  - `[RecoveryStaticIPAddress <String>]`: 
  - `[RecoverySubnetName <String>]`: 
  - `[TfoLbBackendAddressPoolId <String[]>]`: 
  - `[TfoPublicIPAddressId <String>]`: 
  - `[TfoStaticIPAddress <String>]`: 
  - `[TfoSubnetName <String>]`: 

`REPLICATEDPROTECTEDITEM <IReplicationProtectedItem>`: 
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

