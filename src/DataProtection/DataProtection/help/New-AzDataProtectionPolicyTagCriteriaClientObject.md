---
external help file: Az.DataProtection-help.xml
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
New-AzDataProtectionPolicyTagCriteriaClientObject [-DaysOfWeek <DaysOfWeek[]>] [-WeeksOfMonth <WeeksOfMonth[]>]
 [-MonthsOfYear <MonthsOfYear[]>] [-ScheduleTimes <DateTime[]>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### AbsoluteCriteria
```
New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria <AbsoluteTagCriteria>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### MonthlyCriteria
```
New-AzDataProtectionPolicyTagCriteriaClientObject [-MonthsOfYear <MonthsOfYear[]>]
 [-ScheduleTimes <DateTime[]>] -DaysOfMonth <String[]> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
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
Accepted values: AllBackup, FirstOfDay, FirstOfMonth, FirstOfWeek, FirstOfYear

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
Accepted values: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday

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
Parameter Sets: ScheduleCriteria, MonthlyCriteria
Aliases:
Accepted values: January, February, March, April, May, June, July, August, September, October, November, December

Required: False
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

### -ScheduleTimes
Schedule times.

```yaml
Type: System.DateTime[]
Parameter Sets: ScheduleCriteria, MonthlyCriteria
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
Accepted values: First, Second, Third, Fourth, Last

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IScheduleBasedBackupCriteria

## NOTES

## RELATED LINKS
