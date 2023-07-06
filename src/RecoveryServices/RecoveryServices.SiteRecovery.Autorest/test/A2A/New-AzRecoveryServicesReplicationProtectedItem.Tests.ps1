if(($null -eq $TestName) -or ($TestName -contains 'New-AzRecoveryServicesReplicationProtectedItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRecoveryServicesReplicationProtectedItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRecoveryServicesReplicationProtectedItem' {
    It 'CreateExpanded' {
        Import-Module Az.Compute
        $protectionInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AEnableProtectionInput]::new()
        $protectionInput.FabricObjectId="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/abhinav_test/providers/Microsoft.Compute/virtualMachines/a2avmtest2"
        $protectionInput.ReplicationScenario="ReplicateAzureToAzure"
        $protectionInput.RecoveryResourceGroupId="/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/a2avmrecoveryrg"
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2amppcname
        $pcmap = Get-AzRecoveryServicesReplicationProtectionContainerMapping  -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainer $protectioncontainer -MappingName $env.getmappingName
        $output = New-AzRecoveryServicesReplicationProtectedItem -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProtectionContainerMapping $pcmap -ReplicatedProtectedItemName $env.protectedItemtemp -ProviderSpecificDetail $protectionInput -LogStorageAccountId "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/abhinav_test/providers/Microsoft.Storage/storageAccounts/a2aprimarycachestorage"
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
