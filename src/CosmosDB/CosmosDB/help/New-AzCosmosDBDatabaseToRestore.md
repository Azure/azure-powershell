---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbdatabasetorestore
schema: 2.0.0
---

# New-AzCosmosDBDatabaseToRestore

## SYNOPSIS
Creates a new CosmosDB Database to Restore object(PSDatabaseToRestore)

## SYNTAX

```
New-AzCosmosDBDatabaseToRestore -DatabaseName <String> [-CollectionName <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB DatabaseToRestore object(PSDatabaseToRestore). This returned object can be uses to speficy the subset of databases and collections to restore.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBDatabaseToRestore -DatabaseName database1 -CollectionName collection1,collection2,collection3
```

```output
DatabaseName CollectionNames
------------ ---------------
database1    {collection1, collection2, collection3}
```

Creates a new DatabaseToRestore object with the name database1 and collections with names collection1, collection2 and collection3.

## PARAMETERS

### -CollectionName
The names of the collections to be restored.
(If not provided, all the collections will be restored)

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

### -DatabaseName
The name of the database to restore

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseToRestore

## NOTES

## RELATED LINKS
