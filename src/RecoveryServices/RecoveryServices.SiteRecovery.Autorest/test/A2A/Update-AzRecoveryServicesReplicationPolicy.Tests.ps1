if(($null -eq $TestName) -or ($TestName -contains 'Update-AzRecoveryServicesReplicationPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzRecoveryServicesReplicationPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzRecoveryServicesReplicationPolicy' {
    It 'UpdateExpanded' {
        $policyDesc=Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId -PolicyName $env.a2aPolicyName
        $policy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2APolicyCreationInput]::new()
        $policy.AppConsistentFrequencyInMinute=340
        $policy.CrashConsistentFrequencyInMinute=160
        $policy.MultiVMSyncStatus='Enable'
        $policy.RecoveryPointHistory=4420
        $policy.ReplicationScenario="ReplicateAzureToAzure"
        $output=Update-AzRecoveryServicesReplicationPolicy -Policy $policyDesc -ResourceGroupName $env.a2aResourceGroupName -ResourceName $env.a2aVaultName -SubscriptionId $env.a2aSubscriptionId -ReplicationProviderSetting $policy
        $output.Count | Should -Not -BeNullOrEmpty
    }

    It 'Update' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
