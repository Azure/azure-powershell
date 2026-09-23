---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdbfleetspaceaccount
schema: 2.0.0
---

# Get-AzCosmosDBFleetspaceAccount

## SYNOPSIS
Gets information about Cosmos DB database accounts within a Fleetspace.

## SYNTAX

### ByNameParameterSet (Default)
```
Get-AzCosmosDBFleetspaceAccount -ResourceGroupName <String> -FleetName <String> -FleetspaceName <String>
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzCosmosDBFleetspaceAccount -ParentObject <PSFleetspaceGetResults> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzCosmosDBFleetspaceAccount** cmdlet retrieves information about Cosmos DB database accounts that have been added to a Fleetspace. You can get a specific account by name or all accounts within a Fleetspace.

## EXAMPLES

### Example 1: Get a specific account in a Fleetspace
```powershell
Get-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace" -Name "myAccount"
```

```output
Id                                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace/accounts/myAccount
Name                              : myAccount
Type                              : Microsoft.DocumentDB/fleets/fleetspaces/accounts
GlobalDatabaseAccountResourceId   : /subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/myAccount
GlobalDatabaseAccountLocation     : eastus
ProvisioningState                 : Succeeded
```

Gets information about a specific account within the Fleetspace.

### Example 2: Get all accounts in a Fleetspace
```powershell
Get-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace"
```

```output
Id                                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace/accounts/account1
Name                              : account1
Type                              : Microsoft.DocumentDB/fleets/fleetspaces/accounts
GlobalDatabaseAccountResourceId   : /subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/account1
GlobalDatabaseAccountLocation     : eastus
ProvisioningState                 : Succeeded

Id                                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace/accounts/account2
Name                              : account2
Type                              : Microsoft.DocumentDB/fleets/fleetspaces/accounts
GlobalDatabaseAccountResourceId   : /subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/account2
GlobalDatabaseAccountLocation     : westus
ProvisioningState                 : Succeeded
```

Gets all accounts within the specified Fleetspace.

### Example 3: Get accounts using parent Fleetspace object
```powershell
$fleetspace = Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace"
$fleetspace | Get-AzCosmosDBFleetspaceAccount
```

```output
Id                                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace/accounts/myAccount
Name                              : myAccount
Type                              : Microsoft.DocumentDB/fleets/fleetspaces/accounts
GlobalDatabaseAccountResourceId   : /subscriptions/{subscriptionId}/resourceGroups/myRG/providers/Microsoft.DocumentDB/databaseAccounts/myAccount
GlobalDatabaseAccountLocation     : eastus
ProvisioningState                 : Succeeded
```

Gets accounts using a Fleetspace object from the pipeline.

### Example 4: Count accounts in a Fleetspace
```powershell
$accounts = Get-AzCosmosDBFleetspaceAccount -ResourceGroupName "myResourceGroup" -FleetName "myFleet" `
    -FleetspaceName "myFleetspace"
Write-Host "Total accounts in Fleetspace: $($accounts.Count)"
```

```output
Total accounts in Fleetspace: 5
```

Gets all accounts and displays the count.

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

### -Name
Name of the account. If not specified, returns all accounts in the Fleetspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FleetspaceAccountName

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceAccountGetResults

## NOTES

## RELATED LINKS

[Add-AzCosmosDBFleetspaceAccount](./Add-AzCosmosDBFleetspaceAccount.md)

[Remove-AzCosmosDBFleetspaceAccount](./Remove-AzCosmosDBFleetspaceAccount.md)
