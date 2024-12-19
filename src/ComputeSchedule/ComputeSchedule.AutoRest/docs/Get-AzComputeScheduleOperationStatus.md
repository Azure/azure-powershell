---
external help file:
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/get-azcomputescheduleoperationstatus
schema: 2.0.0
---

# Get-AzComputeScheduleOperationStatus

## SYNOPSIS
VirtualMachinesGetOperationStatus: Polling endpoint to read status of operations performed on virtual machines

## SYNTAX

```
Get-AzComputeScheduleOperationStatus -Location <String> -CorrelationId <String> -OperationId <String[]>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesGetOperationStatus: Polling endpoint to read status of operations performed on virtual machines

## EXAMPLES

### Example 1: Poll the status of operations performed on a batch of virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Get-AzComputeScheduleOperationStatus -Location "eastus2euap" -Correlationid "bbb34b32-0ca1-473f-b53d-d06148d0d1fa" -OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" | Format-List
```

```output
ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:09:20 AM
OperationDeadline              : 12/18/2024 5:08:36 AM
OperationDeadlineType          : InitiateAt
OperationId                    : d099fda7-4fdb-4db0-98e5-53fab1821267
OperationOpType                : Start
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exesta83600
OperationState                 : Succeeded
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exesta83600
ResourceOperationErrorCode     :
ResourceOperationErrorDetail   :
RetryPolicyRetryCount          : 3
RetryPolicyRetryWindowInMinute : 30

ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:04:18 AM
OperationDeadline              : 12/18/2024 5:03:15 AM
OperationDeadlineType          : InitiateAt
OperationId                    : 333f8f97-32d0-4a88-9bf0-75e65da2052c
OperationOpType                : Hibernate
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exeHib80440
OperationState                 : Succeeded
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exeHib80440
ResourceOperationErrorCode     :
ResourceOperationErrorDetail   :
RetryPolicyRetryCount          : 3
RetryPolicyRetryWindowInMinute : 30
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls

## PARAMETERS

### -CorrelationId
CorrelationId item

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

### -Location
The location name.

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

### -OperationId
The list of operation ids to get the status of

```yaml
Type: System.String[]
Parameter Sets: (All)
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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IGetOperationStatusResponse

## NOTES

## RELATED LINKS

