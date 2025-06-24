### Example 1: Construct an in-memory NamespaceReplicaLocation object
```powershell
New-AzEventHubLocationsNameObject -LocationName mylocation -RoleType Secondary -ClusterArmId clusterid
```
Creates an in-memory object of type `INamespaceReplicaLocation`. An array of `INamespaceReplicaLocation` can be fed as 
input to `GeoDataReplicationLocation` parameter of New-AzEventHubNamespace and Set-AzEventHubNamespace.