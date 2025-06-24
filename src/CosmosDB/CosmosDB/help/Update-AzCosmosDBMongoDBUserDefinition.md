---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbmongodbuserdefinition
schema: 2.0.0
---

# Update-AzCosmosDBMongoDBUserDefinition

## SYNOPSIS
This cmdlet updates an existing MongoDB user definition in a specified Cosmos DB account.

## SYNTAX

### ByFieldsDataActionsParameterSet (Default)
```
Update-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String>
 [-Mechanisms <String>] -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByNameParameterSet
```
Update-AzCosmosDBMongoDBUserDefinition -ResourceGroupName <String> -AccountName <String> -Id <String>
 -UserName <String> -Password <String> [-Mechanisms <String>] -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String>
 [-Mechanisms <String>] -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] -DatabaseAccountObject <PSDatabaseAccountGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBMongoDBUserDefinition -Id <String> -UserName <String> -Password <String>
 [-Mechanisms <String>] -DatabaseName <String>
 -Roles <System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoRole]>
 [-CustomData <String>] -InputObject <PSMongoDBUserDefinitionGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet updates an existing MongoDB user definition in a specified Cosmos DB account.

## EXAMPLES

### Example 1
```powershell
$subscriptionId = "00000000-0000-0000-0000-000000000000"
$rgName = "myResourceGroup"
$AccountName = "myCosmosDBAccount"
$DatabaseName = "myDatabase"
$Username1 = "myUser"
$UserDefinitionId1 = $DatabaseName + "." + $Username1
$Pass1 = "******"
$Mechanisms = "SCRAM-SHA-256"
$CustomData = "additionalInfo"
$UpdatedRoles = @("role1", "role2")
$FullyQualifiedUserDefinitionId1 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongodbUserDefinitions/$UserDefinitionId1"

$UserDef1 = Update-AzCosmosDBMongoDBUserDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedUserDefinitionId1 -UserName $Username1 -Password $Pass1 -Mechanisms $Mechanisms -CustomData $CustomData -DatabaseName $DatabaseName -Roles $UpdatedRoles
```

This command updates an existing MongoDB user definition in the specified Cosmos DB account.

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
Unique ID (\<Databasename\>.\<UserName\>) for the MongoDB User Definition.

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
A MongoDB User Definition for MongoDB.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoDBUserDefinitionGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Roles
List of Inherited roles for MongoDB Role Definition.

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

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoDBUserDefinitionGetResults

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoDBUserDefinitionGetResults

## NOTES

## RELATED LINKS
