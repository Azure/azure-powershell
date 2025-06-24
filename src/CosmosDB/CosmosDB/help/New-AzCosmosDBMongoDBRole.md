---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbmongodbrole
schema: 2.0.0
---

# New-AzCosmosDBMongoDBRole

## SYNOPSIS
Creates a new CosmosDB MongoDB Role object to be used to create or update  a CosmosDB MongoDB Role Definition and User Definition.

## SYNTAX

```
New-AzCosmosDBMongoDBRole -Database <String> -Role <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB MongoDB Role object to be used to create or update a CosmosDB MongoDB Role Definition and User Definition.

## EXAMPLES

### Example 1
```powershell
$db = 'test'
$role = 'testRoleName'

New-AzCosmosDBMongoDBRole -Database $db -Role $role
```

```output
Object
Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole
```

## PARAMETERS

### -Database
Database Name.

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

### -Role
Role Name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoRole
## NOTES

## RELATED LINKS

[New-AzCosmosDBMongoDBRoleDefinition](./New-AzCosmosDBMongoDBRoleDefinition.md)

[Update-AzCosmosDBMongoDBRoleDefinition](./Update-AzCosmosDBMongoDBRoleDefinition.md)

[New-AzCosmosDBMongoDBUserDefinition](./New-AzCosmosDBMongoDBUserDefinition.md)

[Update-AzCosmosDBMongoDBUserDefinition](./Update-AzCosmosDBMongoDBUserDefinition.md)
