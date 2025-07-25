### Example 1: Disable Arc storage class service in a connected cluster
```powershell
Disable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

```output
Name                           Value
----                           -----
K8sExtensionContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
StorageClassContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
Extension                      {…}
```

Disables Arc storage class service in a connected cluster. Returns the deleted Azure resources.

