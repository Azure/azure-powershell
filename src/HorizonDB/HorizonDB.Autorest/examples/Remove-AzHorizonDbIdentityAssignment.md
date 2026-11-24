### Example 1: Delete a destination identity assignment
```powershell
Remove-AzHorizonDbIdentityAssignment -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -AssignmentName 'fabric-writer' -Confirm
```

Deletes the fabric-writer identity assignment after confirmation. Ensure the assignment is not the active destination identity before removing it.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
