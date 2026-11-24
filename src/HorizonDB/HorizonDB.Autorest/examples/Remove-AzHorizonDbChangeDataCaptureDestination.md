### Example 1: Delete a change data capture destination
```powershell
Remove-AzHorizonDbChangeDataCaptureDestination -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -Confirm
```

Deletes the Microsoft Fabric destination after confirmation. Remove configurations that reference the destination before deleting it.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
