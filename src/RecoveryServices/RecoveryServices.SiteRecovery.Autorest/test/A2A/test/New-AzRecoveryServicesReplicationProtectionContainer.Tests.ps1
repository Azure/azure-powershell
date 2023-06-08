if(($null -eq $TestName) -or ($TestName -contains 'New-AzRecoveryServicesReplicationProtectionContainer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRecoveryServicesReplicationProtectionContainer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRecoveryServicesReplicationProtectionContainer' {
    It 'CreateExpanded' -skip{
        $fabric = Get-AzRecoveryServicesReplicationFabric -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2aFabricName
        $protectionContainer=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AContainerCreationInput]::new()
        $protectionContainer.InstanceType="A2A"
        $output = New-AzRecoveryServicesReplicationProtectionContainer -Fabric $fabric -ProtectionContainerName $env.a2apcName -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -ProviderSpecificInput $protectionContainer
        $output.Count | Should Not BeNullOrEmpty
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
