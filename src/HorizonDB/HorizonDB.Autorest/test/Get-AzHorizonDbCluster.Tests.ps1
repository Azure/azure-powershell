if(($null -eq $TestName) -or ($TestName -contains 'Get-AzHorizonDbCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzHorizonDbCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzHorizonDbCluster' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $cluster = Get-AzHorizonDbCluster -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedClusterName -SubscriptionId $env.SubscriptionId -ErrorAction Stop

        $cluster.Name | Should -Be $env.sharedClusterName
        $cluster.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $cluster.Location | Should -Be $env.location
        $cluster.PostgreSqlVersion | Should -Be '17'
        $cluster.BackupGeoRedundancy | Should -Be 'Disabled'
        $cluster.NetworkPublicAccess | Should -Be 'Disabled'
        $cluster.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List1' {
        $clusters = @(Get-AzHorizonDbCluster -ResourceGroupName $env.sharedResourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction Stop)
        $matching = @($clusters | Where-Object { $_.Name -eq $env.sharedClusterName })

        $matching.Count | Should -Be 1
        $matching[0].ResourceGroupName | Should -Be $env.sharedResourceGroup
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
