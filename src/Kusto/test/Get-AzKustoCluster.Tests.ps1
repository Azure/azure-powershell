$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoCluster' {
    It 'Get' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $skuName = Get-SkuName
        $skuTier = Get-SkuTier
        $resourceType =  Get-Cluster-Resource-Type
        $capacity = Get-Cluster-Default-Capacity

        $clusterGetItem = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -Name $clusterName
        Validate_Cluster $clusterGetItem $clusterName $location "Running" "Succeeded" $resourceType $skuName $skuTier $capacity
    }

    It 'List' {
        $location = Get-Location
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $skuName = Get-SkuName
        $skuTier = Get-SkuTier
        $resourceType =  Get-Cluster-Resource-Type
        $capacity = Get-Cluster-Default-Capacity

        [array]$clusterGet = Get-AzKustoCluster -ResourceGroupName $resourceGroupName
        $clusterGetItem = $clusterGet[0]
        Validate_Cluster $clusterGetItem $clusterName $location "Running" "Succeeded" $resourceType $skuName $skuTier $capacity
    }
}
