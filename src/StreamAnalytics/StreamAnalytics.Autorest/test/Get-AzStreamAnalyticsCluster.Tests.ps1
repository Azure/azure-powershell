$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsCluster' {
    It 'List' {
        $clusterList = Get-AzStreamAnalyticsCluster
        $clusterList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
      $cluster = Get-AzStreamAnalyticsCluster -ResourceGroup $env.resourceGroup -Name $env.Cluster01
      $cluster.Name | Should -Be $env.Cluster01
    }

    It 'List1' {
      $clusterList = Get-AzStreamAnalyticsCluster -ResourceGroup $env.resourceGroup
      $clusterList.Count | Should -Be 2
    }

    It 'GetViaIdentity' {
      $cluster = Get-AzStreamAnalyticsCluster -ResourceGroup $env.resourceGroup -Name $env.Cluster01
      $cluster = Get-AzStreamAnalyticsCluster -InputObject $cluster 
      $cluster.Name | Should -Be $env.Cluster01
    }
}
