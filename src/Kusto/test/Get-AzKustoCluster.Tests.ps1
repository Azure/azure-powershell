$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoCluster' {
    It 'Get' {
        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.clusterName
        Validate_Cluster $clusterGetItem $env.clusterName $env.location "Running" "Succeeded" $env.resourceType $env.skuName $env.skuTier $env.capacity
    }

    It 'List' {
        [array]$clusterGet = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName
        $clusterGetItem = $clusterGet[0]
        Validate_Cluster $clusterGetItem $env.clusterName $env.location "Running" "Succeeded" $env.resourceType $env.skuName $env.skuTier $env.capacity
    }
}
