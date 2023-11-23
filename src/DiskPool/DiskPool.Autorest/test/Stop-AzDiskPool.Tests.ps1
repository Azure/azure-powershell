$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDiskPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzDiskPool' {
    It 'Deallocate' {
        Stop-AzDiskPool -Name $env.diskPool1 -ResourceGroupName $env.resourceGroup
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool1
        $diskPool.status | Should -Be 'Stopped (deallocated)'
    }

    It 'DeallocateViaIdentity' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool5
        Stop-AzDiskPool -InputObject $diskPool
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool5
        $diskPool.status | Should -Be 'Stopped (deallocated)'
    }
}
