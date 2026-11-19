### Example 1: Delete a cluster
```powershell
Remove-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' -Confirm
```

Deletes the specified HorizonDB cluster after confirmation. Review the cluster and its dependent resources before confirming this destructive operation.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
