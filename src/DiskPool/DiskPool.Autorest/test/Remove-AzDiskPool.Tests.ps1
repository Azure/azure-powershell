$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiskPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDiskPool' {
    It 'Delete' {
        {Remove-AzDiskPool -Name $env.diskPool1 -ResourceGroupName $env.resourceGroup} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool5
        $diskPool.name | Should -Be $env.diskPool5
        {Remove-AzDiskPool -InputObject $diskPool} | Should -Not -Throw
    }
}
