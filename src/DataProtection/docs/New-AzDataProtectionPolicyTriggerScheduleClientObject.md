---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionpolicytriggerscheduleclientobject
schema: 2.0.0
---

# New-AzDataProtectionPolicyTriggerScheduleClientObject

## SYNOPSIS
Creates new Schedule object

## SYNTAX

```
New-AzDataProtectionPolicyTriggerScheduleClientObject -IntervalCount <Int32> -IntervalType <BackupFrequency>
 -ScheduleDays <DateTime[]> [<CommonParameters>]
```

## DESCRIPTION
Creates new Schedule object

## EXAMPLES

### Example 1: Create a daily schedule object
```powershell
PS C:\> $date = get-date
PS C:\> New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $date -IntervalType Daily -IntervalCount 1

R/2021-03-03T12:49:55+05:30/P1D
```

This command creates a daily schedule for Azure Backup Rule

### Example 2: Create an hourly schedule object
```powershell
PS C:\> $date = get-date
PS C:\> New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays $date -IntervalType Hourly -IntervalCount 4

R/2021-03-03T12:49:55+05:30/PT4H
```

This command creates an hourly scheudle for Azure Backup Rule.

## PARAMETERS

### -IntervalCount
Frequency of the backup.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IntervalType
Freuquency of the backup.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDays
Days with which backup will be scheduled.

```yaml
Type: System.DateTime[]
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

### System.String[]

## NOTES

ALIASES

## RELATED LINKS

