---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/update-azdataprotectionpolicytag
schema: 2.0.0
---

# Update-AzDataProtectionPolicyTag

## SYNOPSIS
Prepares Datasource object for backup

## SYNTAX

### RemoveTag (Default)
```
Update-AzDataProtectionPolicyTag -Name <String> -Policy <IBackupPolicy> -RemoveRule [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### updateTag
```
Update-AzDataProtectionPolicyTag -Criteria <IScheduleBasedBackupCriteria[]> -Name <String>
 -Policy <IBackupPolicy> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Prepares Datasource object for backup

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Criteria
Datasource Type
To construct, see NOTES section for CRITERIA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IScheduleBasedBackupCriteria[]
Parameter Sets: updateTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Datasource Type

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

### -Policy
Datasource Type
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveRule
Datasource Type

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveTag
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CRITERIA <IScheduleBasedBackupCriteria[]>: Datasource Type
  - `ObjectType <String>`: Type of the specific object - used for deserializing
  - `[AbsoluteCriterion <AbsoluteMarker[]>]`: it contains absolute values like "AllBackup" / "FirstOfDay" / "FirstOfWeek" / "FirstOfMonth"         and should be part of AbsoluteMarker enum
  - `[DaysOfMonth <IDay[]>]`: This is day of the month from 1 to 28 other wise last of month
    - `[Date <Int32?>]`: Date of the month
    - `[IsLast <Boolean?>]`: Whether Date is last date of month
  - `[DaysOfTheWeek <DayOfWeek[]>]`: It should be Sunday/Monday/T..../Saturday
  - `[MonthsOfYear <Month[]>]`: It should be January/February/....../December
  - `[ScheduleTime <DateTime[]>]`: List of schedule times for backup
  - `[WeeksOfTheMonth <WeekNumber[]>]`: It should be Fisrt/Second/Third/Fourth/Last

POLICY <IBackupPolicy>: Datasource Type
  - `DatasourceType <String[]>`: Type of datasource for the backup management
  - `ObjectType <String>`: 
  - `PolicyRule <IBasePolicyRule[]>`: Policy rule dictionary that contains rules for each backptype i.e Full/Incremental/Logs etc
    - `Name <String>`: 
    - `ObjectType <String>`: 
    - `BackupParameterObjectType <String>`: Type of the specific object - used for deserializing
    - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `DataStoreType <DataStoreTypes>`: type of datastore; SnapShot/Hot/Archive
    - `TriggerObjectType <String>`: Type of the specific object - used for deserializing
    - `Lifecycle <ISourceLifeCycle[]>`: 
      - `DeleteAfterDuration <String>`: Duration of deletion after given timespan
      - `DeleteAfterObjectType <String>`: Type of the specific object - used for deserializing
      - `SourceDataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
      - `SourceDataStoreType <DataStoreTypes>`: type of datastore; SnapShot/Hot/Archive
      - `[TargetDataStoreCopySetting <ITargetCopySetting[]>]`: 
        - `CopyAfterObjectType <String>`: Type of the specific object - used for deserializing
        - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
        - `DataStoreType <DataStoreTypes>`: type of datastore; SnapShot/Hot/Archive
    - `[IsDefault <Boolean?>]`: 

## RELATED LINKS

