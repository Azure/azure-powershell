Describe 'New-AzKustoCluster' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }  
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoCluster.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpanded' {
        $name = "testcluster" + $env.rstr4
        $clusterCreated = New-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $name -Location $env.location -SkuName $env.kustoSkuName -SkuTier $env.kustoClusterTier -SkuCapacity 2
        Validate_Cluster $clusterCreated $name  $env.location  "Running" "Succeeded" "Microsoft.Kusto/Clusters" $env.kustoSkuName $env.kustoClusterTier 2
        { Remove-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $name } | Should -Not -Throw
    }
}
