if(($null -eq $TestName) -or ($TestName -contains 'Test-AzRecoveryServicesReplicationProtectedItemFailover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzRecoveryServicesReplicationProtectedItemFailover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzRecoveryServicesReplicationProtectedItemFailover' {
    It 'TestExpanded' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $protectedItem = Get-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName $env.protectedItemtest
        $providerSpecificinput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2ATestFailoverInput]::new()
        $providerSpecificinput.ReplicationScenario = "ReplicateAzureToAzure"
        $providerSpecificinput.CloudServiceCreationOption="AutoCreateCloudService"
        $output = Test-AzRecoveryServicesReplicationProtectedItemFailover -ReplicatedProtectedItem $protectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProviderSpecificDetail $providerSpecificinput -NetworkId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2avmrecoveryrg/providers/Microsoft.Network/virtualNetworks/testVmnetwork" -NetworkType $env.testNetworkType -FailoverDirection "PrimaryToRecovery"
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Test' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
