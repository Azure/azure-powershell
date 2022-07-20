---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbsqlrestorabledatabase
schema: 2.0.0
---

# Get-AzCosmosDBSqlRestorableDatabase

## SYNOPSIS
Gets the list of all the restorable Azure Cosmos DB Sql databases available under the restorable account.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBSqlRestorableDatabase -Location <String> -DatabaseAccountInstanceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBSqlRestorableDatabase -InputObject <PSRestorableDatabaseAccountGetResult>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of all the restorable Azure Cosmos DB Sql databases available under the restorable account.
The list would have entries corresponding to create, replace and delete events of all live and deleted databases.
This list is useful to identify the restore timestamp based on the changes in the database. 
For example, if user wants to restore the database account to a timestamp when a database named foo is deleted, the user can find corresponding database delete event from this list, and choose a timestamp before the delete event for restore.

## EXAMPLES

### Example 1
```powershell
Get-AzCosmosDBSqlRestorableDatabase -Location "location" -DatabaseAccountInstanceId "DatabaseAccountInstanceId"
```

```output
Name            : cb04fbfc-4142-413d-b2c5-c91723a17e28
Id              : /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorableDatabaseAccounts/{DatabaseAccountInstanceId}/restorableSqlDatabases/cb04fbfc-4142-413d-b2c5-c91723
                  a17e28
Type            : Microsoft.DocumentDB/locations/restorableDatabaseAccounts/restorableSqlDatabases
_rid            : a+35ZwAAAA==
OperationType   : Create
EventTimestamp  : 01/20/2021 18:42:37
OwnerId         : foo-db1
OwnerResourceId : Ts0YAA==
Database        : Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlDatabasePropertiesResourceDatabase
```

The resource object contains the properties of the database resource

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
CosmosDB Restorable Database Account object

```yaml
Type: Microsoft.Azure.Management.CosmosDB.Models.PSRestorableDatabaseAccountGetResult
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

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableSqlDatabaseGetResult

## NOTES

## RELATED LINKS
