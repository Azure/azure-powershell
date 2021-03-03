---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/new-azdataprotectionpolicytriggerschedule
schema: 2.0.0
---

# New-AzDataProtectionPolicyTriggerSchedule

## SYNOPSIS
Creates new Schedule object

## SYNTAX

```
New-AzDataProtectionPolicyTriggerSchedule -IntervalCount <Int32> -IntervalType <BackupFrequency>
 -ScheduleDays <DateTime[]> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates new Schedule object

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
$date = get-date
PS C:\> New-AzDataProtectionPolicyTriggerSchedule -ScheduleDays $date -IntervalType Daily -IntervalCount 1
```

R/2021-03-03T12:49:55+05:30/P1D

### -------------------------- EXAMPLE 2 --------------------------
```powershell
$date = get-date
PS C:\> New-AzDataProtectionPolicyTriggerSchedule -ScheduleDays $date -IntervalType Hourly -IntervalCount 4
```

R/2021-03-03T12:49:55+05:30/PT4H

## PARAMETERS

### -IntervalCount
interval count

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
Source Datastore

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
Source Datastore

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

### System.String[]

## NOTES

ALIASES

## RELATED LINKS

