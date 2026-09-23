### Example 1: Delete a GeoCatalog by name
```powershell
Remove-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup'
```

Deletes the specified GeoCatalog resource. This is a long-running operation that may take several minutes to complete.

### Example 2: Delete a GeoCatalog without waiting for completion
```powershell
Remove-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -NoWait
```

Starts the deletion of the specified GeoCatalog resource and returns immediately without waiting for the operation to complete.

