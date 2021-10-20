Describe 'New-AzSynapseKustoPool' -Tag 'LiveOnly' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }  
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSynapseKustoPool.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpanded' {
        $name = "testkustopool" + $env.rstr4
        $kustoPoolCreated = New-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $name -Location $env.location -SkuName $env.skuName -SkuSize $env.skuSize
        Validate_Cluster $kustoPoolCreated $env.workspaceName $name  $env.location  "Running" "Succeeded" $env.resourceType $env.skuName $env.skuSize $env.capacity
        { Remove-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $name } | Should -Not -Throw
    }
}
