---
external help file: Az.ComputeSchedule-help.xml
Module Name: Az.ComputeSchedule
online version: https://learn.microsoft.com/powershell/module/az.computeschedule/get-azcomputescheduleoperationerror
schema: 2.0.0
---

# Get-AzComputeScheduleOperationError

## SYNOPSIS
VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.

## SYNTAX

```
Get-AzComputeScheduleOperationError -Location <String> [-SubscriptionId <String[]>] -OperationId <String[]>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.

## EXAMPLES

### Example 1: Gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine
```powershell
Get-AzComputeScheduleOperationError -Location "eastus2euap" -OperationId "1fd870d3-d2b7-44c8-8ccb-bec05bbbf36f","5018cb59-bc54-42c3-a6c0-a9a4b0cf3f1b" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" | Format-List
```

```output
ActivationTime     : 12/18/2024 5:08:36 AM
CompletedAt        : 12/18/2024 5:09:20 AM
CreationTime       : 12/18/2024 5:08:36 AM
OperationError     : {}
OperationId        : 1fd870d3-d2b7-44c8-8ccb-bec05bbbf36f
RequestErrorCode   :
RequestErrorDetail :

ActivationTime     : 12/18/2024 5:03:15 AM
CompletedAt        : 12/18/2024 5:04:18 AM
CreationTime       : 12/18/2024 5:03:15 AM
OperationError     : {}
OperationId        : 75018cb59-bc54-42c3-a6c0-a9a4b0cf3f1b
RequestErrorCode   :
RequestErrorDetail :
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
