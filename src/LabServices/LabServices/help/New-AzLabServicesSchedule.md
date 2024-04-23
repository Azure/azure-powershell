---
external help file: Az.LabServices-help.xml
Module Name: Az.LabServices
online version: https://learn.microsoft.com/powershell/module/az.labservices/new-azlabservicesschedule
schema: 2.0.0
---

# New-AzLabServicesSchedule

## SYNOPSIS
Operation to create or update a lab schedule.

## SYNTAX

### CreateExpanded (Default)
```
New-AzLabServicesSchedule -Name <String> -LabName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Note <String>] [-RecurrencePatternExpirationDate <DateTime>]
 [-RecurrencePatternFrequency <RecurrenceFrequency>] [-RecurrencePatternInterval <Int32>]
 [-RecurrencePatternWeekDay <WeekDay[]>] [-StartAt <DateTime>] [-StopAt <DateTime>] [-TimeZoneId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Lab
```
New-AzLabServicesSchedule -Name <String> [-SubscriptionId <String>] -Lab <Lab> [-Note <String>]
 [-RecurrencePatternExpirationDate <DateTime>] [-RecurrencePatternFrequency <RecurrenceFrequency>]
 [-RecurrencePatternInterval <Int32>] [-RecurrencePatternWeekDay <WeekDay[]>] [-StartAt <DateTime>]
 [-StopAt <DateTime>] [-TimeZoneId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Operation to create or update a lab schedule.

## EXAMPLES

### Example 1: Create a new schedule in a lab.
```powershell
New-AzLabServicesSchedule `
            -ResourceGroupName "Group Name" `
            -LabName "Lab Name" `
            -Name "Schedule Name" `
            -StartAt "$((Get-Date).AddHours(5))" `
            -StopAt "$((Get-Date).AddHours(6))" `
            -RecurrencePatternFrequency 'Weekly' `
            -RecurrencePatternInterval 1 `
            -RecurrencePatternWeekDay @($((Get-Date).DayOfWeek)) `
            -RecurrencePatternExpirationDate $((Get-Date).AddDays(20)) `
            -TimeZoneId 'America/Los_Angeles'
```

```output
Name
----
Schedule Name
```

Create a weekly schedule.

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

### -Lab
To construct, see NOTES section for LAB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab
Parameter Sets: Lab
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabName
The name of the lab that uniquely identifies it within containing lab account.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the schedule that uniquely identifies it within containing lab.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ScheduleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Note
Notes for this schedule.

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

### -RecurrencePatternExpirationDate
When the recurrence will expire.
This date is inclusive.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrencePatternFrequency
The frequency of the recurrence.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.RecurrenceFrequency
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecurrencePatternInterval
The interval to invoke the schedule on.
For example, interval = 2 and RecurrenceFrequency.Daily will run every 2 days.
When no interval is supplied, an interval of 1 is used.

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

### -RecurrencePatternWeekDay
The week days the schedule runs.
Used for when the Frequency is set to Weekly.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.WeekDay[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartAt
When lab user virtual machines will be started.
Timestamp offsets will be ignored and timeZoneId is used instead.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StopAt
When lab user virtual machines will be stopped.
Timestamp offsets will be ignored and timeZoneId is used instead.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZoneId
The IANA timezone id for the schedule.

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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ISchedule

## NOTES

## RELATED LINKS
