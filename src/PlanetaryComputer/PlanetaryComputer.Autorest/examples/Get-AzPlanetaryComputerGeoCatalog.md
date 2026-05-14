### Example 1: List all GeoCatalogs in the subscription
```powershell
Get-AzPlanetaryComputerGeoCatalog
```

```output
Name         Location    ResourceGroupName ProvisioningState
----         --------    ----------------- -----------------
mycatalog1   centralus   myResourceGroup   Succeeded
mycatalog2   eastus      testRG            Succeeded
```

Lists all GeoCatalog resources in the current subscription.

### Example 2: Get a specific GeoCatalog by name
```powershell
Get-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog1' -ResourceGroupName 'myResourceGroup'
```

```output
Name         Location    ResourceGroupName ProvisioningState
----         --------    ----------------- -----------------
mycatalog1   centralus   myResourceGroup   Succeeded
```

Gets a specific GeoCatalog resource by catalog name and resource group.

