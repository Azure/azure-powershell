---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbmongodbuserdefinition
schema: 2.0.0
---

# New-AzCosmosDBMongoDBUserDefinition

## SYNOPSIS
Update an existing CosmosDB MongoDB User Definition.

## SYNTAX

### Default Parameter Set
```
Update-AzCosmosDBMongoDBUserDefinition 
	-ResourceGroupName <String> 
	-AccountName <String>
	-DatabaseName <String>
	-UserName <String>
	-Password <String>
	-Id <String> 
	-Mechanisms <String> 
	-CustomData <String>
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```
### ParentObject Parameter Set
```
Update-AzCosmosDBMongoDBUserDefinition 
	-DatabaseAccountObject <PSDatabaseAccountGetResults>
	-DatabaseName <String>
	-UserName <String>
	-Password <String>
	-Id <String> 
	-Mechanisms <String> 
	-CustomData <String>
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```

### InputObject Parameter Set
```
Update-AzCosmosDBMongoDBUserDefinition 
	-DatabaseAccountObject <PSMongoDBUserDefinitionGetResults>
	-DatabaseName <String>
	-UserName <String>
	-Password <String>
	-Id <String> 
	-Mechanisms <String> 
	-CustomData <String>
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```

### ResourceId Parameter Set
```
Update-AzCosmosDBMongoDBUserDefinition 
	-ResourceId <String> 
	-DatabaseName <String>
	-UserName <String>
	-Password <String>
	-Id <String> 
	-Mechanisms <String> 
	-CustomData <String>
	[-Roles <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole[]>]
```

## DESCRIPTION
Update an existing CosmosDB MongoDB User Definition.
In order to specify the Role Definition's Roles,  use the New-AzCosmosDBMongoDBRole cmdlet to create PSMongoRole objects to pass in through the Roles parameter.

## EXAMPLES

### Example 1: Default
```powershell
  $Roles = New-AzCosmosDBMongoDBRole -Database test -Role roleName


Update-AzCosmosDBMongoDBUserDefinition
	-AccountName accountName 
	-ResourceGroupName resourceGroupName 
	-DatabaseName 'test'
	-UserName 'myName'
	-Password 'pass'
	-Id id
	-Mechanisms 'SCRAM-SHA-256'
	-CustomData 'test'
	-Roles $Roles
```

```output
Id           : /subscriptions/80be3961-0521-4a0a-8570-5cd5a4e2f98c/resourceGroups/mongorbactest02/providers/Microsoft.DocumentDB/databaseAccounts/ashwini001/mongodbUserDefinitions/test.testuser1
UserName     : testuser1
Password     :
Mechanisms   : SCRAM-SHA-256
DatabaseName : test
CustomData   :
Roles        : {Microsoft.Azure.Management.CosmosDB.Models.Role}
```

### Example 2: ParentObject
```powershell
$DatabaseAccount = Get-AzCosmosDBAccount -Name accountName -ResourceGroupName resourceGroupName
$Actions = 'insert', 'find'
$PrivilegeResource = New-AzCosmosDBMongoDBPrivilegeResource -Database test -Collection test
$Privilege = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $PrivilegeResource -Actions $Actions
$Roles = New-AzCosmosDBMongoDBRole -Database test -Role roleName
Update-AzCosmosDBMongoDBRoleDefinition
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

### Example 3: InputtObject
```powershell
$DatabaseAccount = Get-AzCosmosDBAccount -Name accountName -ResourceGroupName resourceGroupName
$Actions = 'insert', 'find'
$PrivilegeResource = New-AzCosmosDBMongoDBPrivilegeResource -Database test -Collection test
$Privilege = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $PrivilegeResource -Actions $Actions
$Roles = New-AzCosmosDBMongoDBRole -Database test -Role roleName

$UserDef = Get-AzCosmosDBMongoDBUserDefinition -AccountName accountName -ResourceGroupName resourceGroupName -Id id
Update-AzCosmosDBMongoDBRoleDefinition
	-Id id
	-Type CustomRole
	-RoleName roleName
	-Privileges $Privilege
	-Roles $Roles
	-InputObject $UserDef
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

### -InputObject
Role definition object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSMongoDBUserDefinitionGetResults
Parameter Sets: ByParentObjectDataActionsParameterSet, ByParentObjectPermissionsParameterSet
Aliases:

Required: False
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoDBUserDefinitionGetResults
## NOTES

## RELATED LINKS

[Get-AzCosmosDBMongoDBUserDefinition](./Get-AzCosmosDBMongoDBUserDefinition.md)

[New-AzCosmosDBMongoDBUserDefinition](./New-AzCosmosDBMongoDBUserDefinition.md)

[Remove-AzCosmosDBMongoDBUserDefinition](./Remove-AzCosmosDBMongoDBUserDefinition.md)
