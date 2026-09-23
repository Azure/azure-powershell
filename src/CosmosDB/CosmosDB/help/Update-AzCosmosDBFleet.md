---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbfleet
schema: 2.0.0
---

# Update-AzCosmosDBFleet

## SYNOPSIS
Updates an Azure Cosmos DB Fleet.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzCosmosDBFleet -ResourceGroupName <String> -Name <String> [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBFleet -InputObject <PSFleetGetResults> [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzCosmosDBFleet** cmdlet updates properties of an existing Azure Cosmos DB Fleet, such as tags.

## EXAMPLES

### Example 1: Update Fleet tags by name
```powershell
$tags = @{
    "Environment" = "Production"
    "CostCenter" = "IT"
}
Update-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet" -Tag $tags
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet
Name              : myFleet
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {[Environment, Production], [CostCenter, IT]}
ProvisioningState : Succeeded
```

Updates the tags for the specified Fleet.

### Example 2: Update Fleet using pipeline input
```powershell
$fleet = Get-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet"
$fleet | Update-AzCosmosDBFleet -Tag @{"UpdatedBy" = "Admin"}
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet
Name              : myFleet
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {[UpdatedBy, Admin]}
ProvisioningState : Succeeded
```

Gets a Fleet object and updates it using pipeline input.

## PARAMETERS

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

### -InputObject
Fleet object to update.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Cosmos DB Fleet to update.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases: FleetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

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

### -Tag
Hashtable of tags to update on the Fleet resource.

```yaml
Type: System.Collections.Hashtable
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults

## NOTES

## RELATED LINKS

[New-AzCosmosDBFleet](./New-AzCosmosDBFleet.md)

[Get-AzCosmosDBFleet](./Get-AzCosmosDBFleet.md)

[Remove-AzCosmosDBFleet](./Remove-AzCosmosDBFleet.md)
