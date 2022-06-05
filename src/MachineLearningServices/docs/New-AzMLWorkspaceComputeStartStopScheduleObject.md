---
external help file:
Module Name: Az.MachineLearningWorkspaces
online version: https://docs.microsoft.com/powershell/module/az.MLWorkspace/new-AzMLWorkspaceComputeStartStopScheduleObject
schema: 2.0.0
---

# New-AzMLWorkspaceComputeStartStopScheduleObject

## SYNOPSIS
Create an in-memory object for ComputeStartStopSchedule.

## SYNTAX

```
New-AzMLWorkspaceComputeStartStopScheduleObject [-Action <ComputePowerAction>] [-ScheduleId <String>]
 [-ScheduleProvisioningStatus <ScheduleProvisioningState>] [-ScheduleStatus <ScheduleStatus>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ComputeStartStopSchedule.

## EXAMPLES

### Example 1: Create an in-memory object for ComputeStartStopSchedule
```powershell
New-AzMLWorkspaceComputeStartStopScheduleObject
```

Create an in-memory object for ComputeStartStopSchedule

## PARAMETERS

### -Action
The compute power action.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Support.ComputePowerAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleId


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

### -ScheduleProvisioningStatus


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Support.ScheduleProvisioningState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStatus


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Support.ScheduleStatus
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.Api20220501.ComputeStartStopSchedule

## NOTES

ALIASES

## RELATED LINKS

