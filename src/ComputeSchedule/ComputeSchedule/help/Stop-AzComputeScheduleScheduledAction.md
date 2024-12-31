---
external help file: Az.ComputeSchedule-help.xml
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/stop-azcomputeschedulescheduledaction
schema: 2.0.0
---

# Stop-AzComputeScheduleScheduledAction

## SYNOPSIS
VirtualMachinesCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request

## SYNTAX

### CancelExpanded (Default)
```
Stop-AzComputeScheduleScheduledAction -Location <String> [-SubscriptionId <String>] -Correlationid <String>
 -OperationId <String[]> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CancelViaJsonString
```
Stop-AzComputeScheduleScheduledAction -Location <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelViaJsonFilePath
```
Stop-AzComputeScheduleScheduledAction -Location <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Cancel
```
Stop-AzComputeScheduleScheduledAction -Location <String> [-SubscriptionId <String>]
 -RequestBody <ICancelOperationsRequest> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelViaIdentity
```
Stop-AzComputeScheduleScheduledAction -InputObject <IComputeScheduleIdentity>
 -RequestBody <ICancelOperationsRequest> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request

## EXAMPLES

### Example 1: Cancel a batch of operations scheduled on virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Stop-AzComputeScheduleScheduledAction -Location "eastus2euap" -Correlationid "9992a233-8f42-4e7c-8b5a-71eea1a0ead2" -OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" | Format-List
```

```output
ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:36:18 PM
OperationDeadline              : 12/25/2024 11:00:00 PM
OperationDeadlineType          : InitiateAt
OperationId                    : d099fda7-4fdb-4db0-98e5-53fab1821267
OperationOpType                : Hibernate
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85155
OperationState                 : Cancelled
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85155
ResourceOperationErrorCode     : OperationCancelledByUser
ResourceOperationErrorDetail   : Operation: d099fda7-4fdb-4db0-98e5-53fab1821267 was cancelled by the user.
RetryPolicyRetryCount          : 2
RetryPolicyRetryWindowInMinute : 30

ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:36:18 PM
OperationDeadline              : 12/25/2024 11:00:00 PM
OperationDeadlineType          : InitiateAt
OperationId                    : 333f8f97-32d0-4a88-9bf0-75e65da2052c
OperationOpType                : Hibernate
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85152
OperationState                 : Cancelled
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85152
ResourceOperationErrorCode     : OperationCancelledByUser
ResourceOperationErrorDetail   : Operation: 333f8f97-32d0-4a88-9bf0-75e65da2052c was cancelled by the user.
RetryPolicyRetryCount          : 2
RetryPolicyRetryWindowInMinute : 30
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls.

## PARAMETERS

### -Correlationid
CorrelationId item

```yaml
Type: System.String
Parameter Sets: CancelExpanded
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IComputeScheduleIdentity
Parameter Sets: CancelViaIdentity
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

### -Location
The location name.

```yaml
Type: System.String
Parameter Sets: CancelExpanded, CancelViaJsonString, CancelViaJsonFilePath, Cancel
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationId
The list of operation ids to cancel operations on

```yaml
Type: System.String[]
Parameter Sets: CancelExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestBody
This is the request to cancel running operations in scheduled actions using the operation ids

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.ICancelOperationsRequest
Parameter Sets: Cancel, CancelViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CancelExpanded, CancelViaJsonString, CancelViaJsonFilePath, Cancel
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.ICancelOperationsRequest

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IComputeScheduleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.ICancelOperationsResponse

## NOTES

## RELATED LINKS
