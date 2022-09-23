---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbmongodbprivilegere
schema: 2.0.0
---

# New-AzCosmosDBMongoDBPrivilege

## SYNOPSIS
Creates a new CosmosDB MongoDB Privilege object to be used to create or update  a CosmosDB MongoDB Role Definition.

## SYNTAX

```
New-AzCosmosDBMongoDBPrivilege -PrivilegeResource <Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilegeResource>  -Actions <String[]> 
 [-WhatIf] [-Confirm] [<CommonParameters>]
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

## -PrivilegeResource
Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilegeResource Object.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilegeResource
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False

## -Actions
Array of valid Actions(e.g. insert, find).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False

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

### None
## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSMongoPrivilege
## NOTES

## RELATED LINKS
[New-AzCosmosDBMongoDBRoleDefinition](./New-AzCosmosDBMongoDBRoleDefinition.md)

[Update-AzCosmosDBMongoDBRoleDefinition](./Update-AzCosmosDBMongoDBRoleDefinition.md)

[Update-AzCosmosDBMongoDBPrivilegeResource](./Update-AzCosmosDBMongoDBPrivilegeResource.md)
