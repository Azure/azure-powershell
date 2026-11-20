### Example 1: Assign a managed identity to a change data capture destination
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$identityId = "/subscriptions/$subscriptionId/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer"

New-AzHorizonDbIdentityAssignment -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -AssignmentName 'fabric-writer' -IdentityResourceId $identityId | Format-List -Property Name, IdentityResourceId, ValidationState, ActivationState, ProvisioningState
```

```output
Name               : fabric-writer
IdentityResourceId : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer
ValidationState    : Succeeded
ActivationState    : Inactive
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
