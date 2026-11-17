### Example 1: List destination identity assignments
```powershell
Get-AzHorizonDbIdentityAssignment -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' | Format-List -Property Name, IdentityResourceId, ValidationState, ActivationState, ProvisioningState
```

```output
Name               : fabric-writer
IdentityResourceId : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer
ValidationState    : Succeeded
ActivationState    : Active
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a destination identity assignment
```powershell
Get-AzHorizonDbIdentityAssignment -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -AssignmentName 'fabric-writer' | Format-List -Property Name, IdentityResourceId, ValidationState, ActivationState, ProvisioningState
```

```output
Name               : fabric-writer
IdentityResourceId : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer
ValidationState    : Succeeded
ActivationState    : Active
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
