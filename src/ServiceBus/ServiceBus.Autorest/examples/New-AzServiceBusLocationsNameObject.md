### Example 1: Construct an in-memory NamespaceReplicaLocation object
```powershell
New-AzServiceBusLocationsNameObject -LocationName mylocation -RoleType Secondary
```
Creates an in-memory object of type `NamespaceReplicaLocation`. An array of `NamespaceReplicaLocation` can be fed as 
input to `GeoDataReplicationLocation` parameter of New-AzServiceBusNamespace and Set-AzServiceBusNamespace.