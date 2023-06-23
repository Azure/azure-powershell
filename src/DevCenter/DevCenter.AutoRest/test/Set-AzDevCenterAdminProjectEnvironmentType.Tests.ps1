if (($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminProjectEnvironmentType')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminProjectEnvironmentType.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminProjectEnvironmentType' {
    It 'UpdateExpanded' {
        $deploymentTargetId = '/subscriptions/' + $env.subscriptionId
        $creatorRoleAssignmentRole = @{"b24988ac-6180-42a0-ab88-20f7382dd24c" = @{} }
        $userRoleAssignment = @{
            $env.identityPrincipalId = @{
                "roles" = @{
                    "b24988ac-6180-42a0-ab88-20f7382dd24c" = @{}
                }
            }
        }

        $envType = Set-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName $env.projectEnvironmentTypeSet -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -DeploymentTargetId $deploymentTargetId -IdentityType "SystemAssigned" -Location $env.location -Status "Disabled" -UserRoleAssignment $userRoleAssignment
        $envType.IdentityType | Should -Be "SystemAssigned"
        $envType.DeploymentTargetId | Should -Be $deploymentTargetId
        $envType.CreatorRoleAssignmentRole.Keys[0] | Should -Be "b24988ac-6180-42a0-ab88-20f7382dd24c"
        $envType.UserRoleAssignment.Keys[0] | Should -Be $env.identityPrincipalId
        $envType.Name | Should -Be $env.projectEnvironmentTypeSet 
        $envType.Status | Should -Be "Disabled"
    }

    It 'Update' {
        $identityHashTable = @{$env.identityId = @{} }
        $deploymentTargetId = '/subscriptions/' + $env.subscriptionId
        $creatorRoleAssignmentRole = @{"8e3af657-a8ff-443c-a75c-2fe8c4bcb635" = @{} }
        $userRoleAssignment = @{
            $env.identityPrincipalId = @{
                "roles" = @{
                    "8e3af657-a8ff-443c-a75c-2fe8c4bcb635" = @{}
                }
            }
        }
        
        $body = @{"Location" = $env.location; "IdentityUserAssignedIdentity" = $identityHashTable; "CreatorRoleAssignmentRole" = $creatorRoleAssignmentRole; "DeploymentTargetId" = $deploymentTargetId ; "IdentityType" = "SystemAssigned,UserAssigned"; "Status" = "Enabled" ; "UserRoleAssignment" = $userRoleAssignment }
        $envType = Set-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName $env.projectEnvironmentTypeSet -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Body $body

        $envType.IdentityType | Should -Be "SystemAssigned, UserAssigned"
        $envType.DeploymentTargetId | Should -Be $deploymentTargetId
        $envType.CreatorRoleAssignmentRole.Keys[0] | Should -Be "8e3af657-a8ff-443c-a75c-2fe8c4bcb635"
        $envType.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $envType.IdentityUserAssignedIdentity.Values[0].PrincipalId | Should -Be $env.identityPrincipalId
        $envType.UserRoleAssignment.Keys[0] | Should -Be $env.identityPrincipalId
        $envType.Name | Should -Be $env.projectEnvironmentTypeSet
        $envType.Status | Should -Be "Enabled"

    }
}
