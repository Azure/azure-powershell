---
external help file:
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
Stop-AzComputeScheduleScheduledAction -Location <String> -Correlationid <String> -OperationId <String[]>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Cancel
```
Stop-AzComputeScheduleScheduledAction -Location <String> -RequestBody <ICancelOperationsRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaIdentity
```
Stop-AzComputeScheduleScheduledAction -InputObject <IComputeScheduleIdentity>
 -RequestBody <ICancelOperationsRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CancelViaJsonFilePath
```
Stop-AzComputeScheduleScheduledAction -Location <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CancelViaJsonString
```
Stop-AzComputeScheduleScheduledAction -Location <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VirtualMachinesCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request

## EXAMPLES

### Example 1: Cancel a batch of operations scheduled on virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Stop-AzComputeScheduleScheduledAction 
-Location "eastus2euap"
-Correlationid [guid]::NewGuid().ToString() 
-OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c","48d6d537-ecb0-40d5-b54e-fb92eb3eeee5","bf56f36d-edde-43ce-95aa-03f22c3bc286"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls

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
Parameter Sets: Cancel, CancelExpanded, CancelViaJsonFilePath, CancelViaJsonString
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
Parameter Sets: Cancel, CancelExpanded, CancelViaJsonFilePath, CancelViaJsonString
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

