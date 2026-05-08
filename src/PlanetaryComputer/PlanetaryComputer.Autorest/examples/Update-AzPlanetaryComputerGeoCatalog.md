### Example 1: Update tags on a GeoCatalog
```powershell
Update-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -Tag @{environment='production'; team='geospatial'}
```

```output
Name        Location    ResourceGroupName ProvisioningState
----        --------    ----------------- -----------------
mycatalog   centralus   myResourceGroup   Succeeded
```

Updates the tags on an existing GeoCatalog resource.

### Example 2: Assign a user-assigned managed identity to a GeoCatalog
```powershell
Update-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -UserAssignedIdentity @('/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity')
```

```output
Name        Location    ResourceGroupName ProvisioningState
----        --------    ----------------- -----------------
mycatalog   centralus   myResourceGroup   Succeeded
```

Assigns a user-assigned managed identity to the specified GeoCatalog.

