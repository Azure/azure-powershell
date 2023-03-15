---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbgremlindatabasetorestore
schema: 2.0.0
---

# New-AzCosmosDBGremlinDatabaseToRestore

## SYNOPSIS
Creates a new CosmosDB Gremlin Database to Restore object(PSGremlinDatabaseToRestore)

## SYNTAX

```
New-AzCosmosDBGremlinDatabaseToRestore -DatabaseName <String> [-GraphNames <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB GremlinDatabaseToRestore object(PSGremlinDatabaseToRestore). This returned object can be uses to speficy the subset of databases and graphs to restore.

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBGremlinDatabaseToRestore -DatabaseName database1 -GraphName graph1,graph2,graph3
```

```output
DatabaseName GraphNames
------------ ---------------
database1    {graph1, graph2, graph3}
```

Creates a new GremlinDatabaseToRestore object with the name database1 and graphs with names graph1, graph2 and graph3.

## PARAMETERS

### -DatabaseName
The name of the gremlin database to restore

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

### -GraphNames
The names of the graphs to be restored.
(If not provided, all the graphs will be restored)

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSGremlinDatabaseToRestore

## NOTES

## RELATED LINKS
