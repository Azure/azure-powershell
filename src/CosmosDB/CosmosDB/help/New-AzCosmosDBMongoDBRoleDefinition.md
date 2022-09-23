---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbmongodbroledefinition
schema: 2.0.0
---

# New-AzCosmosDBMongoDBRoleDefinition

## SYNOPSIS
Creates a new CosmosDB MongoDB Role Definition.

## SYNTAX

### Default Parameter Set
```
New-AzCosmosDBMongoDBRoleDefinition 
	-ResourceGroupName <String> 
	-AccountName <String> 
	-DatabaseName <String> 
	-Id <String> 
	-RoleName <String> 
	-Type <String> 
	-Privileges <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilege[]> 
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```
### ParentObject Parameter Set
```
New-AzCosmosDBMongoDBRoleDefinition 
	-Id <String> 
	-DatabaseAccountObject <PSDatabaseAccountGetResults>
	-RoleName <String> 
	-Type <String> 
	-DatabaseName <String> 
	-Privileges <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilege[]> 
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```

### ResourceId Parameter Set
```
New-AzCosmosDBMongoDBRoleDefinition 
	-ResourceId <String> 
	-Id <String> 
	-RoleName <String> 
	-Type <String> -DatabaseName <String> 
	-Privileges <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilege[]> 
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```

## DESCRIPTION
Creates a new CosmosDB MongoDB Role Definition.
In order to specify the Role Definition's Privileges,  use the New-AzCosmosDBMongoDBPrivilege cmdlet to create PSMongoPrivilege objects to pass in through the Privileges parameter.
In order to specify the Role Definition's Roles,  use the New-AzCosmosDBMongoDBRole cmdlet to create PSMongoRole objects to pass in through the Roles parameter.

## EXAMPLES

### Example 1: Default
```powershell
  $Actions = 'insert', 'find'
  $PrivilegeResource = New-AzCosmosDBMongoDBPrivilegeResource -Database test -Collection test
  $Privilege = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $PrivilegeResource -Actions $Actions
  $Roles = New-AzCosmosDBMongoDBRole -Database test -Role roleName


New-AzCosmosDBMongoDBRoleDefinition
	-AccountName accountName 
	-ResourceGroupName resourceGroupName 
	-DatabaseName test
	-Id id
	-Type CustomRole
	-RoleName roleName
	-Privileges $Privilege
	-Roles $Roles
```

```output
Id           : /subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/mongodbRoleDefinitions/id
RoleName     : roleName
Type         : CustomRole
DatabaseName : test
Privileges   : {Microsoft.Azure.Management.CosmosDB.Models.Privilege}
Roles        : {Microsoft.Azure.Management.CosmosDB.Models.Role, Microsoft.Azure.Management.CosmosDB.Models.Role}
```

### Example 2: ParentObject
```powershell
$DatabaseAccount = Get-AzCosmosDBAccount -Name accountName -ResourceGroupName resourceGroupName
$Actions = 'insert', 'find'
$PrivilegeResource = New-AzCosmosDBMongoDBPrivilegeResource -Database test -Collection test
$Privilege = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $PrivilegeResource -Actions $Actions
$Roles = New-AzCosmosDBMongoDBRole -Database test -Role roleName
New-AzCosmosDBMongoDBRoleDefinition
	-Id id
	-Type CustomRole
	-RoleName roleName
	-Privileges $Privilege
	-Roles $Roles
	-DatabaseAccountObject $DatabaseAccount
```

```output
Id           : /subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/mongodbRoleDefinitions/id
RoleName     : roleName
Type         : CustomRole
DatabaseName : test
Privileges   : {Microsoft.Azure.Management.CosmosDB.Models.Privilege}
Roles        : {Microsoft.Azure.Management.CosmosDB.Models.Role, Microsoft.Azure.Management.CosmosDB.Models.Role}
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

### -Privileges
Set of Privileges for CosmosDB MongoDB API.

```yaml
Type: System.Collections.Generic.List`1[{Microsoft.Azure.Management.CosmosDB.Models.Privilege]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Roles
Set of inherited roles for CosmosDB MongoDB API Role Definition.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Management.CosmosDB.Models.Role]
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Role Definition Unique Id(Format is <databaseName>.<roleName>).

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

### -DatabaseAccountObject
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

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoDBRoleDefinitionGetResults
## NOTES

## RELATED LINKS

[Get-AzCosmosDBMongoDBRoleDefinition](./Get-AzCosmosDBMongoDBRoleDefinition.md)

[Update-AzCosmosDBMongoDBRoleDefinition](./Update-AzCosmosDBMongoDBRoleDefinition.md)

[Remove-AzCosmosDBMongoDBRoleDefinition](./Remove-AzCosmosDBMongoDBRoleDefinition.md)