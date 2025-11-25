---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/add-azcosmosdbfleetspaceaccount
schema: 2.0.0
---

# Add-AzCosmosDBFleetspaceAccount

## SYNOPSIS
Adds an existing Cosmos DB database account to a Fleetspace.

## SYNTAX

### ByNameParameterSet (Default)
```
Add-AzCosmosDBFleetspaceAccount -ResourceGroupName <String> -FleetName <String> -FleetspaceName <String>
 -Name <String> -GlobalDatabaseAccountResourceId <String> -GlobalDatabaseAccountLocation <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Add-AzCosmosDBFleetspaceAccount -ParentObject <PSFleetspaceGetResults> -Name <String>
 -GlobalDatabaseAccountResourceId <String> -GlobalDatabaseAccountLocation <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzCosmosDBFleetspaceAccount** cmdlet adds an existing Cosmos DB database account to a Fleetspace, enabling unified management and resource sharing within the Fleet.

## EXAMPLES

### Example 1: Add a database account to a Fleetspace
```powershell
$accountResourceId = "/subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/myAccount"
Add-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" -Name "myAccount" `
    -GlobalDatabaseAccountResourceId $accountResourceId -GlobalDatabaseAccountLocation "eastus"
```

```output
Id                                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace/accounts/myAccount
Name                              : myAccount
Type                              : Microsoft.DocumentDB/fleets/fleetspaces/accounts
GlobalDatabaseAccountResourceId   : /subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/myAccount
GlobalDatabaseAccountLocation     : eastus
ProvisioningState                 : Succeeded
```

Adds an existing database account to the specified Fleetspace.

### Example 2: Add a database account using parent Fleetspace object
```powershell
$fleetspace = Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace"
$accountResourceId = "/subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/myAccount"
$fleetspace | Add-AzCosmosDBFleetspaceAccount -Name "myAccount" `
    -GlobalDatabaseAccountResourceId $accountResourceId -GlobalDatabaseAccountLocation "eastus"
```

```output
Id                                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace/accounts/myAccount
Name                              : myAccount
Type                              : Microsoft.DocumentDB/fleets/fleetspaces/accounts
GlobalDatabaseAccountResourceId   : /subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/myAccount
GlobalDatabaseAccountLocation     : eastus
ProvisioningState                 : Succeeded
```

Adds a database account using a Fleetspace object from the pipeline.

### Example 3: Add multiple accounts to a Fleetspace
```powershell
$fleetspace = Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace"
$accounts = @(
    @{Name="account1"; ResourceId="/subscriptions/{sub}/resourceGroups/rg/providers/Microsoft.DocumentDB/databaseAccounts/account1"; Location="eastus"}
    @{Name="account2"; ResourceId="/subscriptions/{sub}/resourceGroups/rg/providers/Microsoft.DocumentDB/databaseAccounts/account2"; Location="westus"}
)

foreach ($account in $accounts) {
    $fleetspace | Add-AzCosmosDBFleetspaceAccount -Name $account.Name `
        -GlobalDatabaseAccountResourceId $account.ResourceId `
        -GlobalDatabaseAccountLocation $account.Location
}
```

Adds multiple database accounts to a Fleetspace in a loop.

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

### -GlobalDatabaseAccountLocation
The Azure region/location of the database account to add.

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

### -GlobalDatabaseAccountResourceId
The full Azure resource ID of the existing Cosmos DB database account to add to the Fleetspace.

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
Name of the account reference within the Fleetspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FleetspaceAccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Fleetspace object representing the parent Fleetspace.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults
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

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceAccountGetResults

## NOTES

## RELATED LINKS

[Get-AzCosmosDBFleetspaceAccount](./Get-AzCosmosDBFleetspaceAccount.md)

[Remove-AzCosmosDBFleetspaceAccount](./Remove-AzCosmosDBFleetspaceAccount.md)
