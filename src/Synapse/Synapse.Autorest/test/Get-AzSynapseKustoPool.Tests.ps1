Describe 'Get-AzSynapseKustoPool' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSynapseKustoPool.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        [array]$kustoPoolGet = Get-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $kustoPoolGetItem = $kustoPoolGet[0]
        Validate_Cluster $kustoPoolGetItem $env.workspaceName $env.kustoPoolName $env.location "Running" "Succeeded" $env.resourceType $env.skuName $env.skuSize $env.capacity
    }

    It 'Get' {
        $kustoPoolGetItem = Get-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.kustoPoolName
        Validate_Cluster $kustoPoolGetItem $env.workspaceName $env.kustoPoolName $env.location "Running" "Succeeded" $env.resourceType $env.skuName $env.skuSize $env.capacity
    }
}
