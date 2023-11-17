Describe 'Stop-AzKustoCluster' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzKustoCluster.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Stop' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoFollowerClusterName

        { Stop-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName } | Should -Not -Throw
        Start-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
    }

    It 'StopViaIdentity' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoFollowerClusterName

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName

        { Stop-AzKustoCluster -InputObject $clusterGetItem } | Should -Not -Throw
        Start-AzKustoCluster -InputObject $clusterGetItem
    }
}
