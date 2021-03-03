---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/new-azdataprotectionpolicytagcriteria
schema: 2.0.0
---

# New-AzDataProtectionPolicyTagCriteria

## SYNOPSIS
Prepares Datasource object for backup

## SYNTAX

### ScheduleCriteria (Default)
```
New-AzDataProtectionPolicyTagCriteria [-DaysOfWeek <DaysOfWeek[]>] [-MonthsOfYear <MonthsOfYear[]>]
 [-ScheduleTimes <DateTime[]>] [-WeeksOfMonth <WeeksOfMonth[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AbsoluteCriteria
```
New-AzDataProtectionPolicyTagCriteria -AbsoluteCriteria <AbsoluteTagCriteria> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### MonthlyCriteria
```
New-AzDataProtectionPolicyTagCriteria -DaysOfMonth <String[]> [-MonthsOfYear <MonthsOfYear[]>]
 [-ScheduleTimes <DateTime[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Prepares Datasource object for backup

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
New-AzDataProtectionPolicyTagCriteria -AbsoluteCriteria FirstOfDay
```

ObjectType                  AbsoluteCriterion DaysOfTheWeek MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- ------------- ------------ ------------ ---------------
ScheduleBasedBackupCriteria {FirstOfDay}

### -------------------------- EXAMPLE 2 --------------------------
```powershell
New-AzDataProtectionPolicyTagCriteria -DaysOfWeek @("Sunday", "Monday")
```

ObjectType                  AbsoluteCriterion DaysOfTheWeek    MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- -------------    ------------ ------------ ---------------
ScheduleBasedBackupCriteria                   {Sunday, Monday}

## PARAMETERS

### -AbsoluteCriteria
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteTagCriteria
Parameter Sets: AbsoluteCriteria
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysOfMonth
Datasource Type

```yaml
Type: System.String[]
Parameter Sets: MonthlyCriteria
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysOfWeek
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DaysOfWeek[]
Parameter Sets: ScheduleCriteria
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonthsOfYear
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.MonthsOfYear[]
Parameter Sets: MonthlyCriteria, ScheduleCriteria
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTimes
Datasource Type

```yaml
Type: System.DateTime[]
Parameter Sets: MonthlyCriteria, ScheduleCriteria
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WeeksOfMonth
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeeksOfMonth[]
Parameter Sets: ScheduleCriteria
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IScheduleBasedBackupCriteria

## NOTES

ALIASES

## RELATED LINKS

