$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStreamAnalyticsCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStreamAnalyticsCluster' {
    It 'Delete' {
        Remove-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster01
        $clusterList = Get-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup
        $clusterList.Name | Should -Not -Contain $env.cluster01
    }

    It 'DeleteViaIdentity' {
      $cluster = Get-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster03 
      Remove-AzStreamAnalyticsCluster -InputObject $cluster
      $clusterList = Get-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup
      $clusterList.Name | Should -Not -Contain $env.cluster03   
    }
}
