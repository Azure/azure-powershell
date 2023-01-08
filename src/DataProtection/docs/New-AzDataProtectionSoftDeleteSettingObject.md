---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionsoftdeletesettingobject
schema: 2.0.0
---

# New-AzDataProtectionSoftDeleteSettingObject

## SYNOPSIS
Get Backup Vault soft delete setting object

## SYNTAX

```
New-AzDataProtectionSoftDeleteSettingObject [-RetentionDurationInDay <Int32>] [-State <SoftDeleteState>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Backup Vault soft delete setting object

## EXAMPLES

### Example 1: Create a new vault soft delete setting object
```powershell
New-AzDataProtectionSoftDeleteSettingObject -RetentionDurationInDay 100 -State On
```

```output
RetentionDurationInDay State
---------------------- -----
100                    On
```

This command creates a new vault soft delete setting object which is used to create a backup vault.

## PARAMETERS

### -RetentionDurationInDay
Retention duration in Days

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

### -State
Soft delete state of the vault

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SoftDeleteState
Parameter Sets: (All)
Aliases:

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

### System.Management.Automation.PSObject

## NOTES

ALIASES

## RELATED LINKS

