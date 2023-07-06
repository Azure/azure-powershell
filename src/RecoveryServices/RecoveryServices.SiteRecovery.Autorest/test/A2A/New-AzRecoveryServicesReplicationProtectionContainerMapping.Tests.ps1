if(($null -eq $TestName) -or ($TestName -contains 'New-AzRecoveryServicesReplicationProtectionContainerMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRecoveryServicesReplicationProtectionContainerMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRecoveryServicesReplicationProtectionContainerMapping' {
    It 'CreateExpanded' {
        $policy = Get-AzRecoveryServicesReplicationPolicy -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -PolicyName $env.mapPolicy
        $mappingInput = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AContainerMappingInput]::new()
        $mappingInput.ReplicationScenario = "ReplicateAzureToAzure"
        $recoveryfabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ampfabricname
        $recoveryprotectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $recoveryfabric -ProtectionContainer $env.a2amppcname
        $primaryfabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2aFabricName
        $primaryprotectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $primaryfabric -ProtectionContainer $env.a2apcName
        $output = New-AzRecoveryServicesReplicationProtectionContainerMapping -MappingName $env.delcreatemap -PrimaryProtectionContainer $primaryprotectioncontainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -ProviderSpecificInput $mappingInput -Policy $policy -RecoveryProtectionContainer $recoveryprotectioncontainer
        $output.Count | Should Not BeNullOrEmpty
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
