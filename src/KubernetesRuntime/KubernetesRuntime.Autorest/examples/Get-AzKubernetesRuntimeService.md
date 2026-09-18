### Example 1: Get all Kubernetes Runtime service objects in a cluster
```powershell
Get-AzKubernetesRuntimeService -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1
```

```output
Id                           : /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1/providers/Microsoft.KubernetesRuntime/services/storageclass
Name                         : storageclass
ProvisioningState            : Succeeded
ResourceGroupName            : example
RpObjectId                   : 00000000-1111-2222-3333-444444444444
SystemDataCreatedAt          : 3/1/2024 0:00:00 AM
SystemDataCreatedBy          : user@user.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/1/2024 0:00:00 AM
SystemDataLastModifiedBy     : user@user.com
SystemDataLastModifiedByType : User
Type                         : microsoft.kubernetesruntime/services
```

Get all Kubernetes Runtime service objects for the connected cluster.

### Example 2: Get a Kubernetes Runtime service object for a connected cluster.
```powershell
Get-AzKubernetesRuntimeService -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name storageclass
```

```output
Id                           : /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1/providers/Microsoft.KubernetesRuntime/services/storageclass
Name                         : storageclass
ProvisioningState            : Succeeded
ResourceGroupName            : example
RpObjectId                   : 00000000-1111-2222-3333-444444444444
SystemDataCreatedAt          : 3/1/2024 0:00:00 AM
SystemDataCreatedBy          : user@user.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/1/2024 0:00:00 AM
SystemDataLastModifiedBy     : user@user.com
SystemDataLastModifiedByType : User
Type                         : microsoft.kubernetesruntime/services
```

Get a Kubernetes Runtime service object for a connected cluster.

