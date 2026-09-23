### Example 1: Create a new GeoCatalog
```powershell
New-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -Location 'centralus'
```

```output
Name        Location    ResourceGroupName ProvisioningState
----        --------    ----------------- -----------------
mycatalog   centralus   myResourceGroup   Succeeded
```

Creates a new GeoCatalog resource in the specified resource group and location. This is a long-running operation that may take several minutes to complete.

### Example 2: Create a new GeoCatalog with tags
```powershell
New-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -Location 'centralus' -Tag @{environment='test'}
```

```output
Name        Location    ResourceGroupName ProvisioningState
----        --------    ----------------- -----------------
mycatalog   centralus   myResourceGroup   Succeeded
```

Creates a new GeoCatalog resource with the specified tags.

