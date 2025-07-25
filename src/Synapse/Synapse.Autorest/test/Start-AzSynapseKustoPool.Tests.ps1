Describe 'Start-AzSynapseKustoPool' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzSynapseKustoPool.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Start' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.plainKustoPoolName

        Stop-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName
        { Start-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.plainKustoPoolName

        $kustoPoolGetItem = Get-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName

        Stop-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName
        { Start-AzSynapseKustoPool -InputObject $kustoPoolGetItem } | Should -Not -Throw
    }
}
