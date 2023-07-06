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
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2aFabricName
        $protectioncontainer = Get-AzRecoveryServicesReplicationProtectionContainer -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId -Fabric $fabric -ProtectionContainer $env.a2apcName
        $pcmapping = Get-AzRecoveryServicesReplicationProtectionContainerMapping -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -ProtectionContainer $protectioncontainer -MappingName $env.delcreatemap -SubscriptionId $env.a2aSubscriptionId
        {Remove-AzRecoveryServicesReplicationProtectionContainerMapping -ProtectionContainerMapping $pcmapping -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId} | Should Not Throw
    }

    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
