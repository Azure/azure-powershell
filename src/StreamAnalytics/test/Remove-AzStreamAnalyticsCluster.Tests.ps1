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
    # Issue: The cmdlet is long time operation. The exception thrown after the resource has been successfully deleted. 
    # becasue the status was deleting when status code equal 200. 
    It 'Delete' -Skip {
        Remove-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster01
        $clusterList = Get-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup
        $clusterList.Name | Should -Not -Contain $env.cluster01
    }

    It 'DeleteViaIdentity' -Skip {
      $cluster = Get-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster03 
      Remove-AzStreamAnalyticsCluster -InputObject $cluster
      $clusterList = Get-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup
      $clusterList.Name | Should -Not -Contain $env.cluster03   
    }
}
