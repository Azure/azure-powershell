### Example 1: Lists the Fleet resources in a subscription
```powershell
Get-AzFleet
```

```output
Location Name SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ETag                                   ResourceGroupName
-------- ---- -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----                                   -----------------
eastus   sss  11/14/2023 8:05:54 AM user1@example.com     User                    11/14/2023 8:05:54 AM    user1@example.com        User                         "25052d24-0000-0100-0000-65532a620000" ps1-test
eastus   ttt  11/14/2023 9:55:13 AM user1@example.com     User                    11/14/2023 9:55:13 AM    user1@example.com        User                         "29054cbc-0000-0100-0000-655344020000" ps1-test
```

This command lists the Fleet resources in a subscription.

### Example 2: Get specific fleet with specified name
```powershell
Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
```

```output
ETag                         : "61052549-0000-0100-0000-65542ab10000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : 
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : testfleet01
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
SystemDataCreatedAt          : 11/15/2023 2:19:28 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/15/2023 2:19:28 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command gets specific fleet with specified name.

