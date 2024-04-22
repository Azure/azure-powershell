---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionretentionlifecycleclientobject
schema: 2.0.0
---

# New-AzDataProtectionRetentionLifeCycleClientObject

## SYNOPSIS
Creates new Lifecycle object

## SYNTAX

```
New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore <DataStoreType>
 -SourceRetentionDurationType <DurationType> -SourceRetentionDurationCount <Int32>
 [-TargetDataStore <DataStoreType>] [-CopyOption <CopyOption>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates new Lifecycle object

## EXAMPLES

### Example 1: Create a daily retention lifecycle
```powershell
New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
```

```output
DeleteAfterDuration        : P30D
DeleteAfterObjectType      : AbsoluteDeleteOption
SourceDataStoreObjectType  : DataStoreInfoBase
SourceDataStoreType        : OperationalStore
TargetDataStoreCopySetting :
```

This command creates a lifecycle object which stores the backup data in operational store for 30 days.

### Example 2: Create a weekly retention lifecycle.
```powershell
New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 20
```

```output
DeleteAfterDuration        : P20W
DeleteAfterObjectType      : AbsoluteDeleteOption
SourceDataStoreObjectType  : DataStoreInfoBase
SourceDataStoreType        : OperationalStore
TargetDataStoreCopySetting :
```

This command creates a lifecycle object which stores the backup data in operational store for 20 weeks.

## PARAMETERS

### -CopyOption
CopyOption

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CopyOption
Parameter Sets: (All)
Aliases:
Accepted values: CustomCopyOption, ImmediateCopyOption, CopyOnExpiryOption

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDataStore
Source Datastore

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType
Parameter Sets: (All)
Aliases:
Accepted values: ArchiveStore, OperationalStore, VaultStore

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceRetentionDurationCount
Retention Duration Count

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

### -SourceRetentionDurationType
Retention Duration Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DurationType
Parameter Sets: (All)
Aliases:
Accepted values: Days, Weeks, Months, Years

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDataStore
Target Datastore

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType
Parameter Sets: (All)
Aliases:
Accepted values: ArchiveStore, OperationalStore, VaultStore

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.ISourceLifeCycle

## NOTES

## RELATED LINKS
