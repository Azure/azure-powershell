---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/update-azdataprotectionpolicytrigger
schema: 2.0.0
---

# Update-AzDataProtectionPolicyTrigger

## SYNOPSIS
Creates new Schedule object

## SYNTAX

```
Update-AzDataProtectionPolicyTrigger -Policy <IBackupPolicy> -Schedule <String[]> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates new Schedule object

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

## PARAMETERS

### -Policy
Source Datastore
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schedule
Source Datastore

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


POLICY <IBackupPolicy>: Source Datastore
  - `DatasourceType <String[]>`: Type of datasource for the backup management
  - `ObjectType <String>`: 
  - `PolicyRule <IBasePolicyRule[]>`: Policy rule dictionary that contains rules for each backuptype i.e Full/Incremental/Logs etc
    - `Name <String>`: 
    - `ObjectType <String>`: 
    - `BackupParameterObjectType <String>`: Type of the specific object - used for deserializing
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
    - `[IsDefault <Boolean?>]`: 

## RELATED LINKS

