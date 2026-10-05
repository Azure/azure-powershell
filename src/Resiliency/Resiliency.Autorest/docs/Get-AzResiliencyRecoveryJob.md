---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/get-azresiliencyrecoveryjob
schema: 2.0.0
---

# Get-AzResiliencyRecoveryJob

## SYNOPSIS
Get a RecoveryJob

## SYNTAX

### List (Default)
```
Get-AzResiliencyRecoveryJob -RecoveryPlanName <String> -ServiceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzResiliencyRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResiliencyRecoveryJob -InputObject <IResiliencyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityRecoveryPlan
```
Get-AzResiliencyRecoveryJob -Name <String> -RecoveryPlanInputObject <IResiliencyIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzResiliencyRecoveryJob -Name <String> -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a RecoveryJob

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The unique name (GUID) of the recovery job.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityRecoveryPlan, GetViaIdentityServiceGroup
Aliases: RecoveryJobName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: GetViaIdentityRecoveryPlan
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
Parameter Sets: Get, GetViaIdentityServiceGroup, List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: GetViaIdentityServiceGroup
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IRecoveryJob

## NOTES

## RELATED LINKS

