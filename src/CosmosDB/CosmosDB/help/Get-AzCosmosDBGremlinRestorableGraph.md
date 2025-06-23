---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbgremlinrestorablegraph
schema: 2.0.0
---

# Get-AzCosmosDBGremlinRestorableGraph

## SYNOPSIS
Lists all the restorable Azure Cosmos DB Gremlin graphs available for a specific database.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBGremlinRestorableGraph -Location <String> -DatabaseAccountInstanceId <String>
 -DatabaseRId <String> [-StartTime <String>] [-EndTime <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBGremlinRestorableGraph -InputObject <PSRestorableGremlinDatabaseGetResult>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Lists all the restorable Azure Cosmos DB Gremlin graphs available for a specific database.
The list would have entries corresponding to create, replace and delete events of all live and deleted graphs under a specific database.
This list is useful to identify the restore timestamp based on the changes in the graph.
For example, if user wants to restore the database account to a timestamp when a specific graph is deleted, the user can find corresponding graph delete event from this list, and choose a timestamp before the delete event for restore.

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBGremlinRestorableGraph -Location "locationName" -DatabaseAccountInstanceId "DatabaseAccountInstanceIdInstanceId" -DatabaseRId "DatabaseRId"
```

```output
Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{locationName}/restorableDatabaseAccounts
                    /{DatabaseAccountInstanceIdInstanceId}/restorableGremlinGraphs/6a0cb3e4-7d2b-4363-b585-04a3b14ada8c
Name            : 6a0cb3e4-7d2b-4363-b585-04a3b14ada8c
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableGremlinGraphs
_rid            : qsLuzwAAAA==
OperationType   : Create
EventTimestamp  : 01/20/2021 18:44:07
OwnerId         : foo-graph1
OwnerResourceId : Ts0YAPGKTvw=

Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{locationName}/restorableDatabaseAccounts
                    /{DatabaseAccountInstanceIdInstanceId}/restorableGremlinGraphs/ff36d1d3-f9dc-40a0-a003-60fe349abcfb
Name            : ff36d1d3-f9dc-40a0-a003-60fe349abcfb
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableGremlinGraphs
_rid            : Ngu72QAAAA==
OperationType   : Replace
EventTimestamp  : 01/20/2021 18:44:07
OwnerId         : foo-graph1
OwnerResourceId : Ts0YAP+RbG0=

Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{locationName}/restorableDatabaseAccounts
                    /{DatabaseAccountInstanceIdInstanceId}/restorableGremlinGraphs/2afb35ba-1755-4fbc-85be-ae175dd0668f
Name            : 2afb35ba-1755-4fbc-85be-ae175dd0668f
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableGremlinGraphs
_rid            : lSuf5gAAAA==
OperationType   : Create
EventTimestamp  : 01/20/2021 18:42:43
OwnerId         : foo-graph2
OwnerResourceId : Ts0YAP+RbG0=
```

The resource object contains the properties of the collection resource

## PARAMETERS

### -DatabaseAccountInstanceId
The instance Id of the CosmosDB database account.
(This is returned as a part of database account properties).

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseRId
ResourceId of the database.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
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

### -EndTime
Restorable Gremlin graphs event feed end time.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
CosmosDB Restorable Gremlin Database object.

```yaml
Type: Microsoft.Azure.Management.CosmosDB.Models.PSRestorableGremlinDatabaseGetResult
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Name of the Location in string.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Restorable Gremlin graphs event feed start time.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
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

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableGremlinDatabaseGetResult

## OUTPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableGremlinGraphGetResult

## NOTES

## RELATED LINKS
