### Example 1: Delete the change data capture capability
```powershell
Remove-AzHorizonDbChangeDataCaptureCapability -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster'
```

Deletes the cluster change data capture capability after confirmation. Remove dependent change data capture resources first.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
