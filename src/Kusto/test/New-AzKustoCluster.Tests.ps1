$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoCluster.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKustoCluster' {
    It 'CreateExpanded' {
        $name = "testcluster" + $env.rstr4
        $clusterCreated = New-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $name -Location $env.location -SkuName $env.skuName -SkuTier $env.skuTier
        Validate_Cluster $clusterCreated $name  $env.location  "Running" "Succeeded" $env.resourceType $env.skuName $env.skuTier $env.capacity
        { Remove-AzKustoCluster -ResourceGroupName $env.resourceGroupName -Name $name } | Should -Not -Throw
    }
}
