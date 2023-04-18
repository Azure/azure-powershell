---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicytriggerclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyTriggerClientObject

## SYNOPSIS
Updates Backup schedule of an existing backup policy.

## SYNTAX

```
Edit-AzDataProtectionPolicyTriggerClientObject -Policy <IBackupPolicy> -Schedule <String[]>
 [<CommonParameters>]
```

## DESCRIPTION
Updates Backup schedule of an existing backup policy.

## EXAMPLES

### Example 1: Add Daily schedule to Azure Backup rule.
```powershell
$schedule = New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays (Get-Date) -IntervalType Daily -IntervalCount 1
Edit-AzDataProtectionPolicyTriggerClientObject -Policy $pol -Schedule $schedule
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command updates backup schedule of given policy to daily backup.

## PARAMETERS

### -Policy
Backup Policy object.
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

### -Schedule
Schedule to be associated to backup policy.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICY <IBackupPolicy>`: Backup Policy object.
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

