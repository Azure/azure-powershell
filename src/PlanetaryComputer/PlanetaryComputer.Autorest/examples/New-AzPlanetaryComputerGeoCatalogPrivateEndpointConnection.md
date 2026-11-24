### Example 1: Approve a pending GeoCatalog private-endpoint connection
```powershell
New-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog" -Name "myConnection" -PrivateLinkServiceConnectionStateStatus "Approved" -PrivateLinkServiceConnectionStateDescription "Approved by the catalog owner"
```

Approves a connection already requested by a private endpoint. This cmdlet does not create the network private endpoint itself.
