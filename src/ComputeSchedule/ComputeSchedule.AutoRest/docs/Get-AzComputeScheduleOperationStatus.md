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
Get-AzComputeScheduleOperationStatus
-Location "eastus2euap"
-Correlationid [guid]::NewGuid().ToString() 
-OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
```

```output
{
    Results: [
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "d099fda7-4fdb-4db0-98e5-53fab1821267",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine",
        OpType: "Start",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2024-12-17T22:25:02.0426307+00:00",
        DeadlineType: "InitiateAt",
        State: "Succeeded",
        TimeZone: "",
        ResourceOperationError: null,
        CompletedAt: null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 7,
          RetryWindowInMinutes: 45
        }
      }
    },
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine-1",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "333f8f97-32d0-4a88-9bf0-75e65da2052c",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine-1",
        OpType: "Start",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2024-12-17T22:25:02.0426307+00:00",
        DeadlineType: "InitiateAt",
        State: "Succeeded",
        TimeZone: "",
        ResourceOperationError: null,
        CompletedAt: null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 7,
          RetryWindowInMinutes: 45
        }
      }
    },
  ]}
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

