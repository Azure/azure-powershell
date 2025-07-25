---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/restore-azcosmosdbsqldatabase
schema: 2.0.0
---

# Restore-AzCosmosDBSqlDatabase

## SYNOPSIS
Restore a deleted sql database to a given timestamp in the same account

## SYNTAX

```
Restore-AzCosmosDBSqlDatabase -ResourceGroupName <String> -AccountName <String> -Name <String>
 [-RestoreTimestampInUtc <DateTime>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Restores the deleted sql database in the same account with the given name and timestamp.

## EXAMPLES

### Example 1
```powershell
Restore-AzCosmosDBSqlDatabase -AccountName "my-pitr-sql-account" -ResourceGroupName "my-rg" -Name "my-database" -RestoreTimestampInUtc "2022-08-25T07:16:20Z"
```

```output
Name     : my-database
Id       : /subscriptions/23587e98-b6ac-4328-a753-03bcd3c8e744/resourceGroups/my-rg/providers/Microsoft.DocumentDB/databaseAccounts/my-pitr-sql-account/sqlDatabases/my-database 
Location :
Tags     :
Resource : Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetPropertiesResource
```

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Database name.

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

### -ResourceGroupName
Name of resource group.

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

### -RestoreTimestampInUtc
Database name.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlDatabaseGetResults

### Microsoft.Azure.Commands.CosmosDB.Exceptions.ConflictingResourceException

## NOTES

## RELATED LINKS
