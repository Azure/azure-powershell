---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbmongodbprivilege
schema: 2.0.0
---

# New-AzCosmosDBMongoDBPrivilege

## SYNOPSIS
Creates a new CosmosDB MongoDB Privilege object to be used to create or update  a CosmosDB MongoDB Role Definition.

## SYNTAX

```
New-AzCosmosDBMongoDBPrivilege [-PrivilegeResource <PSMongoPrivilegeResource>] [-Actions <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB MongoDB Privilege object to be used to create or update a CosmosDB MongoDB Role Definition.

## EXAMPLES

### Example 1
```powershell
$db = 'test'
$collection = 'coll'
$Actions = 'insert', 'find'
$PrivilegeResource = New-AzCosmosDBMongoDBPrivilegeResource -Database $db -Collection $collection

New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $PrivilegeResource -Actions $Actions
```

```output
Object
Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilege
```

## PARAMETERS

### -Actions
Array of valid Actions(e.g. insert, find).

```yaml
Type: System.String[]
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

### -PrivilegeResource
Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilegeResource Object.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB.PSMongoPrivilegeResource
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilege
## NOTES

## RELATED LINKS

[New-AzCosmosDBMongoDBRoleDefinition](./New-AzCosmosDBMongoDBRoleDefinition.md)

[Update-AzCosmosDBMongoDBRoleDefinition](./Update-AzCosmosDBMongoDBRoleDefinition.md)
