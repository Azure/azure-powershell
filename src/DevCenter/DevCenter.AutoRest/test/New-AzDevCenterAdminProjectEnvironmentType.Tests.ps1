if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminProjectEnvironmentType')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminProjectEnvironmentType.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminProjectEnvironmentType' {
    It 'CreateExpanded' {
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

        $envType = New-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName $env.envForProjEnvTypeNew -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -DeploymentTargetId $deploymentTargetId -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssignedIdentity $identityHashTable -Location $env.location -Status "Enabled" -UserRoleAssignment $userRoleAssignment
        $envType.IdentityType | Should -Be "SystemAssigned, UserAssigned"
        $envType.DeploymentTargetId | Should -Be $deploymentTargetId
        $envType.CreatorRoleAssignmentRole.Keys[0] | Should -Be "8e3af657-a8ff-443c-a75c-2fe8c4bcb635"
        $envType.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $envType.IdentityUserAssignedIdentity.Values[0].PrincipalId | Should -Be $env.identityPrincipalId
        $envType.UserRoleAssignment.Keys[0] | Should -Be $env.identityPrincipalId
        $envType.Name | Should -Be $env.envForProjEnvTypeNew
        $envType.Status | Should -Be "Enabled"
    }

}


