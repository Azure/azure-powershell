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
    It 'List' {
        $output = Get-AzMigrateHCIReplicationPolicy `
            -ResourceGroupName $env.hciMigResourceGroup `
            -VaultName $env.hciReplicationVaultName `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $output = Get-AzMigrateHCIReplicationPolicy `
            -ResourceGroupName $env.hciMigResourceGroup `
            -VaultName $env.hciReplicationVaultName `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciReplicationPolicyName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $output = Get-AzMigrateHCIReplicationPolicy `
            -ResourceGroupName $env.hciMigResourceGroup `
            -VaultName $env.hciReplicationVaultName `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciReplicationPolicyName

        $output1 = Get-AzMigrateHCIReplicationPolicy -InputObject $output
        $output1.Count | Should -BeGreaterOrEqual 1
    }
}
