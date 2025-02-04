---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionpolicytemplate
schema: 2.0.0
---

# Get-AzDataProtectionPolicyTemplate

## SYNOPSIS
Gets default policy template for a selected datasource type.

## SYNTAX

```
Get-AzDataProtectionPolicyTemplate -DatasourceType <DatasourceTypes> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets default policy template for a selected datasource type.

## EXAMPLES

### Example 1: Get Azure Disk default policy template
```powershell
Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command returns a default policy template for a given datasource type.
Use this policy template to create a new policy.

## PARAMETERS

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:
Accepted values: AzureDisk, AzureBlob, AzureDatabaseForPostgreSQL, AzureKubernetesService, AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL

Required: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupPolicy

## NOTES

## RELATED LINKS
