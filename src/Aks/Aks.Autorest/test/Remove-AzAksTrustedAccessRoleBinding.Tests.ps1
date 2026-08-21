if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAksTrustedAccessRoleBinding'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAksTrustedAccessRoleBinding.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAksTrustedAccessRoleBinding' {
    It 'Delete' {
        Remove-AzAksTrustedAccessRoleBinding -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Name 'testBinding4'
    }

    It 'DeleteViaIdentityManagedCluster' {
        $aks = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)" }
        Remove-AzAksTrustedAccessRoleBinding -ManagedClusterInputObject $aks -Name 'testBinding5'
    }

    It 'DeleteViaIdentity' {
        $roleBinding = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/trustedAccessRoleBindings/testBinding6" }
        $roleBinding | Remove-AzAksTrustedAccessRoleBinding
    }
}
