Describe 'Remove-AzKustoDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $name = "testdatabase" + $env.rstr4
        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name -Kind ReadWrite -Location $env.location
        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }
}
