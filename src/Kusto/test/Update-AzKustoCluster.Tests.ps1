$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzKustoCluster' {
    It 'UpdateExpanded' {
        $updatedCluster = Update-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.clusterName -SkuName $env.updatedSkuName -SkuTier $env.skuTier
        Validate_Cluster $updatedCluster $env.clusterName $env.location "Running" "Succeeded" $env.resourceType $env.updatedSkuName $env.skuTier $env.capacity
    }

    It 'UpdateViaIdentityExpanded' {
        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.clusterName
        $updatedCluster = Update-AzKustoCluster -InputObject $clusterGetItem -SkuName $env.skuName -SkuTier $env.skuTier
        Validate_Cluster $updatedCluster $env.clusterName $env.location "Running" "Succeeded" $env.resourceType $env.skuName $env.skuTier $env.capacity
    }
}
