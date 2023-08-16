if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateHCIReplicationFabric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateHCIReplicationFabric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateHCIReplicationFabric' {
    It 'List' -skip {
        $output = Get-AzMigrateHCIReplicationFabric
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' -skip {
        $output = Get-AzMigrateHCIReplicationFabric `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -Name $env.asrv2SourceReplicationFabricName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' -skip {
        $output = Get-AzMigrateHCIReplicationFabric `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' -skip {
        $output = Get-AzMigrateHCIReplicationFabric `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -Name $env.asrv2SourceReplicationFabricName

        $output1 = Get-AzMigrateHCIReplicationFabric -InputObject $output
        $output1.Count | Should -BeGreaterOrEqual 1
    }
}
