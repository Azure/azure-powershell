### Example 1: Create a project environment type
```powershell
$identity = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/identityGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity1" = @{} }
$deploymentTargetId = '/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff'
$creatorRoleAssignmentRole = @{"8e3af657-a8ff-443c-a75c-2fe8c4bcb635" = @{} }
$userRoleAssignment = @{
    "e45e3m7c-176e-416a-b466-0c5ec8298f8a" = @{
        "roles" = @{
            "4cbf0b6c-e750-441c-98a7-10da8387e4d6" = @{}
        }
    }
}

New-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName DevTest -ProjectName DevProject -ResourceGroupName testRg -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -DeploymentTargetId $deploymentTargetId -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssignedIdentity $identity -Location "westus3" -Status "Enabled" -UserRoleAssignment $userRoleAssignment
```
This command creates a project environment type named "DevTest" in the project "DevProject".

### Example 2: Create a project environment type using InputObject
```powershell
$identity = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/identityGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity1" = @{} }
$deploymentTargetId = '/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff'
$creatorRoleAssignmentRole = @{"8e3af657-a8ff-443c-a75c-2fe8c4bcb635" = @{} }
$userRoleAssignment = @{
    "e45e3m7c-176e-416a-b466-0c5ec8298f8a" = @{
        "roles" = @{
            "4cbf0b6c-e750-441c-98a7-10da8387e4d6" = @{}
        }
    }
}

$envType = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProjectEnvironmentType -InputObject $envType -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -DeploymentTargetId $deploymentTargetId -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssignedIdentity $identity -Location "westus3" -Status "Enabled" -UserRoleAssignment $userRoleAssignment
```
This command creates a project environment type named "DevTest" in the project "DevProject".

