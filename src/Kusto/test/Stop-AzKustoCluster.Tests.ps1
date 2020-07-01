$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzKustoCluster' {
    It 'Stop' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName + "a"

        { Stop-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName + "a"

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

        { Stop-AzKustoCluster -InputObject $clusterGetItem } | Should -Not -Throw
    }
}
