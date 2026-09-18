---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbfleet
schema: 2.0.0
---

# New-AzCosmosDBFleet

## SYNOPSIS
Creates a new Azure Cosmos DB Fleet.

## SYNTAX

```
New-AzCosmosDBFleet -ResourceGroupName <String> -Name <String> -Location <String> [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBFleet** cmdlet creates a new Azure Cosmos DB Fleet. A Fleet is a logical container that enables you to manage multiple Cosmos DB database accounts together, providing unified management and resource optimization capabilities.

## EXAMPLES

### Example 1: Create a new Cosmos DB Fleet
```powershell
New-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet" -Location "eastus"
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet
Name              : myFleet
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {}
ProvisioningState : Succeeded
```

Creates a new Cosmos DB Fleet named "myFleet" in the "eastus" region.

### Example 2: Create a new Cosmos DB Fleet with tags
```powershell
$tags = @{
    "Environment" = "Production"
    "Department" = "IT"
}
New-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet" -Location "eastus" -Tag $tags
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet
Name              : myFleet
Location          : eastus
Type              : Microsoft.DocumentDB/fleets
Tags              : {[Environment, Production], [Department, IT]}
ProvisioningState : Succeeded
```

Creates a new Cosmos DB Fleet with resource tags.

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

### -Location
The Azure region where the Fleet will be created.

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

### -Name
Name of the Cosmos DB Fleet. Must be unique within the subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FleetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group where the Fleet will be created.

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

### -Tag
Hashtable of tags to associate with the Fleet resource.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults

## NOTES

## RELATED LINKS

[Get-AzCosmosDBFleet](./Get-AzCosmosDBFleet.md)

[Update-AzCosmosDBFleet](./Update-AzCosmosDBFleet.md)

[Remove-AzCosmosDBFleet](./Remove-AzCosmosDBFleet.md)
