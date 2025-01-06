### Example 1: Enable Arc storage class service in a connected cluster
```powershell
Enable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

```output
Name                           Value
----                           -----
K8sExtensionContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
StorageClassContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
Extension                      {…}
```

Enables Arc storage class service in a connected cluster. Returns the created Azure resources.


### Example 2: Enable Arc storage class service in a connected cluster using dev release train extension
```powershell
Enable-AzKubernetesRuntimeStorageClass -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -ReleaseTrain dev
```

```output
Name                           Value
----                           -----
K8sExtensionContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
StorageClassContributorRoleAs… Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
Extension                      {…}
```

Enables Arc storage class service in a connected cluster using dev release train extension. Returns the created Azure resources.

