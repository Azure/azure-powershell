---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbsqlrestorablecontainer
schema: 2.0.0
---

# Get-AzCosmosDBSqlRestorableContainer

## SYNOPSIS
Lists all the restorable Azure Cosmos DB SQL containers available for a specific database.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBSqlRestorableContainer -Location <String> -DatabaseAccountInstanceId <String>
 -DatabaseRId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBSqlRestorableContainer -InputObject <PSRestorableSqlDatabaseGetResult>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Lists all the restorable Azure Cosmos DB SQL containers available for a specific database.
The list would have entries corresponding to create, replace and delete events of all live and deleted containers under the database.
This list is useful to identify the restore timestamp based on the changes in the container. 
For example, if user wants to restore the database account to a timestamp when a specific container is deleted, the user can find corresponding collection delete event from this list, and choose a timestamp before the delete event for restore.

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBSqlRestorableContainer -Location "location" -DatabaseAccountInstanceId "DatabaseAccountInstanceId" -DatabaseRId "DatabaseRId"
```

```output
Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts
                    /{DatabaseAccountInstanceId}/restorableSqlContainers/6a0cb3e4-7d2b-4363-b585-04a3b14ada8c
Name            : 6a0cb3e4-7d2b-4363-b585-04a3b14ada8c
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlContainers
_rid            : qsLuzwAAAA==
OperationType   : Create
EventTimestamp  : 01/20/2021 18:44:07
OwnerId         : foo-container2
OwnerResourceId : Ts0YAPGKTvw=
Container       : Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlContainerPropertiesResourceContainer

Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts
                    /{DatabaseAccountInstanceId}/restorableSqlContainers/ff36d1d3-f9dc-40a0-a003-60fe349abcfb
Name            : ff36d1d3-f9dc-40a0-a003-60fe349abcfb
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlContainers
_rid            : Ngu72QAAAA==
OperationType   : Replace
EventTimestamp  : 01/20/2021 18:44:07
OwnerId         : foo-container1
OwnerResourceId : Ts0YAP+RbG0=
Container       : Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlContainerPropertiesResourceContainer

Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts
                    /{DatabaseAccountInstanceId}/restorableSqlContainers/2afb35ba-1755-4fbc-85be-ae175dd0668f
Name            : 2afb35ba-1755-4fbc-85be-ae175dd0668f
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlContainers
_rid            : lSuf5gAAAA==
OperationType   : Create
EventTimestamp  : 01/20/2021 18:42:43
OwnerId         : foo-container1
OwnerResourceId : Ts0YAP+RbG0=
Container       : Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlContainerPropertiesResourceContainer
```

The resource object contains the properties of the container resource

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

### -InputObject
CosmosDB Restorable Sql Database object

```yaml
Type: Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlDatabaseGetResult
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlContainerGetResult

## NOTES

## RELATED LINKS
