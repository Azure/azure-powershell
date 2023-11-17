### Example 1: Abort the currently running operation on the managed cluster.
```powershell
Invoke-AzAksAbortManagedClusterLatestOperation -ResourceGroupName mygroup -ResourceName mycluster
```

Abort the currently running operation on the managed cluster "mycluster". The Managed Cluster will be moved to a Canceling state and eventually to a Canceled state when cancellation finishes. If the operation completes before cancellation can take place, a 409 error code is returned.


