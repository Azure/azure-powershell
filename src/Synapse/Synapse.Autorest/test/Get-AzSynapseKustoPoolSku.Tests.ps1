Describe 'Get-AzSynapseKustoPoolSku' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSynapseKustoPoolSku.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        [array]$kustoPoolSku = Get-AzSynapseKustoPoolSku
        $kustoPoolSku.Count | Should -Be 298
    }

    It 'List1' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName

        [array]$kustoPoolSku = Get-AzSynapseKustoPoolSku -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName
        $kustoPoolSku.Count | Should -Be 6
    }
}
