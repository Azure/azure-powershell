$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoClusterLanguageExtension.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzKustoClusterLanguageExtension' {
    It 'RemoveExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName

        { Remove-AzKustoClusterLanguageExtension -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Value (@{Name = $env.langExt1 }) } | Should -Not -Throw
    }

    It 'RemoveViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

        { Remove-AzKustoClusterLanguageExtension -InputObject $clusterGetItem -Value (@{Name = $env.langExt2 }) } | Should -Not -Throw
    }
}
