---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbsqlroledefinition
schema: 2.0.0
---

# Get-AzCosmosDBSqlRoleDefinition

## SYNOPSIS
Gets the CosmosDB Role Definition.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBSqlRoleDefinition -ResourceGroupName <String> -AccountName <String> [-Id <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBSqlRoleDefinition [-Id <String>] -ParentObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzCosmosDBSqlRoleDefinition cmdlet gets the list of all existing CosmosDB Sql Role Definitions for a given ResourceGroupName, AccountName and gets a single CosmosDB Sql Database for a given ResourceGroupName, AccountName, and Id.
Id can be either fully qualified or just the Guid.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzCosmosDBSqlRoleDefinition -AccountName accountName -ResourceGroupName resourceGroupName -Id id

RoleName         : roleName
Id               : /subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/sqlRoleDefinitions/id
Type             : CustomRole
Permissions      : {Microsoft.Azure.Management.CosmosDB.Models.Permission}
AssignableScopes : {/subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName}
```

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

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

### -Id
Role Definition Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
CosmosDB Account object

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccountGetResults
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlRoleDefinitionGetResults
## NOTES

## RELATED LINKS
