### Example 1: Delete a GeoCatalog private-endpoint connection
```powershell
Remove-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog" -Name "myConnection"
```

Deletes the connection on the GeoCatalog. The network private endpoint must be managed separately.
