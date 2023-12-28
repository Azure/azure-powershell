### Example 1: Update tag of specified fleet
```powershell
Update-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test -Tag @{"123"="abc"}
```

```output
ETag                         : "cb06f006-0000-0100-0000-655c7e120000"
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
SystemDataLastModifiedAt     : 11/21/2023 9:53:21 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "123": "abc"
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command updates tag of a fleet.

