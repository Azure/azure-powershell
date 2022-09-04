if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubCluster' {
    It 'SetExpanded' {
        $cluster = Set-AzEventHubCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster -Capacity 3
        $cluster.ResourceGroupName | Should -Be $env.resourceGroup
        $cluster.Name | Should -Be $env.cluster
        $cluster.Capacity | Should -Be 3
    }

    It 'SetViaIdentityExpanded' {
        $cluster = Get-AzEventHubCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster
        $cluster = Set-AzEventHubCluster -InputObject $cluster -Tag @{a=b}
        $cluster.ResourceGroupName | Should -Be $env.resourceGroup
        $cluster.Name | Should -Be $env.cluster
        $cluster.Capacity | Should -Be 3
        $cluster.Tag.Count | Should -Be 1
    }
}
