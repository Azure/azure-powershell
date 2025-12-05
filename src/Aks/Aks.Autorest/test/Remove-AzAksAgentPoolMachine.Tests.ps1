if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAksAgentPoolMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAksAgentPoolMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAksAgentPoolMachine' {
    It 'DeleteExpanded' {
        Remove-AzAksAgentPoolMachine -AgentPoolName default -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -MachineName 'aks-default-12988240-vmss000008'
    }
    
    It 'DeleteViaIdentityExpanded'{
        $pool = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/agentPools/default" }
        Remove-AzAksAgentPoolMachine -InputObject $pool -MachineName 'aks-default-12988240-vmss000009' 
    }

    It 'DeleteViaIdentityManagedClusterExpanded' {
       $aks = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)"}
       Remove-AzAksAgentPoolMachine -AgentPoolName default -ManagedClusterInputObject $aks -MachineName 'aks-default-12988240-vmss00000a'
    }
}
