---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbmongodbuserdefinition
schema: 2.0.0
---

# New-AzCosmosDBMongoDBUserDefinition

## SYNOPSIS
Creates a new CosmosDB MongoDB User Definition.

## SYNTAX

### ByFieldsDataActionsParameterSet (Default)
```
New-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String> [-Mechanisms <String>]
 -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByNameParameterSet
```
New-AzCosmosDBMongoDBUserDefinition -ResourceGroupName <String> -AccountName <String> -Id <String>
 -UserName <String> -Password <String> [-Mechanisms <String>] -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectDataActionsParameterSet
```
New-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String> [-Mechanisms <String>]
 -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] -DatabaseAccountObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectPermissionsParameterSet
```
New-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String> [-Mechanisms <String>]
 -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] -DatabaseAccountObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
New-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String> [-Mechanisms <String>]
 -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] [-ResourceId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB MongoDB User Definition.
In order to specify the Role Definition's Roles,  use the New-AzCosmosDBMongoDBRole cmdlet to create PSMongoRole objects to pass in through the Roles parameter.

## EXAMPLES

### Example 1: Default
```powershell
$Roles = New-AzCosmosDBMongoDBRole -Database test -Role roleName


New-AzCosmosDBMongoDBUserDefinition `
	-AccountName accountName `
	-ResourceGroupName resourceGroupName `
	-DatabaseName 'test' `
	-UserName 'myName' `
	-Password 'pass' `
	-Id id `
	-Mechanisms 'SCRAM-SHA-256' `
	-CustomData 'test' `
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
New-AzCosmosDBMongoDBRoleDefinition `
	-Id id `
	-Type CustomRole `
	-RoleName roleName `
	-Privileges $Privilege `
	-Roles $Roles `
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
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomData
Additional information about the user Definition.

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

### -DatabaseName
Database Name for the MongoDB Role Definition.

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

### -Id
Role Definition Unique Id(Format is `<databaseName>.<roleName>`).

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

### -Mechanisms
Password for the user Definition.

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

### -Password
Password for the user Definition.

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

### -ResourceId
ResourceId of the resource.

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Roles
Set of inherited roles for CosmosDB MongoDB API Role Definition.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
Unique username(per database) for the user Definition.

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

[Get-AzCosmosDBMongoDBUserDefinition](./Get-AzCosmosDBMongoDBUserDefinition.md)

[Update-AzCosmosDBMongoDBUserDefinition](./Update-AzCosmosDBMongoDBUserDefinition.md)

[Remove-AzCosmosDBMongoDBUserDefinition](./Remove-AzCosmosDBMongoDBUserDefinition.md)
