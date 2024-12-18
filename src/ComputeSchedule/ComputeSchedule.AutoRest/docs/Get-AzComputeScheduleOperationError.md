---
external help file:
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/get-azcomputescheduleoperationerror
schema: 2.0.0
---

# Get-AzComputeScheduleOperationError

## SYNOPSIS
VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.

## SYNTAX

```
Get-AzComputeScheduleOperationError -Location <String> -OperationId <String[]> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.

## EXAMPLES

### Example 1: Gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine
```powershell
Get-AzComputeScheduleOperationError 
-Location "eastus2euap
-OperationId "48d6d537-ecb0-40d5-b54e-fb92eb3eeee5","bf56f36d-edde-43ce-95aa-03f22c3bc286"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
```

```output
{
  Results: [
    {
      OperationId: "48d6d537-ecb0-40d5-b54e-fb92eb3eeee5",
      CreationTime: "2024-12-17T23:53:16.1332548+00:00",
      ActivationTime: "2024-12-17T23:53:16.1272618+00:00",
      CompletedAt: "2024-12-17T23:55:10.6632969+00:00",
      OperationErrors: [],
      RequestErrorCode: null,
      RequestErrorDetails: null
    },
    {
      OperationId: "bf56f36d-edde-43ce-95aa-03f22c3bc286",
      CreationTime: "2024-12-17T23:53:16.1332548+00:00",
      ActivationTime: "2024-12-17T23:53:16.1272618+00:00",
      CompletedAt: "2024-12-17T23:55:10.6632969+00:00",
      OperationErrors: [],
      RequestErrorCode: null,
      RequestErrorDetails: null
    },
  ]
}
```

The above command gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine

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
The list of operation ids to query errors of

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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Models.IGetOperationErrorsResponse

## NOTES

## RELATED LINKS

