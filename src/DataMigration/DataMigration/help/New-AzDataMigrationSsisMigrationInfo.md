---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.dll-Help.xml
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/en-us/powershell/module/az.datamigration/New-AzDataMigrationSsisMigrationInfo
schema: 2.0.0
---

# New-AzDataMigrationSsisMigrationInfo

## SYNOPSIS
Creates the SsisMigrationInfo object for the Azure Database Migration Service SSIS migration task, which specifies the option to overwrite or ignore existing projects and environment on the target server.

## SYNTAX

```
New-AzDataMigrationSsisMigrationInfo -ProjectOverwriteOption <SsisMigrationOverwriteOptionEnum> -EnvironmentOverwriteOption <SsisMigrationOverwriteOptionEnum>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzDataMigrationSsisMigrationInfo cmdlet creates the SsisMigrationInfo object for the Azure Database Migration Service SSIS migration task, which specifies the option to overwrite or ignore existing projects and environment on the target server. Default options are ignore.

## EXAMPLES

### Example 1
```
PS C:\> New-AzDmsSsisMigrationInfo -Project Overwrite -Environment Overwrite

SsisStoreType ProjectOverwriteOption EnvironmentOverwriteOption
------------- ---------------------- --------------------------
SsisCatalog   Overwrite              Overwrite
```

## PARAMETERS

### -ProjectOverwriteOption
Whether to ignore or overwrite exsiting project(s).

```yaml
Type: Microsoft.Azure.Commands.DataMigration.Models.SsisMigrationOverwriteOptionEnum
Parameter Sets: (All)
Aliases: Project

Required: False
Position: Named
Default value: Ignore
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentOverwriteOption
Whether to ignore or overwrite exsiting environment.

```yaml
Type: Microsoft.Azure.Commands.DataMigration.Models.SsisMigrationOverwriteOptionEnum
Parameter Sets: (All)
Aliases: Environment

Required: False
Position: Named
Default value: Ignore
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.DataMigration.Models.SsisMigrationInfo

## NOTES

## RELATED LINKS
