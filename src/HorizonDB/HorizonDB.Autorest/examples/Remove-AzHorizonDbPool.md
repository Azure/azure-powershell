### Example 1: Delete a pool from a cluster that has multiple pools
```powershell
Remove-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-02' -Confirm
```

Deletes `example-pool-02` after confirmation. The cluster must contain at least one other pool.

> [!IMPORTANT]
> Currently, a pool cannot be deleted if it is the only pool in the cluster.
