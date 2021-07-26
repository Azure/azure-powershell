$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareCluster' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 3 -SkuName av36
            $config.Name | Should -Be $env.rstr2
        } | Should -Not -Throw
    }
}
