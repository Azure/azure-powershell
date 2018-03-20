---
external help file: Microsoft.Azure.Commands.DataMigration.dll-Help.xml
Module Name: AzureRM.DataMigration
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datamigration/new-azurermdatamigrationdatabaseinfo
schema: 2.0.0
---

# New-AzureRmDataMigrationDatabaseInfo

## SYNOPSIS
Creates the DatabaseInfo object for the Azure Database Migration Service, which specifies the database source for migration.

## SYNTAX

```
New-AzureRmDataMigrationDatabaseInfo -SourceDatabaseName <String> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The New-AzureRmDataMigrationDatabaseInfo cmdlet creates the DatabaseInfo object that specifies the source database instance to be migrated. Database name is taken in as input parameter.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmDataMigrationDatabaseInfo -SourceDatabaseName 'AdventureWorks2016'
```

The preceding example creates a new DatabaseInfo object for the source database **AdventureWorks2016**.

This script assumes that you are already logged into your Azure account. You can confirm your login status by using the Get-AzureSubscription cmdlet.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```
### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDatabaseName
Source Database Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: SourceDBName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Management.DataMigration.Models.DatabaseInfo


## NOTES

## RELATED LINKS


