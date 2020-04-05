$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzKustoDiagnoseClusterVirtualNetwork.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzKustoDiagnoseClusterVirtualNetwork' {
    It 'Diagnose' -skip {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName

        { Invoke-AzKustoDiagnoseClusterVirtualNetwork -ResourceGroupName $resourceGroupName -ClusterName $clusterName } | Should -Not -Throw
        Write-Output "hahah"
    }

    It 'DiagnoseViaIdentity' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName

        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
        { Invoke-AzKustoDiagnoseClusterVirtualNetwork -InputObject $cluster } | Should -Not -Throw
    }
}
