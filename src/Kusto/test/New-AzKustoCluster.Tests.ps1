$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKustoCluster' {
    It 'CreateExpanded' {
        $clusterCreated = New-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $env.clusterName -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier
        Validate_Cluster $clusterCreated $env.clusterName  $env.location  "Running" "Succeeded" $env.resourceType $env.skuName $env.skuTier $env.capacity
    }
}
