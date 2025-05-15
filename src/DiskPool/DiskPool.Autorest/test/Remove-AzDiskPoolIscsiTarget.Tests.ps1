$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiskPoolIscsiTarget.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDiskPoolIscsiTarget' {
    It 'Delete' {
        {Remove-AzDiskPoolIscsiTarget -ResourceGroupName $env.resourceGroup -DiskPoolName $env.diskPool5 -Name $env.target0} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $target1 = Get-AzDiskPoolIscsiTarget -Name $env.target1 -DiskPoolName $env.diskPool1 -ResourceGroupName $env.resourceGroup
        $target1.name | Should -Be $env.target1
        {Remove-AzDiskPoolIscsiTarget -InputObject $target1} | Should -Not -Throw
    }
}
