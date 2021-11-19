Describe 'Remove-AzSynapseKustoPoolDatabase' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSynapseKustoPoolDatabase.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $name = "testdatabase" + $env.rstr4
        New-AzSynapseKustoPoolDatabase -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -KustoPoolName $env.kustoPoolName -Name $name -Location $env.location -Kind ReadWrite
        { Remove-AzSynapseKustoPoolDatabase -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -KustoPoolName $env.kustoPoolName -Name $name } | Should -Not -Throw
    }
}
