### Example 1: Creates a Fleet resource
```powershell
New-AzFleet -Name sss -ResourceGroupName ps1-test -Location eastus
```

```output
ETag                         : "25052d24-0000-0100-0000-65532a620000"
Id                           : /subscriptions/'subscriptionId'/resourceGroups/ps1-test/providers/Microsoft.ContainerService/fleets/sss
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : 
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : sss
ProvisioningState            : Succeeded
ResourceGroupName            : ps1-test
SystemDataCreatedAt          : 11/14/2023 8:05:54 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/14/2023 8:05:54 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command creates a Fleet resource with a long running operation.
