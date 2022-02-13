$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiskPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDiskPool' {
    It 'List' {
        $diskPoolList = Get-AzDiskPool -ResourceGroupName $env.resourceGroup
        $diskPoolList.Count | Should -Be 2
    }

    It 'Get' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool1
        $diskPool.name | Should -Be $env.diskPool1
    }

    It 'List1' {
        $diskPools = Get-AzDiskPool
        $diskPools.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool1
        $diskPool = Get-AzDiskPool -InputObject $diskPool
        $diskPool.name | Should -Be $env.diskPool1
    }
}
