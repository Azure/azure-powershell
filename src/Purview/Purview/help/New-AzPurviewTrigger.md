---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.purview/new-azpurviewtrigger
schema: 2.0.0
---

# New-AzPurviewTrigger

## SYNOPSIS
Creates an instance of a trigger

## SYNTAX

```
New-AzPurviewTrigger -Endpoint <String> -DataSourceName <String> -ScanName <String> -Body <ITrigger>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates an instance of a trigger

## EXAMPLES

### Example 1: Create trigger schedule for scan run
```powershell
PS C:\> $obj = New-AzPurviewTriggerObject -RecurrenceEndTime '7/20/2022 12:00:00 AM' -RecurrenceStartTime '2/17/2022 1:32:00 PM' -Interval 1 -RecurrenceFrequency 'Month' -ScanLevel 'Full' -ScheduleHour $(9) -ScheduleMinute $(0) -ScheduleMonthDay $(10)
New-AzPurviewTrigger -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan-6HK' -Body $obj

CreatedAt                  : 2/17/2022 1:35:12 PM
Id                         : datasources/DataScanTestData-Parv/scans/Scan-6HK/triggers/default
IncrementalScanStartTime   :
Interval                   : 1
LastModifiedAt             : 2/17/2022 1:46:22 PM
LastScheduled              :
Name                       : default
RecurrenceEndTime          : 7/20/2022 12:00:00 AM
RecurrenceFrequency        : Month
RecurrenceInterval         :
RecurrenceStartTime        : 2/17/2022 1:32:00 PM
RecurrenceTimeZone         :
ResourceGroupName          :
ScanLevel                  : Full
ScheduleAdditionalProperty : {
                             }
ScheduleHour               : {9}
ScheduleMinute             : {0}
ScheduleMonthDay           : {10}
ScheduleMonthlyOccurrence  :
ScheduleWeekDay            :
```

Create trigger for a full scan starting 02/17/22 1:31 PM UTC and ending 7/20/2022 12:00:00 AM, occuring every 1 month, on 10th of the month, at 09:00 AM UTC

## PARAMETERS

### -Body
.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.ITrigger
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DataSourceName
.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

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

### -ScanName
.

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.ITrigger

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.ITrigger

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <ITrigger>: .
  - `[IncrementalScanStartTime <DateTime?>]`: 
  - `[Interval <Int32?>]`: 
  - `[RecurrenceEndTime <DateTime?>]`: 
  - `[RecurrenceFrequency <TriggerFrequency?>]`: 
  - `[RecurrenceInterval <String>]`: 
  - `[RecurrenceStartTime <DateTime?>]`: 
  - `[RecurrenceTimeZone <String>]`: 
  - `[ScanLevel <ScanLevelType?>]`: 
  - `[ScheduleAdditionalProperty <IRecurrenceScheduleAdditionalProperties>]`: Dictionary of <any>
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ScheduleHour <Int32[]>]`: 
  - `[ScheduleMinute <Int32[]>]`: 
  - `[ScheduleMonthDay <Int32[]>]`: 
  - `[ScheduleMonthlyOccurrence <IRecurrenceScheduleOccurrence[]>]`: 
    - `[AdditionalProperty <IRecurrenceScheduleOccurrenceAdditionalProperties>]`: Dictionary of <any>
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Day <DayOfWeek?>]`: 
    - `[Occurrence <Int32?>]`: 
  - `[ScheduleWeekDay <DaysOfWeek[]>]`: 

## RELATED LINKS
