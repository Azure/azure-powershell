if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksTrustedAccessRoleBinding'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksTrustedAccessRoleBinding.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksTrustedAccessRoleBinding' {
    It 'List' {
        $roleBindings = Get-AzAksTrustedAccessRoleBinding -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName 
        $roleBindings.Count | Should -Be 1
        $roleBindings.Name | Should -Be 'testBinding'
        $roleBindings.Role.Count | Should -Be 1
        $roleBindings.Role | Should -Contain 'Microsoft.MachineLearningServices/workspaces/mlworkload'
    }

    It 'GetViaIdentityManagedCluster' {
        $aks = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)" }
        $roleBindings = Get-AzAksTrustedAccessRoleBinding -ManagedClusterInputObject $aks -Name 'testBinding'
        $roleBindings.Count | Should -Be 1
        $roleBindings.Name | Should -Be 'testBinding'
        $roleBindings.Role.Count | Should -Be 1
        $roleBindings.Role | Should -Contain 'Microsoft.MachineLearningServices/workspaces/mlworkload'
    }

    It 'Get' {
        $roleBindings = Get-AzAksTrustedAccessRoleBinding -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Name 'testBinding'
        $roleBindings.Count | Should -Be 1
        $roleBindings.Name | Should -Be 'testBinding'
        $roleBindings.Role.Count | Should -Be 1
        $roleBindings.Role | Should -Contain 'Microsoft.MachineLearningServices/workspaces/mlworkload'
    }

    It 'GetViaIdentity' {
        $roleBinding = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/trustedAccessRoleBindings/testBinding" }
        $roleBindings = $roleBinding | Get-AzAksTrustedAccessRoleBinding
        $roleBindings.Count | Should -Be 1
        $roleBindings.Name | Should -Be 'testBinding'
        $roleBindings.Role.Count | Should -Be 1
        $roleBindings.Role | Should -Contain 'Microsoft.MachineLearningServices/workspaces/mlworkload'
    }
}
