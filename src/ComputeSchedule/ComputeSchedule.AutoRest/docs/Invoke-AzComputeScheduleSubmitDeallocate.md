---
external help file:
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/invoke-azcomputeschedulesubmitdeallocate
schema: 2.0.0
---

# Invoke-AzComputeScheduleSubmitDeallocate

## SYNOPSIS
VirtualMachinesSubmitDeallocate: Schedule deallocate operation for a batch of virtual machines at datetime in future.

## SYNTAX

```
Invoke-AzComputeScheduleSubmitDeallocate -Location <String> -CorrelationId <String> -DeadlineType <String>
 -ResourceId <String[]> [-SubscriptionId <String>] [-Deadline <DateTime>] [-RetryCount <Int32>]
 [-RetryWindowInMinutes <Int32>] [-Timezone <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesSubmitDeallocate: Schedule deallocate operation for a batch of virtual machines at datetime in future.

## EXAMPLES

### Example 1: Deallocate a batch of virtual machines at the given deadline
```powershell
Invoke-AzComputeScheduleSubmitDeallocate -Location "eastus2euap" -CorrelationId "abb9b6a2-013a-4ad7-af2c-efd2449e6600" -DeadlineType "InitiateAt" -ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85543", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85762" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" -Deadline 2025-01-10T23:00:00 -RetryCount 2 -RetryWindowInMinutes 30 -Timezone "UTC" | Format-List
```

```output
Description : Deallocate Resource request
Location    : eastus2euap
Result      : {{
                "operation": {
                  "retryPolicy": {
                    "retryCount": 2,
                    "retryWindowInMinutes": 30
                  },
                  "operationId": "7eebe846-f687-463d-aa68-3c7485ce28a3",
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85762",
                  "opType": "Deallocate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85762"
              }}
Type        : VirtualMachines

Description : Deallocate Resource request
Location    : eastus2euap
Result      : {{
                "operation": {
                  "retryPolicy": {
                    "retryCount": 2,
                    "retryWindowInMinutes": 30
                  },
                  "operationId": "7eebe846-f687-463d-aa68-3c7485ce28a3",
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85543",
                  "opType": "Deallocate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85543"
              }}
Type        : VirtualMachines
```

The above command is scheduling a deallocate operation on a batch of virtual machines by the given deadline.
The list below describes guidance on Deadline and Timezone:
- Computeschedule supports "UTC" timezone currently
- Deadline for a submit type operation can not be more than 5 minutes in the past or greater than 14 days in the future

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

### -Deadline
The deadline for the operation

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadlineType
The deadlinetype of the operation, this can either be InitiateAt or CompleteBy

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

### -ResourceId
The resource ids used for the request

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

### -RetryCount
Retry count for user request

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryWindowInMinutes
Retry window in minutes for user request

```yaml
Type: System.Int32
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timezone
The timezone for the operation

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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IDeallocateResourceOperationResponse

## NOTES

## RELATED LINKS

