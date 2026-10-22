### Example 1: Delete a node pool
```powershell
Remove-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool
```

Deletes the node pool `mynodepool` from cluster `myCluster`. The call blocks until the node pool is deleted. Delete node pools (and external auths) before deleting the cluster.

### Example 2: Delete a node pool and return a success result
```powershell
Remove-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -PassThru
```

Deletes the node pool `mynodepool` and returns `$true` on success. Use `-WhatIf` to preview the operation without deleting.
