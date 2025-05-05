### Example 1: {{ Add title here }}
```powershell
New-AzEventHubLocationsNameObject -LocationName mylocation -RoleType Secondary
```
Creates an in-memory object of type `INamespaceReplicaLocation`. An array of `INamespaceReplicaLocation` can be fed as 
input to `ReplicaLocation` parameter of New-AzEventHubNamespaceV2 and Set-AzEventHubNamespaceV2.
