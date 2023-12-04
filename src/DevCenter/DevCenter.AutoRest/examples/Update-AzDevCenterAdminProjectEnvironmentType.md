### Example 1: Update a project environment type
```powershell
$deploymentTargetId = '/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff'
$creatorRoleAssignmentRole = @{"b24988ac-6180-42a0-ab88-20f7382dd24c" = @{} }
$userRoleAssignment = @{
    $env.identityPrincipalId = @{
        "roles" = @{
            "b24988ac-6180-42a0-ab88-20f7382dd24c" = @{}
        }
    }
}

Update-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName DevTest -ProjectName DevProject -ResourceGroupName testRg -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -IdentityType "SystemAssigned" -Status "Disabled" -UserRoleAssignment $userRoleAssignment
```
This command updates a project environment type named "DevTest" in the project "DevProject".

### Example 1: Update a project environment type
```powershell
$projEnvTypeInput =Get-AzDevCenterAdminProjectEnvironmentType -ProjectName DevProject -ResourceGroupName testRg -EnvironmentTypeName DevTest

$deploymentTargetId = '/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff'
$creatorRoleAssignmentRole = @{"b24988ac-6180-42a0-ab88-20f7382dd24c" = @{} }
$userRoleAssignment = @{
    $env.identityPrincipalId = @{
        "roles" = @{
            "b24988ac-6180-42a0-ab88-20f7382dd24c" = @{}
        }
    }
}

Update-AzDevCenterAdminProjectEnvironmentType -InputObject $projEnvTypeInput -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -IdentityType "SystemAssigned" -Status "Disabled" -UserRoleAssignment $userRoleAssignment
```
This command updates a project environment type named "DevTest" in the project "DevProject".
