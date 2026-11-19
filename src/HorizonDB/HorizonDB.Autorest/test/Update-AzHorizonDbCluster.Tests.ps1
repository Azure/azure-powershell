if(($null -eq $TestName) -or ($TestName -contains 'Update-AzHorizonDbCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzHorizonDbCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzHorizonDbCluster' {
    It 'UpdateExpanded' {
        $null = Update-AzHorizonDbCluster -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedClusterName -SubscriptionId $env.SubscriptionId -BackupRetentionDay 9 -Confirm:$false -ErrorAction Stop

        $cluster = Get-AzHorizonDbCluster -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedClusterName -SubscriptionId $env.SubscriptionId -ErrorAction Stop

        $cluster.Name | Should -Be $env.sharedClusterName
        $cluster.ResourceGroupName | Should -Be $env.sharedResourceGroup
        $cluster.BackupRetentionDay | Should -Be 9
        $cluster.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
