if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateLocalReplicationFabric'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateLocalReplicationFabric.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateLocalReplicationFabric' {
    It 'List' {
        $output = Get-AzMigrateLocalReplicationFabric `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $output = Get-AzMigrateLocalReplicationFabric `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciSourceReplicationFabricName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $output = Get-AzMigrateLocalReplicationFabric `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $output = Get-AzMigrateLocalReplicationFabric `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciSourceReplicationFabricName

        $output1 = Get-AzMigrateLocalReplicationFabric -InputObject $output
        $output1.Count | Should -BeGreaterOrEqual 1
    }
}
