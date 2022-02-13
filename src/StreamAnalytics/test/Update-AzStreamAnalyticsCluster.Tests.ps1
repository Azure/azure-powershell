$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStreamAnalyticsCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStreamAnalyticsCluster' {
    It 'UpdateExpanded' {
      $cluster = Update-AzStreamAnalyticsCluster -ResourceGroup $env.resourceGroup -Name $env.cluster00 -Tag @{'key1'=1; 'key2'=2}
      $cluster.Tag.Count | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
      $cluster = Get-AzStreamAnalyticsCluster -ResourceGroup $env.resourceGroup -Name $env.cluster00
      $cluster = Update-AzStreamAnalyticsCluster -InputObject $cluster -Tag @{'key1'=1; 'key2'=2; 'key3'=3}
      $cluster.Tag.Count | Should -Be 3
    }
}
