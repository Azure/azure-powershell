---
external help file: Microsoft.Azure.Commands.ResourceManager.Automation.dll-Help.xml
Module Name: AzureRM.Automation
ms.assetid: CB621890-EF8A-4F14-8F18-D8806E624DAB
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.automation/new-azurermautomationschedule
schema: 2.0.0
---

# New-AzureRmAutomationSchedule

## SYNOPSIS
Creates an Automation schedule.

## SYNTAX

### ByDaily (Default)
```
New-AzureRmAutomationSchedule [-Name] <String> [-StartTime] <DateTimeOffset> [-Description <String>]
 [-ExpiryTime <DateTimeOffset>] -DayInterval <Byte> [-TimeZone <String>] [-ResourceGroupName] <String>
 [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByWeekly
```
New-AzureRmAutomationSchedule [-Name] <String> [-StartTime] <DateTimeOffset> [-Description <String>]
 [-DaysOfWeek <DayOfWeek[]>] [-ExpiryTime <DateTimeOffset>] -WeekInterval <Byte> [-TimeZone <String>]
 [-ResourceGroupName] <String> [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByMonthlyDaysOfMonth
```
New-AzureRmAutomationSchedule [-Name] <String> [-StartTime] <DateTimeOffset> [-Description <String>]
 [-DaysOfMonth <DaysOfMonth[]>] [-ExpiryTime <DateTimeOffset>] -MonthInterval <Byte> [-TimeZone <String>]
 [-ResourceGroupName] <String> [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByMonthlyDayOfWeek
```
New-AzureRmAutomationSchedule [-Name] <String> [-StartTime] <DateTimeOffset> [-Description <String>]
 [-DayOfWeek <DayOfWeek>] [-DayOfWeekOccurrence <DayOfWeekOccurrence>] [-ExpiryTime <DateTimeOffset>]
 -MonthInterval <Byte> [-TimeZone <String>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByOneTime
```
New-AzureRmAutomationSchedule [-Name] <String> [-StartTime] <DateTimeOffset> [-Description <String>] [-OneTime]
 [-TimeZone <String>] [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByHourly
```
New-AzureRmAutomationSchedule [-Name] <String> [-StartTime] <DateTimeOffset> [-Description <String>]
 [-ExpiryTime <DateTimeOffset>] -HourInterval <Byte> [-TimeZone <String>] [-ResourceGroupName] <String>
 [-AutomationAccountName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmAutomationSchedule** cmdlet creates a schedule in Azure Automation.

## EXAMPLES

### Example 1: Create a one-time schedule in local time
```
PS C:\>$TimeZone = ([System.TimeZoneInfo]::Local)Id
PS C:\> New-AzureRmAutomationSchedule -AutomationAccountName "Contoso17" -Name "Schedule01" -StartTime "23:00" -OneTime -ResourceGroupName "ResourceGroup01" -TimeZone $TimeZone
```

The first command gets the time zone ID from the system and stores it in the $TimeZone variable.
The second command creates a schedule that runs one time on the current date at 11:00 PM in the specified time zone..

### Example 2: Create a recurring schedule
```
PS C:\>$StartTime = Get-Date "13:00:00"
PS C:\> $EndTime = $StartTime.AddYears(1)
PS C:\> New-AzureRmAutomationSchedule -AutomationAccountName "Contoso17" -Name "Schedule02" -StartTime $StartTime -ExpiryTime $EndTime -DailyInterval 1 -ResourceGroupName "ResourceGroup01"
```

The first command creates a date object by using the **Get-Date** cmdlet, and then stores the object in the $StartDate variable.
Specify a time that is at least five minutes in the future.

The second command creates a date object by using the **Get-Date** cmdlet, and then stores the object in the $EndDate variable.
The command specifies a future time.

The final command creates a daily schedule named Schedule01 to begin at the time stored in $StartDate and expire at the time stored in $EndDate.

## PARAMETERS

### -AutomationAccountName
Specifies the name of an Automation account for which this cmdlet creates a schedule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DayInterval
Specifies an interval, in days, for the schedule.
If you do not specify this parameter, and you do not specify the *OneTime* parameter, the default value is one (1).

```yaml
Type: Byte
Parameter Sets: ByDaily
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DayOfWeek
Specifies a list of days of the week for the weekly schedule.

```yaml
Type: DayOfWeek
Parameter Sets: ByMonthlyDayOfWeek
Aliases: 
Accepted values: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DayOfWeekOccurrence
Specifies the occurrence of the week within the month that the schedule runs.
psdx_paramvalues

- 1
- 2
- 3
- 4
- -1
- First
- Second
- Third
- Fourth
- LastDay

```yaml
Type: DayOfWeekOccurrence
Parameter Sets: ByMonthlyDayOfWeek
Aliases: 
Accepted values: First, Second, Third, Fourth, Last

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysOfMonth
Specifies a list of days of the month for the monthly schedule.

```yaml
Type: DaysOfMonth[]
Parameter Sets: ByMonthlyDaysOfMonth
Aliases: 
Accepted values: One, Two, Three, Four, Five, Six, Seventh, Eighth, Ninth, Tenth, Eleventh, Twelfth, Thirteenth, Fourteenth, Fifteenth, Sixteenth, Seventeenth, Eighteenth, Nineteenth, Twentieth, TwentyFirst, TwentySecond, TwentyThird, TwentyFourth, TwentyFifth, TwentySixth, TwentySeventh, TwentyEighth, TwentyNinth, Thirtieth, ThirtyFirst, LastDay

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysOfWeek
Specifies a list of days of the week for the weekly schedule.

```yaml
Type: DayOfWeek[]
Parameter Sets: ByWeekly
Aliases: 
Accepted values: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Specifies a description for the schedule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpiryTime
Specifies the expiry time of a schedule as a **DateTimeOffest** object.
You can specify a string that can be converted to a valid **DateTimeOffset**.

```yaml
Type: DateTimeOffset
Parameter Sets: ByDaily, ByWeekly, ByMonthlyDaysOfMonth, ByMonthlyDayOfWeek, ByHourly
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HourInterval
Specifies an interval, in hours, for the schedule.

```yaml
Type: Byte
Parameter Sets: ByHourly
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonthInterval
Specifies an interval, in Months, for the schedule.

```yaml
Type: Byte
Parameter Sets: ByMonthlyDaysOfMonth, ByMonthlyDayOfWeek
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies a name for the schedule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OneTime
Specifies that the cmdlet creates a one-time schedule.

```yaml
Type: SwitchParameter
Parameter Sets: ByOneTime
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group for which this cmdlet creates a schedule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartTime
Specifies the start time of a schedule as a **DateTimeOffset** object.
You can specify a string that can be converted to a valid **DateTimeOffset**.
. If the *TimeZone* parameter is specified, the offset will be ignored and the time zone specified is used.

```yaml
Type: DateTimeOffset
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TimeZone
Specifies the time zone for the schedule.
This string can be the IANA ID or the Windows Time Zone ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WeekInterval
Specifies an interval, in weeks, for the schedule.

```yaml
Type: Byte
Parameter Sets: ByWeekly
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.Schedule

## NOTES

## RELATED LINKS

[Get-AzureRmAutomationSchedule](./Get-AzureRMAutomationSchedule.md)

[Remove-AzureRmAutomationSchedule](./Remove-AzureRMAutomationSchedule.md)

[Set-AzureRmAutomationSchedule](./Set-AzureRMAutomationSchedule.md)


