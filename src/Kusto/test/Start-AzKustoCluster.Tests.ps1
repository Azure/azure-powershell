Describe 'Start-AzKustoCluster' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzKustoCluster.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Start' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoFollowerClusterName

        Stop-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
        { Start-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoFollowerClusterName

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

        Stop-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
        { Start-AzKustoCluster -InputObject $clusterGetItem } | Should -Not -Throw
    }
}
