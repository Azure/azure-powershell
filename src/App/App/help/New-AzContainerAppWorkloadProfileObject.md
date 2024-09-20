---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappworkloadprofileobject
schema: 2.0.0
---

# New-AzContainerAppWorkloadProfileObject

## SYNOPSIS
Create an in-memory object for WorkloadProfile.

## SYNTAX

```
New-AzContainerAppWorkloadProfileObject -Name <String> -Type <String> [-MaximumCount <Int32>]
 [-MinimumCount <Int32>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WorkloadProfile.

## EXAMPLES

### Example 1: Create an in-memory object for WorkloadProfile.
```powershell
New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"
```

```output
MaximumCount MinimumCount Name
------------ ------------ ----
                          Consumption
```

Create an in-memory object for WorkloadProfile.

## PARAMETERS

### -MaximumCount
The maximum capacity.

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

### -MinimumCount
The minimum capacity.

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

### -Name
Workload profile type for the workloads to run on.

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

### -Type
Workload profile type for the workloads to run on.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.WorkloadProfile

## NOTES

## RELATED LINKS
