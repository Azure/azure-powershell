---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbsqlroledefinition
schema: 2.0.0
---

# New-AzCosmosDBSqlRoleDefinition

## SYNOPSIS
Creates a new CosmosDB Sql Role Definition.

## SYNTAX

### ByFieldsDataActionsParameterSet (Default)
```
New-AzCosmosDBSqlRoleDefinition -ResourceGroupName <String> -AccountName <String> [-Id <String>]
 -RoleName <String> [-Type <String>] -AssignableScope <System.Collections.Generic.List`1[System.String]>
 -DataAction <System.Collections.Generic.List`1[System.String]> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByFieldsPermissionsParameterSet
```
New-AzCosmosDBSqlRoleDefinition -ResourceGroupName <String> -AccountName <String> [-Id <String>]
 -RoleName <String> [-Type <String>] -AssignableScope <System.Collections.Generic.List`1[System.String]>
 -Permission <System.Collections.Generic.List`1[Microsoft.Azure.Commands.CosmosDB.Models.PSPermission]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectDataActionsParameterSet
```
New-AzCosmosDBSqlRoleDefinition [-Id <String>] -RoleName <String> [-Type <String>]
 -AssignableScope <System.Collections.Generic.List`1[System.String]>
 -DataAction <System.Collections.Generic.List`1[System.String]> -ParentObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectPermissionsParameterSet
```
New-AzCosmosDBSqlRoleDefinition [-Id <String>] -RoleName <String> [-Type <String>]
 -AssignableScope <System.Collections.Generic.List`1[System.String]>
 -Permission <System.Collections.Generic.List`1[Microsoft.Azure.Commands.CosmosDB.Models.PSPermission]>
 -ParentObject <PSDatabaseAccountGetResults> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB Sql Role Definition.
Assignable Scopes can be either fully qualified (ie.
/subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/dbs/dbName) or start with the database name (ie.
/dbs/dbName).
In order to specify the Role Definition's Permissions, either use the DataAction parameter and pass in a list of strings that will be turned into a single Permission object, or use the New-AzCosmosDBPermission cmdlet to create PSPermission objects to pass in through the Permission parameter.

## EXAMPLES

### Example 1: Using DataAction
```
PS C:\> New-AzCosmosDBSqlRoleDefinition
	-AccountName accountName 
	-ResourceGroupName resourceGroupName 
	-Type CustomRole
	-RoleName roleName
	-DataAction "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create"
	-AssignableScope "/"

RoleName         : roleName
Id               : /subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/sqlRoleDefinitions/id
Type             : CustomRole
Permissions      : {Microsoft.Azure.Management.CosmosDB.Models.Permission}
AssignableScopes : {/subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName}
```

### Example 2: Using Permission and ParentObject
```
PS C:\> $DatabaseAccount = Get-AzCosmosDBAccount -Name accountName -ResourceGroupName resourceGroupName
PS C:\> $Permission = New-AzCosmosDBPermission -DataAction "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create"
PS C:\> New-AzCosmosDBSqlRoleDefinition
	-Type CustomRole
	-RoleName roleName
	-Permission $Permission
	-AssignableScope "/"
	-ParentObject $DatabaseAccount

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
Parameter Sets: ByFieldsDataActionsParameterSet, ByFieldsPermissionsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssignableScope
Set of resource paths below which a Role Assignment can be attached to the Role Definition. Eg. '/', '/dbs/dbname','/dbs/dbname/colls/collname'.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataAction
Set of data actions granted through the Role Definition. List of allowed actions can be found at: https://aka.ms/cosmos-native-rbac

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: ByFieldsDataActionsParameterSet, ByParentObjectDataActionsParameterSet
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
Role Assignment Id.

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
Role definition object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccountGetResults
Parameter Sets: ByParentObjectDataActionsParameterSet, ByParentObjectPermissionsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Permission
Permission is a collection of data actions.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.CosmosDB.Models.PSPermission]
Parameter Sets: ByFieldsPermissionsParameterSet, ByParentObjectPermissionsParameterSet
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
Parameter Sets: ByFieldsDataActionsParameterSet, ByFieldsPermissionsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleName
Role Definition Name.

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

### -Type
Type of Role Definition, either CustomRole or BuiltInRole.
Default value is CustomRole.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlRoleDefinitionGetResults
## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSSqlRoleAssignmentGetResults
## NOTES

## RELATED LINKS
