Describe 'Update-AzSynapseKustoPool' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSynapseKustoPool.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'UpdateExpanded' {
        $updatedKustoPool = Update-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.kustoPoolName -SkuName $env.updatedSkuName -SkuSize $env.skuSize
        Validate_Cluster $updatedKustoPool $env.workspaceName $env.kustoPoolName $env.location "Running" "Succeeded" $env.resourceType $env.updatedSkuName $env.skuSize $env.capacity
        Start-TestSleep -Seconds 30
    }

    It 'UpdateViaIdentityExpanded' {
        $kustoPoolGetItem = Get-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.kustoPoolName
        $updatedKustoPool = Update-AzSynapseKustoPool -InputObject $kustoPoolGetItem -SkuName $env.skuName -SkuSize $env.skuSize
        Validate_Cluster $updatedKustoPool $env.workspaceName $env.kustoPoolName $env.location "Running" "Succeeded" $env.resourceType $env.skuName $env.skuSize $env.capacity
    }
}
