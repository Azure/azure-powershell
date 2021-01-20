---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/en-us/powershell/module/az.cosmosdb/get-azcosmosdbmongodbrestorabledatabase
schema: 2.0.0
---

# Get-AzCosmosDBMongoDBRestorableDatabase

## SYNOPSIS
Gets the list of all the restorable Azure Cosmos DB MongoDB databases available under the restorable account.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBMongoDBRestorableDatabase -LocationName <String> -DatabaseAccountInstanceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBMongoDBRestorableDatabase -ParentObject <PSRestorableDatabaseAccountGetResult>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of all the restorable Azure Cosmos DB MongoDB databases available under the restorable account.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzCosmosDBMongoDBRestorableDatabase -LocationName {locationName} -DatabaseAccountInstanceId {DatabaseAccountInstanceIdInstanceId}

Name    Id		Type		Resource
{name}  {id}	{Type}		Microsoft.Azure.Management.CosmosDB.Models.PSRestorableMongoDBDatabasePropertiesResource
```

The resource object contains the properties of the database resource

## PARAMETERS

### -DatabaseAccountInstanceId
The instance Id of the CosmosDB database account.
(This is returned as a part of database account properties).

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationName
Name of the Location in string.

```yaml
Type: String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
CosmosDB Restorable Database Account object

```yaml
Type: PSRestorableDatabaseAccountGetResult
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.CosmosDB.Models.PSRestorableMongodbDatabaseGetResult

## NOTES

## RELATED LINKS
