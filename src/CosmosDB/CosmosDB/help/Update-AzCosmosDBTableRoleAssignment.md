---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbtableroleassignment
schema: 2.0.0
---

# Update-AzCosmosDBTableRoleAssignment

## SYNOPSIS
Updates an existing CosmosDB Table Role Assignment.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Update-AzCosmosDBTableRoleAssignment -ResourceGroupName <String> -AccountName <String> -Id <String>
 [-RoleDefinitionId <String>] [-RoleDefinitionName <String>] [-Scope <String>] [-PrincipalId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzCosmosDBTableRoleAssignment -Id <String> [-Scope <String>] [-PrincipalId <String>]
 -ParentObject <PSTableRoleDefinitionGetResults> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBTableRoleAssignment -InputObject <PSTableRoleAssignmentGetResults>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an existing CosmosDB Table Role Assignment.
Scope can be either fully qualified (ie.
/subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/dbs/dbName) or start with the database name (ie.
/dbs/dbName).
RoleDefinitionId and Id can be either fully qualified or just the Guid.

## EXAMPLES

### Example 1
```powershell
Update-AzCosmosDBTableRoleAssignment `
	-AccountName accountName `
	-ResourceGroupName resourceGroupName `
	-Id roleAssignmentId `
	-RoleDefinitionId "/subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/tableRoleDefinitions/roleDefinitionId"
```

```output
Id               : /subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/tableRoleAssignments/roleAssignmentId
Scope            : /subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/
RoleDefinitionId : /subscriptions/subId/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/accountName/tableRoleDefinitions/roleDefinitionId
PrincipalId      : principalId
```

## PARAMETERS

### -AccountName
Name of the Cosmos DB database account.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
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
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Role Assignment object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSTableRoleAssignmentGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentObject
CosmosDB Account object

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSTableRoleDefinitionGetResults
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrincipalId
Object ID (Guid) of the AAD principal to which the Role Assignment is being granted. This could be user, group, service principal, or managed identity.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
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
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionId
Fully Qualified Role Definition Id.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionName
Role Definition Name

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Resource path below which the Role Assignment shall grant access. Eg. '/', '/dbs/dbname','/dbs/dbname/colls/collname'.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSTableRoleDefinitionGetResults
## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSTableRoleDefinitionGetResults
## NOTES

## RELATED LINKS
