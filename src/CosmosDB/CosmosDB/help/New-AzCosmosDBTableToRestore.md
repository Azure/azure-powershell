---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbtabletorestore
schema: 2.0.0
---

# New-AzCosmosDBTableToRestore

## SYNOPSIS
Creates a new CosmosDB Table to Restore object(PSTableToRestore)

## SYNTAX

```
New-AzCosmosDBTableToRestore [-TableNames <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB TableToRestore object(PSTableToRestore). This returned object can be uses to speficy the subset of tables to restore.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBTableToRestore -TableName table1,table2,table3
```

```output
TableNames
---------------
{table1, table2, table3}
```

Creates a new TableToRestore object with the table names table1, table2 and table3.

## PARAMETERS

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

### -TableNames
The names of the tables to be restored.
(If not provided, all the tables will be restored)

```yaml
Type: System.String[]
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSTablesToRestore

## NOTES

## RELATED LINKS
