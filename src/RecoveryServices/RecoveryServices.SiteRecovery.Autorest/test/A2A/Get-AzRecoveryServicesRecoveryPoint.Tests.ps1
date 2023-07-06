if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesRecoveryPoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesRecoveryPoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesRecoveryPoint' {
    It 'List' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $protectedItem = Get-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName $env.protectedItemtest
        $output = Get-AzRecoveryServicesRecoveryPoint -ReplicatedProtectedItem $protectedItem  -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $protectedItem = Get-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName $env.protectedItemtest
        $output = Get-AzRecoveryServicesRecoveryPoint -ReplicatedProtectedItem $protectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Name $env.recoverypoint
        $output.Count | Should -Not -BeNullOrEmpty
    }
}
