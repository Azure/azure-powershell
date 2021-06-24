$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDiskPoolIscsiTarget.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDiskPoolIscsiTarget' {
    It 'List' {
        $targetList = Get-AzDiskPoolIscsiTarget -ResourceGroupName $env.resourceGroup -DiskPoolName $env.diskPool5
        $targetList.Count | Should -Be 1
    }

    It 'Get' {
        $target = Get-AzDiskPoolIscsiTarget -DiskPoolName $env.diskPool5 -Name $env.target0 -ResourceGroupName $env.resourceGroup
        $target.Name | Should -Be $env.target0
    }

    It 'GetViaIdentity' {
        $target = Get-AzDiskPoolIscsiTarget -DiskPoolName $env.diskPool5 -Name $env.target0 -ResourceGroupName $env.resourceGroup
        $target = Get-AzDiskPoolIscsiTarget -InputObject $target
        $target.Name | Should -Be $env.target0
    }
}
