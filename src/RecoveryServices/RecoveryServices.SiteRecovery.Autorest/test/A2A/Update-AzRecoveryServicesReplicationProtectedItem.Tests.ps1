if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRecoveryServicesReplicationProtectedItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRecoveryServicesReplicationProtectedItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzRecoveryServicesReplicationProtectedItem' {
    It 'UpdateExpanded' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $protectedItem = Get-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName $env.protectedItemtest
        $providerSpecificinput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AUpdateReplicationProtectedItemInput]::new()
        $providerSpecificinput.ReplicationScenario="ReplicateAzureToAzure"
        $output = Update-AzRecoveryServicesReplicationProtectedItem -ReplicatedProtectedItem $protectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProviderSpecificDetail $providerSpecificinput
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Update' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
