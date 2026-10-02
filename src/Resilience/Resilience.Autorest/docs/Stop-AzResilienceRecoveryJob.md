---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/stop-azresiliencerecoveryjob
schema: 2.0.0
---

# Stop-AzResilienceRecoveryJob

## SYNOPSIS
This action attempts to cancel the ongoing recovery orchestration job.

## SYNTAX

### CancelExpanded (Default)
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Cancel
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -Body <IRecoveryActionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaIdentity
```
Stop-AzResilienceRecoveryJob -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IRecoveryActionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CancelViaIdentityExpanded
```
Stop-AzResilienceRecoveryJob -InputObject <IResilienceIdentity> -OperationId <String> [-Description <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaIdentityRecoveryPlan
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanInputObject <IResilienceIdentity>
 -OperationId <String> -Body <IRecoveryActionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaIdentityRecoveryPlanExpanded
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanInputObject <IResilienceIdentity>
 -OperationId <String> [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CancelViaIdentityServiceGroup
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> -Body <IRecoveryActionRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaIdentityServiceGroupExpanded
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -OperationId <String> [-Description <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaJsonFilePath
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CancelViaJsonString
```
Stop-AzResilienceRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 -OperationId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This action attempts to cancel the ongoing recovery orchestration job.

## EXAMPLES

### Example 1: Stop a recovery job
```powershell
Stop-AzResilienceRecoveryJob `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Stops the running recovery job and records the attestation outcome.

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

### -Body
Request body for providing user input for a recovery action.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryActionRequest
Parameter Sets: Cancel, CancelViaIdentity, CancelViaIdentityRecoveryPlan, CancelViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
User-provided input for the action.

```yaml
Type: System.String
Parameter Sets: CancelExpanded, CancelViaIdentityExpanded, CancelViaIdentityRecoveryPlanExpanded, CancelViaIdentityServiceGroupExpanded
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
Parameter Sets: CancelViaIdentity, CancelViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Cancel operation

```yaml
Type: System.String
Parameter Sets: CancelViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Cancel operation

```yaml
Type: System.String
Parameter Sets: CancelViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The unique name (GUID) of the recovery job.

```yaml
Type: System.String
Parameter Sets: Cancel, CancelExpanded, CancelViaIdentityRecoveryPlan, CancelViaIdentityRecoveryPlanExpanded, CancelViaIdentityServiceGroup, CancelViaIdentityServiceGroupExpanded, CancelViaJsonFilePath, CancelViaJsonString
Aliases: RecoveryJobName

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

### -OperationId
A GUID that represents the Long Running OperationId.

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

### -RecoveryPlanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CancelViaIdentityRecoveryPlan, CancelViaIdentityRecoveryPlanExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecoveryPlanName
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: Cancel, CancelExpanded, CancelViaIdentityServiceGroup, CancelViaIdentityServiceGroupExpanded, CancelViaJsonFilePath, CancelViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CancelViaIdentityServiceGroup, CancelViaIdentityServiceGroupExpanded
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
Parameter Sets: Cancel, CancelExpanded, CancelViaJsonFilePath, CancelViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecoveryActionRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IErrorResponse

## NOTES

## RELATED LINKS

