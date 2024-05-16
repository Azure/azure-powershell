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


### Example 2: disable system assigned identity of specified fleet
```powershell
Update-AzFleet -ResourceGroupName joyer-test -Name testfleet03 -EnableSystemAssignedIdentity 0
```

```output
ETag                         : "0a00e5cc-0000-0100-0000-661cea3b0000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.ContainerService/fleets/testflee 
                               t02
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : testfleet02
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 4/15/2024 7:19:15 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/15/2024 8:50:01 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "456": "asd"
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command updates EnableSystemAssignedIdentity of a fleet.
