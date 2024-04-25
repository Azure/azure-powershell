### Example 1: Creates a Fleet resource with none identity type
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

This command creates a Fleet resource with none identity type.


### Example 2: Creates a Fleet resource with EnableSystemAssignedIdentity
```powershell
New-AzFleet -Name testfleet02 -ResourceGroupName joyer-test -Location eastus -Tag @{"456"="asd"} -EnableSystemAssignedIdentity
```

```output
ETag                         : "0a006dc9-0000-0100-0000-661cd4f70000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.ContainerService/fleets/testfleet02
IdentityPrincipalId          : 978528a9-fa0f-4cdb-8282-95b3b30bb883
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : testfleet02
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 4/15/2024 7:19:15 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/15/2024 7:19:15 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "456": "asd"
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command creates a Fleet resource with system assigned identity type.


### Example 3: Creates a Fleet resource with user assigned identity type
```powershell
$mi = Get-AzUserAssignedIdentity -Name testUserAssignedMI -ResourceGroupName joyer-test
New-AzFleet -Name testfleet03 -ResourceGroupName joyer-test -Location eastus -Tag @{"789"="asd"} -UserAssignedIdentity $mi.Id
```

```output
ETag                         : "0a00e0c9-0000-0100-0000-661cd8010000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.ContainerService/fleets/testflee
                               t03
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : UserAssigned
IdentityUserAssignedIdentity : {
                                 "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-test/providers/Microsoft.ManagedIdentity/userAssignedI 
                               dentities/testUserAssignedMI": {
                                 }
                               }
Location                     : eastus
Name                         : testfleet03
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 4/15/2024 7:32:16 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/15/2024 7:32:16 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "789": "asd"
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command creates a Fleet resource with a long running operation.
