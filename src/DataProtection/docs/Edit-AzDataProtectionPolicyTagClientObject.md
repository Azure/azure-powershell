---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicytagclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyTagClientObject

## SYNOPSIS
Adds or removes schedule tag in an existing backup policy.

## SYNTAX

### RemoveTag (Default)
```
Edit-AzDataProtectionPolicyTagClientObject -Name <TagName> -Policy <IBackupPolicy> -RemoveRule
 [<CommonParameters>]
```

### updateTag
```
Edit-AzDataProtectionPolicyTagClientObject -Criteria <IScheduleBasedBackupCriteria[]> -Name <TagName>
 -Policy <IBackupPolicy> [<CommonParameters>]
```

## DESCRIPTION
Adds or removes schedule tag in an existing backup policy.

## EXAMPLES

### Example 1: Add Weekly tag to Backup Policy
```powershell
$criteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -Criteria $criteria
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command adds a weekly tag to given backup policy

### Example 2: Remove Weeky tag from Backup Policy
```powershell
Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -RemoveRule
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command removes Weekly tag from backup policy.

## PARAMETERS

### -Criteria
Criterias to be associated with the schedule tag.
To construct, see NOTES section for CRITERIA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IScheduleBasedBackupCriteria[]
Parameter Sets: updateTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Schedule tag.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.TagName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Backup Policy Object.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveRule
Specify whether to remove the tag from the given policy object.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CRITERIA <IScheduleBasedBackupCriteria[]>: Criterias to be associated with the schedule tag.
  - `ObjectType <String>`: Type of the specific object - used for deserializing
  - `[AbsoluteCriterion <AbsoluteMarker[]>]`: it contains absolute values like "AllBackup" / "FirstOfDay" / "FirstOfWeek" / "FirstOfMonth"         and should be part of AbsoluteMarker enum
  - `[DaysOfMonth <IDay[]>]`: This is day of the month from 1 to 28 other wise last of month
    - `[Date <Int32?>]`: Date of the month
    - `[IsLast <Boolean?>]`: Whether Date is last date of month
  - `[DaysOfTheWeek <DayOfWeek[]>]`: It should be Sunday/Monday/T..../Saturday
  - `[MonthsOfYear <Month[]>]`: It should be January/February/....../December
  - `[ScheduleTime <DateTime[]>]`: List of schedule times for backup
  - `[WeeksOfTheMonth <WeekNumber[]>]`: It should be First/Second/Third/Fourth/Last

POLICY <IBackupPolicy>: Backup Policy Object.
  - `DatasourceType <String[]>`: Type of datasource for the backup management
  - `ObjectType <String>`: 
  - `PolicyRule <IBasePolicyRule[]>`: Policy rule dictionary that contains rules for each backuptype i.e Full/Incremental/Logs etc
    - `Name <String>`: 
    - `ObjectType <String>`: 
    - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
    - `TriggerObjectType <String>`: Type of the specific object - used for deserializing
    - `Lifecycle <ISourceLifeCycle[]>`: 
      - `DeleteAfterDuration <String>`: Duration of deletion after given timespan
      - `DeleteAfterObjectType <String>`: Type of the specific object - used for deserializing
      - `SourceDataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
      - `SourceDataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
      - `[TargetDataStoreCopySetting <ITargetCopySetting[]>]`: 
        - `CopyAfterObjectType <String>`: Type of the specific object - used for deserializing
        - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
        - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
    - `[BackupParameterObjectType <String>]`: Type of the specific object - used for deserializing
    - `[IsDefault <Boolean?>]`: 

## RELATED LINKS

