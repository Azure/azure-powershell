---
external help file:
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/submit-azcomputeschedulescheduledaction
schema: 2.0.0
---

# Submit-AzComputeScheduleScheduledAction

## SYNOPSIS
virtualMachinesSubmitDeallocate: submitDeallocate for a virtual machine

## SYNTAX

### SubmitExpanded (Default)
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -Correlationid <String>
 -ResourceId <String[]> -ScheduleDeadLine <DateTime> -ScheduleDeadlineType <String> -ScheduleTimeZone <String>
 [-SubscriptionId <String>] [-ExecutionParameterOptimizationPreference <String>]
 [-RetryPolicyRetryCount <Int32>] [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitExpanded1
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -Correlationid <String>
 -ResourceId <String[]> -ScheduleDeadLine <DateTime> -ScheduleDeadlineType <String> -ScheduleTimeZone <String>
 [-SubscriptionId <String>] [-ExecutionParameterOptimizationPreference <String>]
 [-RetryPolicyRetryCount <Int32>] [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitExpanded2
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -Correlationid <String>
 -ResourceId <String[]> -ScheduleDeadLine <DateTime> -ScheduleDeadlineType <String> -ScheduleTimeZone <String>
 [-SubscriptionId <String>] [-ExecutionParameterOptimizationPreference <String>]
 [-RetryPolicyRetryCount <Int32>] [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitViaIdentityExpanded
```
Submit-AzComputeScheduleScheduledAction -InputObject <IComputeScheduleIdentity> -Correlationid <String>
 -ResourceId <String[]> -ScheduleDeadLine <DateTime> -ScheduleDeadlineType <String> -ScheduleTimeZone <String>
 [-ExecutionParameterOptimizationPreference <String>] [-RetryPolicyRetryCount <Int32>]
 [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SubmitViaIdentityExpanded1
```
Submit-AzComputeScheduleScheduledAction -InputObject <IComputeScheduleIdentity> -Correlationid <String>
 -ResourceId <String[]> -ScheduleDeadLine <DateTime> -ScheduleDeadlineType <String> -ScheduleTimeZone <String>
 [-ExecutionParameterOptimizationPreference <String>] [-RetryPolicyRetryCount <Int32>]
 [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SubmitViaIdentityExpanded2
```
Submit-AzComputeScheduleScheduledAction -InputObject <IComputeScheduleIdentity> -Correlationid <String>
 -ResourceId <String[]> -ScheduleDeadLine <DateTime> -ScheduleDeadlineType <String> -ScheduleTimeZone <String>
 [-ExecutionParameterOptimizationPreference <String>] [-RetryPolicyRetryCount <Int32>]
 [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SubmitViaJsonFilePath
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitViaJsonFilePath1
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitViaJsonFilePath2
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitViaJsonString
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitViaJsonString1
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SubmitViaJsonString2
```
Submit-AzComputeScheduleScheduledAction -Locationparameter <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
virtualMachinesSubmitDeallocate: submitDeallocate for a virtual machine

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

### -Correlationid
CorrelationId item

```yaml
Type: System.String
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: True
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

### -ExecutionParameterOptimizationPreference
Details that could optimize the user's request

```yaml
Type: System.String
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IComputeScheduleIdentity
Parameter Sets: SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Submit operation

```yaml
Type: System.String
Parameter Sets: SubmitViaJsonFilePath, SubmitViaJsonFilePath1, SubmitViaJsonFilePath2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Submit operation

```yaml
Type: System.String
Parameter Sets: SubmitViaJsonString, SubmitViaJsonString1, SubmitViaJsonString2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Locationparameter
The location name.

```yaml
Type: System.String
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaJsonFilePath, SubmitViaJsonFilePath1, SubmitViaJsonFilePath2, SubmitViaJsonString, SubmitViaJsonString1, SubmitViaJsonString2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ids used for the request

```yaml
Type: System.String[]
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyRetryCount
Retry count for user request

```yaml
Type: System.Int32
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyRetryWindowInMinute
Retry window in minutes for user request

```yaml
Type: System.Int32
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDeadLine
The deadline for the operation

```yaml
Type: System.DateTime
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDeadlineType
The deadlinetype of the operation, this can either be InitiateAt or CompleteBy

```yaml
Type: System.String
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTimeZone
The timezone for the operation

```yaml
Type: System.String
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaIdentityExpanded, SubmitViaIdentityExpanded1, SubmitViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: SubmitExpanded, SubmitExpanded1, SubmitExpanded2, SubmitViaJsonFilePath, SubmitViaJsonFilePath1, SubmitViaJsonFilePath2, SubmitViaJsonString, SubmitViaJsonString1, SubmitViaJsonString2
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IComputeScheduleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IDeallocateResourceOperationResponse

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IHibernateResourceOperationResponse

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IStartResourceOperationResponse

## NOTES

## RELATED LINKS

