---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/edit-azdataprotectionpolicyretentionruleclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyRetentionRuleClientObject

## SYNOPSIS
Adds or removes Retention Rule to existing Policy

## SYNTAX

### RemoveRetention (Default)
```
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Name <RetentionRuleName> -Policy <IBackupPolicy>
 -RemoveRule [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddRetention
```
Edit-AzDataProtectionPolicyRetentionRuleClientObject -IsDefault <Boolean> -LifeCycles <ISourceLifeCycle[]>
 -Name <RetentionRuleName> -Policy <IBackupPolicy> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Adds or removes Retention Rule to existing Policy

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
$pol = Get-AzDataProtectionPolicyTemplate
PS C:\> $lifecycle = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 5
PS C:\> Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $lifecycle -IsDefault $false
```

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy

### -------------------------- EXAMPLE 2 --------------------------
```powershell
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -RemoveRule
```

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy

## PARAMETERS

### -IsDefault
Specifies if retention rule is default retention rule.

```yaml
Type: System.Boolean
Parameter Sets: AddRetention
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LifeCycles
Life cycles associated with the retention rule.
To construct, see NOTES section for LIFECYCLES properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISourceLifeCycle[]
Parameter Sets: AddRetention
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Retention Rule Name

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RetentionRuleName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Backup Policy Object
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

### -RemoveRule
Specifies whether to remove the retention rule.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveRetention
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


LIFECYCLES <ISourceLifeCycle[]>: Life cycles associated with the retention rule.
  - `DeleteAfterDuration <String>`: Duration of deletion after given timespan
  - `DeleteAfterObjectType <String>`: Type of the specific object - used for deserializing
  - `SourceDataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
  - `SourceDataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
  - `[TargetDataStoreCopySetting <ITargetCopySetting[]>]`: 
    - `CopyAfterObjectType <String>`: Type of the specific object - used for deserializing
    - `DataStoreObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive

POLICY <IBackupPolicy>: Backup Policy Object
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

