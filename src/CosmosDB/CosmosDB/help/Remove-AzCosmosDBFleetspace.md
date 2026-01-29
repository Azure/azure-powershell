---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/remove-azcosmosdbfleetspace
schema: 2.0.0
---

# Remove-AzCosmosDBFleetspace

## SYNOPSIS
Deletes an Azure Cosmos DB Fleetspace.

## SYNTAX

### ByNameParameterSet (Default)
```
Remove-AzCosmosDBFleetspace -ResourceGroupName <String> -FleetName <String> -Name <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Remove-AzCosmosDBFleetspace -InputObject <PSFleetspaceGetResults> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzCosmosDBFleetspace** cmdlet deletes an Azure Cosmos DB Fleetspace. Note that all accounts within the Fleetspace must be removed before deleting the Fleetspace.

## EXAMPLES

### Example 1: Delete a Fleetspace by name
```powershell
Remove-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace"
```

Deletes the specified Fleetspace from the Fleet.

### Example 2: Delete a Fleetspace with PassThru
```powershell
Remove-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace" -PassThru
```

```output
True
```

Deletes the Fleetspace and returns True upon successful deletion.

### Example 3: Delete a Fleetspace using pipeline input
```powershell
Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace" | Remove-AzCosmosDBFleetspace
```

Gets a Fleetspace object and deletes it using pipeline input.

### Example 4: Delete all Fleetspaces in a Fleet
```powershell
Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" | Remove-AzCosmosDBFleetspace -PassThru
```

```output
True
True
True
```

Gets all Fleetspaces in a Fleet and deletes them.

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

### -InputObject
Fleetspace object to delete.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Fleetspace to delete.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases: FleetspaceName

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults

## OUTPUTS

### System.Void

### System.Boolean

## NOTES

## RELATED LINKS

[New-AzCosmosDBFleetspace](./New-AzCosmosDBFleetspace.md)

[Get-AzCosmosDBFleetspace](./Get-AzCosmosDBFleetspace.md)

[Update-AzCosmosDBFleetspace](./Update-AzCosmosDBFleetspace.md)
