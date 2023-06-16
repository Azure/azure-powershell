if(($null -eq $TestName) -or ($TestName -contains 'New-AzRecoveryServicesReplicationFabric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRecoveryServicesReplicationFabric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRecoveryServicesReplicationFabric' {
    It 'CreateExpanded' {
        $fabric = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureFabricCreationInput]::new()
        $fabric.ReplicationScenario="ReplicateAzureToAzure"
        $fabric.Location="East US 2"
        $output = New-AzRecoveryServicesReplicationFabric -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId -FabricName $env.a2ademofabric -ProviderDetail $fabric
        $output.Count | Should Not BeNullOrEmpty
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
