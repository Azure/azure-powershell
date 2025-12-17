---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbfleet
schema: 2.0.0
---

# Get-AzCosmosDBFleet

## SYNOPSIS
Gets Azure Cosmos DB Fleet information.

## SYNTAX

```
Get-AzCosmosDBFleet [-ResourceGroupName <String>] [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCosmosDBFleet** cmdlet retrieves information about Azure Cosmos DB Fleets. You can get a specific Fleet by name, all Fleets in a resource group, or all Fleets in the subscription.

## EXAMPLES

### Example 1: Get a specific Cosmos DB Fleet
```powershell
Get-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet"
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet
Name              : myFleet
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {}
ProvisioningState : Succeeded
```

Gets information about the Fleet named "myFleet" in the specified resource group.

### Example 2: Get all Fleets in a resource group
```powershell
Get-AzCosmosDBFleet -ResourceGroupName "myResourceGroup"
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet1
Name              : myFleet1
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {}
ProvisioningState : Succeeded

Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet2
Name              : myFleet2
Location          : westus
Type              : Microsoft.DocumentDB/fleets
Tags              : {}
ProvisioningState : Succeeded
```

Gets all Fleets in the specified resource group.

### Example 3: Get all Fleets in the subscription
```powershell
Get-AzCosmosDBFleet
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/rg1/providers/Microsoft.DocumentDB/fleets/fleet1
Name              : fleet1
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {}
ProvisioningState : Succeeded

Id                : /subscriptions/{subscriptionId}/resourceGroups/rg2/providers/Microsoft.DocumentDB/fleets/fleet2
Name              : fleet2
Location          : westus
Type              : Microsoft.DocumentDB/fleets
Tags              : {}
ProvisioningState : Succeeded
```

Gets all Fleets in the current subscription.

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

### -Name
Name of the Cosmos DB Fleet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FleetName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group. If not specified, lists all Fleets in the subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults

## NOTES

## RELATED LINKS

[New-AzCosmosDBFleet](./New-AzCosmosDBFleet.md)

[Update-AzCosmosDBFleet](./Update-AzCosmosDBFleet.md)

[Remove-AzCosmosDBFleet](./Remove-AzCosmosDBFleet.md)
