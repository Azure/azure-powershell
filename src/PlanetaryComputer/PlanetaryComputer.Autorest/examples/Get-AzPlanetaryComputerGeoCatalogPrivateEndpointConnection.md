### Example 1: List a GeoCatalog's private-endpoint connections
```powershell
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog"
```

Lists the private-endpoint connections associated with the GeoCatalog.

### Example 2: Get one private-endpoint connection
```powershell
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog" -Name "myConnection"
```

Gets the named connection and its approval state.
