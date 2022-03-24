$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiskPoolOutboundNetworkDependencyEndpoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDiskPoolOutboundNetworkDependencyEndpoint' {
    It 'Get' {
        $deps = Get-AzDiskPoolOutboundNetworkDependencyEndpoint -ResourceGroupName $env.resourceGroup -DiskPoolName $env.diskPool1
        $deps.Count | Should -Be 5
    }
}
