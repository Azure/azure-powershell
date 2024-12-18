---
external help file:
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/invoke-azcomputescheduleexecutedeallocate
schema: 2.0.0
---

# Invoke-AzComputeScheduleExecuteDeallocate

## SYNOPSIS
VirtualMachinesExecuteDeallocate: Execute deallocate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.

## SYNTAX

```
Invoke-AzComputeScheduleExecuteDeallocate -Location <String> -CorrelationId <String> -ResourceId <String[]>
 [-SubscriptionId <String>] [-RetryCount <Int32>] [-RetryWindowInMinutes <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesExecuteDeallocate: Execute deallocate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.

## EXAMPLES

### Example 1: Deallocate a batch of virtual machines immediately
```powershell
Invoke-AzComputeScheduleExecuteDeallocate 
-Location "eastus2euap"
-CorrelationId "d8cae7b7-190f-4574-a793-7bffa7a1b4a8" 
-ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-0", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-1"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
-RetryCount 3
-RetryWindowInMinutes 30
```

```output
{
  Description: "Deallocate Resource request",
  Type: "VirtualMachines",
  Location: "eastus2euap",
  Results: [
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-1",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "37346960-9d1d-4b61-87be-898054870a31",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-1",
        OpType: "Deallocate",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2025-01-10T23:00:00+00:00",
        DeadlineType: "InitiateAt",
        State": "Succeeded",
        TimeZone: "UTC",
        ResourceOperationError: null,
        CompletedAt": null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 3,
          RetryWindowInMinutes: 30
        }
      }
    },
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-0",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "45346960-9d1d-4b61-87be-898054870a31",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-0",
        OpType: "Deallocate",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2025-01-10T23:00:00+00:00",
        DeadlineType: "InitiateAt",
        State: "Succeeded",
        TimeZone: "UTC",
        ResourceOperationError: null,
        CompletedAt: null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 3,
          RetryWindowInMinutes: 30
        }
      }
    }
  ]
}
```

Above command is deallocating a batch of virtual machines immediately

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

