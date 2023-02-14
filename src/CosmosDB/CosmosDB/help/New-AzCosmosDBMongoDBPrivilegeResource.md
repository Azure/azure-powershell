---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbmongodbprivilegeresource
schema: 2.0.0
---

# New-AzCosmosDBMongoDBPrivilegeResource

## SYNOPSIS
Creates a new CosmosDB MongoDB PrivilegeResource object to be used to create or update  a CosmosDB MongoDB Role Definition.

## SYNTAX

```
New-AzCosmosDBMongoDBPrivilegeResource -Database <String> -Collection <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB MongoDB PrivilegeResource object to be used to create or update a CosmosDB MongoDB Role Definition.

## EXAMPLES

### Example 1
```powershell
$db = 'test'
$collection = 'coll'

New-AzCosmosDBMongoDBPrivilegeResource -Database $db -Collection $collection
```

```output
Object
Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilegeResource
```

## PARAMETERS

### -Collection
Collection Name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilegeResource
## NOTES

## RELATED LINKS

[New-AzCosmosDBMongoDBRoleDefinition](./New-AzCosmosDBMongoDBRoleDefinition.md)

[Update-AzCosmosDBMongoDBRoleDefinition](./Update-AzCosmosDBMongoDBRoleDefinition.md)
