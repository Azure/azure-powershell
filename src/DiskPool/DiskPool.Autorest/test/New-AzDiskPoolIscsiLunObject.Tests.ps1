$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiskPoolIscsiLunObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDiskPoolIscsiLunObject' {
    It '__AllParameterSets' {
        $lunObject = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId $env.diskId1 -Name 'lun0'
        $lunObject.ManagedDiskAzureResourceId | Should -Be $env.diskId1
        $lunObject.Name | Should -Be 'lun0'
    }
}
