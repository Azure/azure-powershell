---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/update-azresiliencerecoveryplan
schema: 2.0.0
---

# Update-AzResilienceRecoveryPlan

## SYNOPSIS
Update a RecoveryPlan

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzResilienceRecoveryPlan -Name <String> -ServiceGroupName <String> [-Description <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-GroupUniqueId <String>] [-OrderId <Int32>]
 [-PlanDescription <String>] [-PostAction <IRecoveryGroupBaseAction[]>]
 [-PreAction <IRecoveryGroupBaseAction[]>] [-RecoveryGroupSettingAdditionalGroup <IRecoveryGroup[]>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzResilienceRecoveryPlan -Name <String> -ServiceGroupName <String> -Resource <IRecoveryPlan>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzResilienceRecoveryPlan -InputObject <IResilienceIdentity> -Resource <IRecoveryPlan>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzResilienceRecoveryPlan -InputObject <IResilienceIdentity> [-Description <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-GroupUniqueId <String>] [-OrderId <Int32>]
 [-PlanDescription <String>] [-PostAction <IRecoveryGroupBaseAction[]>]
 [-PreAction <IRecoveryGroupBaseAction[]>] [-RecoveryGroupSettingAdditionalGroup <IRecoveryGroup[]>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityServiceGroup
```
Update-AzResilienceRecoveryPlan -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 -Resource <IRecoveryPlan> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityServiceGroupExpanded
```
Update-AzResilienceRecoveryPlan -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 [-Description <String>] [-EnableSystemAssignedIdentity <Boolean?>] [-GroupUniqueId <String>]
 [-OrderId <Int32>] [-PlanDescription <String>] [-PostAction <IRecoveryGroupBaseAction[]>]
 [-PreAction <IRecoveryGroupBaseAction[]>] [-RecoveryGroupSettingAdditionalGroup <IRecoveryGroup[]>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a RecoveryPlan

## EXAMPLES

### Example 1: Update a recovery plan
```powershell
Update-AzResilienceRecoveryPlan -Name 'rp-payments-regional' -ServiceGroupName 'azcmdlet-testing'
```

Updates the specified recovery plan, preserving properties that are not supplied.

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

### -Description
A description of the recovery orchestration group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupUniqueId
A unique id for the recovery orchestration group, which is a GUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityServiceGroup, UpdateViaIdentityServiceGroupExpanded
Aliases: RecoveryPlanName

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

### -OrderId
The order ID of the recovery orchestration group.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDescription
A description of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostAction
Post-actions for the recovery orchestration group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryGroupBaseAction[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreAction
Pre-actions for the recovery orchestration group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryGroupBaseAction[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryGroupSettingAdditionalGroup
Additional recovery orchestration group settings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryGroup[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Represents a recovery orchestration plan resource in the Azure Resilience Management provider namespace.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryPlan
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: UpdateViaIdentityServiceGroup, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryPlan

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryPlan

## NOTES

## RELATED LINKS

