Describe 'Remove-AzKustoCluster' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoCluster.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $name = "testcluster" + $env.rstr5
        New-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $name -Location $env.location -SkuName $env.kustoSkuName -SkuTier $env.kustoClusterTier
        { Remove-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $name } | Should -Not -Throw
    }
}
