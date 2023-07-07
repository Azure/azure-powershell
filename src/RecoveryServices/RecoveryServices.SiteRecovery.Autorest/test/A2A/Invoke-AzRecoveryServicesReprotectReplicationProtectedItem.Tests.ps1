if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzRecoveryServicesReprotectReplicationProtectedItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzRecoveryServicesReprotectReplicationProtectedItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzRecoveryServicesReprotectReplicationProtectedItem' {
    It 'ReprotectExpanded' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $protectedItem = Get-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -ReplicatedProtectedItemName $env.reprotectvm
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2aFabricName
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.reversemap
        $pcmap = Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -MappingName $env.reversemapname
        $reverseInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2ASwitchProtectionInput]::new()
        $reverseInput.RecoveryResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/abhinav_test"
        $reverseInput.ReplicationScenario = "ReplicateAzureToAzure"
        $output = Invoke-AzRecoveryServicesReverseReplicationProtectedItem -ReplicatedProtectedItem $protectedItem -ProtectionContainerMapping $pcmap -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProviderSpecificDetail $reverseInput -LogStorageAccountId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2arecoveryrg/providers/Microsoft.Storage/storageAccounts/a2areversestorage"
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Reprotect' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
