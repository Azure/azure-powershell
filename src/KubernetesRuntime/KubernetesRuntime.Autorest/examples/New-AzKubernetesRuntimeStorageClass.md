### Example 1: Create a NFS storage class
```powershell
$typeProperties = New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject `
    -Server "0.0.0.0" `
    -Share "/share" `
    -MountPermission "777" `
    -OnDelete "Delete" `
    -SubDir "subdir"

New-AzKubernetesRuntimeStorageClass `
    -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 `
    -Name "nfs-test" `
    -TypeProperty $typeProperties
```

Create a NFS storage class `nfs-test` with parameters in the connected cluster.
