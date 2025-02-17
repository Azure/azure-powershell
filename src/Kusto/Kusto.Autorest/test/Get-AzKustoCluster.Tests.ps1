Describe 'Get-AzKustoCluster' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoCluster.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Get' {
        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.kustoClusterName
        Validate_Cluster $clusterGetItem $env.kustoClusterName $env.location "Running" "Succeeded" "Microsoft.Kusto/Clusters" $env.kustoSkuName $env.kustoClusterTier 2
    }

    It 'List' {
        [array]$clustersGet = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName
        $clustersGet.Count | Should -BeGreaterOrEqual 2
        foreach ($cluster in $clustersGet)
        {
            if ($cluster.Name -eq $env.kustoClusterName)
            {
                Validate_Cluster $cluster $env.kustoClusterName $env.location "Running" "Succeeded" "Microsoft.Kusto/Clusters" $env.kustoSkuName $env.kustoClusterTier 2
            }
        }
    }
}
