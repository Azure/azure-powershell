### Example 1: Create a Kubernetes Runtime service for storage class service
```powershell
New-AzKubernetesRuntimeService -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 -Name storageclass
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

Create a Kubernetes Runtime service object for storage class service.
