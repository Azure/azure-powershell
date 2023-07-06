if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzRecoveryServicesReplicationPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzRecoveryServicesReplicationPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzRecoveryServicesReplicationPolicy' {
    It 'Delete' {
        $obj = Get-AzRecoveryServicesReplicationPolicy -PolicyName $env.a2aCreateRemovePolicy -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId
        $obj.Count | Should Not BeNullOrEmpty
        { Remove-AzRecoveryServicesReplicationPolicy -Policy $obj -ResourceName $env.a2aVaultName -ResourceGroupName $env.a2aResourceGroupName -SubscriptionId $env.a2aSubscriptionId } | Should -Not -Throw
    }
}
