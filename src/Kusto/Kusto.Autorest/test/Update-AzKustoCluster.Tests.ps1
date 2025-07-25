Describe 'Update-AzKustoCluster' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoCluster.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    
    It 'UpdateExpanded' {
        $updatedCluster = Update-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.kustoClusterName -PublicIPType "IPv4"
        $updatedCluster.PublicIPType | Should -Be "IPv4"
    }

    It 'UpdateViaIdentityExpanded' {
        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.kustoClusterName
        $updatedCluster = Update-AzKustoCluster -InputObject $clusterGetItem -SkuName $env.kustoSkuName -SkuTier $env.kustoClusterTier
        Validate_Cluster $updatedCluster $env.kustoClusterName $env.location "Running" "Succeeded" "Microsoft.Kusto/Clusters" $env.kustoSkuName $env.kustoClusterTier 2
    }
}
