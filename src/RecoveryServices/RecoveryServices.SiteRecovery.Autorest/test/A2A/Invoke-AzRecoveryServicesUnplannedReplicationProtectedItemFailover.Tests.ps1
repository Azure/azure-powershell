if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover' {
    It 'UnplannedExpanded' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $protectedItem = Get-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName $env.unplannedfailvm
        $providerSpecificinput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AUnplannedFailoverInput]::new()
        $providerSpecificinput.CloudServiceCreationOption = "AutoCreateCloudService"
        $providerSpecificinput.ReplicationScenario = "ReplicateAzureToAzure"
        $output = Invoke-AzRecoveryServicesUnplannedReplicationProtectedItemFailover -ReplicatedProtectedItem $protectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProviderSpecificDetail $providerSpecificinput
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Unplanned' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
