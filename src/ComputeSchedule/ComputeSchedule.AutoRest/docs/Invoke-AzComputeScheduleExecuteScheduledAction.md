---
external help file:
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/invoke-azcomputescheduleexecutescheduledaction
schema: 2.0.0
---

# Invoke-AzComputeScheduleExecuteScheduledAction

## SYNOPSIS
virtualMachinesExecuteDeallocate: executeDeallocate for a virtual machine

## SYNTAX

### ExecuteExpanded (Default)
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -Correlationid <String>
 -ResourceId <String[]> [-SubscriptionId <String>] [-ExecutionParameterOptimizationPreference <String>]
 [-RetryPolicyRetryCount <Int32>] [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteExpanded1
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -Correlationid <String>
 -ResourceId <String[]> [-SubscriptionId <String>] [-ExecutionParameterOptimizationPreference <String>]
 [-RetryPolicyRetryCount <Int32>] [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteExpanded2
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -Correlationid <String>
 -ResourceId <String[]> [-SubscriptionId <String>] [-ExecutionParameterOptimizationPreference <String>]
 [-RetryPolicyRetryCount <Int32>] [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaIdentityExpanded
```
Invoke-AzComputeScheduleExecuteScheduledAction -InputObject <IComputeScheduleIdentity> -Correlationid <String>
 -ResourceId <String[]> [-ExecutionParameterOptimizationPreference <String>] [-RetryPolicyRetryCount <Int32>]
 [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ExecuteViaIdentityExpanded1
```
Invoke-AzComputeScheduleExecuteScheduledAction -InputObject <IComputeScheduleIdentity> -Correlationid <String>
 -ResourceId <String[]> [-ExecutionParameterOptimizationPreference <String>] [-RetryPolicyRetryCount <Int32>]
 [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ExecuteViaIdentityExpanded2
```
Invoke-AzComputeScheduleExecuteScheduledAction -InputObject <IComputeScheduleIdentity> -Correlationid <String>
 -ResourceId <String[]> [-ExecutionParameterOptimizationPreference <String>] [-RetryPolicyRetryCount <Int32>]
 [-RetryPolicyRetryWindowInMinute <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ExecuteViaJsonFilePath
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaJsonFilePath1
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaJsonFilePath2
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaJsonString
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaJsonString1
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ExecuteViaJsonString2
```
Invoke-AzComputeScheduleExecuteScheduledAction -Locationparameter <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
virtualMachinesExecuteDeallocate: executeDeallocate for a virtual machine

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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaIdentityExpanded, ExecuteViaIdentityExpanded1, ExecuteViaIdentityExpanded2
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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaIdentityExpanded, ExecuteViaIdentityExpanded1, ExecuteViaIdentityExpanded2
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
Parameter Sets: ExecuteViaIdentityExpanded, ExecuteViaIdentityExpanded1, ExecuteViaIdentityExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Execute operation

```yaml
Type: System.String
Parameter Sets: ExecuteViaJsonFilePath, ExecuteViaJsonFilePath1, ExecuteViaJsonFilePath2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Execute operation

```yaml
Type: System.String
Parameter Sets: ExecuteViaJsonString, ExecuteViaJsonString1, ExecuteViaJsonString2
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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaJsonFilePath, ExecuteViaJsonFilePath1, ExecuteViaJsonFilePath2, ExecuteViaJsonString, ExecuteViaJsonString1, ExecuteViaJsonString2
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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaIdentityExpanded, ExecuteViaIdentityExpanded1, ExecuteViaIdentityExpanded2
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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaIdentityExpanded, ExecuteViaIdentityExpanded1, ExecuteViaIdentityExpanded2
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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaIdentityExpanded, ExecuteViaIdentityExpanded1, ExecuteViaIdentityExpanded2
Aliases:

Required: False
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
Parameter Sets: ExecuteExpanded, ExecuteExpanded1, ExecuteExpanded2, ExecuteViaJsonFilePath, ExecuteViaJsonFilePath1, ExecuteViaJsonFilePath2, ExecuteViaJsonString, ExecuteViaJsonString1, ExecuteViaJsonString2
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

