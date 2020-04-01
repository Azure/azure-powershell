$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzKustoCluster' {
    It 'UpdateExpanded' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $skuTier = Get-SkuTier
        $updatedSkuName = Get-Updated-SkuName
        $resourceType =  Get-Cluster-Resource-Type
        $capacity = Get-Cluster-Default-Capacity

        $updatedCluster = Update-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName -SkuName $updatedSkuName -SkuTier $skuTier
        Validate_Cluster $updatedCluster $clusterName $location "Running" "Succeeded" $resourceType $updatedSkuName $skuTier $capacity
    }
}
