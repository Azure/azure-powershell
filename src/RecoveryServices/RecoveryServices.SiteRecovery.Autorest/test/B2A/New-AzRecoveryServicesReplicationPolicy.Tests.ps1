if(($null -eq $TestName) -or ($TestName -contains 'New-AzRecoveryServicesReplicationPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRecoveryServicesReplicationPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRecoveryServicesReplicationPolicy' {
    It 'CreateExpanded' {
        $providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HyperVReplicaAzurePolicyInput]::new()
        $providerSpecificPolicy.ApplicationConsistentSnapshotFrequencyInHour = 3
        $providerSpecificPolicy.RecoveryPointHistoryDuration = 10
        $providerSpecificPolicy.ReplicationScenario = "ReplicateHyperVToAzure"
        $providerSpecificPolicy.ReplicationInterval = 300
        $output = New-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName -PolicyName $env.asrNewPolicyCreation -ProviderSpecificInput $providerSpecificPolicy
        $output.Count | Should Not BeNullOrEmpty
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
