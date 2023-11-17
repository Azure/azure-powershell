$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsClusterStreamingJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsClusterStreamingJob' {
    It 'List' {
        # The stream analytics cluster haven't cmdlet that  can add jobs.
        # Use the Azure portal to add jobs in the stream analytics cluster.
        $clusterJobList = Get-AzStreamAnalyticsClusterStreamingJob -ResourceGroupName $env.resourceGroup -ClusterName $env.cluster00
        $clusterJobList.Count | Should -Be 2
      }
}
