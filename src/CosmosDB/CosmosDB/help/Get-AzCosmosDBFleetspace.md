---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbfleetspace
schema: 2.0.0
---

# Get-AzCosmosDBFleetspace

## SYNOPSIS
Gets Azure Cosmos DB Fleetspace information.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBFleetspace -ResourceGroupName <String> -FleetName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBFleetspace -ParentObject <PSFleetGetResults> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCosmosDBFleetspace** cmdlet retrieves information about Azure Cosmos DB Fleetspaces within a Fleet. You can get a specific Fleetspace by name or all Fleetspaces within a Fleet.

## EXAMPLES

### Example 1: Get a specific Fleetspace
```powershell
Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace"
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name              : myFleetspace
Type              : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind : NoSQL
ServiceTier       : GeneralPurpose
DataRegions       : {eastus, westus}
ProvisioningState : Succeeded
```

Gets information about the specified Fleetspace.

### Example 2: Get all Fleetspaces in a Fleet
```powershell
Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet"
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/fleetspace1
Name              : fleetspace1
Type              : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind : NoSQL
ServiceTier       : GeneralPurpose
DataRegions       : {eastus}
ProvisioningState : Succeeded

Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/fleetspace2
Name              : fleetspace2
Type              : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind : NoSQL
ServiceTier       : BusinessCritical
DataRegions       : {westus}
ProvisioningState : Succeeded
```

Gets all Fleetspaces within the specified Fleet.

### Example 3: Get Fleetspaces using parent Fleet object
```powershell
$fleet = Get-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet"
$fleet | Get-AzCosmosDBFleetspace
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name              : myFleetspace
Type              : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind : NoSQL
ServiceTier       : GeneralPurpose
DataRegions       : {eastus}
ProvisioningState : Succeeded
```

Gets Fleetspaces using a Fleet object from the pipeline.

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

### -FleetName
Name of the parent Fleet.

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

### -Name
Name of the Fleetspace. If not specified, returns all Fleetspaces in the Fleet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FleetspaceName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Fleet object representing the parent Fleet.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults

## NOTES

## RELATED LINKS

[New-AzCosmosDBFleetspace](./New-AzCosmosDBFleetspace.md)

[Update-AzCosmosDBFleetspace](./Update-AzCosmosDBFleetspace.md)

[Remove-AzCosmosDBFleetspace](./Remove-AzCosmosDBFleetspace.md)
