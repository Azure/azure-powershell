### Example 1: Update a GeoCatalog private-endpoint connection description
```powershell
Update-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog" -Name "myConnection" -PrivateLinkServiceConnectionStateDescription "Reviewed by the catalog owner"
```

Updates the description while preserving the connection's current approval state.
