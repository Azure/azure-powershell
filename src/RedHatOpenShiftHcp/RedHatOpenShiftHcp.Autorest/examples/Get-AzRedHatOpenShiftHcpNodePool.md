### Example 1: List all node pools in a cluster
```powershell
Get-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB VersionId
----        -------- ----------------- ------- --------------   ------------- ---------
mynodepool  eastus   Succeeded         2       Standard_D8s_v3  128           4.22.18
worker-pool eastus   Succeeded         3       Standard_D8s_v3  64            4.22.18
```

Lists all node pools belonging to cluster `myCluster`.

### Example 2: Get a single node pool by name
```powershell
Get-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB OSDiskStorageAccountType VersionId
----        -------- ----------------- ------- --------------   ------------- ------------------------ ---------
mynodepool  eastus   Succeeded         2       Standard_D8s_v3  128           StandardSSD_LRS          4.22.18
```

Retrieves the single node pool `mynodepool`. The osDisk/platform properties are flattened on the returned `INodePool` object (`OSDiskSizeGiB`, `PlatformVMSize`, `Replica`), not the nested API shape `.Platform.OSDisk.*`.
