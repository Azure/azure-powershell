### Example 1: Delete a pool
```powershell
Remove-AzHorizonDbPool -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01'
```

Deletes the specified HorizonDB pool after confirmation.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
