Describe 'Remove-AzSynapseKustoPoolLanguageExtension' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSynapseKustoPoolLanguageExtension.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName  
    }
    It 'RemoveExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName

        { Remove-AzSynapseKustoPoolLanguageExtension -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -Value (@{Name = $env.langExt1 }) } | Should -Not -Throw
    }

    It 'RemoveViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName

        $kustoPoolGetItem = Get-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName

        { Remove-AzSynapseKustoPoolLanguageExtension -InputObject $kustoPoolGetItem -Value (@{Name = $env.langExt2 }) } | Should -Not -Throw
    }
}
