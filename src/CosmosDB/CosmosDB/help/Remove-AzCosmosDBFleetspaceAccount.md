---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/remove-azcosmosdbfleetspaceaccount
schema: 2.0.0
---

# Remove-AzCosmosDBFleetspaceAccount

## SYNOPSIS
Removes a Cosmos DB database account from a Fleetspace.

## SYNTAX

### ByNameParameterSet (Default)
```
Remove-AzCosmosDBFleetspaceAccount -ResourceGroupName <String> -FleetName <String> -FleetspaceName <String>
 -Name <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Remove-AzCosmosDBFleetspaceAccount -InputObject <PSFleetspaceAccountGetResults> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzCosmosDBFleetspaceAccount** cmdlet removes a Cosmos DB database account from a Fleetspace. Note that this only removes the account from the Fleetspace; it does not delete the actual database account.

## EXAMPLES

### Example 1: Remove an account from a Fleetspace
```powershell
Remove-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" -Name "myAccount"
```

Removes the specified account from the Fleetspace.

### Example 2: Remove an account with PassThru
```powershell
Remove-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" -Name "myAccount" -PassThru
```

```output
True
```

Removes the account and returns True upon successful removal.

### Example 3: Remove an account using pipeline input
```powershell
Get-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" -Name "myAccount" | Remove-AzCosmosDBFleetspaceAccount
```

Gets an account object and removes it using pipeline input.

### Example 4: Remove all accounts from a Fleetspace
```powershell
Get-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" | Remove-AzCosmosDBFleetspaceAccount -PassThru
```

```output
True
True
True
```

Gets all accounts in a Fleetspace and removes them.

### Example 5: Remove account with confirmation
```powershell
Remove-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" -Name "myAccount" -Confirm
```

Prompts for confirmation before removing the account from the Fleetspace.

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

### -FleetspaceName
Name of the parent Fleetspace.

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
Fleetspace account object to remove.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceAccountGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the account to remove from the Fleetspace.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases: FleetspaceAccountName

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceAccountGetResults

## OUTPUTS

### System.Void

### System.Boolean

## NOTES

## RELATED LINKS

[Add-AzCosmosDBFleetspaceAccount](./Add-AzCosmosDBFleetspaceAccount.md)

[Get-AzCosmosDBFleetspaceAccount](./Get-AzCosmosDBFleetspaceAccount.md)
