---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionpolicytagcriteriaclientobject
schema: 2.0.0
---

# New-AzDataProtectionPolicyTagCriteriaClientObject

## SYNOPSIS
Creates a new criteria object

## SYNTAX

### ScheduleCriteria (Default)
```
New-AzDataProtectionPolicyTagCriteriaClientObject [-DaysOfWeek <DaysOfWeek[]>]
 [-MonthsOfYear <MonthsOfYear[]>] [-ScheduleTimes <DateTime[]>] [-WeeksOfMonth <WeeksOfMonth[]>]
 [<CommonParameters>]
```

### AbsoluteCriteria
```
New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria <AbsoluteTagCriteria> [<CommonParameters>]
```

### MonthlyCriteria
```
New-AzDataProtectionPolicyTagCriteriaClientObject -DaysOfMonth <String[]> [-MonthsOfYear <MonthsOfYear[]>]
 [-ScheduleTimes <DateTime[]>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new criteria object

## EXAMPLES

### Example 1: Create a tag with absolute criteria 
```powershell
New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfDay
```

```output
ObjectType                  AbsoluteCriterion DaysOfTheWeek MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- ------------- ------------ ------------ ---------------
ScheduleBasedBackupCriteria {FirstOfDay}
```

This command creates a criteria object with absolute criteria.

### Example 2: create a tag with weekly criteria
```powershell
New-AzDataProtectionPolicyTagCriteriaClientObject -DaysOfWeek @("Sunday", "Monday")
```

```output
ObjectType                  AbsoluteCriterion DaysOfTheWeek    MonthsOfYear ScheduleTime WeeksOfTheMonth
----------                  ----------------- -------------    ------------ ------------ ---------------
ScheduleBasedBackupCriteria                   {Sunday, Monday}
```

This command creates a critetia object with weekly criteria

## PARAMETERS

### -AbsoluteCriteria
Absolute criteria

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
Days of the month.
Allowed values are 1 to 28 and Last

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
Days of the week

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
Months of the year.

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
Schedule times.

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
Weeks of the month.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IScheduleBasedBackupCriteria

## NOTES

ALIASES

## RELATED LINKS

