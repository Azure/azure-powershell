if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateHCIReplicationPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateHCIReplicationPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateHCIReplicationPolicy' {
    It 'List' -skip {
        $output = Get-AzMigrateHCIReplicationPolicy `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -VaultName $env.asrv2ReplicationVaultName `
            -SubscriptionId $env.asrv2SubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' -skip {
        $output = Get-AzMigrateHCIReplicationPolicy `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -VaultName $env.asrv2ReplicationVaultName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -Name $env.asrv2ReplicationPolicyName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' -skip {
        $output = Get-AzMigrateHCIReplicationPolicy `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -VaultName $env.asrv2ReplicationVaultName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -Name $env.asrv2ReplicationPolicyName

        $output1 = Get-AzMigrateHCIReplicationPolicy -InputObject $output
        $output1.Count | Should -BeGreaterOrEqual 1
    }
}
