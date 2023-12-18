if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminProjectEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminProjectEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminProjectEnvironmentType' {
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

        $envType = Update-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName $env.projectEnvironmentTypeUpdate -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -IdentityType "SystemAssigned" -Status "Disabled" -UserRoleAssignment $userRoleAssignment
        $envType.IdentityType | Should -Be "SystemAssigned"
        $envType.DeploymentTargetId | Should -Be $deploymentTargetId
        $creatorRoles = $envType.CreatorRoleAssignmentRole.Keys | ConvertTo-Json | ConvertFrom-Json
        $creatorRoles[0] | Should -Be "8e3af657-a8ff-443c-a75c-2fe8c4bcb635"
        $creatorRoles[1] | Should -Be "b24988ac-6180-42a0-ab88-20f7382dd24c"
        $envType.UserRoleAssignment.Keys[0] | Should -Be $env.identityPrincipalId
        $envType.Name | Should -Be $env.projectEnvironmentTypeUpdate 
        $envType.Status | Should -Be "Disabled"
        }

    It 'UpdateViaIdentityExpanded' {
        $projEnvTypeInput = Get-AzDevCenterAdminProjectEnvironmentType -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -EnvironmentTypeName $env.projectEnvironmentTypeUpdate

        $deploymentTargetId = '/subscriptions/' + $env.subscriptionId
        $creatorRoleAssignmentRole = @{"b24988ac-6180-42a0-ab88-20f7382dd24c" = @{} }
        $userRoleAssignment = @{
            $env.identityPrincipalId = @{
                "roles" = @{
                    "b24988ac-6180-42a0-ab88-20f7382dd24c" = @{}
                }
            }
        }

        $envType = Update-AzDevCenterAdminProjectEnvironmentType -InputObject $projEnvTypeInput -CreatorRoleAssignmentRole $creatorRoleAssignmentRole -IdentityType "SystemAssigned" -Status "Disabled" -UserRoleAssignment $userRoleAssignment
        $envType.IdentityType | Should -Be "SystemAssigned"
        $envType.DeploymentTargetId | Should -Be $deploymentTargetId
        $creatorRoles = $envType.CreatorRoleAssignmentRole.Keys | ConvertTo-Json | ConvertFrom-Json
        $creatorRoles[0] | Should -Be "8e3af657-a8ff-443c-a75c-2fe8c4bcb635"
        $creatorRoles[1] | Should -Be "b24988ac-6180-42a0-ab88-20f7382dd24c"
        $envType.UserRoleAssignment.Keys[0] | Should -Be $env.identityPrincipalId
        $envType.Name | Should -Be $env.projectEnvironmentTypeUpdate 
        $envType.Status | Should -Be "Disabled" 
       }
}
