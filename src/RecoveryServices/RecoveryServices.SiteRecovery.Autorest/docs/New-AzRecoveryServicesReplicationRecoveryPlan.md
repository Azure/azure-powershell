---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesreplicationrecoveryplan
schema: 2.0.0
---

# New-AzRecoveryServicesReplicationRecoveryPlan

## SYNOPSIS
The operation to create a recovery plan.

## SYNTAX

### Create (Default)
```
New-AzRecoveryServicesReplicationRecoveryPlan -RecoveryPlanName <String> -ResourceGroupName <String>
 -ResourceName <String> -Input <ICreateRecoveryPlanInput> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzRecoveryServicesReplicationRecoveryPlan -RecoveryPlanName <String> -ResourceGroupName <String>
 -ResourceName <String> -Group <IRecoveryPlanGroup[]> -PrimaryFabricId <String> -RecoveryFabricId <String>
 [-SubscriptionId <String>] [-FailoverDeploymentModel <FailoverDeploymentModel>]
 [-ProviderSpecificInput <IRecoveryPlanProviderSpecificInput[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create a recovery plan.

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

### -FailoverDeploymentModel
The failover deployment model.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.FailoverDeploymentModel
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
The recovery plan groups.
To construct, see NOTES section for GROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRecoveryPlanGroup[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Input
Create recovery plan input class.
To construct, see NOTES section for INPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ICreateRecoveryPlanInput
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -PrimaryFabricId
The primary fabric Id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderSpecificInput
The provider specific input.
To construct, see NOTES section for PROVIDERSPECIFICINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRecoveryPlanProviderSpecificInput[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryFabricId
The recovery fabric Id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlanName
Recovery plan name.

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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ICreateRecoveryPlanInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IRecoveryPlan

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


GROUP <IRecoveryPlanGroup[]>: The recovery plan groups.
  - `GroupType <RecoveryPlanGroupType>`: The group type.
  - `[EndGroupAction <IRecoveryPlanAction[]>]`: The end group actions.
    - `ActionName <String>`: The action name.
    - `CustomDetailInstanceType <String>`: Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
    - `FailoverDirection <PossibleOperationsDirections[]>`: The list of failover directions.
    - `FailoverType <ReplicationProtectedItemOperation[]>`: The list of failover types.
  - `[ReplicationProtectedItem <IRecoveryPlanProtectedItem[]>]`: The list of protected items.
    - `[Id <String>]`: The ARM Id of the recovery plan protected item.
    - `[VirtualMachineId <String>]`: The virtual machine Id.
  - `[StartGroupAction <IRecoveryPlanAction[]>]`: The start group actions.

INPUT <ICreateRecoveryPlanInput>: Create recovery plan input class.
  - `Group <IRecoveryPlanGroup[]>`: The recovery plan groups.
    - `GroupType <RecoveryPlanGroupType>`: The group type.
    - `[EndGroupAction <IRecoveryPlanAction[]>]`: The end group actions.
      - `ActionName <String>`: The action name.
      - `CustomDetailInstanceType <String>`: Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
      - `FailoverDirection <PossibleOperationsDirections[]>`: The list of failover directions.
      - `FailoverType <ReplicationProtectedItemOperation[]>`: The list of failover types.
    - `[ReplicationProtectedItem <IRecoveryPlanProtectedItem[]>]`: The list of protected items.
      - `[Id <String>]`: The ARM Id of the recovery plan protected item.
      - `[VirtualMachineId <String>]`: The virtual machine Id.
    - `[StartGroupAction <IRecoveryPlanAction[]>]`: The start group actions.
  - `PrimaryFabricId <String>`: The primary fabric Id.
  - `RecoveryFabricId <String>`: The recovery fabric Id.
  - `[FailoverDeploymentModel <FailoverDeploymentModel?>]`: The failover deployment model.
  - `[ProviderSpecificInput <IRecoveryPlanProviderSpecificInput[]>]`: The provider specific input.
    - `InstanceType <String>`: Gets the Instance type.

PROVIDERSPECIFICINPUT <IRecoveryPlanProviderSpecificInput[]>: The provider specific input.
  - `InstanceType <String>`: Gets the Instance type.

## RELATED LINKS

