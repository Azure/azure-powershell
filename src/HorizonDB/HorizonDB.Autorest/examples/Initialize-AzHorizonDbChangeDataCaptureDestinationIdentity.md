### Example 1: Activate a destination identity and drain existing sessions
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$assignmentId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/example-cluster/changeDataCaptureDestinations/fabric-mirroring/identityAssignments/fabric-writer"

Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -IdentityAssignmentResourceId $assignmentId -IfMatch '*' -DrainExistingSession | Format-List -Property Status, TargetIdentityAssignmentResourceId, PreviousIdentityAssignmentResourceId
```

```output
Status                               : Succeeded
TargetIdentityAssignmentResourceId   : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/example-cluster/changeDataCaptureDestinations/fabric-mirroring/identityA
                                       ssignments/fabric-writer
PreviousIdentityAssignmentResourceId : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/example-cluster/changeDataCaptureDestinations/fabric-mirroring/identityA
                                       ssignments/previous-writer
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
