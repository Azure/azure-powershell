---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/remove-azcosmosdbfleet
schema: 2.0.0
---

# Remove-AzCosmosDBFleet

## SYNOPSIS
Deletes an Azure Cosmos DB Fleet.

## SYNTAX

### ByNameParameterSet (Default)
```
Remove-AzCosmosDBFleet -ResourceGroupName <String> -Name <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Remove-AzCosmosDBFleet -InputObject <PSFleetGetResults> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzCosmosDBFleet** cmdlet deletes an Azure Cosmos DB Fleet. Note that all Fleetspaces within the Fleet must be removed before deleting the Fleet.

## EXAMPLES

### Example 1: Delete a Fleet by name
```powershell
Remove-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet"
```

Deletes the Fleet named "myFleet" from the specified resource group.

### Example 2: Delete a Fleet with PassThru
```powershell
Remove-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet" -PassThru
```

```output
True
```

Deletes the Fleet and returns True upon successful deletion.

### Example 3: Delete a Fleet using pipeline input
```powershell
Get-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet" | Remove-AzCosmosDBFleet
```

Gets a Fleet object and deletes it using pipeline input.

### Example 4: Delete a Fleet with confirmation
```powershell
Remove-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet" -Confirm
```

Prompts for confirmation before deleting the Fleet.

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
Fleet object to delete.

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
Name of the Cosmos DB Fleet to delete.

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

### -PassThru
Returns True if the operation succeeds.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### System.Void

### System.Boolean

## NOTES

## RELATED LINKS

[New-AzCosmosDBFleet](./New-AzCosmosDBFleet.md)

[Get-AzCosmosDBFleet](./Get-AzCosmosDBFleet.md)

[Update-AzCosmosDBFleet](./Update-AzCosmosDBFleet.md)
