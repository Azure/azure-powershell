$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterSku.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoClusterSku' {
    It 'List' {
        [array]$clusterSku = Get-AzKustoClusterSku
        $clusterSku.Count | Should -Be 493
    }

    It 'List1' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName

        [array]$clusterSku = Get-AzKustoClusterSku -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $clusterSku.Count | Should -Be 23
    }
}
