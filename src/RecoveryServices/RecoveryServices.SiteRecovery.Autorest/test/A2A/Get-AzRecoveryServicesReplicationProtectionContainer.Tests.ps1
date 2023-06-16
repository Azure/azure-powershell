if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesReplicationProtectionContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesReplicationProtectionContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesReplicationProtectionContainer' {
    It 'List1' {
        $output = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId
        $output.Count | Should Not BeNullOrEmpty
    }

    It 'List' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2aFabricName
        $output = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -Fabric $fabric -SubscriptionId $env.a2aSubscriptionId
        $output.Count | Should Not BeNullOrEmpty
    }

    It 'Get' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2aFabricName
        $output = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -Fabric $fabric -ProtectionContainer $env.a2aProtectionContainerName -SubscriptionId $env.a2aSubscriptionId
        $output.Count | Should Not BeNullOrEmpty
    }
}
