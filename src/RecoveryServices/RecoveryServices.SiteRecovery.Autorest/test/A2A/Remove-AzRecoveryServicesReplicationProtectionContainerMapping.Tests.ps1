if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRecoveryServicesReplicationProtectionContainerMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRecoveryServicesReplicationProtectionContainerMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzRecoveryServicesReplicationProtectionContainerMapping' {
    It 'DeleteExpanded' {
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -FabricName $env.a2ampfabricname -SubscriptionId $env.a2aSubscriptionId
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -Fabric $fabric -ProtectionContainer $env.a2amppcname -SubscriptionId $env.a2aSubscriptionId
        $pcmapping = Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -ProtectionContainer $protectioncontainer -MappingName $env.mappingName -SubscriptionId $env.a2aSubscriptionId
        {Remove-AzRecoveryServicesReplicationProtectionContainerMapping -ProtectionContainerMapping $pcmapping -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId} | Should Not Throw
    }

    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
