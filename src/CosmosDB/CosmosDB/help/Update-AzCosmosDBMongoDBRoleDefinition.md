---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbmongodbroledefinition
schema: 2.0.0
---

# Update-AzCosmosDBMongoDBRoleDefinition

## SYNOPSIS
This cmdlet updates an existing MongoDB role definition in a specified Cosmos DB account.

## SYNTAX

### ByFieldsDataActionsParameterSet (Default)
```
Update-AzCosmosDBMongoDBRoleDefinition -Id <String> [-RoleName <String>] [-Type <String>]
 [-DatabaseName <String>]
 [-Privileges <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoPrivilege]>]
 [-Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByNameParameterSet
```
Update-AzCosmosDBMongoDBRoleDefinition -ResourceGroupName <String> -AccountName <String> -Id <String>
 [-RoleName <String>] [-Type <String>] [-DatabaseName <String>]
 [-Privileges <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoPrivilege]>]
 [-Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzCosmosDBMongoDBRoleDefinition -Id <String> [-RoleName <String>] [-Type <String>]
 [-DatabaseName <String>]
 [-Privileges <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoPrivilege]>]
 [-Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>]
 -DatabaseAccountObject <PSDatabaseAccountGetResults> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBMongoDBRoleDefinition -Id <String> [-RoleName <String>] [-Type <String>]
 [-DatabaseName <String>]
 [-Privileges <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoPrivilege]>]
 [-Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>]
 -InputObject <PSMongoDBRoleDefinitionGetResults> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet updates an existing MongoDB role definition in a specified Cosmos DB account.

## EXAMPLES

### Example 1
```powershell
$subscriptionId = "00000000-0000-0000-0000-000000000000"
$rgName = "myResourceGroup"
$AccountName = "myCosmosDBAccount"
$DatabaseName = "myDatabase"
$RoleName1 = "mongoPSRole1"
$RoleDefinitionId1 = $DatabaseName + "." + $RoleName1
$FullyQualifiedRoleDefinitionId1 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongodbRoleDefinitions/$RoleDefinitionId1"
$CollectionName = "collection1"
$Resource1 = New-AzCosmosDBMongoDBPrivilegeResource -Database $DatabaseName -Collection $CollectionName
$actions1 = 'insert', 'find'
$Privilege1 = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $Resource1 -Actions $actions1
Update-AzCosmosDBMongoDBRoleDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedRoleDefinitionId1 -RoleName $RoleName1 -Type "CustomRole" -DatabaseName $DatabaseName -Privileges $Privilege1
```

This command updates an existing MongoDB role definition in the specified Cosmos DB account.

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

### -DatabaseAccountObject
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

### -DatabaseName
Database Name for the MongoDB Role Definition.

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
Unique ID (\<Databasename\>.\<RoleName\>) for the MongoDB Role Definition.

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

### -InputObject
A MongoDB Role Definition For Mongo DB.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoDBRoleDefinitionGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Privileges
MongoDB Role Definition Privileges define allowed actions for corresponding resources.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoPrivilege]
Parameter Sets: (All)
Aliases:

Required: False
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

### -RoleName
Unique display name(per database) for the Role Definition.

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

### -Roles
List of Inherited roles for MongoDB Role Definition.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of the MongoDB Role Definition, either CustomRole or BuiltInRole.

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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSDatabaseAccountGetResults

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoDBRoleDefinitionGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoDBCollectionGetResults

## NOTES

## RELATED LINKS
